

public class FileSystem
{
    private class Node
    {
        public string directory;
        public List<string> file;
        public Node leftMostChild;
        public Node rightSibling;
        //public Node leftSibling; // new property is created to store the previous sibling
        public Node( string Directory = "", Node Leftmostchild = null, Node Rightsibling = null )
        {
            directory = Directory;
            file = new List<string>(); 
            leftMostChild = Leftmostchild;
            rightSibling = Rightsibling;
  

        }
    }
    private Node root;
    // Creates a file system with a root directory where the name of the root directory is “/”.
    public FileSystem() 
    {
        root = new Node();
        root.directory = "/";
    }
    // Adds a file at the given address
    // Returns false if the file already exists at that address or the path is undefined; true otherwise
    public bool AddFile(string address)
    { 
        Node curr = new Node();
        curr = root;
        string[] addressStorage = address.Split('/');
        int I = 0; // counter for the number of times we loop through the for loop
    

        for (I = 1; I <= addressStorage.Count() - 2; I++)// loop through the file system
        {
           
            curr = curr.leftMostChild; //curr moves ot the lower directory level
            while (curr != null && curr.directory != (addressStorage[I]))// Check if the directories are equal
            {
              
                curr = curr.rightSibling; // Curr moves ot the next right sibling
            }
            
            if (curr == null) // if the address is not in the file system
            {
                Console.WriteLine("Path undefined");
                return false;
            }

        }

            if (curr.file.Contains(addressStorage[I])) // check the current list of files to see if it already exists
        {
            Console.WriteLine("File already exists"); // Use the list built in function
            return false;
        }
        else
            curr.file.Add(addressStorage[I]); // add the file
          return true;              
                    
    }
    // Removes the file at the given address
    // Returns false if the file is not found at that address or the path is undefined; true otherwise
    public bool RemoveFile(string address) 
    {
        Node curr = new Node();
        curr = root;
        string[] addressStorage = address.Split('/');  // splits the string
        int I = 0; // counter for the number of times we loop through the for loop


        for (I = 1; I <= addressStorage.Count() - 2; I++)// loop through the file system
        {

            curr = curr.leftMostChild;
            while (curr != null && curr.directory != (addressStorage[I]))// Check if the directories are equal
            {

                curr = curr.rightSibling; // Curr moves ot the next right sibling
            }

            if (curr == null)
            {
                Console.WriteLine("Path undefined");
                return false;
            }

        }

        if (curr.file.Contains(addressStorage[I])) // check the current list of files to see if it exists
        {
            curr.file.Remove(addressStorage[I]);    //remove the file at that position
            return true;
        }
        else
        {
            Console.WriteLine("File is not in this directory address"); 
            return false;
        }
    }
    // Adds a directory at the given address
    // Returns false if the directory already exists or the path is undefined; true otherwise
    public bool AddDirectory(string address)
    {
        Node curr = root;
        Node prev = root;
        string[] addressStorage = address.Split('/');
        int I = 0; // counter for the number of times we loop through the for loop


        for (I = 1; I <= addressStorage.Count() - 2; I++)// loop through the file system
        {
            prev = curr.leftMostChild; 
            curr = curr.leftMostChild;
            while (curr != null && curr.directory != (addressStorage[I]))// Check if the directories are equal
            {

                curr = curr.rightSibling; // Curr moves ot the next right sibling
            }

            if (curr == null)  // checks if the directory is not at the current address
            {
                Console.WriteLine("Path undefined");
                return false;
            }
        }

        if (curr.leftMostChild != (null)) // check if the node is null
        {
            prev = curr.leftMostChild;
            curr = curr.leftMostChild;
            while (curr != null && curr.directory != (addressStorage[I]))// Check if the directories are equal
            {

                curr = curr.rightSibling; // Curr moves to the next right sibling
            }

            if (curr == null) // if the directory doesn't exist already
            {
                Node NewNodee = new Node();  // Create a new node at the dierctory                               
                NewNodee.rightSibling = prev.rightSibling; 
                prev.rightSibling = NewNodee;   
                NewNodee.directory = addressStorage[I]; // add the directory name to the new node
                return true;
            }
        }
        else// if (curr.leftMostChild.Equals(null))
        {
            Node NewNode = new Node();
            curr.leftMostChild = NewNode;    // create a new node at the directory
            NewNode.directory = (addressStorage[I]);    //add the directoy at that position
            return true;
        }
        return false;
        
    }
    // Removes the directory (and its subdirectories) at the given address
    // Returns false if the directory is not found or the path is undefined; true otherwise
    public bool RemoveDirectory(string address) 
    {
        Node curr = root; // refers to the current node
        Node prev = root; // refers to the node before current
        Node top = root;  // refers to the node at the directory level above
        string[] addressStorage = address.Split('/');
        int I; // counter for the number of times we loop through the for each loop


        for (I = 1; I <= addressStorage.Count() - 2; I++)// loop through the file system
        {
            top = curr.leftMostChild;
            prev = curr.leftMostChild;
            curr = curr.leftMostChild;
            while (curr != null && curr.directory != (addressStorage[I]))// Check if the directories are equal
            {

                curr = curr.rightSibling; // Curr moves ot the next right sibling
            }

            if (curr == null)  // checks if the directory is not at the current address
            {
                Console.WriteLine("Path undefined");
                return false;
            }
        }
        // I++; // To refer to the last position in the array
        if (!curr.leftMostChild.Equals(null)) // check if the node is null
        {
            top = curr;
            prev = curr.leftMostChild;
            curr = curr.leftMostChild;
            while (curr != null && !curr.directory.Equals(addressStorage[I]))// Check if the directories are equal
            {
                prev = curr; // previous is assigned to current or i can use prev = prev.rightsibling
                curr = curr.rightSibling; // Curr moves ot the next right sibling
               
            }

            if (curr == null) // if the directory doesn't exist 
            {
                Console.WriteLine("Directory not in file system");
                return false;
            }
            else
            {
                if (curr.rightSibling == null && curr == prev)  //if the node is the only on that directory level
                {
                    top.leftMostChild = null;
                }
                else if (curr.rightSibling == null) // if the node is the last on that directory level
                {
                    prev.rightSibling = null;
                }
                else
                {
                    prev.rightSibling = prev.rightSibling.rightSibling; // node with the directory is removed
                    curr.rightSibling = null;
                }
                return true;
            }
        }
        else// if (curr.leftMostChild.Equals(null))
        {
            Console.WriteLine("Directory not in file system");
            return false;
        }
    }
    // Returns the number of files in the file system (Do not add a count as a data member)
    public int NumberFiles() 
    {
        int Num = 0;

            Preorderr(root, ref Num);

        // Private Preorder
        // Recursively implements the preorder traversal

        void Preorderr(Node root, ref int Num)
        {
             Num = Num + root.file.Count; // Add the number of files in the specific node to the number of files counter

            if (root.leftMostChild != null) // Continue the tree traversal
                Preorderr(root.leftMostChild, ref Num);
            else 
            if (root.rightSibling != null)
                Preorderr(root.rightSibling, ref Num);         
        }
        return Num;
    }
    // Prints the directories in a pre-order fashion along with their files
    public void PrintFileSystem() 
    {
        // First preorder method

            Preorderr(root, 0);

        // Recursively implements the preorder traversal

        void Preorderr(Node root, int indent)
        {
            Console.WriteLine(new string (' ',indent)+ "Directory: " + root.directory); // prints out the name of the directory
            Console.WriteLine(new string(' ', indent )+" The files in this directory are: ");
            foreach (string s in root.file)   // loops through the current list of files for this directory and prints them
                    Console.WriteLine(new string (' ', indent) + s); 

            Console.WriteLine();
            if (root.leftMostChild != null )  // Traverses the file system recursively
                Preorderr(root.leftMostChild, indent+5);
            else if (root.rightSibling != null)
                Preorderr(root.rightSibling, indent);
            

        }

    }
}

