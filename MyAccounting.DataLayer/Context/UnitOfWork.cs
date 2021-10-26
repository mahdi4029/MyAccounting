using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAccounting.DataLayer.Repositories;

namespace MyAccounting.DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        private MyAccounting_DBEntities _db = new MyAccounting_DBEntities();

        private GenericRepository<Persons> _personRepository;

        public GenericRepository<Persons> personRepository
        {
            get
            {
                if (_personRepository==null)
                {
                    _personRepository = new GenericRepository<Persons>(_db);
                }

                return _personRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
