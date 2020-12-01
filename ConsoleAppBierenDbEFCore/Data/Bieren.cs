using System;
using System.Collections.Generic;

namespace ConsoleAppBierenDbEFCore.Data
{
    public partial class Bieren
    {
        public int BierNr { get; set; }
        public string Naam { get; set; }
        public int? BrouwerNr { get; set; }
        public int? SoortNr { get; set; }
        public double? Alcohol { get; set; }

        public virtual Brouwers BrouwerNrNavigation { get; set; }
        public virtual Soorten SoortNrNavigation { get; set; }
    }
}
