using System;
using System.Collections.Generic;
using VoorbeeldOpdracht3UIWPF.Utility;

namespace VoorbeeldOpdracht3UIWPF.Data
{
    public partial class SoortBier:ObservableObject
    {
        public SoortBier()
        {
            Bieren = new HashSet<Bier>();
        }

        public int SoortNr { get; set; }
        public string Soort { get; set; }

        public virtual ICollection<Bier> Bieren { get; set; }
    }
}
