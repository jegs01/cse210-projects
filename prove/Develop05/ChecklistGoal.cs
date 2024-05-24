using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
    {
        Name = name;
        Points = points;
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
        currentCount = 0;
    }

    public override bool IsComplete()
    {
        return currentCount >= targetCount;
    }

    public override void RecordEvent()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            Program.AddPoints(Points);
            if (currentCount == targetCount)
            {
                Program.AddPoints(bonusPoints);
            }
        }
    }

    public override string GetStatus()
    {
        return IsComplete() ? $"[X] Completed {currentCount}/{targetCount} times" : $"[ ] Completed {currentCount}/{targetCount} times";
    }

    public int GetCurrentCount()
    {
        return currentCount;
    }

    public int GetTargetCount()
    {
        return targetCount;
    }

    public int GetBonusPoints()
    {
        return bonusPoints;
    }
}