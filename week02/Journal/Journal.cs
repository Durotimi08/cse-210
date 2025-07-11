using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;

    public Journal()
    {
        _entries = new List<Entry>();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me laugh today?",
            "What am I grateful for today?",
            "What challenged me today and how did I respond?",
            "What did I learn today?",
            "How did I help someone else today?"
        };
    }

    public void AddEntry()
    {
        Random random = new Random();
        string randomPrompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine($"\nPrompt: {randomPrompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string currentDate = DateTime.Now.ToString("MM/dd/yyyy");

        Entry newEntry = new Entry(randomPrompt, response, currentDate);
        _entries.Add(newEntry);

        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayAllEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found in the journal.\n");
            return;
        }

        Console.WriteLine("\n=== JOURNAL ENTRIES ===\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save journal: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
            Console.WriteLine($"Journal saved to {filename} successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}\n");
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();

        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File {filename} not found.\n");
                return;
            }

            _entries.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        Entry entry = new Entry(parts[1], parts[2], parts[0]);
                        _entries.Add(entry);
                    }
                }
            }
            Console.WriteLine($"Journal loaded from {filename} successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}\n");
        }
    }
}