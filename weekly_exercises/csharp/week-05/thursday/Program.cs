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
            new Weapon { Name = "Rocket", CurrentDurability = 0, MaxDurability = 80}
        };

        foreach (var outer in BuildMaintenanceReport(weapons))
        {
            Console.WriteLine($"{outer.Key}:");
            MaintenanceGroup group = outer.Value;
            Console.WriteLine($"    count: {group.Count}");
            Console.WriteLine($"    average_durability: {group.AverageDurability:F2}");
            Console.WriteLine($"    missions:");
            foreach (string description in group.Weapons)
            {
                Console.WriteLine($"          {description}");
            }
            Console.WriteLine($" ");
        }
    }

    public class Weapon
    {
        public string Name { get; set; } = "";
        public int CurrentDurability { get; set; }
        public int MaxDurability { get; set; }
    }


    public class MaintenanceGroup
    {
        public int Count { get; set; }
        public double TotalDurability {get; set; }
        public double AverageDurability { get; set; }
        public List<string> Weapons { get; set; } = new();
    }


    public static Dictionary<string, MaintenanceGroup> BuildMaintenanceReport(List<Weapon> weapons)
    {
        Dictionary<string, MaintenanceGroup> maintenance_report = new()
        {
            {"READY", new MaintenanceGroup()},
            {"REPAIR", new MaintenanceGroup()},
            {"BROKEN", new MaintenanceGroup()}
        };

        foreach (Weapon weapon in weapons)
        {

            float durability_percent = MathF.Round(((float)weapon.CurrentDurability / (float)weapon.MaxDurability) * 100);
            string repair_status;

            if (durability_percent == 0)
            {
                repair_status = "BROKEN";
            }
            else if (durability_percent >= 1 && durability_percent <= 25)
            {
                repair_status = "REPAIR";
            }
            else
            {
                repair_status = "READY";
            }

            string description = $"{weapon.Name} - Durability: {durability_percent}%";

            maintenance_report[repair_status].Count++;
            maintenance_report[repair_status].TotalDurability += durability_percent;
            maintenance_report[repair_status].Weapons.Add(description);
        }

        foreach (MaintenanceGroup mg in maintenance_report.Values)
        {
            if (mg.Count > 0)
                mg.AverageDurability = MathF.Round((float)mg.TotalDurability / (float)mg.Count, 2);
        }

        return maintenance_report;
    }
}