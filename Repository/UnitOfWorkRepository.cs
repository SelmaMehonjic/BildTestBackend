using System.Threading.Tasks;
using bildExamNew.Data;

namespace BildTestBackend.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly DataContext _context;

        public UnitOfWorkRepository(DataContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();

        }
    }
}