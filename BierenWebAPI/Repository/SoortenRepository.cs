using BierenWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BierenWebAPI.Repository
{
    public class SoortenRepository : ISoortenRepository
    {
        private readonly BierenDbContext _dbContext;

        public SoortenRepository(BierenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Soort> GeefSoorten()
        {
            return _dbContext.Soorten.ToList();
        }

        public Soort GeefSoortVoorID(int soortId)
        {
            return _dbContext.Soorten.Find(soortId);
        }

        public void Bewaar()
        {
            _dbContext.SaveChanges();
        }

       


        public void VerwijderSoort(int soortId)
        {
            var soort = _dbContext.Soorten.Find(soortId);
            _dbContext.Soorten.Remove(soort);
            Bewaar();
        }

        public void VoegSoortToe(Soort soort)
        {
            _dbContext.Add(soort);
            Bewaar();
        }

        public void WijzigSoort(Soort soort)
        {
            _dbContext.Entry(soort).State = EntityState.Modified;
            Bewaar();
        }
    }
}
