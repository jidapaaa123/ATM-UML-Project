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

    public void withdraw(double amount)
    {
        balance -= amount;
    }

    public double getBalance()
    {
        return balance;
    }
}