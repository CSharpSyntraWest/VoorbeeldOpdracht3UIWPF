using BierenWebAPI.Data;
using System.Collections.Generic;

namespace BierenWebAPI.Repository
{
    public interface IBierenRepository
    {
        IEnumerable<Bier> GeefBieren();
        Bier GeefBierVoorID(int bierId);
        void VoegBierToe(Bier bier);
        void VerwijderBier(int bierId);
        void WijzigBier(Bier bier);
        void Bewaar();
  
    }
}
