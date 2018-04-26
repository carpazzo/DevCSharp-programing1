using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // For this task I had to creat a mini guess the number game ,I started declaing the variables that will be used.
            //also the solution was offered over the assingment how to randomize a number.
            //To make the game more exiting I tried to add 2 lvls that the player could choose to try.
            int guessNumber;
            bool gameon = false;
            Random randomize = new Random();
            int randomNumber = randomize.Next(1, 101);
            // here was my first approach trying to make a constant because was red lines over when i thried to make the lvl system.
            //I will keep so  i can see after and undertand what I did.
            //string dificulty;
            //const string easy;
            //const string hard;
            
            //Game starting here ,i could make a method separete so i could call it back to restart the game.
            //it dindt work as i want so i keept it simple , i guess i will learn how to do that forward.
            Console.WriteLine("Lets play a guessing the number game??\n You have to guess a number between 1 and 100");
            Console.WriteLine("\n Select the dificulty : \n 1 - Easy Mode \n 2 - Hard Mode");
            //player selected the diffciulty 
            int dificulty = int.Parse (Console.ReadLine());
            switch (dificulty)
            {
                //case one will be a forever loop until the person eventually gets the rigth number.
                
                case 1:
                    Console.WriteLine("Easy Mode - you have unlimited chances to guess!!\n Guess the number:");
                                      
                    while (!gameon)
                    {
                        try
                        {
                            //the next method will convert the string that the use imputs in interger.
                            guessNumber = Convert.ToInt32(Console.ReadLine());
                            if (guessNumber == randomNumber)
                            {
                                Console.WriteLine("You win on easy mode !!\n * Good Game *");
                                Console.WriteLine("Press 'any key' to exit");
                                Console.ReadKey(true);
                                return;
                            }
                            else if (guessNumber < randomNumber)
                            {
                                Console.WriteLine("a little more...");
                            }
                            else if (guessNumber > randomNumber)
                            {
                                Console.WriteLine("a little less...");
                            }

                        }
                        catch
                        {
                            Console.ReadKey();
                        }
                    }
                    break;
                case 2:
                    //for the case 2 i will use a do-while loop so it will restrain the chances to make the game more fun as been requested.
                    Console.WriteLine("Hard Mode - You have only 5 chances to guess it rigth. Good Luck!! \n Lets the game Begin!!");
                    int hardmode = 0;
                    do
                    {
                        guessNumber = Convert.ToInt32(Console.ReadLine());
                        if (guessNumber == randomNumber)
                        {
                            Console.WriteLine("Winner,Winner Chicken Dinner!!\n *Good Game*");
                            Console.WriteLine("Press 'any key' to exit");
                            Console.ReadKey(true);
                        }
                        else if (guessNumber < randomNumber)
                        {
                            Console.WriteLine("need to go up..");
                        }
                        else if (guessNumber > randomNumber)
                        {
                            Console.WriteLine("need to go down..");
                        }
                        hardmode++;
                    }
                    while (hardmode != 5);
                    if (hardmode == 5 && guessNumber != randomNumber)
                    {
                        Console.WriteLine("\n YOU ARE NOT PREPARED!!");
                    }
                    Console.ReadKey();
                    break;

                case 51:
                    //This would be a fun thing to have a easteregg, you know as a gamer that like this things, and its also nice for me to learn a bit further. 
                    Console.Clear();
                    Console.WriteLine("Secret Level unlocked - You have 1 chance to guess");
                    {
                        Console.WriteLine("let's see what you got.\nthe number is :");
                        guessNumber = Convert.ToInt32(Console.ReadLine());
                        if (guessNumber == randomNumber)
                        {
                            Console.WriteLine("Are you a PreCog,this was..AMAZING \n* GOOD GAME *");
                        }
                        else 
                        {
                            Console.WriteLine("\nI knew it, get out here !!!");
                            Console.WriteLine("The rigth number was :"+randomNumber);
                        }
                        //one more time where i could restart the game.
                     
                    }
                    Console.ReadKey();
                    break;
                 default:
                    //how do I make it return to the start?? would i need to create separeted methods and call on return?
                    Console.WriteLine("*Choose 1 or 2 only*\n Maybe the U.S Air Force facility in Nevada could help your choise next time!! \n You broke the game 'press any key' to close and try again...\n Shame On You!!");
                    Console.ReadKey();
                    break;
            }
                        
        }
    }
}