//----------------------------------------------------------------------------------------------------

class program
{
    static void Main()
    {
        string input = "/A";
        string input2 = "/B";
        string input3 = "/C";
        string input4 = "/B/E";
        string input5= "/B/T";
        string input6 = "/B/G";
        string input7 = "/B/D";
        string input8 = "/B/T/J";
        string input9 = "/B/T/W";
        string input10 = "/B/T/W/Tomisin";

        FileSystem fileSystem = new FileSystem();
        fileSystem.AddDirectory(input);
       fileSystem.AddDirectory(input2);
        fileSystem.AddDirectory(input3);
        fileSystem.AddDirectory(input4);
        fileSystem.AddDirectory(input5);
        fileSystem.AddDirectory(input6);
        fileSystem.AddDirectory(input7);
        fileSystem.AddDirectory(input8);
        fileSystem.AddDirectory(input9);

        fileSystem.AddFile(input10);
        fileSystem.AddFile(input9);
        fileSystem.AddFile(input8);
        fileSystem.AddFile(input7);
        fileSystem.AddFile(input6);
        fileSystem.AddFile(input5);
        fileSystem.AddFile(input4);
        fileSystem.AddFile(input3);
        fileSystem.AddFile(input2); 
        fileSystem.AddFile(input);

        fileSystem.PrintFileSystem();

        // make input for the user. It must start with a /. If it doesn't prompt them to enter one that has it.
        // user cannot delete root.

       // fileSystem.RemoveFile(input);
        // fileSystem.PrintFileSystem();

        Console.WriteLine("The number of files are: " + fileSystem.NumberFiles());
    }
}
