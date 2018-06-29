using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IDataRequestApplicationRepository DataRequestApplicationRepository { get; }
    }
}
