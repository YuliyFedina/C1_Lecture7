namespace Homework.Model.Clients
{
    public class VipClient : BankClient
    {
        public VipClient(long id, string name) : base(id, name)
        {
        }

        public override int MaxAccounts => 10;
    }
}
