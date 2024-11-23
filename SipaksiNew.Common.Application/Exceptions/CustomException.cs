using SipaksiNew.Common.Domain;

namespace SipaksiNew.Common.Application.Exceptions
{
    public sealed class CustomException : Exception
    {
        public CustomException(string requestName, Error? error = default, Exception? innerException = default)
            : base("Application exception", innerException)
        {
            RequestName = requestName;
            Error = error;
        }

        public string RequestName { get; }

        public Error? Error { get; }
    }
}
