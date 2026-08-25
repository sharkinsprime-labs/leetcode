using System.Formats.Tar;
using System.Xml;

class TestClass
{
    static void Main(String[] args)
    {
        var rows = new List<string>
        {
            "  repair_beacon | Ada | ready  ",
            "OPEN_VAULT|Tomas| in_progress",
            " find_artifact | Mira | COMPLETE ",
            "clear_ruins|Rook|not_started",
            "broken_row | only_two_fields"
        };

        foreach (string row in CleanMissionRows(rows))
        {
            Console.WriteLine(row);
        }
    }

    public static List<string> CleanMissionRows(List<string> rows)
    {
        List<string> clean_missions = new List<string>();

        foreach(String row in rows)
        {
            string[] post_split = row.Split("|");
            string output;

            if (post_split.Length != 3)
            {
                output = $"INVALID: {row.Trim()}";        
            }
            else
            {
                string mission_name = post_split[0].Trim().Replace("_", " ").ToUpper();
                string agent = post_split[1].Trim();
                string status = post_split[2].Trim().Replace("_", " ").ToUpper();
                output = $"{mission_name} | {agent} | {status}";
            }
            
            clean_missions.Add(output);
        }
        return clean_missions;
    }
}