using System.ComponentModel;
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

        foreach (string mission in GetAvailableMissions(missions, player_power))
        {
            Console.WriteLine(mission);
        }
    }

    public class Mission
    {
        public string Name { get; set; } = "";
        public int RequiredPower { get; set; }
        public bool Completed { get; set; }
    }

    public static List<string> GetAvailableMissions( List<Mission> missions, int playerPower)
    {
        List<string> mission_list = new List<string>();


        foreach (Mission mission in missions)
        {
            if (mission.RequiredPower <= playerPower && !mission.Completed)
            {
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                string description = $"{textInfo.ToTitleCase(mission.Name)} - Required Power: {mission.RequiredPower}";
                mission_list.Add(description);
            }
        }

        return mission_list;
    }
}