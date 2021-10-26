using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class Savings : Bank, IInterest
    {
        public Savings()
        {

        }

        public Savings(string name, double amt) : base(name, amt)
        {

        }
        public double CalculateInterest()
        {
            return Balance * .1;
        }
        public sealed override void Withdraw(double amount)
        {
            if ((Balance-amount)> 0)
            {
                //allow to withdraw
                Balance -= amount;
            }
            else
            {
                throw new Exception("Balance not enough. Cannot Withdraw.");
            }
        }
    }
}
