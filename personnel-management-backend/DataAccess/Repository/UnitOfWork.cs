using PersonnelMgtBackend.DataAccess;
using PersonnelMgtBackend.DataAccess.Repository;
using PersonnelMgtBackend.DataAccess.Repository.IRepository;


namespace BuildCostEstimator.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Personnel = new PersonRepository(_db);
            
        }
        
        public IPersonRepository Personnel { get; private set; }
        

        public void Dispose()
        {
            _db?.Dispose();
            //StoredProcedureCall?.Dispose(); // Auto generated
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
