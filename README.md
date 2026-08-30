[![](https://img.shields.io/nuget/v/soenneker.extensions.daterangetype.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.daterangetype/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.daterangetype/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.daterangetype/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.daterangetype.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.daterangetype/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.daterangetype/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.daterangetype/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.DateRangeType

Converts `Soenneker.Enums.DateRangeType.DateRangeType` presets into UTC date boundaries using a supplied time zone.

## Installation

```bash
dotnet add package Soenneker.Extensions.DateRangeType
```

## Resolve a preset

```csharp
using Soenneker.Enums.DateRangeType;
using Soenneker.Extensions.DateRangeType;

TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");

(DateTimeOffset? startAt, DateTimeOffset? endAt) =
    DateRangeType.CurrentMonth.GetDateTimesFromRange(timeZone);
```

Both non-null results are UTC instants. The supplied time zone determines the local calendar boundary before that boundary is converted to UTC, so offsets remain correct across daylight-saving transitions.

## Range behavior

| Preset | Start | End |
| --- | --- | --- |
| `Today` | Start of the current local day | Time of the call |
| `Yesterday` | Start of the previous local day | Last tick of the previous local day |
| `CurrentWeek` | Start of the current local week | Time of the call |
| `PreviousWeek` | Start of the previous local week | Last tick of the previous local week |
| `CurrentMonth` | Start of the current local month | Time of the call |
| `PreviousMonth` | Start of the previous local month | Last tick of the previous local month |
| `CurrentYear` | Start of the current local year | Time of the call |
| `PreviousYear` | Start of the previous local year | Last tick of the previous local year |
| `Custom` or an unsupported value | `null` | `null` |

Weeks begin on Monday. Current ranges use `DateTimeOffset.UtcNow` captured during the call; the API does not accept an external clock or custom endpoint.

## Unit mapping

```csharp
UnitOfTime unit = DateRangeType.Today.ToUnitOfTime();
```

`Today` and `Yesterday` map to `UnitOfTime.Hour`. Every other value maps to `UnitOfTime.Second`, including `Custom`.
