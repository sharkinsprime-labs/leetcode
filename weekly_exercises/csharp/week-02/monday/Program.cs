using System.Formats.Asn1;
using System.Runtime.InteropServices;

class Week2TestClass
{
    static List<string> CleanPlayerTags(List<string> playerTags)
    {
        List<string> cleaned_tags = new List<string>();

        foreach (string tag in playerTags)
        {
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
                cleaned_tags.Add(cleaned);
            }
        }

        return cleaned_tags;
    }


    static void Main(String[] args)
    {
        var playerTags = new List<string>{" ghost prime ", "Nova-77", " player!one ", "###", "Astra_9"};
        
        foreach(string tag in CleanPlayerTags(playerTags))
        {
            Console.WriteLine(tag);    
        }
    }
}