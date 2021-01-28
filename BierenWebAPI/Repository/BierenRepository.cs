using BierenWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BierenWebAPI.Repository
{
    public class BierenRepository : IBierenRepository
    {
        private readonly BierenDbContext _dbContext;

        public BierenRepository(BierenDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Bier> GeefBieren()
        {
            return _dbContext.Bieren.ToList();
        }

        public Bier GeefBierVoorID(int bierId)
        {
            return _dbContext.Bieren.Find(bierId);
        }

        public void Bewaar()
        {
            _dbContext.SaveChanges();
        }


        public void VerwijderBier(int bierId)
        {
            var product = _dbContext.Bieren.Find(bierId);
            _dbContext.Bieren.Remove(product);
            Bewaar();
        }

        public void VoegBierToe(Bier bier)
        {
            _dbContext.Add(bier);
            Bewaar();
        }

        public void WijzigBier(Bier bier)
        {
            _dbContext.Entry(bier).State = EntityState.Modified;
            Bewaar();
        }

    
    }
}
