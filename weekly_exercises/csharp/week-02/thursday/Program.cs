public class TagCleanupResult
{
    public string OriginalTag { get; set; } = "";
    public string? CleanedTag { get; set; }
    public bool IsValid { get; set; }
    public string Reason { get; set; } = "";
}

class Week2TestClass
{
    static List<TagCleanupResult> BuildTagCleanupReport(List<string> playerTags)
    {
        List<TagCleanupResult> validation_report = new List<TagCleanupResult>();

        foreach (string tag in playerTags)
        {
            TagCleanupResult result = new TagCleanupResult();
            string original_tag = tag;
            string? cleaned_tag = null;
            bool is_valid = true;
            string reason = "OK";

            string cleaned = "";
            string new_tag = tag.Trim();
            new_tag = new_tag.ToUpper();
            new_tag = new_tag.Replace(" ","_");

            foreach (char character in new_tag)
            {
                if (char.IsLetterOrDigit(character) || character == '_')
                {
                    cleaned += character;
                }
            }

            if (!string.IsNullOrEmpty(cleaned))
            {
                cleaned_tag = cleaned;
                if(cleaned.Length < 3)
                {
                    is_valid = false;
                    reason = "TOO_SHORT";
                }
                else if (cleaned.Length > 15)
                {
                    is_valid = false;
                    reason = "TOO_LONG";
                }
            }
            else
            {
                is_valid = false;
                reason = "EMPTY";
            }

            result.OriginalTag = original_tag;
            result.CleanedTag = cleaned_tag;
            result.IsValid = is_valid;
            result.Reason = reason;

            validation_report.Add(result);
        }

        return validation_report;
    }


    static void Main(String[] args)
    {
        var playerTags = new List<string>
        {
            "  ghost prime  ",
            "Nova-77",
            " player!one ",
            "###",
            "x",
            "super legendary guardian tag",
            "Astra_9"
        };
        
        foreach(TagCleanupResult tag in BuildTagCleanupReport(playerTags))
        {
            Console.WriteLine($"Original Tag: {tag.OriginalTag}"); 
            Console.WriteLine($"Cleaned Tag: {tag.CleanedTag}");   
            Console.WriteLine($"Is Valid: {tag.IsValid}");   
            Console.WriteLine($"Reason: {tag.Reason}");      
        }
    }
}