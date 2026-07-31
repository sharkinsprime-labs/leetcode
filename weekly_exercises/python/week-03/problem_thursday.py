def main() -> None:

    items = [
        {"name": "iron rifle", "rarity": "common", "power": 120},
        {"name": "void cannon", "rarity": "legendary", "power": 950},
        {"name": "solar blade", "rarity": "rare", "power": 430},
        {"name": "arc bow", "rarity": "legendary", "power": 1050},
        {"name": "field shotgun", "rarity": "common", "power": 180}
    ]

    inventory_report = build_inventory_report(items)

    print(inventory_report)

    return

def format_inventory_items(items):

    reformated_items = []

    for i in items:
        rarity = i["rarity"].upper()
        item_name = i["name"].title()
        power = i["power"]

        output = f"{rarity} - {item_name} (Power: {power})"

        reformated_items.append(output)

    return reformated_items

def build_inventory_report(items):
    rarities = set([rarity["rarity"].upper() for rarity in items])
    inventory_report = {}

    for filtered_rarity in rarities:
        item_count = 0
        total_power = 0
        
        filtered_data = [item for item in items if item["rarity"].upper() == filtered_rarity]
        
        for data in filtered_data:
            item_count += 1
            total_power += data["power"]

        if item_count <= 0:
            average_power = None
        else:
            average_power = round(total_power / item_count, 2)

        output = {
            "item_count": item_count,
            "total_power": total_power, 
            "average_power": average_power,
            "formatted_items": format_inventory_items(filtered_data)
        }

        inventory_report[filtered_rarity] = output

    return inventory_report

if __name__ == "__main__":
    main()