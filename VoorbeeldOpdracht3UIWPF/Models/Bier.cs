using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoorbeeldOpdracht3UIWPF.Utility;

namespace VoorbeeldOpdracht3UIWPF.Data
{
    public partial class Bier:ObservableObject
    {
        public int BierNr { get; set; }
        public string Naam { get; set; }
        public int? BrouwerNr { get; set; }
        public int? SoortNr { get; set; }
        public double? Alcohol { get; set; }

        public virtual Brouwer BrouwerNrNavigation { get; set; }
        public virtual SoortBier SoortNrNavigation { get; set; }

    }
}
