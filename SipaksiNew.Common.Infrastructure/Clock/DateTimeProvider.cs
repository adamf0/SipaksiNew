using SipaksiNew.Common.Application.Clock;

namespace SipaksiNew.Common.Infrastructure.Clock
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
