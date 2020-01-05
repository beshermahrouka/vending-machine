using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_machine
{
    class Program
    {
        private static int ValidateInsertedAmount(int insertedAmount)
        {
            int[] y = new int[5] { 1, 5, 10, 20, 100 };
            bool IsAcceptableCurrency = false;
            while (!IsAcceptableCurrency)
            {
                for (int i = 0; i < y.Length; i++)
                {
                    if (insertedAmount == y[i])
                    {
                        IsAcceptableCurrency = true;
                        break;
                    }
                }
                if (IsAcceptableCurrency)
                {
                    return insertedAmount;
                }
                else
                {
                    Console.WriteLine("Vending machine only accept 1,5,10,20,100$, please try again ");
                    string str_insertedAmount = Console.ReadLine();
                    int.TryParse(str_insertedAmount, out insertedAmount);
                }
            }

            return insertedAmount;
        }


        private static void ShowPurchaseOptions(string[] choicesName, string[] choicesNumber)
        {
            Console.WriteLine("what would you like to purchase");
            for (int i = 0; i < choicesName.Length; i++)
            {
                Console.WriteLine(choicesNumber[i] + " " + choicesName[i]);
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("HELLO");
            const int ArrayLength = 4;
            string[] choicesName = new string[ArrayLength] { "sandwish", "drink", "Chocolate", "exit" };
            string[] choicesNumber = new string[ArrayLength] { "1", "2", "3", "0" };
            int[] itemPrice = new int[ArrayLength] { 10, 5, 20, 0 };
            string Choice = "";
            string str_insertedAmount = "";
            int insertedAmount;
            int.TryParse(str_insertedAmount, out insertedAmount);
            int totalAmount = 0;
            const string total_amount_Msg = "your total amount inserted is {0:C}";
            const string change_Msg = "your change is {0:C}";
            const string inserted_amount_Msg = "you have insterted {0:C}";
            const string invalid_input_Msg = "Invalid Input, Please try again!";
            const string price_msg = "the price is {0:C},please insert the money";
            const string not_enough_money_Msg = "not enough money, please insert the right amount, remain is {0:C}";
            do
            {
                ShowPurchaseOptions(choicesName, choicesNumber);
                Choice = Console.ReadLine();
                bool AcceptedChoice = false;

                while (!AcceptedChoice)
                {
                    for (int i = 0; i < choicesName.Length; i++)
                    {
                        if (Choice == choicesName[i] || Choice == choicesNumber[i])
                        {
                            AcceptedChoice = true;
                            break; // for optimization purpose 
                        }
                    }
                    if (!AcceptedChoice)
                    {
                        Console.WriteLine(invalid_input_Msg);
                        ShowPurchaseOptions(choicesName, choicesNumber);
                        Choice = Console.ReadLine();
                    }
                }
                for (int i = 0; i < choicesName.Length; i++)
                {
                    //Below is the Exit Condition
                    if (Choice == choicesName[3] || Choice == choicesNumber[3])
                    {
                        break;
                    }
                    //Below is the logic for....
                    if (Choice == choicesName[i] || Choice == choicesNumber[i])
                    {
                        Console.WriteLine(price_msg, itemPrice[i]);
                        str_insertedAmount = Console.ReadLine();
                        int.TryParse(str_insertedAmount, out insertedAmount);
                        insertedAmount = ValidateInsertedAmount(insertedAmount);
                        totalAmount = insertedAmount;
                        Console.WriteLine(inserted_amount_Msg, insertedAmount);
                        if (insertedAmount >= itemPrice[i])
                        {
                            Console.WriteLine(total_amount_Msg, totalAmount);
                            Console.WriteLine(change_Msg, (totalAmount - itemPrice[i]));
                        }
                        while (insertedAmount < itemPrice[i])
                        {
                            int remain = (itemPrice[i] - totalAmount);
                            Console.WriteLine(not_enough_money_Msg, remain);
                            Console.WriteLine(total_amount_Msg, totalAmount);
                            str_insertedAmount = Console.ReadLine();
                            int.TryParse(str_insertedAmount, out insertedAmount);
                            insertedAmount = ValidateInsertedAmount(insertedAmount);
                            totalAmount += insertedAmount;
                            if (totalAmount >= itemPrice[i])
                            {
                                Console.WriteLine(total_amount_Msg, totalAmount);
                                Console.WriteLine(change_Msg, (totalAmount - itemPrice[i]));
                                break;
                            }
                        }
                        break;
                    }
                }
            } while (Choice != "exit" && Choice != "0");
        }
    }
}








