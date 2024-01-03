// Name: Ekpo Emmanuel		// Code File Lab11.cs
// Student Number: 0725487
// Lab 11
// Program Description: This program consists of two classes: a dynamic BankAccount
//    and a static BankAccountDemo (which contains Main()).  The sole purpose of
//    Main() is to test the various properties and methods of BankAccount objects.

using System;
public static class BankAccountDemo
{
    public static void Main()
    {
        int acctNumber;
        double amount;
        BankAccount savings = new BankAccount();
        BankAccount chequing = new BankAccount(12345, 350.45);
        BankAccount newAcct;

        // input a 5 digit account number and balance for savings
        do
        {
            Console.Write("Enter a 5-digit account number => ");
            acctNumber = Convert.ToInt32(Console.ReadLine());
        } while ((acctNumber < 10000) || (acctNumber > 99999));
        savings.AcctNum = acctNumber;

        // print out the account information
        Console.WriteLine("Account {0} contains {1:C2}", savings.AcctNum, savings.Balance);
        Console.WriteLine("Account {0} contains {1:C2}", chequing.AcctNum, chequing.Balance);

        // prompt the user to enter an amount to deposit to savings (be sure to validate)
        do
        {
            Console.Write("Enter the amount you want to deposit =>");
            amount = Convert.ToDouble(Console.ReadLine());
        } while (amount < 0);

        // perform the deposit to savings
        savings.Deposit(amount);

        // print out the savings account information
        Console.WriteLine("The current savings account balance is {0:C}",savings.Balance);

        // prompt the user to enter an amount to withdraw from chequing (be sure to validate)
        //do
       // {
            Console.Write("Enter the amount you want to withdraw =>");
            amount = Convert.ToDouble(Console.ReadLine());
        //} while (amount < 0);

        // perform the withdrawal from chequing
        chequing.Withdrawal(amount);

        // print out the chequing account information
        Console.WriteLine("The current chequings account balance is {0:C}", chequing.Balance);

        // apply the interest to savings
        savings.Interest();

        // print out the savings account information
        Console.WriteLine("The current savings account balance is {0:C}", savings.Balance);

        // combine chequing and savings into newAcct using overloaded operator
        newAcct = savings + chequing;

        // print out the newAcct account information
        Console.WriteLine("Account {0} contains {1:C2}", newAcct.AcctNum, newAcct.Balance);
        Console.ReadLine();
    }
}