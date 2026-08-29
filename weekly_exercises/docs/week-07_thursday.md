# Ghost Academy - Week 07 Thursday Coding Rep

Suggested path: `weekly_exercises/docs/week-07_thursday.md`
Due: Sunday, August 30, 2026 - end of day
Languages: Python and C#
Focus: Phase 3 - Strings, parsing, cleanup, token extraction, and structured results

## Connection to Monday

Monday's rep had you take raw mission rows, split them on `|`, trim whitespace,
normalize underscores/case, validate the field count, and rebuild clean strings.

Thursday keeps that same raw-data theme, but adds one meaningful step:

Instead of only rebuilding a cleaned string, you will extract a token embedded
inside one field and return structured results.

You are still working primarily with strings. No regex is needed.

## Scenario - Mission Dispatch Parser

Ghost Strike's mission server now receives rows that include a sector code
embedded inside the mission field.

A valid row looks like this:

```text
repair_beacon [echo-7] | Ada | in_progress
```

The first field actually contains two pieces of information:

```text
mission name = repair_beacon
sector       = echo-7
```

Your job is to parse each row, normalize the values, extract the sector code
from inside the brackets, validate the row, and return a structured result for
every input row.

## Requirements

Write a function that accepts a list of raw mission strings and returns one
structured result for each input row.

For each row:

1. Trim the original row.
2. Split the row on `|`.
3. If there are not exactly 3 fields, mark the result invalid with:
   ```text
   BAD FIELD COUNT
   ```
4. Trim all three fields.
5. The first field must contain:
   ```text
   mission_name [sector]
   ```
6. Extract the mission name from the text before `[`.
7. Extract the sector from the text between `[` and `]`.
8. If the bracketed mission format is missing or malformed, mark the result
   invalid with:
   ```text
   BAD MISSION FORMAT
   ```
9. Normalize the mission name:
   - replace `_` with a space
   - convert to uppercase
10. Leave the agent name trimmed but otherwise unchanged.
11. Normalize the status:
   - replace `_` with a space
   - convert to uppercase
12. Valid statuses are:
   ```text
   READY
   IN PROGRESS
   COMPLETE
   NOT STARTED
   ```
13. If the normalized status is not in the allowed list, mark the result
   invalid with:
   ```text
   UNKNOWN STATUS
   ```
14. Normalize the sector to uppercase.
15. Preserve the original row order.
16. Preserve the trimmed original row in every result so invalid records can
   still be identified.
17. Do not use regex.

## Result Shape

### Python

Each returned dictionary should contain:

```python
{
    "is_valid": True,
    "mission": "REPAIR BEACON",
    "agent": "Ada",
    "status": "IN PROGRESS",
    "sector": "ECHO-7",
    "original_row": "repair_beacon [echo-7] | Ada | in_progress",
    "error": None
}
```

For an invalid row, the parsed fields may be `None`, but the result should still
contain the original row and an error reason.

Example:

```python
{
    "is_valid": False,
    "mission": None,
    "agent": None,
    "status": None,
    "sector": None,
    "original_row": "broken_row | only_two_fields",
    "error": "BAD FIELD COUNT"
}
```

### C#

Use a result class with equivalent fields/properties.

```csharp
public class MissionParseResult
{
    public bool IsValid { get; set; }
    public string? Mission { get; set; }
    public string? Agent { get; set; }
    public string? Status { get; set; }
    public string? Sector { get; set; }
    public string OriginalRow { get; set; } = "";
    public string? Error { get; set; }
}
```

## Python Starter Data

```python
rows = [
    "  repair_beacon [echo-7] | Ada | in_progress  ",
    "OPEN_VAULT [DELTA-2]|Tomas| ready",
    " find_artifact [relic-1] | Mira | COMPLETE ",
    "clear_ruins echo-3|Rook|not_started",
    "decode_signal [sigma-4]|Nyx|waiting_for_team",
    "broken_row | only_two_fields"
]
```

### Suggested Function Signature

```python
def parse_mission_rows(rows: list[str]) -> list[dict]:
    pass
```

### Suggested Print Loop

