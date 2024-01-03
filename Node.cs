using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

public class Program
{


    public class MyString
    {
        private class Node
        {
            public char item { get; set; }
            public Node next { get; set; }

            // Constructor (2 marks)
            public Node(char Item, Node Next)
            {
                item = Item;
                next = null;
            }
            public Node()
            {
                next = null;
            }
        }
        private Node? front; // Reference to the first (header) node

        private int length; // Number of characters in MyString


        // Initialize with a header node an instance of MyString to the given character array A (4 marks)
        public MyString(char[] A)
        {
            Node temp = front = new Node();
            for (int i = 0; i < A.Length; i++)
            {
                temp.next = new Node(A[i], temp.next);
                temp = temp.next;
                length++;
            }

        }

        // Using a stack, reverse this instance of MyString (6 marks)
        public void Reverse(char[] A)
        {
            Stack<char> S;
            S = new Stack<char>();
            Node node = front.next;


            for (int i = 0; i < A.Length; i++)
            {
                S.Push(node.item);
                node = node.next;
            }
            node = front.next;

            for (int i = 0; i < A.Length; i++)
            {

                node.item = S.Pop();
                node = node.next;

            }
        }

        // Return the index of the first occurrence of c in this instance; otherwise -1 (4 marks)
        public int IndexOf(char c)
        {
            Node newnode = front = new Node();
            int counter = 0;
            while (newnode != null)
            {
                if (newnode.item == c)
                {
                    return counter;
                }
                else
                {
                    newnode = newnode.next;
                    counter++;
                }
            }
            return -1;
            //while loop then if statement
        }


        // Remove all occurrences of c from this instance (4 marks)
        public void Remove(char c)
        {
            while (front != null && front.item == c)
            {
                front = front.next;
                length--;
            }
            if (front == null)
            {
                return;
            }

            Node node = front;
            while (node.next != null)
                if (node.next.item == c)
                {
                    node.next = node.next.next;
                    length--;
                }
                else
                {
                    node = node.next;
                }
        }

        // Return true if obj is both of type MyString and the same as this instance;
        // otherwise false (6 marks)
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            else return false;
        }

        // Print out this instance of MyString (3 marks)
        public void Print()
        {
            Node node = front;
            while (node != null)
            {
               Console.Write(node.item + " ");
               node = node.next;

            }
            Console.WriteLine();
        }

    }
    public static void Main()
    {
        //Declaration of variable
        String string1;
        char wordcode = ' ';

        // Writes the instruction 
        Console.WriteLine("Instructions are below");
        Console.WriteLine("‘e’ or ‘E’ to check if the first string and a new one is the same");
        Console.WriteLine("‘i’ or ‘I’ to get the index of a particular character in the string");
        Console.WriteLine("‘x’ or ‘X’ to remove every occurence of that particular string");
        Console.WriteLine("‘t’ or ‘T’ to reverse the string you inputted");
        Console.WriteLine("Or ‘q’ or ‘Q’ to quit");
        Console.WriteLine();
        
        Console.Write("Input a string => ");
        string1 = Console.ReadLine(); // String1 is created and it stores the first variable input from the user
       
        //Inputing the character code and verifying it
        do
        {
            switch (char.ToUpper(wordcode))
            {
                case 'E':
                    Equals(string1);
                    break;
                case 'I':
                    indexOf(string1);
                    break;
                case 'X':
                    Remove(string1);
                    break;
                case 'T':
                    Reverse(string1);
                    break;
            }
            Console.Write("Please enter one of the following instructions above-->"); //ask the user for character code input
            wordcode = Convert.ToChar(Console.ReadLine());
        } while (char.ToUpper(wordcode) != 'Q');

        // Uses the Q character to end the code
         if (char.ToUpper(wordcode) == 'Q')
                Console.WriteLine("Bye bye!");

        //Test for Equals method 
        static void Equals(string string1)
         { 
            Console.Write("Input a second string => ");
           String string2 = Console.ReadLine(); // String2 is created and it stores the second variable input from the user
            bool Boolean = string1.Equals(string2); //Boolean value is created to store the result from the Equals method call
            if (Boolean == true)
                Console.WriteLine("The 2 strings are equal");
            else
                Console.WriteLine("The strings aren't equal"); //if statement to print out the result from the equals method 
        }



        //Test for reverse
        static void Reverse(string string1)
        {
            char[] array = string1.ToCharArray(); // An array is created to store the string input from the user
            MyString word = new MyString(array);  // A MyString type  is created to store the array
            word.Reverse(array);            
            Console.WriteLine("The new string is:");
            word.Print();  // The new string is printed out
        }

        //Test for indexOf
        static void indexOf( string string1)
        {
            Console.Write("What character do you want to get the index of from your string?>>");
            char c = Convert.ToChar(Console.ReadLine()); // A character c is created and stores the user input
            int index = string1.IndexOf(c);
            if (index != -1)
                Console.WriteLine("The index of the character is " + index);
            else
                Console.WriteLine("There is no index for that character"); //if statement is used print out a statement depending on the index
        }


         //Test for Remove
         static void Remove(string string1)
        {
            char[] ch = string1.ToCharArray(); // A character array is created to store string
            MyString Newstring = new MyString(ch);
            Console.Write("Input the character you want to remove from the first string>>"); // Asks the user for the character to be removed
            char d = Convert.ToChar(Console.ReadLine());
            Newstring.Remove(d);
            Console.WriteLine("The new string is:");
            Newstring.Print(); // The new string is printed
        }
    }

}
