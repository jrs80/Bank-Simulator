using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEncapsulation
{

    public class BankAccount
    {
        private double Balance { get; set; }
        public BankAccount() => Balance = 0;

        public void Deposit(double amt) { Balance += amt; }
        public bool Withdraw(double amt)
        {
            if(amt > Balance) return false;
            Balance -= amt;
            return true;
        }
        public double GetBalance() => Balance;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var acct = new BankAccount();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 5);
            Console.WriteLine("__________________________");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 6);
            Console.WriteLine("|                        |");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 7);
            Console.WriteLine("|  Welcome to the Bank.  |");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 8);
            Console.WriteLine("|________________________|");
            Console.ForegroundColor = ConsoleColor.Green;

            bool exit = false;
            while(!exit) {
                Clear();
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("[D]eposit, [W]ithdraw, [V]iew Balance, or E[x]it?");
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch(key.KeyChar) {
                    case 'd':
                    case 'D':
                            Console.Write("\n\nEnter amount to deposit: $");
                            double dep = 0;
                            if(!double.TryParse(Console.ReadLine(), out dep)) Console.WriteLine("Invalid input.");
                            else {
                                acct.Deposit(dep);
                                Console.WriteLine("\nDeposit confirmed.");
                            }
                            break;
                    case 'w':
                    case 'W':
                            Console.WriteLine("\nEnter amount to withdraw: $");
                            double amt = 0;
                            if(!double.TryParse(Console.ReadLine(), out amt)) Console.WriteLine("Invalid input");
                            else {
                                if(acct.Withdraw(amt)) Console.WriteLine("Withdrawal confirmed.");
                                else Console.WriteLine("Insufficient funds!");
                            }
                            break;
                    case 'v':
                    case 'V': 
                            Console.WriteLine("\nCurrent balance is: $" + acct.GetBalance()); 
                            break;
                    case 'x':
                    case 'X': 
                            exit = true; 
                            break;
                    default: 
                            Console.WriteLine("\nInvalid input.  Please try again."); 
                            break;
                }
                if(!exit) {
                    Console.WriteLine("\nPress any key to return to main menu.");
                    Console.ReadKey();
                }
            }

            Clear();
            Console.WriteLine("\nGoodbye!");
            Console.ReadKey(true);
        }

        static void Clear()
        {
            Console.SetCursorPosition(0, 10);
            for(int i = 0; i < Console.WindowHeight-10; i++) {
                Console.WriteLine("                                                                               ");
                }
            Console.SetCursorPosition(0, 10);
        }
    }
}
        
