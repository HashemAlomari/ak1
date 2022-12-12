using System;

namespace ATM_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int bankCapacity = 10;  //indicate bankcapacity
            Person p1 = new Person();

            string pinCode = "0000";   // ppincode of 4 digits
            string cardNumber = "098712345";
            int accountBalance = 250;   // initinal balance
            BankAccount tmpAccount = new BankAccount(p1, "hashemjaser@test.com", cardNumber, pinCode, accountBalance);


            Bank testBank = new Bank(bankCapacity);

            testBank.AddNewAccount(tmpAccount);

            testBank.Save();

            Bank newTestBank = new Bank();
            newTestBank.Load();
        }
    }
}
