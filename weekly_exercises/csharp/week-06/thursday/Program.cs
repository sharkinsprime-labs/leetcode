class TestClass
{
    static void Main(String[] args)
    {
        var quests = new List<Quest>
        {
            new Quest { Name = "Repair the Beacon", CompletedSteps = 3, TotalSteps = 5},
            new Quest { Name = "Clear the Ruins", CompletedSteps = 0, TotalSteps = 4},
            new Quest { Name = "Find the Artifact", CompletedSteps = 6, TotalSteps = 6},
            new Quest { Name = "Open the Vault", CompletedSteps = 2, TotalSteps = 8},
            new Quest { Name = "Decode the Signal", CompletedSteps = 3, TotalSteps = 4}
        };

        foreach (var outer in BuildQuestProgressReport(quests))
        {
            Console.WriteLine($"{outer.Key}:");
            QuestProgressGroup group = outer.Value;
            Console.WriteLine($"    count: {group.Count}");
            Console.WriteLine($"    average_durability: {group.AverageProgress:F2}");
            Console.WriteLine($"    quets:");
            foreach (string description in group.Quests)
            {
                Console.WriteLine($"          {description}");
            }
            Console.WriteLine($" ");
        }
    }

    public class Quest
    {
        public string Name { get; set; } = "";
        public int CompletedSteps { get; set; }
        public int TotalSteps { get; set; }
    }


    public class QuestProgressGroup
    {
        public int Count { get; set; }
        public double TotalProgress { get; set; }
        public double AverageProgress { get; set; }
        public List<string> Quests { get; set; } = new();
    }


    public static Dictionary<string, QuestProgressGroup> BuildQuestProgressReport(List<Quest> quests)
    {
        Dictionary<string, QuestProgressGroup> quest_report = new()
        {
            {"COMPLETE", new QuestProgressGroup()},
            {"IN PROGRESS", new QuestProgressGroup()},
            {"NOT STARTED", new QuestProgressGroup()}
        };

        foreach (Quest quest in quests)
        {
            float progress_percent = MathF.Round(((float)quest.CompletedSteps / (float)quest.TotalSteps) * 100);
            string quest_status;

            if (progress_percent >= 100)
            {
                quest_status = "COMPLETE";
            }
            else if (progress_percent == 0)
            {
                quest_status = "NOT STARTED";
            }
            else
            {
                quest_status = "IN PROGRESS";
            }

            quest_report[quest_status].Count++;
            quest_report[quest_status].TotalProgress += progress_percent;
            quest_report[quest_status].Quests.Add($"{quest.Name} - {progress_percent}%");
        }

        foreach (QuestProgressGroup qpg in quest_report.Values)
        {
            if (qpg.Count > 0)
            {
                qpg.AverageProgress = MathF.Round((float)qpg.TotalProgress / (float)qpg.Count, 2);
            }
        }

        return quest_report;
    }
}