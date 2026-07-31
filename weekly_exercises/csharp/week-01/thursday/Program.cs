public class Encounter
{
    public string Player {get; set;} = "";
    public int Damage {get; set;}
}

public class DamageSummary
{
    public int EncounterCount { get; set; }
    public int TotalDamage { get; set; }
    public double? AverageDamage { get; set; }
    public int? HighestDamage { get; set; }
    public int HighDamageCount { get; set; }
}

class TestClassThursday
{
    static void Main(String[] args)
    {
        var roster = new List<string>{"Astra", "Bram", "Cyra"};
        var encounters = new List<Encounter>
        {
            new Encounter { Player = "Astra", Damage = 850 },
            new Encounter { Player = "Bram", Damage = 1200 },
            new Encounter { Player = "Astra", Damage = 1600 },
            new Encounter { Player = "Bram", Damage = 950 },
            new Encounter { Player = "Astra", Damage = 1100 }
        };
        
        foreach (var outer in BuildDamageReport(roster, encounters))
        {
            Console.WriteLine($"{outer.Key}:");
            DamageSummary summary = outer.Value;

            Console.WriteLine($"    encounter_count: {summary.EncounterCount}");
            Console.WriteLine($"    total_damage: {summary.TotalDamage}");
            Console.WriteLine($"    average_damage: {summary.AverageDamage}");
            Console.WriteLine($"    highest_damage: {summary.HighestDamage}");
            Console.WriteLine($"    high_damage_count: {summary.HighDamageCount}");
            Console.WriteLine();

        }
    }

    static Dictionary<string, DamageSummary> BuildDamageReport(List<string> roster, List<Encounter> encounters)
    {
        Dictionary<string, DamageSummary> summary = new Dictionary<string, DamageSummary>();

        for (int x = 0; x < roster.Count; x++)
        {
            int encounter_count = 0;
            int total_damage = 0;
            double? average_damage = 0;
            int? highest_damage = 0;
            int high_damage_count = 0;

            var filteredList = encounters.Where(player => player.Player == roster[x]);
            foreach (var player in filteredList)
            {
                encounter_count++;
                total_damage += player.Damage;
                if (player.Damage >= 1000) 
                {
                    high_damage_count++;
                }
            }

            if (encounter_count <= 0)
            {
                average_damage = null;
                highest_damage = null;
            }
            else
            {
                average_damage = Math.Round((double)total_damage / encounter_count, 2);
                highest_damage = filteredList.Max(d => d.Damage);
            }

            DamageSummary player_summary = new DamageSummary()
            {
                EncounterCount = encounter_count,
                TotalDamage = total_damage,
                AverageDamage = average_damage,
                HighestDamage = highest_damage,
                HighDamageCount = high_damage_count
            };

            summary.Add(roster[x], player_summary);
        }
        
        return summary;
    }
}