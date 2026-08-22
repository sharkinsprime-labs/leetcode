using System.Globalization;

class TestClass
{
    
    static void Main(string[] args)
    {
        var items = new List<InventoryItem>
        {
            new InventoryItem { Name = "iron rifle", Rarity = "common", Power = 120 },
            new InventoryItem { Name = "void cannon", Rarity = "legendary", Power = 950 },
            new InventoryItem { Name = "solar blade", Rarity = "rare", Power = 430 },
            new InventoryItem { Name = "arc bow", Rarity = "legendary", Power = 1050 },
            new InventoryItem { Name = "field shotgun", Rarity = "common", Power = 180 }
        };

        foreach (var outer in BuildInventoryReport(items))
        {
            Console.WriteLine($"{outer.Key}:");
            RaritySummary summary = outer.Value;
            Console.WriteLine($"    item_count: {summary.ItemCount}");
            Console.WriteLine($"    total_power: {summary.TotalPower}");
            Console.WriteLine($"    average_power: {summary.AveragePower:F2}");
            Console.WriteLine($"    formatted_items:");
            foreach (string description in summary.FormattedItems)
            {
                Console.WriteLine($"          {description}");
            }
            Console.WriteLine($" ");
        }
    }

    public class InventoryItem
    {
        public string Name { get; set; } = "";
        public string Rarity { get; set; } = "";
        public int Power { get; set; }
    }

    public class RaritySummary
    {
        public int ItemCount { get; set; }
        public int TotalPower { get; set; }
        public double AveragePower { get; set; }
        public List<string> FormattedItems { get; set; } = new();
    }

    static string FormatInventoryItems(InventoryItem item)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string reformatted_item = $"{item.Rarity.ToUpper()} - {textInfo.ToTitleCase(item.Name)} (Power: {item.Power})";
        return reformatted_item;
    }

    static Dictionary<string, RaritySummary> BuildInventoryReport(List<InventoryItem> items)
    {
        Dictionary<string, RaritySummary> summary = new()
        {
            {"COMMON", new RaritySummary()},
            {"LEGENDARY", new RaritySummary()},
            {"RARE", new RaritySummary()}
        };

        foreach (InventoryItem item in items)
        {
            summary[item.Rarity.ToUpper()].ItemCount++;
            summary[item.Rarity.ToUpper()].TotalPower += item.Power;
            summary[item.Rarity.ToUpper()].FormattedItems.Add(FormatInventoryItems(item));
        }

        foreach (var key in summary)
        {
            if(key.Value.ItemCount > 0)
                key.Value.AveragePower = MathF.Round((float)key.Value.TotalPower / (float)key.Value.ItemCount, 2);
        }

        return summary;
    }
}