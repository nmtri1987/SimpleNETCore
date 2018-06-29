using Domain.Repositories;
using Domain.UnitOfWork;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataRequestApplicationDbContext _context;

        private IDataRequestApplicationRepository _dataRequestApplicationRepository;

        public UnitOfWork(DataRequestApplicationDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IDataRequestApplicationRepository DataRequestApplicationRepository
        {
            get
            {
                if(_dataRequestApplicationRepository == null)
                {
                    _dataRequestApplicationRepository = new DataRequestApplicationRepository(_context);
                }

                return _dataRequestApplicationRepository;
            }
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
