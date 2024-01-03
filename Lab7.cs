public static class Lab7
{
    public static void Main()
    {
        string[] dataArray = new string[10] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
        int n = 0;

        // Fill the array
        Fill(dataArray, ref n);

        // Display the array contents
        Dump(dataArray, n);

        ReverseDump(dataArray, n);

        string locateName = "Fred";
        int found = FindName(locateName, dataArray, n);
        if (found >= 0)
            Console.WriteLine("{0} was found in the array", locateName);
        else
            Console.WriteLine("{0} does not exist in the array", locateName);

        // Pause until user is done
        Console.ReadLine();
    }

    // Method:       Fill
    // Description:  Fill an array with values.
    // Parameters:   arrValues: the array to fill.
    //               num: number of elements in the array.
    // Returns:      void
    public static void Fill(string[] arrValues, ref int num)
    {
        // input the number of data values to put in the array
        do
        {
            Console.Write("Enter the number of elements (between 0 and 10) => ");
            num = Convert.ToInt32(Console.ReadLine());
        } while (num < 0 || num > 10);

        // loop to enter the values, using the loop counter (i)
        // to access consecutive positions in the array
        for (int i = 0; i < num; ++i)
        {
            Console.Write("Enter name {0} => ", i);
            arrValues[i] = Console.ReadLine();
        }
    }

    // Method:       Dump
    // Description:  Display the contents of an array.
    // Parameters:   arrVals: array to be displayed.
    //               num: number of elements in the array.
    // Returns:      void
    public static void Dump(string[] arrVals, int num)
    {
        // output the values from the array
        Console.WriteLine("\nThe elements in the array are:");
        for (int i = 0; i < num; ++i)
            Console.WriteLine(" {0}", arrVals[i]);
    }


    public static void ReverseDump(string[] arrItems, int num)
    {
        Console.WriteLine("\nThe elements in the array are:");
        for (int i = num - 1; i >= 0; --i)
            Console.WriteLine(" {0}", arrItems[i]);
    }


    public static int FindName(string name, string[] arrItems, int num)
    {
        int found = -1;
        //for (int i = 0; i < num; ++i)
        //{
        //    if (arrItems[i] == name)
        //         found =i ;
        //}
        //return found;
        int i = 0;
        while ( i < num)
        {
            if (arrItems[i] == name)
                found = i;
            i++;
        }
        return found;
    }

}