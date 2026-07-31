class TestClassMonday
{
    static void Main(String[] args)
    {
        List<int> scores = new List<int> {850,1200,950,1600};

        foreach(KeyValuePair<string, object> kvp in Mission_Summary(scores))
        {
            Console.WriteLine($"{kvp.Key}, {kvp.Value}");
        }

        scores = new List<int>();;

        foreach(KeyValuePair<string, object> kvp in Mission_Summary(scores))
        {
            Console.WriteLine($"{kvp.Key}, {kvp.Value}");
        }
        
    }

    static Dictionary<string, object> Mission_Summary(List<int> damageValues)
    {
        int total_damage = 0;
        int encounters_over_1000 = 0;
        for (int x = 0; x < damageValues.Count; x ++)
        {
            total_damage += damageValues[x];
            if (damageValues[x] > 1000)
            {
                encounters_over_1000++;
            }
        }
        
        double average_damage = 0;
        int? highest_damage = 0;
        if (damageValues.Count <= 0)
        {
            average_damage = 0;
            highest_damage = null;
        }
        else
        {
            average_damage = Math.Round((double)total_damage / damageValues.Count,2);
            highest_damage = damageValues.Max();
        }

        Dictionary<string, object> summary = new ()
        {
            {"total_damage",total_damage},
            {"average_damange",average_damage},
            {"highest_damange",highest_damage},
            {"encounters_over_1000",encounters_over_1000}
        };

        return summary; 
    }
}