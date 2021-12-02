using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineGUI
{
    class FlightManager
    {
        private int maxFlights;
        private Flight[] flightList;

        public FlightManager(int max)
        {
            maxFlights = max;
            flightList = new Flight[maxFlights];
        }

        public Flight[] flightDatabase()
        {
            int lnCount = File.ReadLines("FlightDB.txt").Count();
            StreamReader input = new StreamReader("FlightDB.txt", true);
            Flight[] list = new Flight[lnCount];
            string[] flightlist;
            int cnt = 0;
            while (input.Peek() != -1)
            {
                flightlist = input.ReadLine().Split(',');
                list[cnt++] = new Flight(int.Parse(flightlist[0]), flightlist[1], flightlist[2], int.p(flightlist[3]));
            }
            input.Close();
            return list;
        }

        public int numOfFlight()
        {
            int lnCount = File.ReadLines("FlightDB.txt").Count();
            return lnCount;
        }

        public bool addFlight(int fn, string or, string dest, int mSeats)
        {
            Flight[] list = flightDatabase();
            if (numOfFlight() < maxFlights)
            {

                StreamWriter outputFile = new StreamWriter("flightDB.txt", true);
                Flight f = new Flight(fn, or, dest, mSeats);
                outputFile.WriteLine(f);
                outputFile.Close();
                return true;
            }
            return false;
        }

        public int findFlight(int fid)
        {
            Flight[] list = flightDatabase();
            for (int x = 0; x < list.Length; x++)
            {
                if (list[x].getFlightNumber() == fid)
                    return x;
            }
            return -1;
        }

        public bool flightExists(int fid)
        {
            int loc = findFlight(fid);
            if (loc == -1) { return false; }
            return true;
        }

        public bool getPassengers()
        {
            Flight[] list = flightDatabase();
            for (int x = 0; x < list.Length; x++)
            {
                if (list[x].getNumPassengers() == 0)
                    return true;
            }
            return false;
        }

        public bool hasSpace()
        {
            Flight[] list = flightDatabase();
            for (int x = 0; x < list.Length; x++)
            {
                if (list[x].getNumPassengers() < list[x].getMaxSeats())
                    return true;
            }
            return false;
        }

        public Flight getFlight(int fid)
        {
            int loc = findFlight(fid);
            if (loc == -1) { return null; }
            return flightList[loc];
        }


        public bool deleteFlight(int fid)
        {
            List<Flight> list = flightDatabase().ToList();
            int loc = findFlight(fid);
            bool passengers = getPassengers();
            if (loc == -1 && passengers == true) { return false; }
            list.RemoveAt(loc);
            StreamWriter outputFile = new StreamWriter("FlightDB.txt");
            for (int x = 0; x < list.Count; x++)
            {
                Flight f = new Flight(list[x].getFlightNumber(), list[x].getOrigin(), list[x].getDestination(), list[x].getMaxSeats());
                outputFile.WriteLine(f);
            }
            outputFile.Close();
            return true;
        }

        public string getFlightList()
        {
            Flight[] list = flightDatabase();
            string s = "Flight List:\n";

            for (int x = 0; x < list.Length; x++)
            {
                s = s + "\n" + list[x].getFlightNumber() + " from " + list[x].getOrigin() + " to " + list[x].getDestination() + "\n";

            }
            return s;
        }
    }
}
