using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Customer_Loyalty_Program_Project
{
    internal class Program
    {
        //Global List


        /// <summary>
        /// This List Contaisns all the books in stock, rented books, registered customers, their registration years,   
        /// </summary>
        static List<string> bookCatalog = new List<string>();           // All books in stock
        static List<string> rentedBooks = new List<string>();           // Books being rented in current session
        static List<string> customerNames = new List<string>();         // Registered customers
        static List<int> registrationYears = new List<int>();           // Their registration years
        static List<int> customerBookTotals = new List<int>();          // Total books rented per customer
        static List<double> MoneySpent = new List<double>(); // Total galleons spent per customer
        static int totalBooksRented = 0; // Total books rented in the current session
       

        /// <summary>
        /// This method display the main menu
        /// </summary>
        static void ShowMenu()
        {
            Console.WriteLine("Group_EP2 Magical Bookstore");
            Console.WriteLine("=============================");
            Console.WriteLine("1. Register Customer");
            Console.WriteLine("2. Add Book to Catalog");
            Console.WriteLine("3. Rent Books");
            Console.WriteLine("4. View Catalog");
            Console.WriteLine("5. View Rented Books");
            Console.WriteLine("6. Checkout");
            Console.WriteLine("7. Exit");
        }



        /// <summary>
        /// This method is used to register a customer in the system. It asks the user for their name and registration year,
        /// </summary>
        static void CustomerRegistration()
        {
            string name;                //Declaring
            int year;

            Console.WriteLine("Enter Customer name: ");
            name = Console.ReadLine();
            customerNames.Add(name);

            Console.WriteLine("Enter registration year: ");
            year = int.Parse(Console.ReadLine());           //convert registration year to an integer, and store it in 'year'
            registrationYears.Add(year);                       //Adding to track how long the customer has been registered

            customerBookTotals.Add(0);
            MoneySpent.Add(0.0);

            Console.WriteLine($"{name} Registered Successfully!!");
        }


       /// <summary>
       /// This method is used to add a book to a catalog
       /// </summary>
        static void AddBook()
        {
            string title;
            Console.WriteLine("Enter Book title: ");
            title = Console.ReadLine();
            bookCatalog.Add(title);  // Add the book to the catalog 

            Console.WriteLine($"{title} Added Successfully!!");
        }


        /// <summary>
        /// // This method displays all the books currently available in the catalog
        /// </summary>
        static void ViewCatalog()
        {
            if (bookCatalog.Count == 0) // Check if the catalog is empty 
            {
                Console.WriteLine("No books available in the catalog.");
            }
            else
            {
                Console.WriteLine("======OUR BOOK CATALOG=========");
                
                Console.WriteLine("Books Available:");
                foreach (string book in bookCatalog)    // Loop through each book in the list(book Catalog) and..
                {
                    Console.WriteLine($":: {book}");  //print it
                }
            }
        }



        /// <summary>
        ///  Method to handle renting books
        /// </summary>
        static void RentBooks()
        { 
            bool found = false;   //track if the book was found in the catalog
            Console.WriteLine("Enter Customer Name: ");
            string customer = Console.ReadLine();
            
            Console.WriteLine("Enter a book title to rent: ");
            string book = Console.ReadLine();

            for (int i = 0; i < bookCatalog.Count; i++)  // // Loop through the entire book catalog to find the entered book
            {
                if (bookCatalog[i] == book)     // Check if the book matches the user's input
                {
                    rentedBooks.Add(bookCatalog[i]);     // Add the book found
                    Console.WriteLine($"{bookCatalog[i]} was rented by: {customer}");
                    found = true;
                    break;     // Stop searching once the book is found
                }
            }

            if (!found)
            {
                Console.WriteLine("The book is not available in the catalog.");
            }
        }



        /// <summary>
        /// This method is used to get the price of a book in Galleons.
        /// </summary>
        /// <returns></returns>
        static double BookPrice(string title)
        {
            double price = 0.0;
            Console.WriteLine("Enter the price of the book in Galleons: ");
            price = double.Parse(Console.ReadLine());
            return price;
        }



        /// <summary>
        /// This method is used to view the books that are currently rented out in the current session.
        /// </summary>
        static void ViewRentedBooks()
        {
            Console.WriteLine("Books Currently Rented: ");

            if (rentedBooks.Count == 0)                      // Check if no books have been rented yet
            {
                Console.WriteLine("No books rented yet.");
            }
            else
            {
                
                foreach (string book in rentedBooks)            //// Loop through each book in the rentedBooks list
                {
                    Console.WriteLine($"- {book}");
                }
                Console.WriteLine($"Total Books rented: {rentedBooks.Count}");
            }



        }




        /// <summary>
        /// This method calculates and displays the discount rate based on the number of years registered.
        /// </summary>
        /// <param name="yearsRegistered"></param>
        /// <param name="discount"></param>
        static void DiscountRate(int yearsRegistered, double discount)
        {
            
            if (yearsRegistered >= 15)
            {
                discount = 0.35;
            }
            else if (yearsRegistered >= 10)
            {
                discount = 0.20;
            }
            else if (yearsRegistered >= 5)
            {
                discount = 0.10;
            }
            else
            {
                discount = 0.05;
            }
            Console.WriteLine($"Your Discount is: {discount * 100}%");
        }

        /// <summary>
        /// This method calculates how many free rentals a customer earns based on total books rented
        /// </summary>
        /// <param name="booksRented"></param>
        /// <returns></returns>
        static int FreeRentals(int booksRented)   //these parameters(int booksRented) give value to a method
        {
            int freeRentals = 0;

            if (booksRented >= 75)
            {
                freeRentals = 8;
            }
            else if (booksRented >= 50)
            {
                freeRentals = 4;
            }
            else if (booksRented >= 25)
            {
                freeRentals = 2;
            }
            else if (booksRented >= 10)
            {
                freeRentals = 1;
            }
            else
                freeRentals = 0;

            return freeRentals;    

        }
        static string BonusReward(int yearsRegistered, int booksRented)
        {
            string bonus = " ";

            if (yearsRegistered >= 15 && booksRented >= 75)
            {
                return "5 Bronze x 2 Silver x 1 Gold tier Book!";
            }
            else if (yearsRegistered >= 10 && booksRented >= 50)
            {
                return "3 Bronze x 1 Silver tier Book!";
            }
            else if (yearsRegistered >= 5 && booksRented >= 25)
            {
                return "1 Bronze tier Book!";
            }
            else
                bonus = "No Bonus";  //if criteria is not met

            Console.WriteLine($"Bonus Reward: {bonus}");
            return bonus;

        }



        /// <summary>
        /// This method handles the checkout process for rented books,
        /// </summary>
        static void CheckOut()
        {
            string name;
            double totalPrice = 0.0,
                discount = 0.0,
                discountAmount,
                price,
                finalTotal = 0.0;
            int yearsRegistered = 0,
                books;

            Console.WriteLine("Enter Your name for the receipt: ");
            name = Console.ReadLine().Trim();

            int index = customerNames.IndexOf(name);

            if (index == -1) // if customer is not found
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            if (rentedBooks.Count == 0)   // If statement used to Check if there are any rented books
            {
                Console.WriteLine("No books Rented. Please rent atleast one book before checkout.");
                return;
            }
            foreach (string book in rentedBooks)      // Loop through each rented book to get its price
            {
                Console.WriteLine($"Book: {book}");
                Console.WriteLine("Enter Price for this book: ");
                price = double.Parse(Console.ReadLine());  // Convert the input(price) into a number
                totalPrice = totalPrice + price; // Add the price of each rented book to the total price
            }
            Console.WriteLine($"Total before Discount: {totalPrice} Galleons");


            int registrationYear = registrationYears[index];   //Getting the year registered
                yearsRegistered = 2025 - registrationYear;
            

            books = customerBookTotals[index];
            

            // Calculate discount based on years registered

            if (yearsRegistered >= 15)
                discount = 0.35;
            else if (yearsRegistered >= 10)
                discount = 0.20;
            else if (yearsRegistered >= 5)
                discount = 0.10;
            else
                discount = 0.05;

            discountAmount = totalPrice * discount;
            finalTotal = totalPrice - discountAmount;



            MoneySpent[index] = MoneySpent[index] + finalTotal; //index used to update the customer's totals
            customerBookTotals[index] += rentedBooks.Count;


            int totalBooks = customerBookTotals[index];
            int earnedFreeRentals = FreeRentals(totalBooks);
            string bonus = BonusReward(yearsRegistered, totalBooks);


            Console.WriteLine("\n====== RECEIPT ======");
            Console.WriteLine($"Customer: {name}");
            Console.WriteLine($"Books Rented: {rentedBooks.Count}");
            Console.WriteLine($"Total Before Discount: {totalPrice} Galleons");
            Console.WriteLine($"Discount Applied: {discount * 100}% ({discountAmount} galleons)");
            Console.WriteLine($"Total After Discount: {finalTotal} Galleons");
            Console.WriteLine($"Free Rentals Earned: {earnedFreeRentals}");
            Console.WriteLine($"Bonus Magical Books: {bonus}");

            Console.WriteLine(); 

            // Call other methods to show detailed discount rate, free rentals, and bonus rewards
            DiscountRate(yearsRegistered, discount);
            FreeRentals(books);
            BonusReward(yearsRegistered, books);

            Console.WriteLine("============================\n");

            rentedBooks.Clear(); // Clear rented books after checkout

        }





        enum Menu             // useful for making menu code more readable and manageable.
        {
            RegisterCustomer = 1,
            AddBook,
            RentBooks,
            ViewCatalog,
            ViewRentedBooks,
            Checkout,
            Exit
        }




        static void Main(string[] args)
        {

            Menu choice;


            do    // This loop Continues to show the menu until the user exits
            {
                ShowMenu();   
                Console.WriteLine("Enter Your Choice: ");
                choice = (Menu)int.Parse(Console.ReadLine());

               

                switch (choice)                     // switch-case performs actions based on the selected menu option
                {
                    case Menu.RegisterCustomer:
                        CustomerRegistration();         //Call a method so it can display when the program runs
                        break;
                    case Menu.AddBook:
                        AddBook();
                        break;
                    case Menu.RentBooks:
                        RentBooks();
                        break;
                    case Menu.ViewCatalog:
                        ViewCatalog();
                        break;
                    case Menu.ViewRentedBooks:
                        ViewRentedBooks();
                        break;
                    case Menu.Checkout:
                        CheckOut();
                        break;
                    case Menu.Exit:  //Exits the program with emidiate effect
                        Console.WriteLine("Thank you for Using Our Program!");           
                        break;
                }

            } while (true);                              //keeps running until the user exits!
        }
    }
}


//======== GROUP MEMBER'S CONTRIBUTIONS==============

//1. BOITUMELO SEGOLE          -- CUSTOMER REGISTRATION && ADDING BOOKS // ASSISTED IN DISCOUNT CALCULATIONS
//2. CHARLTON MACDONALD        -- ENUM MENU SYSTEM STRUCTURE PLUS MENU.EXIT FUNCTION
//3. VHUWAVHO RAPHALA          -- RENTING BOOKS && VIEWING CATALOG
//4. KOENA SEOPA               -- CHECKOUT && DISCOUNT CALCULATIONS
//5. BOITUMELO && VHUWAVHO     -- VIEWING RENTED BOOKS && FREE RENTALS && BONUS REWARDS
//7. CHARLTON AND KOENA        -- CODE REVIEW && TESTING
