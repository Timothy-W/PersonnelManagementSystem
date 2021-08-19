using PersonnelMgtBackend.DataAccess.Repository.IRepository;
using PersonnelMgtBackend.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PersonnelMgtBackend.DataAccess.Repository
{
    public class PersonRepository : RepositoryAsync<Person>, IPersonRepository
    {
        private readonly AppDbContext _db;

        public PersonRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Person item)
        {
            var objFromDb = _db.People.FirstOrDefault(s => s.Id == item.Id);

            if (objFromDb != null){
                objFromDb.FirstName = item.FirstName;
                objFromDb.LastName = item.LastName;
                objFromDb.Rank = item.Rank;

            }
        }

        public async Task UpdateAsync(Person item)
        {
            var objFromDb = await _db.People.FirstOrDefaultAsync(s => s.Id == item.Id);

            if (objFromDb != null){
                objFromDb.FirstName = item.FirstName;
                objFromDb.LastName = item.LastName;
                objFromDb.Rank = item.Rank;

            }
        }
    }
}
