using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Project planing for programing 1 , I will be working over the sodacrate skeleton, to be sure to fullfill the required task but 
 * instead being a soda machine i decided to go with a coffee dispenser where the user can chose their coffee grains 
 * if they want it toasted ,smashed, choose how many grams and payment method.
 * The idea is that you will be able to have different nationalities of the beans as an option also brands(Gevalia,zoega,pilao,etc) I will research and work with 5 brands 
 * that exist in the swedish market.
 *Once the selection is made the machine will pack your coffee with its brand bag so you will know what you got, the options can be 50,100,150 and 200 grams.
 * Its not a ready made coffee.
 * I can also go with pre-packaged coffee, wich would take some of the work off, if I see it is taking diferent directions.
 */

namespace Coffee_dispenser
{

    class CoffeeGrainMachine
    {
        //public int[] coffeebags = new int[20];
        //private string[] Coffeebrands = new string []//{ gevalia, arvid, zoega, lofbergs, nescafe };
         
        public CoffeeBrand[] shoppingCart = new CoffeeBrand[20];

        public void Run()
        {   
            Console.WriteLine("Get ready for your Coffee experience");
            WelcomeScreen();
        }

        public void WelcomeScreen()
        {
            /*I will use the switch here with 5 options 
             * Here the person can read about the brand of their choise. 
             * and select to place an order.
			 */
            try
            {
                var brand = new CoffeeBrand();

                Console.WriteLine("Choose the Brand you want to buy");
                Console.WriteLine(" ---------------------------------");
                Console.WriteLine("   Press 1 for     Gevalia ");
                Console.WriteLine("   Press 2 for     Arvid   ");
                Console.WriteLine("   Press 3 for     Zoega   ");
                Console.WriteLine("   Press 4 for     Lofbergs");
                Console.WriteLine("   Press 5 for     Nescafe ");
                Console.WriteLine("   Press 6 to  Search on ShopCart");
                Console.WriteLine(" ---------------------------------");
                string brandselection = Console.ReadLine();
                var brand_value = Convert.ToInt32(brandselection);
                SelectBrand(brand, brand_value);
            }
            catch
            {
                Console.WriteLine("Unexpected Error\n");
                WelcomeScreen();
            }
        }

        private void SelectBrand(CoffeeBrand brand, int brand_value)
        {
            bool brandselectiondone = false;
            while (!brandselectiondone)
            {
                switch (brand_value)
                {
                    //Only the names are real , the informtaion and prices here are fictional.
                     
                    case 1:
                        brand.Brandname = "Gevalia";
                        brand.Type = "Roasted";
                        brand.Flavour = "Mildly strong";
                        brand.Price = 25;
                        brandselectiondone = true;
                        DisplayChoice(brand);
                        
                        break;
                    case 2:
                        brand.Brandname = "Arvid";
                        brand.Type = "Dryied";
                        brand.Flavour = "Strong";
                        brand.Price = 35;
                        brandselectiondone = true;
                        DisplayChoice(brand);

                        break;
                    case 3:
                        brand.Brandname = "Zoega";
                        brand.Type = "Roasted";
                        brand.Flavour = "Mild";
                        brand.Price = 30;
                        brandselectiondone = true;
                        DisplayChoice(brand);

                        break;
                    case 4:
                        brand.Brandname = "Lofbergs";
                        brand.Type = "Sun Dryied";
                        brand.Flavour = "Strong";
                        brand.Price = 40;
                        brandselectiondone = true;
                        DisplayChoice(brand);

                        break;
                    case 5:
                        brand.Brandname = "Nescafe";
                        brand.Type = "Toasted";
                        brand.Flavour = "Weak";
                        brand.Price = 45;
                        brandselectiondone = true;
                        DisplayChoice(brand);

                        break;
                        //this part i implemented at last,so can be buggy ,but was working.
                    case 6:
                        Console.WriteLine("\nType the Coffee name : ");
                        FindBrand(Console.ReadLine().ToLower());
                        
                        break;
                    default:

                        Console.WriteLine("Invalid value, Select from our range of Brands (1-5).");
                        string brandselection = Console.ReadLine();
                        brand_value = Convert.ToInt32(brandselection);
                        brandselectiondone = false;
                        break;

                }
            }
            
        }
        //This function will be a display of the brand for extra information about your coffee selected. 
        public void DisplayChoice(CoffeeBrand coffeeBrand)
        {
            Console.WriteLine("You Choose " + coffeeBrand.Brandname +" The beans of this Coffee are " + coffeeBrand.Type + " and it has a " + coffeeBrand.Flavour + " flavour.\nEach bag will cost " + coffeeBrand.Price + " Krons" );
            Console.WriteLine("\nEach bag have 200 grams of Coffee Beans.");
            Console.WriteLine($"How many bags of this coffee would you like?\n1-{GetSpaceLeftInCart()}");
            ChooseQuantity(coffeeBrand);
        }
    

