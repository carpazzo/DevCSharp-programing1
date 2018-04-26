using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*For this task I had to creat an Bingo Game ,where the user will type 10 numbers from 1 to 25 
 * and these number will be checked in a Array of random numbers. First was only one number but lately i will have to Implement a second number
 * The catch for the task was to input all code in "For and Foreach" loops kepping it simple and not using any shortcut.
 * 
*/ 

namespace BingoLottoTask
{
    class Program
    {       
        static void Main(string[] args)
        {
            /*Here I declared credit as a boolean so it keep running the program, in a future implemantation we could use a
             * catch statment and stop it.if credit = 0
             * like the real deal people add credit ,maybe win something maybe not.
            */ 
            var credit = true;
            do
            {
                Console.WriteLine("\n      * * * * BINGO LOTTO GAME * * * *\n");
                StartGame();
            }
            while (credit != false);
        }
        //Here Is the method whre the game will start, and where we will be coming back after sucess or failure.
        //since this is a gambling game.
        public static void StartGame()
        {
            //Luckynumbers it is the array where will store the numbers  that the user imputs.
            var luckyNumbers = new int[10];
            Console.WriteLine("Enter your (10) lucky numbers bettwen 1 and 25\n      Press Enter after each number!");
            //inside the for loop, the numbers are checked if stays on the proper values 
            for (var index = 0; index < luckyNumbers.Length; index++)
            {   //I add a try catch here to not crash , when the user type no numbers.
                try
                {
                    luckyNumbers[index] = int.Parse(Console.ReadLine());
                    if (luckyNumbers[index] < 1)
                    {
                        Console.WriteLine("Number Too low!");
                        luckyNumbers[index] = index++;
                    }
                    else if (luckyNumbers[index] > 25)
                    {
                        Console.WriteLine("Number too high!");
                        luckyNumbers[index] = index--;
                    }
                }
                catch
                {
                    Console.WriteLine("You need to type your numbers");
                }
                
            }
            Console.Clear();
            Console.WriteLine("         Good Luck!!\n     Those are your numbers");
            //Console.ReadKey(true);
            Gameon(luckyNumbers);
        }
        /*
         * the numbers typed is inside the values allowed ,now we move for the next method where we will 
         * have a statment that creat a random number(at first) and lately implemented for 2 numbers
         * stil here we have to stay using for,forech loops for the ittereation.
         * 
         */
        public static void Gameon(int[] luckyNumbers)
        {

            
            foreach (var number in luckyNumbers)
            {    //Winnernumber is the new array that will store the random winning numbers, I also print that out so the user can see if that match.   
                Random bingoNumbers = new Random();
                int randombingonumber = bingoNumbers.Next(1, 25);
                int randombingonumber2 = bingoNumbers.Next(1, 25);
                int randombingonumber3 = bingoNumbers.Next(1, 25);
                var winnerNumbers = new int[2] { randombingonumber, randombingonumber2 };
                //this line of print i add to see if the code was rigth , but decided to leave there it made look more organized on the user end.
                Console.WriteLine("[{0}]", string.Join(", ", luckyNumbers));
                Console.WriteLine("\nThe Wining numbers are : " + randombingonumber + " and " + randombingonumber2);
                //The next conditionals will check matching luckynumbers with bingonumbers
                //I tried to simplify it using the array winnernumbers but it didnt work as expeted.The size of the arrays conflict.
                if (luckyNumbers[number] == randombingonumber && luckyNumbers[number] == randombingonumber2)
                {
                    Console.WriteLine("* * * $$$ BINGO!! Congratulations!!! $$$ * * *\nLets try to doble it.. Play again!!");
                    Console.ReadKey();
                    Console.Clear();
                    StartGame();
                }
                else if (luckyNumbers[number] == randombingonumber || luckyNumbers[number] == randombingonumber2)
                {
                    Console.WriteLine("Urghh!!! That was so close, maybe next try.\n Play Again!!");
                    Console.ReadKey();
                    Console.Clear();
                    StartGame();
                }
                //I dont want to give a free spin , but i had to do that to check the numbers, it never happened on my debugging but can happen!
                //what i really want here was that if this condition was met randomnumber2 get a new random number. 
                else if (randombingonumber == randombingonumber2)
                {
                    randombingonumber2 = randombingonumber3;
                    Console.WriteLine("\nThe Wining numbers are : " + randombingonumber + " and " + randombingonumber3);
                }
                //if none of the winning conditions are met, display the else statment.
                else
                {
                    Console.WriteLine("Better Luck on your next Game");
                    Console.ReadKey();
                    Console.Clear();
                    StartGame();
                }
            }
            StartGame();

        }
    }
}
