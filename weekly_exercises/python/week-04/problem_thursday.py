def get_missions_status(missions, powerlevel, readiness_status):

    mission_list = []

    for mission in missions:
        
        name = mission["name"].title()
        power = mission["required_power"]
        is_complete = mission["completed"]

        if is_complete:
            status = readiness_status[2]
        elif power > powerlevel:
            status = readiness_status[1]
        else:
            status = readiness_status[0]

        output = {
            "description": f"{name} - {status} (Required Power: {power})",
            "status": status
        }

        mission_list.append(output)
    return mission_list

def build_mission_readiness_report(missions, powerlevel):
    readiness_status = ["READY","LOCKED","COMPLETED"]
    readiness_report = {}

    mission_list = get_missions_status(missions, powerlevel, readiness_status)

    for readiness_type in readiness_status:
        missions = []
        count = 0
        for mission in mission_list:
            if mission["status"] == readiness_type:
                count += 1
                missions.append(mission["description"])

        output = {"count": count, "missions": missions}

        readiness_report[readiness_type] = output

    return readiness_report


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

    print(build_mission_readiness_report(missions, player_power))

if __name__ == "__main__":
    main()

