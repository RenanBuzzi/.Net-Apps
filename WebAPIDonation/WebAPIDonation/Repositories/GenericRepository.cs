using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebAPIDonation.Model;

namespace WebAPIDonationV1.Repositories
{
    public abstract class GenericRepository<T>
        : IRepository<T> where T : class
    {
        protected DonationDBContext _context;
        
        public GenericRepository(DonationDBContext context)
        {
            _context = context;
        }

        /*Appling CRUD methods below*/
        public virtual T Add(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public virtual T Get(int id)
        {
            return _context.Find<T>(id);
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            return _context.Update(entity).Entity;
        }

        public virtual IEnumerable<DbCandidate> All()
        {
            return _context.Set<DbCandidate>()
                 .AsQueryable()
                 .ToList();
        }

        public virtual bool DbCandidateExists(int id)
        {
            return _context.DBCandidates.Any(c => c.Id == id);
        }

        public virtual T Find(int id)
        {
            return _context.Find<T>(id);
        }

        public virtual T Remove(T entity)
        {
            return _context.Remove(entity).Entity;
        }


    }
}
