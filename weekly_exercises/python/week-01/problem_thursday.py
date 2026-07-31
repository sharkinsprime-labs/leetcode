def build_damage_report(roster, encounters) -> dict:

    damage_report = {}

    for name in roster:

        encounter_count = 0
        total_damage = 0
        average_damage = 0
        highest_damage = 0
        high_damage_count = 0

        filtered = [data for data in encounters if data["player"] == name]
        for data in filtered:
            encounter_count += 1
            total_damage += data["damage"]
            if data["damage"] >= 1000:
                high_damage_count += 1

        if encounter_count <= 0:
            average_damage = None
            highest_damage = None
        else:
            average_damage = round(total_damage / encounter_count, 2)
            max_damage = max(filtered, key=lambda item: item["damage"])
            highest_damage = max_damage["damage"]

        output = {
            "encounter_count": encounter_count,
            "total_damage": total_damage,
            "average_damage": average_damage,
            "highest_damage": highest_damage,
            "high_damage_count": high_damage_count
        }

        damage_report[name] = output
    
    return damage_report

def main() -> None:
    roster = ["Astra", "Bram", "Cyra"]

    encounters = [
        {"player": "Astra", "damage": 850},
        {"player": "Bram", "damage": 1200},
        {"player": "Astra", "damage": 1600},
        {"player": "Bram", "damage": 950},
        {"player": "Astra", "damage": 1100}
    ]

    print(build_damage_report(roster, encounters))

if __name__ == "__main__":
    main()