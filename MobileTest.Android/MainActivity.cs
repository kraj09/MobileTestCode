using Android.App;
using Android.OS;
//using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using MobileTest.Android.Adapters;
using MobileTest.Domain.Entities;
using MobileTest.IoC;
using System.Collections.Generic;

namespace MobileTest.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView recyclerView;
        RecyclerView.LayoutManager layoutManager;
        FeedAdapter feedAdapter;
        List<FeedModel> feeds;
        ServiceModule service;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);
            layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            service = new ServiceModule();
            feeds = await service.GetFeeds();

            feedAdapter = new FeedAdapter(feeds);
            feedAdapter.ItemClick += OnItemClick;
            recyclerView.SetAdapter(feedAdapter);
        }

        private void OnItemClick(object sender, int e)
        {
            int itemNum = e + 1;
            Toast.MakeText(this, "This is item number " + itemNum, ToastLength.Short).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] global::Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}