def main() -> None:

    items = [
        {"name": "iron rifle", "rarity": "common", "power": 120},
        {"name": "void cannon", "rarity": "legendary", "power": 950},
        {"name": "solar blade", "rarity": "rare", "power": 430}
    ]

    formatted_items = format_inventory_items(items)

    for item in formatted_items:
        print(item)

    return

def format_inventory_items(items):

    reformated_items = []

    for data in items:
        rarity = data["rarity"].upper()
        item_name = data["name"].title()
        power = data["power"]

        output = f"{rarity} - {item_name} (Power: {power})"

        reformated_items.append(output)

    return reformated_items

if __name__ == "__main__":
    main()