class TestClass
{
    static void Main(String[] args)
    {
        var weapons = new List<Weapon>
        {
            new Weapon { Name = "Pulse Rifle", CurrentDurability = 80, MaxDurability = 100},
            new Weapon { Name = "Hand Cannon", CurrentDurability = 15, MaxDurability = 60},
            new Weapon { Name = "Scout Rifle", CurrentDurability = 45, MaxDurability = 50},
            new Weapon { Name = "Sword", CurrentDurability = 20, MaxDurability = 100},
        };

        foreach (string summary in CheckWeaponDurability(weapons))
        {
            Console.WriteLine(summary);
        }
    }

    public class Weapon
    {
        public string Name { get; set; } = "";
        public int CurrentDurability { get; set; }
        public int MaxDurability { get; set; }
    }


    public static List<string> CheckWeaponDurability(List<Weapon> weapons)
    {
        List<string> durability_report = new List<string>();

        foreach (Weapon weapon in weapons)
        {
            float durability_percent = MathF.Round(((float)weapon.CurrentDurability / (float)weapon.MaxDurability) * 100);
            string repair_status = (durability_percent <= 25) ? "REPAIR" : "READY";
            string output = $"{weapon.Name} - Durability: {durability_percent}% - {repair_status}";

            durability_report.Add(output);
        }
        return durability_report;
    }
}