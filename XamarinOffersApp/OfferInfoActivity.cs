using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using FFImageLoading;
using Newtonsoft.Json;
using XamarinOffersApp.Repositories;

namespace XamarinOffersApp
{
    [Activity(Label = "Offer Info", Theme = "@style/AppTheme")]
    public class OfferInfoActivity : AppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_offer_info);
            var textView = FindViewById<TextView>(Resource.Id.offerJson);
            textView.Text = Intent.Extras.GetString("offer");
        }
    }
}