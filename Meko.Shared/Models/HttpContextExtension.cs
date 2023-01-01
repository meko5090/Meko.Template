using System.Globalization;
using Meko.Shared;
using Microsoft.AspNetCore.Http;

namespace Meko.Models;

public static class HttpContextExtension
{
    /// <summary>
    /// Extracts the Subject Claim value and returns it casted to
    /// long.
    /// </summary>
    /// <param name="httpContext">An HttpContext object</param>
    /// <returns>The Subject Claim value</returns>
    public static long GetSubjectClaimValue(this HttpContext httpContext)
    {
        try
        {
            var subject = long.Parse(
                httpContext.User.Claims
                    .FirstOrDefault(claim => claim.Type == "sub")!
                    .Value,
                CultureInfo.InvariantCulture
            ); // gets the users id when set
            return subject;
        }
        catch (Exception)
        {
            throw new InvalidOperationException(
                "The User Claim does not "
                    + "contain a valid Subject. Make sure that the user is "
                    + "authenticated (isAuthenticated) before calling this method."
            );
        }
    }

    /// <summary>
    /// Extracts the Subject Role value(s) and returns them.
    /// </summary>
    /// <param name="httpContext">An HttpContext object</param>
    /// <returns>Array of the Role Claim value(s)</returns>
    public static string[] GetRolesClaimValue(this HttpContext httpContext)
    {
        var roles = httpContext.User.Claims
            .Where(claim => claim.Type == "role")
            .Select(r => r.Value)
            .ToArray();

        return roles;
    }

    /// <summary>
    /// Extracts the Subject Claim value and returns it casted to
    /// the given T.
    /// </summary>
    /// <typeparam name="T">The type of expected subject</typeparam>
    /// <param name="httpContext">An HttpContext object</param>
    /// <returns>The Subject Claim value</returns>
    public static T GetSubjectClaimValue<T>(this HttpContext httpContext)
    {
        try
        {
            var subject = Helper.Convert<T>(
                httpContext.User.Claims
                    .FirstOrDefault(claim => claim.Type == "sub")!
                    .Value
            ); // gets the users id when set
            return subject;
        }
        catch (Exception)
        {
            throw new InvalidOperationException(
                "The User Claim does not "
                    + "contain a valid Subject. Make sure that the user is "
                    + "authenticated (isAuthenticated) before calling this method."
            );
        }
    }
}
