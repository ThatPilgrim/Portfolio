// Name: Emmanuel Ekpo
// Student Number: xxxxxxx
// Lab 4 Part 2
// Program Description: This program uses a loop and if statement to input marks
//    between 0 and 100) from a user, determines if the mark is pass or fail
//    and outputs the percentage of passing and failing marks. The user then
//    terminates the program by entering a negative value for a mark.

using System;
public static class Lab4_2
{
    public static void Main()
    {
        const int PASS = 50;
        int numPass = 0, numFail = 0, totalMarks = 0;
        double mark; 
        // loop to read in a valid mark or the sentinel value
        do
        {
            // Read initial mark (seed the loop)
            Console.Write("Enter a mark between 0 and 100 (-ve value to stop): ");
            mark = Convert.ToDouble(Console.ReadLine());
        } while (mark > 100);
        // if the inputted mark is not the sentinel value, process it

        while (mark >= 0)
        {

            // increment the counter for the total number of data values
            totalMarks++;

            // Determine if the mark is a pass or fail (If statement)
            if (mark >= PASS)
                numPass++;
            else if (mark < PASS)
                numFail++;


            // Read next mark
            Console.Write("Enter a mark between 0 and 100 (-ve value to stop): ");
            mark = Convert.ToDouble(Console.ReadLine());


        }

        // Calculate the percentage of marks that were passes and fails
        double perPass = ((double)numPass / totalMarks) ;
        double perFail = ((double)numFail / totalMarks) ;


        // Print results

        Console.WriteLine("Total number of marks = {0}", totalMarks);
        Console.WriteLine("Percentage of passing marks = {0:P1}", perPass);
        Console.WriteLine("Percentage of failing marks = {0:P1}", perFail);
        Console.ReadLine();
    }
}