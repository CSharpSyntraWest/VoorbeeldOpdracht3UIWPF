using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using VoorbeeldOpdracht3UIWPF.Data;
using VoorbeeldOpdracht3UIWPF.Models;
using VoorbeeldOpdracht3UIWPF.Utility;
using System.Threading.Tasks;
using VoorbeeldOpdracht3UIWPF.Services;

namespace VoorbeeldOpdracht3UIWPF.ViewModels
{
    public class MijnViewModel : ObservableObject
    {
        private Persoon _persoon;
       // private IBierenService _bierendataService;
        public MijnViewModel()
        {
            //_bierendataService = new BierenService();
            PersonenLaden();
           // BierenLadenAsync();
        }

        //private void BierenLadenAsync()
        //{        
        //        var bieren = _bierendataService.GeefAlleBierenAsync();
        //        BierenCollectie = bieren.Result;

        //    }

        //private ObservableCollection<Bier> _bierenCollectie;
        //public ObservableCollection<Bier> BierenCollectie
        //{
        //    get { return _bierenCollectie; }
        //    set {
        //        _bierenCollectie = value;
        //        OnPropertyChanged();
        //    }
        //}
        private ObservableCollection<Persoon> _persoonCollectie;
        public ObservableCollection<Persoon> PersoonCollectie
        {
            get { return _persoonCollectie; }
            set
            {
                _persoonCollectie = value;
                OnPropertyChanged();
            }
        }
        public Persoon HuidigePersoon
        {
            get
            {
                return _persoon;
            }
            set
            {
                _persoon = value;
                OnPropertyChanged();
            }
        }
        //private Bier _huidigBier;
        //public Bier HuidigBier
        //{
        //    get { return _huidigBier; }
        //    set {
        //        _huidigBier = value;
        //        OnPropertyChanged();
        //    }
        //}

        private void PersonenLaden()
        {
            IEnumerable<Persoon> personen = new List<Persoon>()
            {
                new Persoon
                {
                    Naam = "Jan Jansens",
                    TelNr = "047202515",
                    Email ="jan.jansens@personal.com",
                },
                new Persoon
                {
                    Naam = "Piet Pieters",
                    TelNr = "0498124589",
                    Email= "Piet.pieters@personal.com",
                }
            };

            PersoonCollectie = new ObservableCollection<Persoon>(personen);

        }
    }
}
