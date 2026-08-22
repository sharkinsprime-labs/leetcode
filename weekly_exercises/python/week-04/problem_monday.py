def get_available_missions(missions, powerlevel) -> list[str]:

    mission_list = []

    for mission in missions:
        if mission["required_power"] <= powerlevel and not mission["completed"]:
            name = mission["name"].title()
            power = mission["required_power"]

            output = f"{name} - Required Power: {power}"
            mission_list.append(output)
    return mission_list


def main() -> None:
    player_power = 300
    missions = [
        {
            "name": "the broken gate",
            "required_power": 120,
            "completed": False
        },
        {
            "name": "ashen vault",
            "required_power": 350,
            "completed": False
        },
        {
            "name": "signal lost",
            "required_power": 250,
            "completed": True
        },
        {
            "name": "frozen relay",
            "required_power": 275,
            "completed": False
        }
    ]

    print(get_available_missions(missions, player_power))

if __name__ == "__main__":
    main()