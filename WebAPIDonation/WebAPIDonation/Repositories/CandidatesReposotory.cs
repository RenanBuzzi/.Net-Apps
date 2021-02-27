using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPIDonation.Model;

namespace WebAPIDonationV1.Repositories
{
    public class CandidatesReposotory : GenericRepository<DbCandidate>
    {
        public CandidatesReposotory(DonationDBContext context) : base(context)
        {
        }

        public override DbCandidate Update(DbCandidate entity)
        {
            var candidate = _context.DBCandidates
                .Single(p => p.Id == entity.Id);

            candidate.Address = entity.Address;
            candidate.Age = entity.Age;
            candidate.BloodGroup = entity.BloodGroup;
            candidate.FullName = entity.FullName;
            candidate.Mobile = entity.Mobile;

            return base.Update(candidate);
        }

        public override DbCandidate Get(int id)
        {
            var candidateId = _context.DBCandidates
                    .Where(c => c.Id == id)
                    .Select(c => c.Id)
                    .Single();

            return _context.DBCandidates.Find(candidateId);
        }

        public override DbCandidate Add(DbCandidate entity)
        {
            return  _context.DBCandidates.Add(entity).Entity;
        }



    }
}
