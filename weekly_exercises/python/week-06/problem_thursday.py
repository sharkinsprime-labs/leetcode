def check_quest_progress(quests):
    quest_report = {
            "COMPLETE": {"count": 0, "total_progress": 0.0, "average_progress": 0, "quests": []},
            "IN PROGRESS": {"count": 0, "total_progress": 0.0, "average_progress": 0, "quests": []},
            "NOT STARTED": {"count": 0, "total_progress": 0.0, "average_progress": 0, "quests": []}
        }

    for quest in quests:
        name = quest["name"]

        progress_percent = round(quest["completed_steps"] / quest["total_steps"] * 100)
        if progress_percent >= 100:
            quest_status = "COMPLETE"
        elif progress_percent <= 0:
            quest_status = "NOT STARTED"
        else:
            quest_status = "IN PROGRESS"

        progress_report = f"{name} - {progress_percent}%"

        quest_report[quest_status]["count"] += 1

        quest_report[quest_status]["total_progress"] += progress_percent
        quest_report[quest_status]["quests"].append(progress_report)

    for status, bucket in quest_report.items():
        if bucket["count"] > 0:
            bucket["average_progress"] = round(bucket["total_progress"] / bucket["count"], 2)

        del bucket["total_progress"]

    return quest_report

def main() -> None:
    quests = [
        {
            "name": "Repair the Beacon",
            "completed_steps": 3,
            "total_steps": 5
        },
        {
            "name": "Clear the Ruins",
            "completed_steps": 0,
            "total_steps": 4
        },
        {
            "name": "Find the Artifact",
            "completed_steps": 6,
            "total_steps": 6
        },
        {
            "name": "Open the Vault",
            "completed_steps": 2,
            "total_steps": 8
        },
        {
            "name": "Decode the Signal",
            "completed_steps": 3,
            "total_steps": 4
        }
    ]

    print(check_quest_progress(quests))


if __name__ == "__main__":
    main()