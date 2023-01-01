using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using FluentValidation;

// using Meko.Logger.Configuration.Extensions;
// using Microsoft.Extensions.Logging;

namespace Meko.Shared;

public class Helper
{
    // private readonly ILogger<Helper> _logger;

    // public Helper(ILogger<Helper> logger) {
    //     _logger = logger;
    // }

    /// <summary>
    /// Check if email is null or correct email address
    /// </summary>
    /// <param name="email">email address to check</param>
    /// <returns>
    /// true if null or correct email
    /// false otherwise
    /// </returns>
    public static bool IsValidEmail(string? email)
    {
        if (email is null)
        {
            return true;
        }

        string pattern =
            @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        return regex.IsMatch(email);
    }

    /// <summary>
    /// Checks if the given website is valid or not. The accepted schemes
    /// are either https or http. Any website without a scheme is considered
    /// http by default
    /// </summary>
    /// <param name="website">The website to be checked</param>
    /// <returns>true of the website is valid, false otherwise</returns>
    public static bool IsValidWebsite(string? website)
    {
        if (website is null)
        {
            return true;
        }

        return (
                Uri.TryCreate(website, UriKind.Absolute, out var uri)
                || Uri.TryCreate("http://" + website, UriKind.Absolute, out uri)
            )
            && (
                uri.Scheme == Uri.UriSchemeHttp
                || uri.Scheme == Uri.UriSchemeHttps
            );
    }

    public static TModel EntityToModel<TModel, TEntity>(TEntity entity)
        where TModel : new()
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var model = new TModel();
        var properties = model.GetType().GetProperties();
        foreach (var property in properties)
        {
            var _property = entity.GetType().GetProperty(property.Name);
            if (_property is not null)
            {
                property.SetValue(model, _property.GetValue(entity));
            }
        }
        return model;
    }

    /// <summary>
    /// Splits the comma-separated string and parses the result
    /// to array of given type
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    /// <param name="value">The string to parse</param>
    /// <returns>Array of type T</returns>
    /// <exception cref="ArgumentException">When input cannot be casted to needed Type</exception>
    public static T[] ParseItemsQueryParam<T>(string value)
    {
        var Items = Array.Empty<T>();

        if (value is not null)
        {
            var fields = value.Split(',');
            try
            {
                Items = fields
                    .Select(
                        field =>
                            Convert<T>(field)
                            ?? throw new Exception(
                                "fields contains an invalid value"
                            )
                    )
                    .ToArray();
            }
            catch (Exception)
            {
                var message = new FluentValidation.Results.ValidationFailure(
                    "items",
                    "items contains an invalid value",
                    value
                );

                throw new ValidationException(
                    "Invalid value for query parameter; items",
                    new FluentValidation.Results.ValidationFailure[] { message }
                );
            }
        }
        else
        {
            throw new ArgumentNullException(value);
        }
        return Items;
    }

    /// <summary>
    /// Dynamically casts string to any type
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    /// <param name="s">The string to parse</param>
    /// <returns>Object of type T</returns>
    /// <exception cref="ArgumentException">When input cannot be casted to needed Type</exception>
    public static T Convert<T>(string s)
    {
        var converter = TypeDescriptor.GetConverter(typeof(T));
        if (converter is not null)
        {
            //Cast ConvertFromString(string text) : object to (T)
            var output = converter.ConvertFromString(s);
            if (output is not null)
            {
                return (T)output;
            }
        }
        throw new ArgumentException("Input cannot be cast to specified Type");
    }

    /// <summary>
    /// Sends POST request.
    /// </summary>
    /// <typeparam name="SuccessResponse">The type of successful response object.</typeparam>
    /// <typeparam name="ErrorResponse">The type of failure response object.</typeparam>
    /// <param name="endpoint">The full path of the API.</param>
    /// <param name="values">The body content of the request.</param>
    /// <returns>An Object of type T representing the successful response
    /// of the API.</returns>
    /// <exception cref="HttpRequestException">Thrown when
    /// the API call fails</exception>
    /// <exception cref="JsonException">Thrown when
    /// parsing API response fails</exception>
    /// <exception cref="Exception">Thrown when
    /// unknown exception occurs</exception>
    public static async Task<SuccessResponse?> PostAsync<
        SuccessResponse,
        ErrorResponse
    >(string endpoint, string values)
    {
        var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
        );
        try
        {
            var content = new StringContent(
                values,
                Encoding.UTF8,
                "application/json"
            );

            var response = await httpClient.PostAsync(endpoint, content);

            // _logger.LogInformation(
            //     "Calling API: {endpoint}. Request: {request}.",
            //     endpoint,
            //     values
            // );

            var contentString = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new JsonStringEnumConverter());

                var result = JsonSerializer.Deserialize<SuccessResponse>(
                    contentString,
                    options
                );
                return result;
            }
            else
            {
                var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(
                    contentString
                );

                // _logger.LogAlert(
                //     $"Error Calling API: "
                //         + $"{errorResponse}."
                //         + $"Endpoint: {endpoint}. "
                //         + $"Content: {values}."
                // );

                throw new HttpRequestException($"{errorResponse}");
            }
        }
        catch (JsonException e)
        {
            // _logger.LogAlert(
            //     "Error Calling API."
            //         + "Message: {message}. "
            //         + "Endpoint: {endpoint}. "
            //         + "API response: {response}. "
            //         + "JSON path: {jsonPath}. ",
            //     e.Message,
            //     endpoint,
            //     contentString,
            //     e.Path
            // );

            throw e;
        }
        catch (Exception e)
        {
            // _logger.LogAlert(
            //     "Error Calling API: {message}. Endpoint: {endpoint}",
            //     e.Message,
            //     endpoint
            // );

            throw;
        }
    }
}
