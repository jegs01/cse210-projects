using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Airman";
        job1._company = "Nigerian Air Force";
        job1._startYear = 2012;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "IT Assistant";
        job2._company = "Mass Medical Mission";
        job2._startYear = 2023;
        job2._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "Kolawole Jegede";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}