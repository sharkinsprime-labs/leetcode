using System.Globalization;

class Week2TestClass
{
    static void Main(string[] args)
    {
        var items = new List<InventoryItem>
        {
            new InventoryItem { Name = "iron rifle", Rarity = "common", Power = 120 },
            new InventoryItem { Name = "void cannon", Rarity = "legendary", Power = 950 },
            new InventoryItem { Name = "solar blade", Rarity = "rare", Power = 430 }
        };

        var formattedItems = FormatInventoryItems(items);

        foreach (string item in formattedItems)
        {
            Console.WriteLine(item);
        }
    }

    public class InventoryItem
    {
        public string Name { get; set; } = "";
        public string Rarity { get; set; } = "";
        public int Power { get; set; }
    }

    static List<string> FormatInventoryItems(List<InventoryItem> items)
    {
        List<string> reformatted_items = new List<string>();
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        foreach (InventoryItem item in items)
        {
            string output = $"{item.Rarity.ToUpper()} - {textInfo.ToTitleCase(item.Name)} (Power: {item.Power})";

            reformatted_items.Add(output);
        }

        return reformatted_items;
    }
}