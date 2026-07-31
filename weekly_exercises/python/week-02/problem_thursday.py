def build_tag_cleanup_report(player_tags):

    validation_report = []

    for tag in player_tags:
        original_tag = tag
        cleaned_tag = None
        is_valid = False
        reason = "OK"

        tag = tag.strip()
        tag = tag.upper()
        tag = tag.replace(" ", "_")

        cleaned = ""

        for character in tag:
            if character.isalnum() or character == "_":
                cleaned += character

        if cleaned:
            cleaned_tag = cleaned
            if len(cleaned) < 3:
                reason = "TOO_SHORT"
            elif len(cleaned) > 15:
                reason = "TOO_LONG"
        else:
            reason = "EMPTY"

        if reason == "OK":
            is_valid = True

        output = {
            "original_tag": original_tag,
            "cleaned_tag": cleaned_tag,
            "is_valid": is_valid,
            "reason": reason
        }

        validation_report.append(output)

    return validation_report

def main() -> None:
    player_tags = [ 
        "  ghost prime  ",
        "Nova-77",
        " player!one ",
        "###",
        "x",
        "super legendary guardian tag",
        "Astra_9" 
    ]

    print(build_tag_cleanup_report(player_tags))

    return

if __name__ == "__main__":
    main()