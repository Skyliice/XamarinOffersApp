using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Newtonsoft.Json;
using XamarinOffersApp.Models;
using XamarinOffersApp.Repositories;
using XamarinOffersApp.Services;

namespace XamarinOffersApp
{
    [Activity(Label = "Offers list", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var offers = DataRepository.GetOffers();
            var list = FindViewById<ListView>(Resource.Id.offersList);
            var ids = offers.Select(o => "Order №" + o.OfferId.ToString()).ToList();
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, ids);
            list.Adapter = adapter;
            list.ItemClick += (sender, e) =>
            {
                Intent intent = new Intent(this, typeof(OfferInfoActivity));
                intent.PutExtra("offer", JsonConvert.SerializeObject(offers[e.Position]));
                StartActivity(intent);
            };
        }
    }
}