        public void ChooseQuantity(CoffeeBrand coffeeBrand)
        {
            /*May move it up to select brand, while the person reads about the option the person can choose 
             * how many of that brand want to put in the tray.
             * numberofbags can be added here too.
             */
            
            
            var spacesLeft = GetSpaceLeftInCart();
            var checkout = false;

            do
            {
                int coffeebagsqty = int.Parse(Console.ReadLine());

                if (coffeebagsqty <= spacesLeft)
                {
                    // adding to shopping cart
                    //else and if statments to verify the spaces left in the shopcart
                    AddToShoppingCart(coffeeBrand, coffeebagsqty);
                    if (GetSpaceLeftInCart() > 0)
                    {
                        Console.WriteLine($"There are {GetSpaceLeftInCart()} spaces left would like to buy more Coffee (Y)es / (N)o ");
                        char decision = Convert.ToChar(Console.ReadLine());
                        try
                        {
                            switch (decision)
                            {
                                case 'y':
                                    //go back to coffe selection.
                                    WelcomeScreen();
                                    break;
                                case 'n':
                                    //go to pay the bill
                                    Console.WriteLine("Proceed to Checkout!");
                                    DoCheckout();
                                    break;
                                default:
                                    Console.WriteLine("make your decision");
                                    checkout = false;
                                    break;
                            }
                        }
                        //trying to catch some possibly error do wrong input
                        catch
                        {
                            Console.WriteLine("Yes or No option,only");
                            checkout = false;
                        }
                    } else
                    {
                        Console.WriteLine("Proceed to Checkout!");
                        DoCheckout();
                    }
                    
                }//
                else if (coffeebagsqty > spacesLeft)
                {
                    Console.WriteLine($"You can't buy more than {spacesLeft} bags.");
                    ChooseQuantity(coffeeBrand);
                }
                else if (spacesLeft==0)
                {
                    Console.WriteLine("Your Shopping Cart is full proceed to Checkout");
                    checkout = true;
                    DoCheckout();
                }
                else if (coffeebagsqty < 1)
                {
                    Console.WriteLine("Invalid value.");
                    WelcomeScreen();
                }
            }
            while (!checkout);
        }

        //next function will add produts to my shop cart,keeping the brand name and quantity so it can be used on the invoice.
        public void AddToShoppingCart(CoffeeBrand coffeeBrand, int quantity)
        {
            int amountToAdd = quantity;
            for(var i = 0; i < shoppingCart.Length; i++)
            {
                if (amountToAdd != 0)
                {
                    if (shoppingCart[i] == null)
                    {
                        shoppingCart[i] = coffeeBrand;
                        amountToAdd--;
                    }
                } else
                {
                    break;
                }
            }
        }
        //Print the invoce, here i add some print lines to look nice on the output, like i did on the start. 
        public void DoCheckout()
        {
            int totalPrice = 0;
            Console.Clear();
            Console.WriteLine(" Here is your invoice: ");
            Console.WriteLine("=======================");

            for(var i=0; i < shoppingCart.Length; i++)
            {
                if (shoppingCart[i] != null)
                {
                    var coffeeBrand = shoppingCart[i];
                    Console.WriteLine($"   # {coffeeBrand.Brandname} | {coffeeBrand.Price}kr");
                    totalPrice = totalPrice + coffeeBrand.Price;
                }
            }

            Console.WriteLine("=======================");
            Console.WriteLine($"Total Price: {totalPrice}kr");
            Console.WriteLine($"Thank you for your Purchase!");

            Console.WriteLine("\n Press to finish...");
            Console.ReadKey();
            Console.Clear();
            shoppingCart = new CoffeeBrand[20];
            Run();
            //here is where my program finish ,since i want it to be a machine that can use over and over again, i let the code restart from this point.
        }


        //The next method will check the alocation of the spaces in the array"cart"

        public int GetSpaceLeftInCart()
        {
            int count = 0;
            for (var i = 0; i < shoppingCart.Length; i++)
            {
                if (shoppingCart[i] == null)
                {
                    count++;
                }
            }
            return count;
        }
        // The last implementation to the work ,since i didnt know if would work this way.
        //I create a list so i could check if the name typed on the option 6 would match.
        //I looked other examples on stack overflow.
        public void FindBrand(string searchQuery)
        {
            List<CoffeeBrand> searchResults = new List<CoffeeBrand>();
            int amountFound = 0;
            foreach (var coffeBrand in shoppingCart)
            {
                if (coffeBrand != null)
                {
                    if (coffeBrand.Brandname.ToLower() == searchQuery.ToLower())
                    {
                        amountFound++;
                    }
                }
            }
            Console.WriteLine($"Found {amountFound} results for {searchQuery} in your shopping cart");
            //i just copy and past from before, to give the option if they user want to see what is in the cart. 
            Console.WriteLine($"There are {GetSpaceLeftInCart()} spaces left would like to buy more Coffee (Y)es / (N)o ");
            char decision = Convert.ToChar(Console.ReadLine());
            
            switch (decision)
            {
                case 'y':
                    //go back to coffe selection.
                    WelcomeScreen();
                    break;
                case 'n':
                    //go to pay the bill
                    Console.WriteLine("Proceed to Checkout!");
                    DoCheckout();
                    break;
                default:
                    Console.WriteLine("make your decision");
                    break;
            }
        }
           
                
    }
    //Making a calss for the coffeebrand so i can call and reuse over the methods after.This class could be in another file,i left it here so i can send one .cs file.
    public class CoffeeBrand
    {
            public string  Brandname;
            public string  Type;
            public string  Flavour; 
            public int  Price;

    }

    class Program
    {
        static void Main(string[] args)
        {
           
            var grainmachine = new CoffeeGrainMachine();
            grainmachine.Run();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
//Thats is the planing that ill be working now, ill try to implement as much as possible and access all that i learned so far to pull 
//this project, I left some parts open for later acessment since I wasnt so sure if this is the direction to go, I saw all your videos that was on the link.
//but still a lot of doubts what I was supposed to be doing on this assingment, I think with this project the course escalated quickly,and the information in novo was 
//a little shallow for such complexity, but i guess we will be acessing it on programing 2.


