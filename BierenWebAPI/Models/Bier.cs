using System;
using System.Collections.Generic;

namespace BierenWebAPI.Data
{
    public partial class Bier
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int? BrouwerId { get; set; }
        public int? SoortId { get; set; }
        public double? Alcohol { get; set; }

        public virtual Brouwer Brouwers { get; set; }
        public virtual Soort Soorten { get; set; }
    }
}
