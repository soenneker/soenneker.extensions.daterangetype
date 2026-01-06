using System.Diagnostics.Contracts;
using Soenneker.Enums.UnitOfTime;
using Soenneker.Extensions.DateTimeOffsets.Days;
using Soenneker.Extensions.DateTimeOffsets.Months;
using Soenneker.Extensions.DateTimeOffsets.Weeks;
using Soenneker.Extensions.DateTimeOffsets.Years;

namespace Soenneker.Extensions.DateRangeType;

/// <summary>
/// A collection of helpful DateRangeType enum extension methods
/// </summary>
public static class DateRangeTypeExtension
{
    /// <summary>
    /// Returns UTC values
    /// </summary>
    [Pure]
    public static (System.DateTimeOffset? startAt, System.DateTimeOffset? endAt) GetDateTimesFromRange(this Enums.DateRangeType.DateRangeType dateRangeType, System.TimeZoneInfo timeZoneInfo)
    {
         System.DateTimeOffset utcNow = System.DateTimeOffset.UtcNow;

        switch (dateRangeType.Name)
        {
            case nameof(Enums.DateRangeType.DateRangeType.Today):
                {
                    System.DateTimeOffset start = utcNow.ToStartOfTzDay(timeZoneInfo);
                    return (start, utcNow);
                }
            case nameof(Enums.DateRangeType.DateRangeType.Yesterday):
                {
                    System.DateTimeOffset start = utcNow.ToStartOfPreviousTzDay(timeZoneInfo);
                    System.DateTimeOffset end = utcNow.ToEndOfPreviousTzDay(timeZoneInfo);
                    return (start, end);
                }
            case nameof(Enums.DateRangeType.DateRangeType.Custom):
                return (null, null);
            case nameof(Enums.DateRangeType.DateRangeType.CurrentWeek):
                {
                    System.DateTimeOffset start = utcNow.ToStartOfTzWeek(timeZoneInfo);
                    return (start, utcNow);
                }
            case nameof(Enums.DateRangeType.DateRangeType.PreviousWeek):
                {
                    System.DateTimeOffset start = utcNow.ToStartOfPreviousTzWeek(timeZoneInfo);
                    System.DateTimeOffset end = utcNow.ToEndOfPreviousTzWeek(timeZoneInfo);
                    return (start, end);
                }
            case nameof(Enums.DateRangeType.DateRangeType.CurrentMonth):
                {
                    System.DateTimeOffset start = utcNow.ToStartOfTzMonth(timeZoneInfo);
                    return (start, utcNow);
                }
            case nameof(Enums.DateRangeType.DateRangeType.PreviousMonth):
                {
                    System.DateTimeOffset start = utcNow.ToStartOfPreviousTzMonth(timeZoneInfo);
                    System.DateTimeOffset end = utcNow.ToEndOfPreviousTzMonth(timeZoneInfo);
                    return (start, end);
                }
            case nameof(Enums.DateRangeType.DateRangeType.CurrentYear):
                {
                    System.DateTimeOffset start = utcNow.ToStartOfTzYear(timeZoneInfo);
                    return (start, utcNow);
                }
            case nameof(Enums.DateRangeType.DateRangeType.PreviousYear):
                {
                    System.DateTimeOffset start = utcNow.ToStartOfPreviousTzYear(timeZoneInfo);
                    System.DateTimeOffset end = utcNow.ToEndOfPreviousTzYear(timeZoneInfo);
                    return (start, end);
                }
            default:
                return (null, null);
        }
    }

    public static UnitOfTime ToUnitOfTime(this Enums.DateRangeType.DateRangeType dateRangeType)
    {
        // TODO: add more resolution
        switch (dateRangeType.Name)
        {
            case nameof(Enums.DateRangeType.DateRangeType.Today):
            case nameof(Enums.DateRangeType.DateRangeType.Yesterday):
                return UnitOfTime.Hour;
            default:
                return UnitOfTime.Second;
        }
    }
}
