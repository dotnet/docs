using System;
using System.Threading.Tasks;

public class Account
{
    private readonly object balanceLock = new object();
    private decimal balance;

    public Account(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public decimal Debit(decimal amount)
    {
        lock (balanceLock)
        {
            if (balance >= amount)
            {
                Console.WriteLine($"Balance before debit :{balance, 5}");
                Console.WriteLine($"Amount to remove     :{amount, 5}");
                balance = balance - amount;
                Console.WriteLine($"Balance after debit  :{balance, 5}");
                return amount;
            }
            else
            {
                return 0;
            }
        }
    }

    public void Credit(decimal amount)
    {
        lock (balanceLock)
        {
            Console.WriteLine($"Balance before credit:{balance, 5}");
            Console.WriteLine($"Amount to add        :{amount, 5}");
            balance = balance + amount;
            Console.WriteLine($"Balance after credit :{balance, 5}");
        }
    }
}

class AccountTest
{
    static void Main()
    {
        var account = new Account(1000);
        var tasks = new Task[100];
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(() => RandomlyUpdate(account));
        }
        Task.WaitAll(tasks);
    }

    static void RandomlyUpdate(Account account)
    {
        var rnd = new Random();
        for (int i = 0; i < 10; i++)
        {
            var amount = rnd.Next(1, 100);
            bool doCredit = rnd.NextDouble() < 0.5;
            if (doCredit)
            {
                account.Credit(amount);
            }
            else
            {
                account.Debit(amount);
            }
        }
    }
}