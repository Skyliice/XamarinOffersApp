using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using XamarinOffersApp.Models;

namespace XamarinOffersApp.Services
{
    public class DeserializeService
    {
        private string url = "https://yastatic.net/market-export/_/partner/help/YML.xml";
        public async Task<List<Offer>> DeserializeOffers()
        {
            var lst = new List<Offer>();
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.Async = true;
            var xmlDocument = XmlReader.Create(url,settings);
            do
            {
                await xmlDocument.ReadAsync();
            } while (xmlDocument.Name != "offer");
            var serializer = new XmlSerializer(typeof(Offer));
            do
            {
                var offer = (Offer)serializer.Deserialize(xmlDocument);
                lst.Add(offer);
                await xmlDocument.ReadAsync();
            } while (xmlDocument.Name == "offer");
            xmlDocument.Close();
            return lst;
        }
    }
}