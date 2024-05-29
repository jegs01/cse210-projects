using System;
using System.Collections.Generic;   

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Win at writing", "Vicky Jegede", 1500);
        video1.AddComment(new Comment("Daniel", "Nice video"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Charlie", "Thanks for the video!"));
        video1.AddComment(new Comment("Eva", "Very clear explanation."));

        Video video2 = new Video("The Art of Public Speaking", "Janet Susan", 1400);
        video2.AddComment(new Comment("Dave", "Loved the examples."));
        video2.AddComment(new Comment("Sunday", "Very clear explanation."));
        video2.AddComment(new Comment("Frank", "Very helpful to me."));

        Video video3 = new Video("JavaScript Essentials", "Jay Johnson", 1900);
        video3.AddComment(new Comment("George", "Excellent coverage of topics."));
        video3.AddComment(new Comment("Hannah", "Great explanations."));
        video3.AddComment(new Comment("Irene", "Useful for my project."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
