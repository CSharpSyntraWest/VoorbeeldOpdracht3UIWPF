using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VoorbeeldOpdracht3UIWPF.Data;

namespace VoorbeeldOpdracht3UIWPF.Services
{
    interface IBierenService
    {
        Task<ObservableCollection<Bier>> GeefAlleBieren();
        Task<Bier> GeefBierVoorBierNr(int bierNr);
        Task<ObservableCollection<Brouwer>> GeefAlleBrouwers();
        Task<ObservableCollection<SoortBier>> GeefAlleBierSoorten();
        Task<ObservableCollection<SoortBier>> ZoekBieren(int brouwerNr, int soortNr);
    }
}