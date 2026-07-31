def mission_summary(damage_values):
    count = len(damage_values)
    total_damage = 0
    encounters_over_1000 = 0

    for damage in damage_values:
        total_damage += damage
        if damage > 1000:
            encounters_over_1000 += 1
    
    if count <= 0:
        average_damage = 0
        highest_damage = None
    else:
        average_damage = total_damage / count
        highest_damage = max(damage_values)

    return {
        "total_damage": total_damage,
        "average_damage": average_damage,
        "highest_damage": highest_damage,
        "encounters_over_1000": encounters_over_1000
    }

def main() -> None:
    scores = [850, 1200, 950, 1600]
    print(mission_summary(scores))

    scores = []
    print(mission_summary(scores))


if __name__ == "__main__":
    main()