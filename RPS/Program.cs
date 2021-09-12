using System;

namespace RPS
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var businessLayer = new RPS_BusinessLayer();
                Console.WriteLine("Do you want to play? (y/n)");
                var userResponse = Console.ReadLine();

                if (userResponse != "y")
                {
                    return;
                }
                businessLayer.Run();
            }
        }
    }
}
