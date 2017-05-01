using Livraria.Infra.Contexts;

namespace Livraria.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly LivrariaContext _context;

        public Uow(LivrariaContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
        }
    }
}