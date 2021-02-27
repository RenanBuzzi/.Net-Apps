using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDonation.Model;
using WebAPIDonationV1.Repositories;

namespace WebAPIDonation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbCandidatesController : ControllerBase
    {
        //private readonly DonationDBContext _context;
        private readonly IRepository<DbCandidate> _CandidateRepository;

        public DbCandidatesController(IRepository<DbCandidate> CandidateRepository)
        {
            _CandidateRepository = CandidateRepository;           
        }

        // GET: api/DbCandidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbCandidate>>> GetDBCandidates()
        {
            return _CandidateRepository.All().ToList();
        }

        // GET: api/DbCandidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DbCandidate>> GetDbCandidate(int id)
        {
            var dbCandidate = _CandidateRepository.Get(id);

            if (dbCandidate == null)
            {
                return NotFound();
            }

            return dbCandidate;
        }

        // PUT: api/DbCandidates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, DbCandidate dbCandidate)
        {
            dbCandidate.Id = id;

            _CandidateRepository.Update(dbCandidate);

            try
            {
                _CandidateRepository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbCandidateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DbCandidates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DbCandidate>> PostDbCandidate(DbCandidate dbCandidate)
        {
            _CandidateRepository.Add(dbCandidate);
            _CandidateRepository.SaveChanges();

            return CreatedAtAction("GetDbCandidate", new { id = dbCandidate.Id }, dbCandidate);
        }

        // DELETE: api/DbCandidates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var dbCandidate = _CandidateRepository.Find(id);
            if (dbCandidate == null)
            {
                return NotFound();
            }

            _CandidateRepository.Remove(dbCandidate);
            _CandidateRepository.SaveChanges();

            return NoContent();
        }

        private bool DbCandidateExists(int id)
        {
            return _CandidateRepository.DbCandidateExists(id);
        }
    }
}
