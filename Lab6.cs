// Name: Ekpo Emmanuel
// Student Number: xxxxxxx
// Lab 6
// Program Description: This program uses two user defined methods to compute
//    the gross pay and net pay for an employee after entering the employee’s
//    last name, hours worked, hourly rate, and percentage of tax.

using System;
public static class Lab6
{
    public static void Main()
    {
        // declare variables
        int hrsWrked;
        double ratePay, taxRate, grossPay, netPay = 0, OTPay;
        string lastName;

        // enter the employee's last name
        Console.Write("Enter the last name of the employee => ");
        lastName = Console.ReadLine();

        // enter (and validate) the number of hours worked (positive number)
        do
        {
            Console.Write("Enter the number of hours worked (> 0) => ");
            hrsWrked = Convert.ToInt32(Console.ReadLine());
        } while (hrsWrked < 0);

        // enter (and validate) the hourly rate of pay (positive number)
        do
        {
            Console.Write("Enter the rate of pay (> 0) =>");
            ratePay = Convert.ToDouble(Console.ReadLine());
        }
        while (ratePay < 0);

        // enter (and validate) the percentage of tax (between 0 and 1)
        do
        {
            Console.Write("Enter percentage tax between 0 and 1=>");
            taxRate = Convert.ToDouble(Console.ReadLine());
        }
        while (taxRate <= 0 || taxRate >= 1);

       

        // Call a method to calculate the gross pay (call by value)
        grossPay = CalculateGross(hrsWrked, ratePay);

        // Invoke a method to calculate the overtime pay (call by value)
       OTPay =  CalculateOT( hrsWrked,  ratePay );

        grossPay += OTPay;

        // Invoke a method to calculate the net pay (call by reference)
        CalculateNet(grossPay, taxRate, ref netPay);

        // print out the results
        Console.WriteLine("{0} worked {1} hours at {2:C} per hour", lastName,
                          hrsWrked, ratePay);
        Console.WriteLine(" Your grosspay is {0:C} while your net pay is {1:C}", grossPay,netPay);
        Console.ReadLine();
    }

    // Method: CalculateGross
    // Parameters
    //      hours: integer storing the number of hours of work
    //      rate: double storing the hourly rate
    // Returns: double storing the computed gross pay
    public static double CalculateGross(int hours, double rate)
    {
        double  calculatedGrossPay = hours * rate;
        return calculatedGrossPay;
    }

    // Method: CalculateNet
    // Parameters
    //      grossP: double storing the grossPay
    //      tax: double storing tax percentage to be removed from gross pay
    //      netP: call by reference double storing the computed net pay
    // Returns: void
    public static void CalculateNet(double grossP, double tax, ref double netP)
    {
        netP = grossP - tax * grossP;
        
    }

    // Method: CalclulateOT
    // Parameters
    //       hours: integer storing the number of hours worked
    //       rate: double storing the hourly rate
    public static double CalculateOT(int hours, double rate)
    {
        double OtPAY ;
        if (hours > 40)
            OtPAY = (hours - 40) * rate * 0.5;
        else OtPAY = 0;

        
        return OtPAY ;
        

    }

}

