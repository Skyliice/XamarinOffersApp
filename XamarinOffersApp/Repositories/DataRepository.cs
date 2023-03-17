using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinOffersApp.Models;
using XamarinOffersApp.Services;

namespace XamarinOffersApp.Repositories
{
    public class DataRepository
    {
        private static List<Offer> _offers;

        static DataRepository()
        {
            var parsingSevice = new DeserializeService();
            _offers = Task.Run(() => parsingSevice.DeserializeOffers()).Result;
        }

        public static List<Offer> GetOffers() => _offers;

        public static Offer GetOfferById(int id) => _offers.FirstOrDefault(o => o.OfferId == id);
    }
}