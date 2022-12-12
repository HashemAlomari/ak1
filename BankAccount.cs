using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Assignment
{
    public class BankAccount
    {
        private Person p1; private string email; private string cardNumber; private string pinCode;



        private int accountBalance;

        public BankAccount(Person p1, string email, string cardNumber, string pinCode, int accountBalance)
        {
            this.p1 = p1;
          
            this.email = email;
            this.cardNumber = cardNumber;
            this.pinCode = pinCode;
            this.AccountBalance = accountBalance;
        }

        public String CardNumber { get
            {
                return cardNumber;


            }
        }
        public String PinCode
        {
            get
            {
                return pinCode;


            }
        }

        public int AccountBalance { get => accountBalance; set => accountBalance = value; }
        public Person P1 { get => p1; set => p1 = value; }
        public string Email { get => email; set => email = value; }

        public bool is_correct(string cardNumber, string pinCode)
        {
            return this.cardNumber.Equals(cardNumber) && this.pinCode.Equals(pinCode);
        }
    }
}
