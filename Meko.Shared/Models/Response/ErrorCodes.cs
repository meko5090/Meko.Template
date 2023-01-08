namespace Meko.Models.Response;

public static class ErrorCodes
{
    public static class RequestValidation
    {
        public const string ValidationError = "validation_error";

        public const string MissingParameters = "missing_parameters";
    }

    public static class Generic
    {
        public const string UnexpectedError = "unexpected_error";

        public const string BadRequest = "bad_request";

        public const string RuleMismatch = "rule_mismatch";

        public const string NotFoundError = "not_found";

        public const string RequestValidationError = "validation_error";

        public const string ActionForbidden = "forbidden";
    }
}
