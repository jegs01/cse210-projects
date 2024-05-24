using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class SimpleGoal : Goal
{
    private bool completed;

    public SimpleGoal(string name, int points)
    {
        Name = name;
        Points = points;
        completed = false;
    }

    public override bool IsComplete()
    {
        return completed;
    }

    public override void RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            Program.AddPoints(Points);
        }
    }

    public override string GetStatus()
    {
        return completed ? "[X]" : "[ ]";
    }

    public bool GetCompletedStatus()
    {
        return completed;
    }
}
