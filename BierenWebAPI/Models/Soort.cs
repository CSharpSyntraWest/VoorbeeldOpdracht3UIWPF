using System;
using System.Collections.Generic;

namespace BierenWebAPI.Data
{
    public partial class Soort
    {
        public Soort()
        {
            Bieren = new HashSet<Bier>();
        }

        public int Id { get; set; }
        public string SoortNaam { get; set; }

        public virtual ICollection<Bier> Bieren { get; set; }
    }
}
