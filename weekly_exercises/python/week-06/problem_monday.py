def check_quest_progress(quests):
    quest_progress = []

    for quest in quests:
        name = quest["name"]
        progress_percent = round(quest["completed_steps"] / quest["total_steps"])
        if progress_percent == 100:
            quest_status = "COMPLETE"
        elif progress_percent == 0:
            quest_status = "NOT STARTED"
        else:
            quest_status = "IN PROGRESS"

        progress_report = f"{name} - {progress_percent} - {quest_status}"
        
        quest_progress.append(progress_report)

    return quest_progress 

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
        }
    ]

    print(check_quest_progress(quests))


if __name__ == "__main__":
    main()