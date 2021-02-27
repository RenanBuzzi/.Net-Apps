using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebAPIDonation.Model;

namespace WebAPIDonationV1.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Get(int id);
        IEnumerable<DbCandidate> All();
        void SaveChanges();
        bool DbCandidateExists(int id);
        T Find(int id);
        T Remove(T entity);


    }
}
