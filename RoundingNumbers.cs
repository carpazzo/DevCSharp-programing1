using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//For this task I need to make a float /double number print out with how many desireable houses after the coma/dot.
//It was hard to come up with a soulution on this ,when you have to ask the person how many houses they want
//Im happy with the result but I can learn something later maybe that can make it better.


namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //double number ();
            //Trying to find a reason to ask for this type of number,so the only thing came in mind was the reason of GPU prices inflation.
            Console.WriteLine("Enter the number of bitcoins you want to be rounded. Use '.' to space it,and press enter");
            string newnumber = Console.ReadLine();
            double number = Convert.ToDouble(newnumber);
            //putting a extra pinting line here so the person can check if the number is correct.
            Console.Clear;
            Console.WriteLine("You have " +newnumber+ " Bitcoins");
            Console.WriteLine("How many houses after the dot would you like to see?\n Choose between 1 and 4");
            string dot = Console.ReadLine();
            int house = Convert.ToInt32(dot);
            //gonna use the examples from c#skola to see the outputs
            //i was stuck here how i would make it happen,so i  move to task 3 and came back. I gonna use the same solution a Switch statment.
            //there is probably a better solution ,but i tried different things here and it doenst work as expected.
            //I go with this one because worked and want to see your feedback on it Oscar.
            switch(house) 
            {
                case 1:
                    string numberrounded = String.Format("{0:f1}", +number);
                    Console.WriteLine("Your rounded bitcoin value is " + numberrounded);
                    break;
                case 2:
                    string numberrounded2 = String.Format("{0:f2}", +number);
                    Console.WriteLine("Your rounded bitcoin value is " + numberrounded2);
                    break;
                case 3:
                    string numberrounded3 = String.Format("{0:f3}", +number);
                    Console.WriteLine("Your rounded bitcoin value is " + numberrounded3);
                    break;
                case 4:
                    string numberrounded4 = String.Format("{0:f4}", +number);
                    Console.WriteLine("Your rounded bitcoin value is " + numberrounded4);
                    break;
                default:
                    Console.WriteLine("Between 1 and 4 , try again");
                    Console.ReadKey();
                    return;
            }
               //what can be implented here is a function where we can convert the number rounded to our currency krona ...so it would be a bitcoin converter to see how much money you making.
               //but its values fluctuate and would have to compare with some online source database. I think im going to areas I have no idea how to pull out yet.
               //for the task I think its done.
            Console.ReadKey();
        }
    }
}
