class TestClass
{
    static void Main(String[] args)
    {
        var quest = new List<Quest>
        {
            new Quest { Name = "Repair the Beacon", CompletedSteps = 3, TotalSteps = 5},
            new Quest { Name = "Clear the Ruins", CompletedSteps = 0, TotalSteps = 4},
            new Quest { Name = "Find the Artifact", CompletedSteps = 6, TotalSteps = 6},
            new Quest { Name = "Open the Vault", CompletedSteps = 2, TotalSteps = 8},
        };

        foreach (string summary in CheckQuestProgress(quest))
        {
            Console.WriteLine(summary);
        }
    }

    public class Quest
    {
        public string Name { get; set; } = "";
        public int CompletedSteps { get; set; }
        public int TotalSteps { get; set; }
    }


    public static List<string> CheckQuestProgress(List<Quest> quests)
    {
        List<string> quest_progress = new List<string>();

        foreach (Quest quest in quests)
        {
            float progress_percent = MathF.Round(((float)quest.CompletedSteps / (float)quest.TotalSteps) * 100);
            string quest_status;

            if (progress_percent == 100)
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

            quest_progress.Add($"{quest.Name} - {progress_percent}% - {quest_status}");
        }

        return quest_progress;
    }
}