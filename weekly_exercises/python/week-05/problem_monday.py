def check_weapon_durability(weapons):
    weapon_list = []

    for weapon in weapons:
        name = weapon["name"]
        durability_percent = round(weapon["current_durability"] / weapon["max_durability"] * 100)
        repair_status = "REPAIR" if durability_percent <= 25 else "READY"

        output = f"{name} - Durability: {durability_percent}% - {repair_status}"

        weapon_list.append(output)

    return weapon_list

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
        }
    ]

    print(check_weapon_durability(weapons))

if __name__ == "__main__":
    main()