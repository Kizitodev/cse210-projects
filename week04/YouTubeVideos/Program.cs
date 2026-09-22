class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "How to Learn C#",
            "Programming Channel",
            600);

        video1.AddComment(new Comment(
            "John",
            "This was very helpful!"));

        video1.AddComment(new Comment(
            "Mary",
            "I finally understand classes."));

        video1.AddComment(new Comment(
            "David",
            "Great explanation."));

        videos.Add(video1);


        // Video 2
        Video video2 = new Video(
            "Introduction to Databases",
            "Tech Academy",
            720);

        video2.AddComment(new Comment(
            "Sarah",
            "I learned a lot from this video."));

        video2.AddComment(new Comment(
            "Michael",
            "The examples were really good."));

        video2.AddComment(new Comment(
            "Chris",
            "Thanks for explaining this clearly."));

        videos.Add(video2);


        // Video 3
        Video video3 = new Video(
            "Understanding Object Oriented Programming",
            "Code School",
            850);

        video3.AddComment(new Comment(
            "James",
            "Encapsulation makes much more sense now."));

        video3.AddComment(new Comment(
            "Daniel",
            "Very useful lesson."));

        video3.AddComment(new Comment(
            "Lisa",
            "I enjoyed this explanation."));

        videos.Add(video3);


        // Display all videos
        foreach (Video video in videos)
        {
            video.DisplayVideo();
        }
    }
}