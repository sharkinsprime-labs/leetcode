def calculate_average_durability(weapons):
    totals = []
    for weapon in weapons:
        value = weapon[-3:-1]
        totals.append(value)

    int_totals = [float(x) for x in totals]
    return round(sum(int_totals) / len(int_totals), 2)

def build_maintenance_report(weapons):
    maintenance_report = {
        "READY": {"count": 0, "average_durability": 0, "weapons": []},
        "REPAIR": {"count": 0, "average_durability": 0, "weapons": []},
        "BROKEN": {"count": 0, "average_durability": 0, "weapons": []}
    }

    for weapon in weapons:
        name = weapon["name"]
        durability_percent = round(weapon["current_durability"] / weapon["max_durability"] * 100)

        if durability_percent == 0:
            repair_status = "BROKEN"
        elif durability_percent >= 1 and durability_percent <= 25:
            repair_status = "REPAIR"
        else:
            repair_status = "READY"

        description = f"{name} - Durability: {durability_percent}%"

        maintenance_report[repair_status]["count"] += 1
        maintenance_report[repair_status]["weapons"].append(description)

        maintenance_report[repair_status]["average_durability"] = calculate_average_durability(maintenance_report[repair_status]["weapons"])

    return maintenance_report

def main() -> None:
    weapons = [
        {
            "name": "Pulse Rifle",
            "current_durability": 80,
            "max_durability": 100
        },
        {
            "name": "Hand Cannon",
            "current_durability": 15,
            "max_durability": 60
        },
        {
            "name": "Scout Rifle",
            "current_durability": 45,
            "max_durability": 50
        },
        {
            "name": "Sword",
            "current_durability": 20,
            "max_durability": 100
        },
        {
            "name": "Rocket",
            "current_durability": 0,
            "max_durability": 80
        }
    ]

    print(build_maintenance_report(weapons))

if __name__ == "__main__":
    main()