using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infinite.AdminPage.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> Update(int id,T obj);
    }
}
