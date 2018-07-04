using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IDataRequestApplicationRepository : IDisposable
    {
        void Add(DataRequestApplication entity);
        DataRequestApplication Get(int id);
        void Update(DataRequestApplication entity);
        IList<DataRequestApplication> List(Expression<Func<DataRequestApplication, bool>> predicate);
    }
}
