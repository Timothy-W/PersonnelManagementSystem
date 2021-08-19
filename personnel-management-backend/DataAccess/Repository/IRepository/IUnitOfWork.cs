using System;

namespace PersonnelMgtBackend.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Personnel { get; }
     
        void Save();
    }
}
