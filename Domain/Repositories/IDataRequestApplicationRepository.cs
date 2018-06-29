using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IDataRequestApplicationRepository : IDisposable
    {
        void Add(DataRequestApplication entity);
        DataRequestApplication Get(int id);
        void Update(DataRequestApplication entity);
    }
}
