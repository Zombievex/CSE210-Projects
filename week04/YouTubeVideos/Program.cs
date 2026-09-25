using System;
using System.Reflection.PortableExecutable;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Video video = new Video("How to Basics", "Jimminy Snicket", 68);
        video.AddComment("John", "Wow, watched the whole thing and now my counter is destroyed. 10/10 would watch again.");
        video.AddComment("SigmaGamer", "first");

        Console.WriteLine(video.GetDisplayText());
        video.DisplayComments();
        Console.WriteLine();


        Video video2 = new Video("The long history of watches", "Local Geographic", 3738);
        video2.AddComment("Lickity", "watched the whole thing. Not quite as good as Avengers Engame, but it will do");
        video2.AddComment("SigmaGamer", "do it again, but with morgan freeman");
        video2.AddComment("SusanSaprano12", "The voice is quite painful, couldnt they afford anyone better sounding?");

        Console.WriteLine(video2.GetDisplayText());
        video2.DisplayComments();
        Console.WriteLine();


        Video video3 = new Video("Angry Birds movie (full)", "BasicNoneCommital479", 5820);
        video3.AddComment("LeakyFaucet", "This whole movie in a meme-mine");
        video3.AddComment("ICantBeliveItsNotBigChungus", "Me when it's my turn to present the group project 19:23");

        Console.WriteLine(video3.GetDisplayText());
        video3.DisplayComments();
        Console.WriteLine();
    }
}