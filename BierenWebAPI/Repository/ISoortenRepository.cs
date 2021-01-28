using BierenWebAPI.Data;
using System.Collections.Generic;

namespace BierenWebAPI.Repository
{
    public interface ISoortenRepository
    {
        IEnumerable<Soort> GeefSoorten();
        Soort GeefSoortVoorID(int soortId);
        void VoegSoortToe(Soort soort);
        void VerwijderSoort(int soortId);
        void WijzigSoort(Soort soort);
        void Bewaar();
        
    }
}
