using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create Video 1: Cooking Tutorial
        Video cookingVideo = new Video("How to Make Perfect Pasta", "Chef Maria", 1200);
        cookingVideo.AddComment(new Comment("John Smith", "This recipe changed my life!"));
        cookingVideo.AddComment(new Comment("Sarah Johnson", "I tried this and it was amazing!"));
        cookingVideo.AddComment(new Comment("Mike Wilson", "Great tips on timing the pasta."));
        cookingVideo.AddComment(new Comment("Lisa Brown", "Can you do a gluten-free version?"));
        videos.Add(cookingVideo);

        // Create Video 2: Programming Tutorial
        Video programmingVideo = new Video("C# Basics for Beginners", "CodeMaster Alex", 1800);
        programmingVideo.AddComment(new Comment("David Lee", "Finally understand classes!"));
        programmingVideo.AddComment(new Comment("Emily Chen", "Your explanations are so clear."));
        programmingVideo.AddComment(new Comment("Tom Anderson", "When is the next video coming?"));
        videos.Add(programmingVideo);

        // Create Video 3: Travel Vlog
        Video travelVideo = new Video("Exploring Tokyo in 24 Hours", "TravelWithJen", 2400);
        travelVideo.AddComment(new Comment("Mark Davis", "I'm planning my trip to Tokyo!"));
        travelVideo.AddComment(new Comment("Rachel Green", "The food looks incredible."));
        travelVideo.AddComment(new Comment("Chris Taylor", "What camera do you use?"));
        travelVideo.AddComment(new Comment("Amanda White", "Please do more Japan content!"));
        videos.Add(travelVideo);

        // Create Video 4: Fitness Workout
        Video fitnessVideo = new Video("30-Minute Full Body Workout", "FitLife Coach", 1800);
        fitnessVideo.AddComment(new Comment("Jessica Park", "This workout is intense!"));
        fitnessVideo.AddComment(new Comment("Ryan Miller", "Perfect for busy schedules."));
        fitnessVideo.AddComment(new Comment("Sophie Turner", "Can beginners do this?"));
        videos.Add(fitnessVideo);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}