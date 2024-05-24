using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class GoalData
{
    public string Type { get; set; }
    public string Name { get; set; }
    public int Points { get; set; }
    public bool Completed { get; set; } 
    public int CurrentCount { get; set; } 
    public int TargetCount { get; set; } 
    public int BonusPoints { get; set; } 
}
