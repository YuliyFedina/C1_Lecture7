using System;
using Homework.Model.Accounts;

namespace Homework.Model
{
    public class Bank
    {
        public void Transaction(BankAccount from, BankAccount to, decimal sum)
        {
            from.WithdrawFunds(sum);
            if (sum > 0 && to.GetStatus())
            {
                to.AddFunds(sum);
            }

            else
            {
                from.AddFunds(sum);
                throw new Exception("Операция перевода средств между счетами не может быть выполнена");
            }
        }
    }
}
