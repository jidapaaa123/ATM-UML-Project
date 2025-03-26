using System;
using Logic;
using static Logic.ATM;


public class Program
{
    public static void Main()
    {

        var initialCards = new Dictionary<string, (int pin, BankAccount accoutn)>
          {

              {"123456", (1234, new BankAccount())},
              {"654321", (4321, new BankAccount())}
          };

        var bankServer = new BankServer(initialCards);

        var atm = new ATM(bankServer);

        while (true)
        {

            ATMAction action = atm.GetNextAction();


            switch (action)
            {

                case ATMAction.InsertCard:
                    HandleInsertCard(atm, bankServer);
                    break;
                case ATMAction.EnterPIN:
                    HandleEnterPIN(atm);
                    break;
                case ATMAction.DisplayOptions:
                    HandleDisplayOptions(atm);
                    break;
                default:
                    Console.WriteLine("bye bye ATM system... ");
                    return;
            }


        }

        static void HandleInsertCard(ATM atm, BankServer? bankServer)
        {
            Console.Write("Please insert your card: ");
            string cardNumber = Console.ReadLine();
            // atm.insertCard(cardNumber);
            if (bankServer.verifyCard(cardNumber))
            {
                atm.insertCard(cardNumber);
                Console.WriteLine("Card inserted successfully.");
                return;
            }
            else
            {
                Console.WriteLine("Invalid card number. Please try again.");
            }

        }

        /*  static void HandleEnterPIN(ATM atm)
       {
           if (atm.enterPin()) { Console.WriteLine("PIN invalid"); }

           else { Console.WriteLine("YOU failed! try 1234 "); }

       }*/
        static void HandleEnterPIN(ATM atm)
        {
            atm.enterPin();

            static void HandleEnterPIN(ATM atm)
            {
                atm.enterPin();
                if (atm.pinValidated)
                {
                    Console.WriteLine("PIN validated successfully.");
                    return;
                }
            }
        }

        static void HandleDisplayOptions(ATM atm)
        {
            Console.WriteLine("1. Withdraw cash");
            Console.WriteLine("2. Check balance");
            Console.WriteLine("3. Eject card");
            Console.Write("Please select an option: ");
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 1:
                        atm.requestAmount();
                        break;
                    case 2:
                        atm.checkBalance();
                        break;
                    case 3:
                        atm.ejectCard();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }
}
