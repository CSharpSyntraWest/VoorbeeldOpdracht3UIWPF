using System;
using System.Collections.Generic;
using VoorbeeldOpdracht3UIWPF.Utility;

namespace VoorbeeldOpdracht3UIWPF.Data
{
    public partial class Brouwer:ObservableObject
    {
        public Brouwer()
        {
            Bieren = new HashSet<Bier>();
        }

        public int BrouwerNr { get; set; }
        public string BrNaam { get; set; }
        public string Adres { get; set; }
        public short? PostCode { get; set; }
        public string Gemeente { get; set; }
        public int? Omzet { get; set; }

        public virtual ICollection<Bier> Bieren { get; set; }
    }
}
