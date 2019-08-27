namespace Homework.Model.Clients
{
    public class SimpleClient : BankClient
    {
        public SimpleClient(long id, string name) : base(id, name)
        {
        }

        public override int MaxAccounts => 3;
    }
}
