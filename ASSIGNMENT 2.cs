// Name:Ekpo Emmanuel
//Student Number: 0725487
// Assignment 2
// Program Description: This program accepts a character input from the user then a mark 
// value and uses a do-while statement to validate the mark input. Then it calculates the 
// averageof all the different department codes and outputs the averages.
// 

// Data Dictionary
//  deptCode = The department code.   
//  markVal = the mark the user entered
// numOfMarksForC = the count for the number of marks for computer science
// numOfMarksForB = the count for the number of marks for History
// numOfMarksForP = the count for the number of marks for Physics
// totalForC = the sum of all the marks in computer science
// totalForB = the sum of all the marks in History
// totalForP = the sum of all the marks in Physics
// averageMarkForC = the average of the total marks for Computer Science
// averageMarkForB = the average of the total marks for History
// averageMarkForP = the average of the total marks for Physics




public static class DepartmentCode
{
    public static void Main()
    {
      // Declare the variables
       char deptCode = ' ';
        double markVal = 0;
       double numOfMarksForC = 0;
        double numOfMarksForB = 0;
        double numOfMarksForP = 0;
        double totalForC = 0;
        double totalForB = 0;
        double totalForP = 0;
        double averageMarkForC= 0;
        double averageMarkForB = 0;
        double averageMarkForP = 0;

        // input the department code     
                Console.WriteLine("The department codes are as follows");
                Console.WriteLine("'C' or 'c' for Computer Science, 'B' or 'b' for History and 'P' or 'p' for Physics");
                Console.Write("Input the department code or Q to quit ->");
                

        // computing mark data for each department
        while (char.ToUpper(deptCode) != 'Q')
        {
            do
            {
                Console.Write("Enter a mark between 0 and a 100 => ");
                markVal = Convert.ToDouble(Console.ReadLine());
            }while (markVal <= 0 || markVal >=100 );

            
                if (markVal <= 0 || markVal >= 100)               
                Console.WriteLine("Invalid mark");
              else
              {

                if (char.ToUpper(deptCode) == 'C')
                {
                    numOfMarksForC++;
                    totalForC = markVal + totalForC;
                }
                else if (char.ToUpper(deptCode) == 'B')
                {
                    numOfMarksForB++;
                    totalForB = markVal + totalForB;
                }
                else if (char.ToUpper(deptCode) == 'P')
                {
                    numOfMarksForP++;
                    totalForP = markVal + totalForP;
                }
                else
                {
                    Console.WriteLine("Invalid department code");
                }

              }
         // propmpt the user to enter another dept. code or quit
            Console.WriteLine("The department codes are as follows");
                Console.WriteLine(" 'C' or 'c' for Computer Science, 'B' or 'b' for History and 'P' or 'p' for Physics");
                Console.Write("Input the department code or Q to quit ->");
                deptCode = Convert.ToChar(Console.ReadLine());

        }   

        //computing the average for each department and it corresponding output
        if (numOfMarksForC > 0)
        {
            averageMarkForC = totalForC / (1.0 * numOfMarksForC);
            Console.WriteLine("The average for Computer Science is {0:F}", averageMarkForC);
            Console.ReadLine();
        }
        else
            Console.WriteLine("No marks available for Computer Science");

        if (numOfMarksForB > 0)
        {
            averageMarkForB = totalForB / (1.0 * numOfMarksForB);
            Console.WriteLine("The average for History is {0:F}", averageMarkForB);
            Console.ReadLine();
        }
        else
            Console.WriteLine("No marks vailable for History");

        if (numOfMarksForP > 0)
        {
            averageMarkForP = totalForP / (1.0 * numOfMarksForP);
            Console.WriteLine("The average for Physics is {0:F}", averageMarkForP);
            Console.ReadLine();
        }
        else
            Console.WriteLine("No marks available for Physics");











    }






}
