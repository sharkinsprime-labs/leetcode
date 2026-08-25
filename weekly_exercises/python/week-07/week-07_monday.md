# Ghost Academy — Week 07 Monday Coding Rep

**Suggested path:** `weekly_exercises/docs/week-07_monday.md`  
**Due:** Wednesday, August 26, 2026 — end of day  
**Languages:** Python and C#  
**Focus:** Phase 3 — Strings, parsing, and cleanup

## Scenario

A game server is receiving mission rows as raw text. The values are usable, but the formatting is inconsistent: some fields have extra spaces, mission/status names use underscores, and capitalization is all over the place.

Your job is to clean each row and return a normalized list of strings.

Keep this one gentle. The goal is to practice **split, trim/strip, replace, case conversion, and rebuilding strings**.

## Requirements

Write a function that:

1. Accepts a list of raw mission-row strings.
2. Splits each valid row on `|`.
3. Trims whitespace around each field.
4. Normalizes the mission name:
   - replace `_` with a space
   - convert to uppercase
5. Leaves the agent name trimmed, but otherwise unchanged.
6. Normalizes the status:
   - replace `_` with a space
   - convert to uppercase
7. Rebuilds each valid row in this format:

```text
MISSION NAME | Agent | STATUS
```

8. If a row does **not** contain exactly 3 fields after splitting, return:

```text
INVALID: <trimmed original row>
```

9. Preserve the original row order.
10. Do **not** use regex.

## Python Starter Data

```python
rows = [
    "  repair_beacon | Ada | ready  ",
    "OPEN_VAULT|Tomas| in_progress",
    " find_artifact | Mira | COMPLETE ",
    "clear_ruins|Rook|not_started",
    "broken_row | only_two_fields"
]
```

### Suggested Function Signature

```python
def clean_mission_rows(rows: list[str]) -> list[str]:
    pass
```

### Example Usage

```python
for row in clean_mission_rows(rows):
    print(row)
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
            "  repair_beacon | Ada | ready  ",
            "OPEN_VAULT|Tomas| in_progress",
            " find_artifact | Mira | COMPLETE ",
            "clear_ruins|Rook|not_started",
            "broken_row | only_two_fields"
        };

        foreach (string row in CleanMissionRows(rows))
        {
            Console.WriteLine(row);
        }
    }

    public static List<string> CleanMissionRows(List<string> rows)
    {
        // Your code here
        return new List<string>();
    }
}
```

## Expected Output

```text
REPAIR BEACON | Ada | READY
OPEN VAULT | Tomas | IN PROGRESS
FIND ARTIFACT | Mira | COMPLETE
CLEAR RUINS | Rook | NOT STARTED
INVALID: broken_row | only_two_fields
```

## Concepts Being Practiced

- [ ] Splitting strings into fields
- [ ] `strip()` / `Trim()`
- [ ] `replace()` / `Replace()`
- [ ] Uppercase normalization
- [ ] Rebuilding formatted strings
- [ ] Simple validation
- [ ] Preserving input order
- [ ] Returning a new list instead of only printing inside the function

## Rules

- No regex.
- No dictionaries are required.
- No sorting is required.
- Try to solve it without looking up a full solution.
- It is completely fine to use language documentation for syntax reminders.

## Optional A+ Stretch

After the base version works, make the function also handle rows where the status contains multiple underscores, such as:

```text
waiting_for_team
```

and correctly output:

```text
WAITING FOR TEAM
```

Your base solution may already handle this automatically depending on how you write it.

## Thursday Preview

Thursday can build on this by taking the cleaned rows, turning them into structured `Mission` records/objects, and doing a small amount of filtering or matching. That will connect **string parsing** to the data-processing patterns you have already been practicing.
