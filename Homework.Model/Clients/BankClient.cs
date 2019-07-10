using System;
using System.Collections.Generic;
using System.Linq;
using Homework.Model.Accounts;

namespace Homework.Model.Clients
{
    public abstract class BankClient : IComparable
    {
        private readonly List<BankAccount> _clientAccounts = new List<BankAccount>();

        public BankClient(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }
        public string Name { get; set; }
        public abstract int MaxAccounts { get; }

        public decimal WholeSum => _clientAccounts.Sum(x => x.Sum);

        private void CheckCountOfAccounts()
        {
            if (_clientAccounts.Count >= MaxAccounts)
                throw new Exception($"Нельзя добавить клиенту больше {MaxAccounts} счетов");
        }

        public void AddAccount(BankAccount bankAccount)
        {
            CheckCountOfAccounts();
            _clientAccounts.Add(bankAccount);
        }

        public void CreateCheckingAccountForClient(long accountId, decimal accountSum,
            decimal accountServiceCharge)
        {
            CheckCountOfAccounts();
            var account = new CheckingAccount(accountId, accountSum, accountServiceCharge);
            AddAccount(account);
        }

        public void
            CreateSavingAccountForClient(long accountId, decimal sum)
        {
            CheckCountOfAccounts();
            var account = new SavingAccount(accountId, sum);
            AddAccount(account);
        }

        public void CloseAccount(long accountId)
        {
            var account = _clientAccounts.FirstOrDefault(x => x.Id == accountId);
            if (account == null) throw new Exception("Счет для клиента не найден");
            account.Close();
        }

        public int CompareTo(object o)
        {
            var account = (BankClient)o;
            if (WholeSum > account.WholeSum)
                return 1;
            if (WholeSum < account.WholeSum)
                return -1;
            return 0;
        }
    }
}