```python
results = parse_mission_rows(rows)

for result in results:
    if result["is_valid"]:
        print(
            f'VALID: {result["mission"]} | '
            f'{result["agent"]} | '
            f'{result["status"]} | '
            f'{result["sector"]}'
        )
    else:
        print(
            f'INVALID: {result["error"]} | '
            f'{result["original_row"]}'
        )
```

## C# Starter Data

```csharp
using System;
using System.Collections.Generic;

class TestClass
{
    static void Main(string[] args)
    {
        var rows = new List<string>
        {
            "  repair_beacon [echo-7] | Ada | in_progress  ",
            "OPEN_VAULT [DELTA-2]|Tomas| ready",
            " find_artifact [relic-1] | Mira | COMPLETE ",
            "clear_ruins echo-3|Rook|not_started",
            "decode_signal [sigma-4]|Nyx|waiting_for_team",
            "broken_row | only_two_fields"
        };

        List<MissionParseResult> results = ParseMissionRows(rows);

        foreach (MissionParseResult result in results)
        {
            if (result.IsValid)
            {
                Console.WriteLine(
                    $"VALID: {result.Mission} | " +
                    $"{result.Agent} | " +
                    $"{result.Status} | " +
                    $"{result.Sector}"
                );
            }
            else
            {
                Console.WriteLine(
                    $"INVALID: {result.Error} | {result.OriginalRow}"
                );
            }
        }
    }

    public static List<MissionParseResult> ParseMissionRows(List<string> rows)
    {
        // Your code here
        return new List<MissionParseResult>();
    }
}

public class MissionParseResult
{
    public bool IsValid { get; set; }
    public string? Mission { get; set; }
    public string? Agent { get; set; }
    public string? Status { get; set; }
    public string? Sector { get; set; }
    public string OriginalRow { get; set; } = "";
    public string? Error { get; set; }
}
```

## Expected Output

```text
VALID: REPAIR BEACON | Ada | IN PROGRESS | ECHO-7
VALID: OPEN VAULT | Tomas | READY | DELTA-2
VALID: FIND ARTIFACT | Mira | COMPLETE | RELIC-1
INVALID: BAD MISSION FORMAT | clear_ruins echo-3|Rook|not_started
INVALID: UNKNOWN STATUS | decode_signal [sigma-4]|Nyx|waiting_for_team
INVALID: BAD FIELD COUNT | broken_row | only_two_fields
```

## Concepts Being Practiced

- `split()` / `Split()`
- `strip()` / `Trim()`
- `replace()` / `Replace()`
- Case normalization
- Finding a character position with `find()` / `IndexOf()`
- Slicing / `Substring()`
- Extracting a token from inside delimiters
- Validating against a small set/list of allowed values
- Returning structured results instead of only formatted strings
- `None` / `null` for unavailable parsed values
- Preserving original input for failed records
- Preserving input order

## Rules

- No regex.
- Do not solve the entire problem inside `Main`.
- Your parsing logic belongs inside the requested function.
- It is fine to use Python/C# documentation for syntax reminders.
- Prefer readable intermediate variables over trying to compress everything
  into one expression.

## Optional A+ Stretch - Validate the Sector Token

After the base version works, validate the sector without regex.

A valid sector must look like:

```text
LETTERS-NUMBER
```

Examples:

```text
ECHO-7
DELTA-2
RELIC-12
```

Invalid examples:

```text
ECHO
-7
ECHO-
ECHO-SEVEN
```

For the stretch:

1. Split the extracted sector on `-`.
2. Require exactly two pieces.
3. Require both pieces to be non-empty.
4. Confirm the right side contains only digits.
5. If invalid, return:
   ```text
   BAD SECTOR
   ```

Try the digit check with a character loop if you can instead of reaching for a
shortcut immediately.

## What Thursday Adds Over Monday

Monday:

```text
raw row
    -> split
    -> trim
    -> normalize
    -> rebuild string
```

Thursday:

```text
raw row
    -> split
    -> trim
    -> locate embedded token
    -> slice / extract
    -> normalize
    -> validate allowed value
    -> return structured result
```

That is the rep: same foundation, one layer deeper into parsing.
