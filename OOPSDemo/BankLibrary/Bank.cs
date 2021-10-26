using System;

namespace BankLibrary
{
    public class Bank
    {
        #region Fields & Properties

        private string accHolderName;

        public string AccHolderName
        {
            get { return accHolderName; }
            set { accHolderName = value; }
        }

        private double balance;

        public double Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        #endregion

        #region Methods

        public void Deposit (double amount)
        {
            Balance += amount;
        }

        public virtual void Withdraw (double amount)
        {
            Balance -= amount;
        }

        public override string ToString()
        {
            //traditional
            // return "AccountHolderName : " + AccHolderName + " Balance : " + Balance;

            //formated string
            //return string.Format("AccountHolderName : {0} Balance : {1}", AccHolderName, Balance);

            //string interpolation
            return string.Format($"Account Holder Name : {AccHolderName} Balance : {Balance}");
        }

        #endregion

        #region Constructor

        public Bank()
        {
            Balance = 1000;
        }

        public Bank(string name, double amount)
        {
            this.AccHolderName = name;
            this.Balance = amount;
        }

        #endregion
    }
}