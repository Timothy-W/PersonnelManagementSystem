using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonnelMgtBackend.Models;

namespace PersonnelMgtBackend.DataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private AppDbContext _db { get; }

        public DbInitializer(AppDbContext db)
        {
            _db = db;
        }


        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception e)
            {
                //Log them
                throw;
            }
        }
    }
}
