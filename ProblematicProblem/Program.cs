using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        //static Random rng;  //This variable is declared and instantiated later
        //static bool cont = true;  //Bools are replaced with While & Ifs to Handle Exceptions

        private static List<string> activities = new List<string>()
        {
            "Movies", "Paintball", "Bowling", "Lazer Tag",
            "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("\n" +
                              "Hello, welcome to the random activity generator!\n" +
                              "Would you like to generate a random activity? yes/no: ");

            string cont = Console.ReadLine().ToLower();
            
            //Replacing Bool Logic with While and If to Handle Exceptions, then proceeding with rest of code:
            //Removed: bool cont = bool.Parse(Console.ReadLine());
            while (cont != "yes" && cont != "no")
            {
                Console.WriteLine("Invalid input. Please type either Yes or No:");
                cont = Console.ReadLine().ToLower();
            }

            if (cont == "no")
            {
                Console.WriteLine("No problem, come back later if you change your mind!");
                return;
            }
            
            Console.WriteLine();
            Console.Write("Great! We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write($"Hi, {userName}! What is your age? ");
            
            //Fixing unhandled exception for age.
            var parsedSuccess = int.TryParse(Console.ReadLine(), out int userAge);
            
            while (!parsedSuccess)
            {
                Console.WriteLine("Please enter a valid number for your age:");
                parsedSuccess = int.TryParse(Console.ReadLine(), out userAge);
            }
            
            Console.WriteLine($"\n" +
                              $"That's cool! My pet turtle used to be {userAge}.\n" +
                              $"Would you like to see the current list of activities? Sure/No thanks: ");

            string seeList = Console.ReadLine().ToLower();
            
            //Replacing Bool Logic with While and If to Handle Exceptions, then proceeding with rest of code:
            while (seeList != "sure" && seeList != "no thanks")
            {
                Console.WriteLine("Invalid input. Please type either Sure or No Thanks:");
                seeList = Console.ReadLine().ToLower();
            }

            if (seeList == "no thanks")
            {
                Console.WriteLine("No problem! Come back later if you change your mind.");
                return;
            }
            
            Console.WriteLine("\n" +
                              "Awesome! Here are the current activities:");
            
            foreach (string activity in activities)
            {
                    Console.Write($"{activity}, ");
                    Thread.Sleep(250);
            }
            
            Console.WriteLine("\n" +
                              "Would you like to add any activities before we generate one? yes/no: ");

            var addToList1 = Console.ReadLine().ToLower();
            
            //Replacing Bool Logic with While and If to Handle Exceptions, then proceeding with rest of code:
            //Removed: bool addToList1 = bool.Parse(Console.ReadLine());
            Console.WriteLine();

            while (addToList1 != "yes" && addToList1 != "no")
            {
                Console.WriteLine("Invalid input. Please type either Yes or No:");
                addToList1 = Console.ReadLine().ToLower();
            }

            if (addToList1 == "no")
            {
                Console.WriteLine("No problem! We shall proceed...");
            }
            
            //Changed While Condition below to specify Yes:
            while (addToList1 == "yes")         
            {
                Console.Write("What would you like to add? ");
                string userAddition = Console.ReadLine();
                activities.Add(userAddition);
                Console.WriteLine($"\n" +
                                  $"{userAddition} is a great choice!\n" +
                                  $"Here is our new list of activities,\n" +
                                  $"with {userAddition} included:");
                foreach (string activity in activities)
                {
                    Console.Write($"{activity}, ");
                    Thread.Sleep(250);
                }
                Console.WriteLine("\n" +
                                  "Would you like to add more? yes/no: ");
                
                //Replacing Bool Logic with While and If to Handle Exceptions, then rest of code:
                //Removed: bool addToList = bool.Parse(Console.ReadLine());
                addToList1 = Console.ReadLine().ToLower();
                
                while (addToList1 != "yes" && addToList1 != "no")
                {
                    Console.WriteLine("Invalid input. Please type either Yes or No:");
                    addToList1 = Console.ReadLine().ToLower();
                }

                if (addToList1 == "no")
                {
                    Console.WriteLine("No problem! We shall proceed...");
                }
            }    
            
            Console.WriteLine("Now we will generate a random activity from the list above!");
            
            //Changed While Condition Below from cont to true:
            //Nevermind: While Loop created infinite loop here, so it is removed now. //while (true)
            Console.Write("Connecting to the database");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(". ");
                Thread.Sleep(500);
            }
            
            Console.WriteLine();
            Console.Write("Choosing your random activity");
            for (int i = 0; i < 9; i++)
            {
                Console.Write(". ");
                Thread.Sleep(500);
            }

            Console.WriteLine();
            var rng = new Random();
            int randomNumber1 = rng.Next(activities.Count);     
            string randomActivity1 = activities[randomNumber1];
                
            if (userAge < 21 && randomActivity1 == "Wine Tasting")
            {
                Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity1}");
                Console.WriteLine("Pick something else!");
                activities.Remove(randomActivity1);
                int randomNumber2 = rng.Next(activities.Count);
                randomActivity1 = activities[randomNumber2];
            }

            Console.WriteLine($"\n" +
                              $"Ah got it! {userName}, your random activity is: {randomActivity1}!\n" +
                              $"Is this ok or do you want to grab another activity? Keep/Redo: ");
            Console.WriteLine();
            var approveActivity = Console.ReadLine().ToLower();
            
            //Replacing Bool Logic with While and If to Handle Exceptions, then proceeding with rest of code:
            //Removed: bool cont2 = bool.Parse(Console.ReadLine());
            while (true)         
            {
                if (approveActivity == "redo")
                {
                    Console.WriteLine("\n" +
                                      "No problem! Give us a sec, and we'll generate a new option:");
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 4; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                
                    int randomNumber3 = rng.Next(activities.Count);
                    randomActivity1 = activities[randomNumber3];
                    Console.WriteLine($"Alright, {userName}! Your NEW random activity is: {randomActivity1}!\n" +
                                      $"Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    approveActivity = Console.ReadLine().ToLower();
                }
                
                while (approveActivity != "keep" && approveActivity != "redo")
                {
                    Console.WriteLine("Invalid input. Please type either Keep or Redo:");
                    approveActivity = Console.ReadLine().ToLower();
                }

                if (approveActivity == "keep")
                {
                    Console.WriteLine($"Sounds great! Time for an epic round of {randomActivity1}!");
                    return;
                }
            }
        }
    }
}

