using Soenneker.Tests.FixturedUnit;
using AwesomeAssertions;
using Soenneker.Extensions.DateTimeOffsets;
using Soenneker.Extensions.DateTimeOffsets.Months;
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

        (System.DateTimeOffset? startAt, System.DateTimeOffset? endAt) = dateRange.GetDateTimesFromRange(Tz.Eastern);

        System.DateTimeOffset eastern1 = startAt.Value.ToTz(Tz.Eastern);

        System.DateTimeOffset eastern2 = endAt.Value.ToTz(Tz.Eastern);
    }

    [Fact]
    public void GetDateTimesFromRange_Yesterday_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.Yesterday;

        (System.DateTimeOffset? startAt, System.DateTimeOffset? endAt) = dateRange.GetDateTimesFromRange(Tz.Eastern);

        _ = startAt.Value.ToTz(Tz.Eastern);

        _ = endAt.Value.ToTz(Tz.Eastern);
    }

    [Fact]
    public void GetDateTimesFromRange_CurrentWeek_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.CurrentWeek;

        (System.DateTimeOffset? startAt, System.DateTimeOffset? endAt) = dateRange.GetDateTimesFromRange(Tz.Eastern);

        _ = startAt.Value.ToTz(Tz.Eastern);

        _ = endAt.Value.ToTz(Tz.Eastern);
    }

    [Fact]
    public void GetDateTimesFromRange_PreviousWeek_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.PreviousWeek;

        (System.DateTimeOffset? startAt, System.DateTimeOffset? endAt) = dateRange.GetDateTimesFromRange(Tz.Eastern);

        _ = startAt.Value.ToTz(Tz.Eastern);
        _ = endAt.Value.ToTz(Tz.Eastern);
    }

    [Fact]
    public void GetDateTimesFromRange_CurrentMonth_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.CurrentMonth;

        (System.DateTimeOffset? startAt, System.DateTimeOffset? endAt) = dateRange.GetDateTimesFromRange(Tz.Eastern);

        System.DateTimeOffset eastern1 = startAt.Value.ToTz(Tz.Eastern);
        eastern1.Day.Should().Be(1);

        _ = endAt.Value.ToTz(Tz.Eastern);
    }

    [Fact]
    public void GetDateTimesFromRange_PreviousMonth_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.PreviousMonth;

        //List<DateTime>? result = dateRange.GetDateTimesFromRange();

        System.DateTimeOffset utcNow = System.DateTimeOffset.UtcNow;

        System.DateTimeOffset start = utcNow.ToStartOfPreviousTzMonth(Tz.Eastern);
        System.DateTimeOffset end = utcNow.ToEndOfPreviousTzMonth(Tz.Eastern);

        System.DateTimeOffset eastern1 = start.ToTz(Tz.Eastern);
        eastern1.Day.Should().Be(1);

        System.DateTimeOffset eastern2 = end.ToTz(Tz.Eastern);
        eastern2.Day.Should().BeGreaterThan(27);
        eastern2.Hour.Should().Be(23);
        eastern2.Minute.Should().Be(59);
    }

    [Fact]
    public void GetDateTimesFromRange_PreviousYear_should_give_expected()
    {
        Enums.DateRangeType.DateRangeType dateRange = Enums.DateRangeType.DateRangeType.PreviousYear;

        (System.DateTimeOffset? startAt, System.DateTimeOffset? endAt) = dateRange.GetDateTimesFromRange(Tz.Eastern);

        System.DateTimeOffset eastern1 = startAt.Value.ToTz(Tz.Eastern);
        eastern1.Day.Should().Be(1);

        System.DateTimeOffset eastern2 = endAt.Value.ToTz(Tz.Eastern);
        eastern2.Day.Should().Be(31);
    }
}
