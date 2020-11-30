using System;
using System.Collections.Generic;
using System.Text;
using VoorbeeldOpdracht3UIWPF.Utility;

namespace VoorbeeldOpdracht3UIWPF.Models
{
    public class Persoon : ObservableObject
    {
        private string _naam;
        public string Naam
        {
            get { return _naam; }
            set { OnPropertyChanged(ref _naam, value); }
        }

        private string _telNr;
        public string TelNr
        {
            get { return _telNr; }
            set { OnPropertyChanged(ref _telNr, value); }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { OnPropertyChanged(ref _email, value); }
        }

    }

}
