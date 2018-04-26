using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//For this task we will have to make a converter from Farenhit to celsius
//the motivation is a sauna that need to be operated with this code so it has to print out the rigth values for the user 
//some condition have to be made, the sauna best operates bettwen 73 and 77 degress and the perfect point is 75 celsius
// I will try to use conditions, Switch,exeptions, Try and Catch, call methods

namespace SaunaTask
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool running = true;
            Selection();
            while (running) { };
        }

        
        public static void Selection()
        {
            Console.WriteLine("Select 1 for Fahrenheit or 2 for Celsius ");
            string select = Console.ReadLine();
            int selected = Convert.ToInt32(select);

            switch (selected)
            {

                case 1:
                    Console.Clear();
                    Console.WriteLine("Select curent temprature in Fahrenheit :");
                    int fahrraw, celret;
                    Farencalc(out fahrraw, out celret);
                    
                    Console.WriteLine("You choose " + fahrraw + " Fahrenheit");
                    Console.WriteLine("This is " + celret + " Celsius");
                    Safety(fahrraw,celret);
                    break;


                case 2:
                    Console.Clear();
                    Console.WriteLine("Select curent temprature in Celsius :");
                    int celsius, celraw;
                    Celccalc(out celsius, out celraw);

                    Console.WriteLine("You choose " + celsius + " Degress");
                    Console.WriteLine("this is " + celraw + "fucking nigths");
                    Safety(celsius,celraw);
                    break;



                default:
                    
                    Console.WriteLine("Operating on Recomended temp");
                    Console.WriteLine("Press to return...");
                    Console.ReadKey();
                    break;


            }

            
        }


        public static void Safety(int celret, int celsius)
        {
            
            try
            {
                if (celsius > 77|| celret > 77)
                {
                    Console.WriteLine("Not safe to operate on this temprature,too warm");
                    Console.WriteLine("Press to return...");
                    Console.ReadKey();
                    //return celret;
                }
                else if (celsius == 73 || celret == 73)
                {
                    Console.WriteLine("This is the coldest temperature to operate");
                    Console.WriteLine("Press to return...");
                    Console.ReadKey();
                    //return celret;
                }
                else if (celsius < 73 || celret < 73)
                {
                    Console.WriteLine("This is too cold for a normal operation");
                    Console.WriteLine("Press to return and try something warmer");
                    Console.ReadKey();
                    //return celraw;
                }
            }
            catch
            {
                Console.WriteLine("Sauna is operating at Default temperature 75 degress");
                celsius = 75;
                Console.ReadKey();
                //return celraw;
            }

        }

        public static int Farencalc(out int fahrraw, out int celret)
        {
            fahrraw = int.Parse(Console.ReadLine());
            celret = (fahrraw - 32) * 5 / 9;
            return celret;
           
        }

        public static int Celccalc(out int celsius, out int celraw)
        {
            celsius = int.Parse(Console.ReadLine());
            celraw = (celsius * 9) / 5 +32;
            return celraw;

        }
    }
}


