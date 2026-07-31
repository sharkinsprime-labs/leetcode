def clean_player_tags(player_tags):

    cleaned_tags = []

    for tag in player_tags:
        cleaned = ""

        tag = tag.strip()
        tag = tag.upper()
        tag = tag.replace(" ", "_")

        for character in tag:
            if character.isalnum() or character == "_":
                cleaned += character
        #this is checking if its a not blank before appending
        if cleaned:
            cleaned_tags.append(cleaned)

    return cleaned_tags

def main() -> None:
    cleaned_tags = clean_player_tags([ " ghost prime ", "Nova-77", " player!one ", "###", "Astra_9" ])

    print(cleaned_tags)

    return

if __name__ == "__main__":
    main()