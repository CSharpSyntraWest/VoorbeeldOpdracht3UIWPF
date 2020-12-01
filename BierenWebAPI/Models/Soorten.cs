using System;
using System.Collections.Generic;

namespace BierenWebAPI.Data
{
    public partial class Soorten
    {
        public Soorten()
        {
            Bieren = new HashSet<Bieren>();
        }

        public int SoortNr { get; set; }
        public string Soort { get; set; }

        public virtual ICollection<Bieren> Bieren { get; set; }
    }
}
