namespace DotNetSuperBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Kendra", 10000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");

            account.MakeWithdrawal(120, DateTime.Now, "hammock");
            

            account.MakeWithdrawal(50, DateTime.Now, "xbox game");
            

            Console.WriteLine(account.GetAccountHistory());












           // // test for a negative balance
           // try
           // {
           //     account.MakeWithdrawal(75000, DateTime.Now, "attempt to overdraw");
           // }
           // catch (InvalidOperationException e)
           // {
           //     Console.WriteLine("Exception caught trying to overdraw");
           //     Console.WriteLine(e.ToString());
           // }

           //// test that the initial balances must be positive
           // try
           // {
           //     var invalidAccount = new BankAccount("invalid", -55);
           // }
           // catch (ArgumentOutOfRangeException e)
           // {
           //     Console.WriteLine("Exception caught creating account with negative balance");
           //     Console.WriteLine(e.ToString());
           // }



        }
    }
}