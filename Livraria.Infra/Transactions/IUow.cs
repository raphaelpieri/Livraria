namespace Livraria.Infra.Transactions
{
    public interface IUow
    {
        void Commit();
        void RollBack();
    }
}