using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            Name = "Breathing";
            Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        public override void Run()
        {
            Start();
            for (int i = 0; i < Duration; i += 6)
            {
                Console.WriteLine("Breathe in...");
                ShowAnimation(3);
                Console.WriteLine("Now breathe out...");
                ShowAnimation(3);
                Console.WriteLine();
            }
            End();
        }
    }
