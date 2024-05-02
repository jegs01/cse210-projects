using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    public List<JournalEntry> GetEntries()
    {
        return entries;
    }

    public void ClearEntries()
    {
        entries.Clear();
    }
}