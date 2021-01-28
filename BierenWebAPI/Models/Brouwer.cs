using System;
using System.Collections.Generic;

namespace BierenWebAPI.Data
{
    public partial class Brouwer
    {
        public Brouwer()
        {
            Bieren = new HashSet<Bier>();
        }

        public int Id { get; set; }
        public string BrNaam { get; set; }
        public string Adres { get; set; }
        public short? PostCode { get; set; }
        public string Gemeente { get; set; }
        public int? Omzet { get; set; }

        public virtual ICollection<Bier> Bieren { get; set; }
    }
}
