using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class EternalGoal : Goal
{
    public EternalGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override bool IsComplete()
    {
        return false; 
    }

    public override void RecordEvent()
    {
        Program.AddPoints(Points);
    }

    public override string GetStatus()
    {
        return "[∞]"; 
    }
}
