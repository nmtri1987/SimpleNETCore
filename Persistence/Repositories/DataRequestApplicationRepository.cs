using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Persistence.Repositories
{
    public class DataRequestApplicationRepository : IDataRequestApplicationRepository
    {
        private readonly DataRequestApplicationDbContext _context;

        public DataRequestApplicationRepository(DataRequestApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(DataRequestApplication entity)
        {
            entity.CreatedDate = DateTime.Now;
            _context.DataRequestApplications.Add(entity);
        }

        public DataRequestApplication Get(int id)
        {
            return _context.DataRequestApplications.Find(id);
        }

        public void Update(DataRequestApplication entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public IList<DataRequestApplication> List(Expression<Func<DataRequestApplication, bool>> predicate)
        {
            if(predicate == null)
            {
                return _context.DataRequestApplications.ToList();
            }

            return _context.DataRequestApplications.Where(predicate).ToList();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
