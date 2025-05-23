﻿namespace Logic;

public class BankServer
{
    private Dictionary<string, (int pin, BankAccount account)> validCards = new();


    public BankServer(Dictionary<string, (int, BankAccount)> initialCards)
    {
        validCards = initialCards;
    }

    public bool verifyCard(string cardNumber)
    {
        return validCards.ContainsKey(cardNumber);
    }

    public bool verifyPIN(string cardNumber, int pin)
    {
        return verifyCard(cardNumber) && validCards[cardNumber].pin == pin;
    }

    public bool processTransaction(string cardNumber, double amount)
    {
        BankAccount account = validCards[cardNumber].account;

        if (account.hasSufficientFunds(amount))
        {
            account.withdraw(amount);
            return true;
        }
        else
        {
            return false;
        }
    }

    public double checkBalance(string cardNumber)
    {
        return validCards[cardNumber].account.getBalance();
    }
}




