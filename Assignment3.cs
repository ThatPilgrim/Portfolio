// Name:Ekpo Emmanuel
//Student Number: 0725487
// Assignment 3
// Program Description: This program manages a credit card debt. You input the transaction
// code then the amount of money you need to remove from the card. It validates the amount
// and does the neccessary calculations needed. The user can also check their credit card 
// balance.

// Data Dictionary
// ccBalance - the credit card balance
// transactCode - the transaction code
// itemAmt - The price of the item you want to buy
// cashAmt - Amount of cash withdrawn
// payAmt - credit card payment amount



public static class Creditcard
{
    public static void Main()
    {
        // Declaration of variables
        double ccBalance = 0.00;
        char transactCode = ' ';
        double itemAmt = 0;
        double payAmt = 0;
        double cashAmt = 0;
        
        // Writes the instruction and guidelines
        Console.WriteLine("Welcome!");
        Console.WriteLine("The instructions are as follows");
        Console.WriteLine("‘B’ or ‘b’ to buy an item using the credit card");
        Console.WriteLine("‘c’ or ‘C’ to make a cash withdrawal");
        Console.WriteLine("‘p’ or ‘P’ to make a payment on the credit card");
        Console.WriteLine("‘D’ or ‘d’ to display the credit card balance");
        Console.WriteLine("Or ‘q’ or ‘Q’ to quit");
        Console.WriteLine("Press Enter to proceed");
        Console.ReadLine();

        // Input the transaction code of your choice
        Console.Write("Please enter one of the following above-->");
                transactCode  = Convert.ToChar(Console.ReadLine());

        // validate transaction code and invokes the neccesary method
        //while (char.ToUpper(transactCode) != 'Q')
       // {
            do
            {

                switch (char.ToUpper(transactCode))
                {
                    case 'P':
                          payAmt = ReadAmount();
                        MakePayment(payAmt, ref  ccBalance); 
                        break;
                    case 'B':                      
                            itemAmt = ReadAmount();                        
                        BuyAnItem(itemAmt, ref ccBalance);
                        break;
                    case 'C':
                            cashAmt = ReadAmount();
                        CashWithdrawal(cashAmt, ref ccBalance);
                        break;
                    case 'D':
                        Display(ccBalance);
                        break;
                    //default:
                       // Console.WriteLine("Invalid code");
                     //   break;
                }
                Console.Write("Please enter one of the following above-->");
                transactCode = Convert.ToChar(Console.ReadLine());
            } while (char.ToUpper(transactCode) != 'Q');


      //  }


    }

    // Method: ReadAmount
    // Variable:
    //amount - the amount the user entered
    public static double ReadAmount()
    {
        // Declaration of variables   
        double amount = 0.0;

        // Validate the amount entered
            do
            {
                Console.Write("Enter the amount => ");
                amount = Convert.ToDouble(Console.ReadLine());
            } while (amount <= 0);
            
       //Returns the value inputed
        return amount;
    }



    // Method: BuyAnItem
    // Variables:
    // hST - constant HST that's applied to totalItemPrice
    // totalItemPrice - the amount of the purchase after applying hST
    // cardLimit - the max amountof credit the card allows
    // itemAmt - the amount of the purchase excluding hST
    // ccBalance - The credit card balance
    public static void BuyAnItem(double itemAmt, ref double ccBalance)
    {
        // Declaration of variables
        const double hST = 0.13;
        double totalItemPrice = 0;
        const int cardLimit = 2000;
         totalItemPrice = itemAmt *(1.0 * hST) + itemAmt ;

        // Validate if purchase is over credit limit
        if (totalItemPrice > cardLimit)
        {
            Console.WriteLine("PURCHASE OVER CREDIT LIMIT");
        }
        else if (totalItemPrice < cardLimit)
        {
            ccBalance = ccBalance - totalItemPrice  ;
        }

    }


    // Method: CashWithdrawal
    // Variables:
    // serviceCharge - constant amount added to withdrawal amount
    //cashAmt - the initial withdrawal amount
    // cardLimit - the max amount of credit the card allows
    // ccBalance - The credit card balance
    public static void CashWithdrawal(double cashAmt, ref double ccBalance)
    {
        // Declaration of variables
        const double serviceCharge = 3.50;
        cashAmt = cashAmt + serviceCharge;
        const int cardLimit = 2000;

        // Validate if withdrawal amount is over credit limit
        if (cashAmt > cardLimit)
        {
            Console.WriteLine("AMOUNT OVER CREDIT LIMIT");
        }
        else if (cashAmt < cardLimit)
        {
            ccBalance = ccBalance - cashAmt;
        }

    }

     
    // Method: MakePayment
    // Variables:
    // payAmt - the amount of payment made on the credit card
    // ccBalance - The credit card balance
    public static void MakePayment(double payAmt, ref double ccBalance)
    {
        // Calculate the credit card balance
        ccBalance = ccBalance - payAmt;
    }

    // Method: Display
    // Variables: 
    // ccBalance - The credit card balance
    public static void Display(double ccBalance)
      {
        // Display the credit card balance
        Console.WriteLine("Your current credit card balance is {0}",ccBalance);
        
      }

}








