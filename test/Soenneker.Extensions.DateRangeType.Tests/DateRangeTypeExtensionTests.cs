using Soenneker.Tests.FixturedUnit;
using AwesomeAssertions;
using Soenneker.Extensions.DateTime;
using Soenneker.Extensions.DateTime.Month;
using Soenneker.Utils.TimeZones;
using Xunit;

namespace Soenneker.Extensions.DateRangeType.Tests;

[Collection("Collection")]
public class DateRangeTypeExtensionTests : FixturedUnitTest
{

    public DateRangeTypeExtensionTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {
    }

    [Fact]
    public void GetDateTimesFromRange_Today_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.Today;

        (System.DateTime? startAt, System.DateTime? endAt) = dateRange.GetDateTimesFromRange(Tz.Eastern);

        System.DateTime eastern1 = startAt.Value.ToTz(Tz.Eastern);

        System.DateTime eastern2 = endAt.Value.ToTz(Tz.Eastern);
    }

    [Fact]
    public void GetDateTimesFromRange_Yesterday_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.Yesterday;

        (System.DateTime? startAt, System.DateTime? endAt) = dateRange.GetDateTimesFromRange(Tz.Eastern);

        _ = startAt.Value.ToTz(Tz.Eastern);

        _ = endAt.Value.ToTz(Tz.Eastern);
    }

    [Fact]
    public void GetDateTimesFromRange_CurrentWeek_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.CurrentWeek;

        (System.DateTime? startAt, System.DateTime? endAt) = dateRange.GetDateTimesFromRange(Tz.Eastern);

        _ = startAt.Value.ToTz(Tz.Eastern);

        _ = endAt.Value.ToTz(Tz.Eastern);
    }

    [Fact]
    public void GetDateTimesFromRange_PreviousWeek_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.PreviousWeek;

        (System.DateTime? startAt, System.DateTime? endAt) = dateRange.GetDateTimesFromRange(Tz.Eastern);

        _ = startAt.Value.ToTz(Tz.Eastern);
        _ = endAt.Value.ToTz(Tz.Eastern);
    }

    [Fact]
    public void GetDateTimesFromRange_CurrentMonth_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.CurrentMonth;

        (System.DateTime? startAt, System.DateTime? endAt) = dateRange.GetDateTimesFromRange(Tz.Eastern);

        System.DateTime eastern1 = startAt.Value.ToTz(Tz.Eastern);
        eastern1.Day.Should().Be(1);

        _ = endAt.Value.ToTz(Tz.Eastern);
    }

    [Fact]
    public void GetDateTimesFromRange_PreviousMonth_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.PreviousMonth;

        //List<DateTime>? result = dateRange.GetDateTimesFromRange();

        System.DateTime utcNow = System.DateTime.UtcNow;

        System.DateTime start = utcNow.ToStartOfPreviousTzMonth(Tz.Eastern);
        System.DateTime end = utcNow.ToEndOfPreviousTzMonth(Tz.Eastern);

        System.DateTime eastern1 = start.ToTz(Tz.Eastern);
        eastern1.Day.Should().Be(1);

        System.DateTime eastern2 = end.ToTz(Tz.Eastern);
        eastern2.Day.Should().BeGreaterThan(27);
        eastern2.Hour.Should().Be(23);
        eastern2.Minute.Should().Be(59);
    }

    [Fact]
    public void GetDateTimesFromRange_PreviousYear_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.PreviousYear;

        (System.DateTime? startAt, System.DateTime? endAt) = dateRange.GetDateTimesFromRange(Tz.Eastern);

        System.DateTime eastern1 = startAt.Value.ToTz(Tz.Eastern);
        eastern1.Day.Should().Be(1);

        System.DateTime eastern2 = endAt.Value.ToTz(Tz.Eastern);
        eastern2.Day.Should().Be(31);
    }
}
