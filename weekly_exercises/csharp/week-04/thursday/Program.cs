using System.Globalization;

class TestClass
{
    static void Main(String[] args)
    {
        int player_power = 300;
        var missions = new List<Mission>
        {
            new Mission { Name = "the broken gate", RequiredPower = 120, Completed = false},
            new Mission { Name = "ashen vault", RequiredPower = 350, Completed = false},
            new Mission { Name = "signal lost", RequiredPower = 250, Completed = true},
            new Mission { Name = "frozen relay", RequiredPower = 275, Completed = false},
        };

        foreach (var outer in BuildMissionReadinessReport(missions, player_power))
        {
            Console.WriteLine($"{outer.Key}:");
            MissionGroup group = outer.Value;
            Console.WriteLine($"    count: {group.Count}");
            Console.WriteLine($"    missions:");
            foreach (string description in group.Missions)
            {
                Console.WriteLine($"          {description}");
            }
            Console.WriteLine($" ");
        }
    }

    public class Mission
    {
        public string Name { get; set; } = "";
        public int RequiredPower { get; set; }
        public bool Completed { get; set; }
    }

    public class MissionGroup
    {
        public int Count { get; set; }
        public List<string> Missions { get; set; } = new();
    }

    public static Dictionary<string, MissionGroup> BuildMissionReadinessReport(List<Mission> missions, int playerPower)
    {
        Dictionary<string, MissionGroup> summary = new()
        {
            {"READY", new MissionGroup()},
            {"LOCKED", new MissionGroup()},
            {"COMPLETED", new MissionGroup()}
        };

        foreach (Mission mission in missions)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            string status;
            string description;

            if (mission.Completed)
            {
                status = "COMPLETED";
                description = $"{textInfo.ToTitleCase(mission.Name)} - {status}";
            }
            else if (mission.RequiredPower > playerPower)
            {
                status = "LOCKED";
                description = $"{textInfo.ToTitleCase(mission.Name)} - {status} (Need {mission.RequiredPower - playerPower} More Power)";
            }
            else
            {
                status = "READY";
                description = $"{textInfo.ToTitleCase(mission.Name)} - {status} (Required Power: {mission.RequiredPower})";
            }
            
            summary[status].Count++;
            summary[status].Missions.Add(description);
        }

        return summary;
    }
}