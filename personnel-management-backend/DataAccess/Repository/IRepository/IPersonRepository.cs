using System.Threading.Tasks;
using PersonnelMgtBackend.Models;

namespace PersonnelMgtBackend.DataAccess.Repository.IRepository
{
    public interface IPersonRepository : IRepositoryAsync<Person>
    {
        void Update(Person item);
        Task UpdateAsync(Person item);
    }
}
