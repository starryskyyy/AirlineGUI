using System;
using System.Windows.Forms;

namespace AirlineGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            aCoord = new AirlineCoordinator(100, 50, 50);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }

        static AirlineCoordinator aCoord;

        public static void addFlight(int fn, string or, string dest, int mSeats)
        {
            aCoord.addFlight(fn, or, dest, mSeats);

        }


        public static void addCustomer(string fName, string lName, string phone)
        {
            aCoord.addCustomer(fName, lName, phone);
        }

        /*public static void addBooking()
        {
            Console.WriteLine(aCoord.flightList());
            Console.WriteLine(aCoord.customersList());
            Console.Write("\nPlease enter the flight number: ");
            int flightNo = getValidFlightNum();
            Console.Write("\nPlease enter the Customer ID: ");
            int id = getValidCustomerId();

            if (aCoord.flightExists(flightNo) && aCoord.customerExists(id)) //flight && customer exist
            {
                if (aCoord.hasSpace())
                {
                    if (aCoord.addBooking(id, flightNo))
                    {
                        Console.WriteLine("\nBooking was successfully made!");
                    }
                }
                else
                {
                    Console.WriteLine("\nNo available seats!");
                }
            }
            else if (!aCoord.customerExists(id))
            {
                Console.WriteLine("\nCustomer with id {0} does not exists!", id);
            }
            else if (!aCoord.flightExists(flightNo))
            {
                Console.WriteLine("\nFlight number {0} does not exists!", flightNo);
            }


            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }*/

        public static void viewFlights()
        {
            Console.WriteLine(aCoord.flightList());

            int id, choice;
            Console.WriteLine("\n1. Yes\n2. No");
            Console.Write("\nPlease select one option: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("\nPlease enter flight number: \n");
                int flightNo = Convert.ToInt32(Console.ReadLine());

                if (aCoord.getFlight(flightNo) != null)
                {
                    Console.Clear();
                    Console.WriteLine("\n" + aCoord.getFlight(flightNo).toString());
                    Console.WriteLine("\nPress any key to continue return to the main menu.");
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("\nFlight number {0} was not found!", flightNo);
                    Console.WriteLine("\nPress any key to continue return to the main menu.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\nPress any key to continue return to the main menu.");
                Console.ReadKey();
            }


        }


        public static void viewCustomers()
        {
            aCoord.customersList();
        }

        /*public static void viewBooking()
        {
            Console.Clear();
            darkYellowColor("-----------View Booking----------\n");
            Console.WriteLine(aCoord.bookingsList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();

        }*/

        public static void deleteCustomer()
        {

            int cid;
            Console.Clear();
            Console.WriteLine(aCoord.customersList());
            Console.Write("\nPlease enter a Customer ID to delete: ");
            cid = Convert.ToInt32(Console.ReadLine());
            if (aCoord.deleteCustomer(cid))
            {
                Console.WriteLine("\nCustomer with id {0} deleted!", cid);

            }
            else if (aCoord.deleteCustomer(cid) && aCoord.getBookings() == false)
            {
                Console.WriteLine("\nSorry customer has a booking!");
            }
            else
            {
                Console.WriteLine("\nCustomer with id {0} was not found!", cid);
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void deleteFlight()
        {
            int id;
            Console.Clear();
            Console.WriteLine(aCoord.flightList());
            Console.Write("\nPlease enter a flight number to delete: ");
            id = Convert.ToInt32(Console.ReadLine());
            if (aCoord.deleteFlight(id))
            {
                Console.WriteLine("\nFlight number {0} deleted!", id);
            }
            else if (aCoord.deleteFlight(id) && aCoord.getPassengers() == false)
            {
                Console.WriteLine("\nSorry this flight has customers booked!");
            }
            else
            {
                Console.WriteLine("\nFlight number {0} was not found!", id);
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }


        public static void showMainMenu()
        {
            Console.Clear();
            Console.WriteLine("XYZ AirLines Limited.\n\nMenu:\n");
            Console.WriteLine("1. Add Flight\n2. Add Customer\n3. Add Booking\n4. View Flights\n5. View Customers\n6. View Bookings\n");
            Console.WriteLine("7. Delete Flight\n8. Delete Customer");
            Console.WriteLine("9. Exit\n");
        }
    }
}
