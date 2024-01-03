// Name:Ekpo Emmanuel
//Student Number: 0725487
// Assignment 4
// Program Description: 

// Data Dictionary
/* The program uses an array to store the seat numbers of an airplane and the names of the people
 * who booked those seats. You can book a seat, cancel your booking, check the current seat 
 * numbers and those who have booked the seats and check for the available seat numbers.*/

public static class ReservationSystem
{
    public static void Main()
    {
        // Declaration of variables
        string[] seatAssign = new string[12];
        string cName ;
        char bookingCode = ' ';
        

        // Writes the instruction and guidelines
        Console.WriteLine("Welcome to Air Canada!");
        Console.WriteLine("The instructions for seat reservations are as follows");
        Console.WriteLine("‘b’ or ‘B’ to book a seat");
        Console.WriteLine("‘c’ or ‘C’ to cancel a seat ");
        Console.WriteLine("‘p’ or ‘P’ to print the seating assignments");
        Console.WriteLine("‘l’ or ‘L’ to print the available lists of seats");
        Console.WriteLine("Or ‘q’ or ‘Q’ to quit");
        Console.WriteLine();
        //Inputing the booking code and validating it
        do
        {
            switch (char.ToUpper(bookingCode))
             {
                 case 'P':
                   PrintSeatReservations(seatAssign);
                     break;
                 case 'B':
                    Booking(seatAssign);
                     break;
                 case 'C':
                    Cancel(seatAssign);
                     break;
                 case 'L':
                    PrintAvailableSeatNums(seatAssign);
                    break;
             }
             Console.Write("Please enter one of the following above-->");
             bookingCode = Convert.ToChar(Console.ReadLine());
         } while (char.ToUpper(bookingCode) != 'Q');
        // thanks the user for using the Air Canada
        if (char.ToUpper(bookingCode) == 'Q')
            Console.WriteLine("Thank you for using Air Canada!");
     }
    // Method:       FindEmptySeat
    // Description:  Searches the contents of the array
    // Parameters:   found: boolean valuue for if a null value has been found
    //               availableSeat: the position of the available value in the array
    // Returns:      the position of the first null value in the array
    public static int FindEmptySeat(string[] seatAssign)
     {
        bool found = false;
        int availableSeat = -1;
         for (int i = 0;(i < seatAssign.Length && !found); ++i)
           if ( seatAssign[i] == null)
           {
           found = true;
             availableSeat = i;
           }
         return availableSeat;
     }
    // Method:       FindCustomerSeat
    // Description:  Search the array for the position of the name in the array
    // Parameters:   cName: The name that is being searched for in the array
    //               found: boolean valuue for if the name has been found
    //               position: the positionof the name in the array
    // Returns:      the position of the name in the array
    public static int FindCustomerSeat(string[] seatAssign, string cName)
     {
        int position = -1;
         bool found = false;
        for (int i = 0; (i < seatAssign.Length && !found); i++)
        {
            if (cName == seatAssign[i])
            {
                position = i;
                found = true;
            }
        }
            return position;        
     }
    // Method:       Booking
    // Description:  Used to book a seat in the plane
    // Parameters:   custName: The name of the person booking a seat
    //               seatPos: The position of the name in the array
    // Returns:      void
    public static void Booking(string[] seatAssign)
     {
        int seatPos; 
        string custName;
        // user input's their name
       Console.Write("Please enter your name => ");
        custName = Convert.ToString(Console.ReadLine());
        //searches for the user's name in the array
        seatPos = FindCustomerSeat(seatAssign, custName);
        if (seatPos == -1)
            Console.WriteLine("YOU ARE CURRENTLY NOT BOOKED ON THIS FLIGHT.");
        else 
            Console.WriteLine("YOUR SEAT NUMBER IS {0}.", seatPos);
        // assign a seat number to the user or prints that there are no available seats
        if (seatPos == -1)
        {
            seatPos = FindEmptySeat(seatAssign);
            if (seatPos > -1)
            {
                seatAssign[seatPos] = custName;
                Console.WriteLine("{0}, we have assigned you to seat number {1}", custName, seatPos);
            }
            else if (seatPos == -1)
                Console.WriteLine("Currently there are no available seats. The plane is full.");
        }  
    }
    // Method:       Cancel
    // Description:  Cancels a booking
    // Parameters:   pos: position of the name in the array
    //               custName: The name of the person booking a seat
    // Returns:      void
    public static void Cancel(string[] seatAssign)
    {   //declare variables
        string custName;
        int pos;
        // user inputs a new variable
        Console.Write("Please enter your name => ");
        //cancels the seat booking
        custName = Convert.ToString(Console.ReadLine());
        pos = FindCustomerSeat(seatAssign, custName);
        if (pos == -1)
        {
            Console.WriteLine("{0}, currently you do not have a seat.", custName);
            Console.WriteLine();
        }
        else if (seatAssign[pos] == custName)
            seatAssign[pos] = null;
        Console.WriteLine("Your seat has been cancelled");
        Console.WriteLine();
    }
    // Method:       PrintSeatReservation
    // Description:  Prints the current people who have booked a seat and their seat number
    // Parameters:   i: the position of the item in the array
    // Returns:      void
    public static void PrintSeatReservations(string[] seatAssign)
    {
          int i = 0;
        for ( i = 0; i < seatAssign.Length; ++i)
        {
            string custName = seatAssign[i];
            if(seatAssign[i] != null)
            Console.WriteLine("Seat number {0} is booked by {1}", i, custName);
            Console.WriteLine();
        }
    }
    // Method:       PrintAvailableSeatNums
    // Description:  Display the contents of the array 
    // Parameters:   counter: counts the number of seats that have been booked.
    //               counterII: counts the number of seats in the array that are null(empty).
    //                i: the position of the item in the array
    // Returns:      void
    public static void PrintAvailableSeatNums(string[] seatAssign)
    {   // declare variables
        int i=0;
        int counter= 0;
        int counterII = 0;
        // searches the array for empty seats
            for (i = 0; i < seatAssign.Length; ++i)
            
                if (seatAssign[i] == null)
                {
                    Console.WriteLine(" {0}", i);
                    counterII++;
                }
        // prints out available seats
        if (counterII == 12)
        {
            Console.WriteLine("These are the remaining available seat numbers");
            Console.WriteLine();
        }
        // searches the array for seats that have been taken
                for (i = 0; i < seatAssign.Length; ++i)
                    if (seatAssign[i] != null)
                    {
                       ++counter;
                    }
        // prints that all the seats are taken
        if (counter == 12)
            Console.WriteLine("There are no avaiable seats. The plane is currently full.");
        Console.WriteLine();
    }
}
