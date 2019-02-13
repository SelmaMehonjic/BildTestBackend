using System.Threading.Tasks;

namespace BildTestBackend.Repository
{
    public interface IUnitOfWorkRepository
    
    {
         Task SaveChanges();
    }
}