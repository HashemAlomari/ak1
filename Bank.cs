using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ATM_Assignment
{
    public class Bank
    {
        private int bankCapacity; private BankAccount[] ar;

        private int counter = 0;
        public Bank(int bankCapacity)
        {
            if (bankCapacity <= 0)
            {
                bankCapacity = 10;
            }
            ar = new BankAccount[bankCapacity];
            this.bankCapacity = bankCapacity;
        }





        public Bank()      // construer
        {
            bankCapacity = 10;
            ar = new BankAccount[bankCapacity];
        }

        public int NumberOfCustomers { get
            {
                return counter;  // return num of coustmer
            }
        }

        public void AddNewAccount(BankAccount tmpAccount)
        {
            ar[counter] = tmpAccount;
            counter++;
           
        }

        public bool IsBankUser(string cardNumber, string pinCode)
        {

            for (int i = 0; i < counter; i++)
            {
                if (ar[i].is_correct(cardNumber, pinCode))
                {
                    return true;
                }
            }
            return false;
        }

        public int CheckBalance(string cardNumber, string pinCode)
        {
            for (int i = 0; i < counter; i++)
            {
                if (ar[i].is_correct(cardNumber, pinCode))
                {
                    return ar[i].AccountBalance;
                }
            }
            return 0;
        }

        public void Withdraw(BankAccount tmpAccount, int withdrawAmount)
        {
            bool k = false;
           for(int i=0;i<counter;i++)
            {
                if (ar[i].is_correct(tmpAccount.CardNumber, tmpAccount.PinCode))
                {
                    k = true;
                    if (withdrawAmount <= ar[i].AccountBalance)
                    {
                        ar[i].AccountBalance -= withdrawAmount;
                      
                        break;
                    }
                    else
                    {
                        Console.WriteLine("withdrawAmount > AccountBalance");

                        break;
                    }
                }
            }
            if (!k)
            {
                Console.WriteLine("BankAccount not found");
            }
        }

        public void Deposit(BankAccount tmpAccount, int withdrawAmount)
        {
            bool k = false;
            for (int i = 0; i < counter; i++)
            {
                k = true;
                if (ar[i].is_correct(tmpAccount.CardNumber, tmpAccount.PinCode))
                {
                   
                        ar[i].AccountBalance += withdrawAmount;
                         break;
                        
                    
                }
            }
            if (!k)
            {
                Console.WriteLine("BankAccount not found");
            }
        }

        public void Save()
        {
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "acount.txt");
            String all = "";
            for (int i = 0; i < counter; i++)
            {
                BankAccount a = ar[i];
                all += a.P1.first_name + "\t" + a.P1.last_name + "\t" + a.Email + "\t" + a.AccountBalance + "\t" + a.CardNumber + "\t" + a.PinCode + "\n";
            }
            File.WriteAllText(destPath, all);
        }

        public void Load()
        {
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "acount.txt");
            String all = File.ReadAllText(destPath);
         
            string[] a = all.Split(new char[] {  '\n' }, StringSplitOptions.RemoveEmptyEntries);
           
            bankCapacity = a.Length;
            ar = new BankAccount[bankCapacity];
            counter = 0;
            foreach (string s in a)
            {
                string []l=s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(s);
                Person p = new Person();
                p.first_name = l[0];
                p.last_name = l[1];
                BankAccount b = new BankAccount(p, l[2], l[4], l[5], int.Parse(l[3]));
                ar[counter] = b;
                counter++;

            }
        }
    }
}
