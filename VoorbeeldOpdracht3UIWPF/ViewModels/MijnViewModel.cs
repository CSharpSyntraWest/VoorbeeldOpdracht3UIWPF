using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VoorbeeldOpdracht3UIWPF.Models;
using VoorbeeldOpdracht3UIWPF.Utility;

namespace VoorbeeldOpdracht3UIWPF.ViewModels
{
    public class MijnViewModel : ObservableObject
    {
        private Persoon _persoon;
        public MijnViewModel()
        {
            PersonenLaden();

        }

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
