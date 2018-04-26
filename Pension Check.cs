using System;
//Task 1 is to create an application that save the person name ,check their age and tell how long they have until reach retirement at the age of 65.
//I gonna start creating string variables to store the name of the client so it can be printed on final lines.


namespace PesionCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables and data to be stored and used
            string personname;
            int actyear = 2018;
            int retireage = 65;
            
            //Welcome screen and main question.
            Console.WriteLine("Hello,would you like to know when you can retire?");
            Console.WriteLine("Please, provide your Name and Surrname, and then Press Enter");
            //console get client name to use on next line.
            personname = Console.ReadLine();

            if (personname == null)
            {
                //im trying to make that if the person dont type anything or if the person type numbers instead not be accepted as a name.
                Console.WriteLine("Provide a Name, Please!");
                return;
            }
            else
            {
                
                //Console.WriteLine("Press Enter");
                //Console.ReadKey(true);
                Console.WriteLine("Date of Birthday : YYYY ");
                // we could ask for personnumber and isolate the 4  first and do some condition to check if the biryhday have happen too.
                string birthyear = Console.ReadLine();
                int birthdate = Convert.ToInt32(birthyear);
                int clientage = actyear - birthdate;
                // Now I need to converte string to interger, I dont understand whhy cant we just use int directly.
                //int clientage = Console.ReadLine()<-- something like this
                int clientrealage = Convert.ToInt32(clientage);
                //I add a line to show the age. Here we could 
                // need to implement here some cases when birthday hasn't been celebrated need to deduce clientage - 1.
                Console.WriteLine("You Are " + clientrealage + " years old");
                Console.WriteLine("Press Enter");
                Console.ReadKey(true);
                //now that the user type his/her age the next statments will check the age and proceed.
                if (clientrealage < retireage)
                {
                    int lefttime = retireage - clientrealage;//calculation to check how long until the person can retire.
                    Console.WriteLine("Sorry " + personname + ", you have " + lefttime + " years left until your retierment!");
                    Console.WriteLine("Press Enter to finish!");
                    Console.ReadKey(true);
                }
                else
                {
                    // This will happen if the person is alredy 65 or over.
                    Console.WriteLine("Congratulations," + personname + " you can retire already.");
                    Console.WriteLine("Povide you contact and we will proceed your enquire");
                    Console.WriteLine("Press Enter to finish!");
                    Console.ReadKey(true);
                }
            }
        }
      
    }
}
