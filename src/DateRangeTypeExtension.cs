using System.Diagnostics.Contracts;
using Soenneker.Enums.UnitOfTime;
using Soenneker.Extensions.DateTime.Day;
using Soenneker.Extensions.DateTime.Month;
using Soenneker.Extensions.DateTime.Week;
using Soenneker.Extensions.DateTime.Year;

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
    public static (System.DateTime? startAt, System.DateTime? endAt)? GetDateTimesFromRange(this Enums.DateRangeType.DateRangeType? dateRangeType, System.TimeZoneInfo? timeZoneInfo)
    {
        if (dateRangeType == null || timeZoneInfo == null)
            return null;

        System.DateTime utcNow = System.DateTime.UtcNow;

        switch (dateRangeType.Name)
        {
            case nameof(Enums.DateRangeType.DateRangeType.Today):
                {
                    System.DateTime start = utcNow.ToStartOfTzDay(timeZoneInfo);
                    return (start, utcNow);
                }
            case nameof(Enums.DateRangeType.DateRangeType.Yesterday):
                {
                    System.DateTime start = utcNow.ToStartOfPreviousTzDay(timeZoneInfo);
                    System.DateTime end = utcNow.ToEndOfPreviousTzDay(timeZoneInfo);
                    return (start, end);
                }
            case nameof(Enums.DateRangeType.DateRangeType.Custom):
                return null;
            case nameof(Enums.DateRangeType.DateRangeType.CurrentWeek):
                {
                    System.DateTime start = utcNow.ToStartOfTzWeek(timeZoneInfo);
                    return (start, utcNow);
                }
            case nameof(Enums.DateRangeType.DateRangeType.PreviousWeek):
                {
                    System.DateTime start = utcNow.ToStartOfPreviousTzWeek(timeZoneInfo);
                    System.DateTime end = utcNow.ToEndOfPreviousTzWeek(timeZoneInfo);
                    return (start, end);
                }
            case nameof(Enums.DateRangeType.DateRangeType.CurrentMonth):
                {
                    System.DateTime start = utcNow.ToStartOfTzMonth(timeZoneInfo);
                    return (start, utcNow);
                }
            case nameof(Enums.DateRangeType.DateRangeType.PreviousMonth):
                {
                    System.DateTime start = utcNow.ToStartOfPreviousTzMonth(timeZoneInfo);
                    System.DateTime end = utcNow.ToEndOfPreviousTzMonth(timeZoneInfo);
                    return (start, end);
                }
            case nameof(Enums.DateRangeType.DateRangeType.CurrentYear):
                {
                    System.DateTime start = utcNow.ToStartOfTzYear(timeZoneInfo);
                    return (start, utcNow);
                }
            case nameof(Enums.DateRangeType.DateRangeType.PreviousYear):
                {
                    System.DateTime start = utcNow.ToStartOfPreviousTzYear(timeZoneInfo);
                    System.DateTime end = utcNow.ToEndOfPreviousTzYear(timeZoneInfo);
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
