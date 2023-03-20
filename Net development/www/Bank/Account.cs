using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Account
    {
        public class BalanceInsufficientException : ApplicationException { }
        private double balance = 0;
        public void Credit(double amount)
        {
           if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            balance += amount;
        }
        public void Debit(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
            }
        }

        public double Balance
        {
            get { return balance; }
        }
    }
}
