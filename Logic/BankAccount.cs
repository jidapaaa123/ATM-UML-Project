public class BankAccount
{
    private double balance;

    public bool hasSufficientFunds(double amount)
    {
        if(amount <= balance){
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool withdraw(double amount)
    {
        balance -= amount;
        if (balance > 0)
        {
            return true;
        }else
        {
            return false;
        }
    }

    public double getBalance()
    {
        return balance;
    }
}