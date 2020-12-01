using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VoorbeeldOpdracht3UIWPF.Data;
using VoorbeeldOpdracht3UIWPF.Services;
using VoorbeeldOpdracht3UIWPF.Utility;

namespace VoorbeeldOpdracht3UIWPF.ViewModels
{
    class BierenViewModel:ObservableObject
    {
        private readonly Task _initializingTask;
        private ObservableCollection<Bier> _alleBieren;
        private async Task Init()
        {
            await BierenLadenAsync();
            await BrouwersLadenAsync();
            await BierSoortenLadenAsync();
        }
        // GeefBierVoorID
        private IBierenService _bierendataService;
        public ICommand ClearCommand { get; private set; }
        public ICommand ZoekCommand { get; private set; }
        public BierenViewModel()
        {
            _bierendataService = new BierenService();
            _initializingTask = Init();
            //EditCommand = new RelayCommand(Edit, CanEdit);
            //SaveCommand = new RelayCommand(Save, IsInEdit);
            //UpdateCommand = new RelayCommand(Update);
            //BrowseImageCommand = new RelayCommand(BrowseImage, IsInEdit);
            //AddCommand = new RelayCommand(Add);
            ZoekCommand = new RelayCommand(Zoek);
            ClearCommand = new RelayCommand(Clear);
           // DeleteCommand = new RelayCommand(Delete, CanDelete);
        }

        private void Clear()
        {
            BierenCollectie = new ObservableCollection<Bier>(_alleBieren);
        }

        private async Task BrouwersLadenAsync()
        {      
            var brouwers = await _bierendataService.GeefAlleBrouwers();
            BrouwersCollectie = brouwers;

        }

        private async Task BierSoortenLadenAsync()
        {
            var biersoorten = await _bierendataService.GeefAlleBierSoorten();
            BierSoortenCollectie = biersoorten;

        }
        private void Zoek()
        {
            //var bier = _bierendataService.GeefBierVoorBierNr(4);
            // HuidigBier = bier.Result;
            // var bieren = await _bierendataService.ZoekBieren(HuidigeBrouwer.BrouwerNr,HuidigeBierSoort.SoortNr);
            var result= (IEnumerable<Bier>)BierenCollectie.Where(b => b.BrouwerNr == HuidigeBrouwer.BrouwerNr && b.SoortNr == HuidigeBierSoort.SoortNr).ToList();
            BierenCollectie = new ObservableCollection<Bier>(result);
        }


        //private void Delete()
        //{

        //}

        //private bool CanDelete()
        //{
        //    return HuidigBier == null ? false : true;
        //}

        //private void Add()
        //{
        //    Bier nieuwBier = new Bier
        //    {
        //        Naam = "N/A", 
        //        BrouwerNr = HuidigeBrouwer,
        //        SoortNr = HuidigeBierSoort

        //    };


        //}
        private Brouwer _huidigeBrouwer;
        public Brouwer HuidigeBrouwer
        {
            get { return _huidigeBrouwer; }
            set
            {
                _huidigeBrouwer = value;
                OnPropertyChanged();
            }
        }

        private Bier _huidigBier;
        public Bier HuidigBier
        {
            get { return _huidigBier; }
            set
            {
                _huidigBier = value;
                OnPropertyChanged();
            }
        }
        private SoortBier _huidigeBierSoort;
        
        public SoortBier HuidigeBierSoort
        {
            get { return _huidigeBierSoort; }
            set
            {
                _huidigeBierSoort = value;
                OnPropertyChanged();
            }
        }
        private async Task BierenLadenAsync()
        {
            var bieren = await _bierendataService.GeefAlleBieren();
            BierenCollectie = bieren;//.Result;
            _alleBieren = new ObservableCollection<Bier>(bieren);
        }

        private ObservableCollection<Bier> _bierenCollectie;
        public ObservableCollection<Bier> BierenCollectie
        {
            get { return _bierenCollectie; }
            set
            {
                _bierenCollectie = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Brouwer> _brouwersCollectie;
        public ObservableCollection<Brouwer> BrouwersCollectie
        {
            get { return _brouwersCollectie; }
            set
            {
                _brouwersCollectie = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<SoortBier> _biersoortenCollectie;
        public ObservableCollection<SoortBier> BierSoortenCollectie
        {
            get { return _biersoortenCollectie; }
            set
            {
                _biersoortenCollectie = value;
                OnPropertyChanged();
            }
        }
    }
}
