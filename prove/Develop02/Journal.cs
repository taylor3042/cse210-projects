
public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private PromptGenerator promptGenerator = new PromptGenerator();

    public void WriteEntry()
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        entries.Add(new Entry
        {
            Date = DateTime.Now.ToString(),
            Prompt = prompt,
            Response = response
        });
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}, Prompt: {entry.Prompt}, Response: {entry.Response}");
        }
    }

    public void SaveJournalToFile(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.WriteLine("Date,Prompt,Response"); 
            foreach (var entry in entries)
            {
                
                sw.WriteLine($"\"{entry.Date.Replace("\"", "\"\"")}\",\"{entry.Prompt.Replace("\"", "\"\"")}\",\"{entry.Response.Replace("\"", "\"\"")}\"");
            }
        }
    }

    public void LoadJournalFromFile(string filename)
    {
        entries.Clear();
        using (StreamReader sr = new StreamReader(filename))
        {
            string line;
            sr.ReadLine(); 
            while ((line = sr.ReadLine()) != null)
            {
                var parts = line.Split(',');
                entries.Add(new Entry
                {
                    Date = parts[0].Trim('"').Replace("\"\"", "\""),
                    Prompt = parts[1].Trim('"').Replace("\"\"", "\""),
                    Response = parts[2].Trim('"').Replace("\"\"", "\"")
                });
            }
        }
    }
}
