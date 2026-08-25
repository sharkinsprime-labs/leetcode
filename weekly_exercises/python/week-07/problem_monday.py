
def main() -> None:
    rows = [
        "  repair_beacon | Ada | ready  ",
        "OPEN_VAULT|Tomas| in_progress",
        " find_artifact | Mira | COMPLETE ",
        "clear_ruins|Rook|not_started",
        "broken_row | only_two_fields"
    ]

    for row in clean_mission_rows(rows):
        print(row)

    return

def clean_mission_rows(rows: list[str]) -> list[str]:

    clean_missions = []
    for row in rows:
        post_split = row.split("|")

        if len(post_split) != 3:
            output = f"INVALID: {row.strip()}"
        else:
            mission_name = post_split[0].strip().replace("_"," ").upper()
            agent = post_split[1].strip()
            status = post_split[2].strip().replace("_"," ").upper()

            output = f"{mission_name} | {agent} | {status}"
        clean_missions.append(output)

    return clean_missions

if __name__ == "__main__":
    main()