using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Xamarin.Android;
using System;
using Mono;

namespace MilkyWayApp
{
    [Activity(Label = "MilkyWayApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            
            //ScrollView scrollView = FindViewById<ScrollView>(Resource.Id.scrollView);
            GridView gridView = FindViewById<GridView>(Resource.Id.gridview);

            ImageButton home = FindViewById<ImageButton>(Resource.Id.home);
            ImageButton map = FindViewById<ImageButton>(Resource.Id.map);
            ImageButton camera = FindViewById<ImageButton>(Resource.Id.camera);
            ImageButton profile = FindViewById<ImageButton>(Resource.Id.profile);

            /*
            gridView.Adapter = new ImageAdapter(this);

            gridView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                Toast.MakeText(this, args.Position.ToString(), ToastLength.Short).Show();
            };
            */

            home.Click += (e, o) => {
                Toast.MakeText(this, "Clicked", ToastLength.Short).Show();
                Log.Debug("MilkyWayApp", "Button Debug PResssed");
                Console.Write("Button pressed");
            };
            map.Click += OnButtonClicked;
            camera.Click += OnButtonClicked;
            profile.Click += OnButtonClicked;
        }

        public void OnButtonClicked(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Clicked", ToastLength.Short).Show();
            Log.Debug("MilkyWayApp", "Button Debug PResssed");
            Log.Verbose("MilkyWayApp", "Button Verbose PResssed");
            Console.WriteLine("mayApp", "Button was pressed");
            
            
        }
    }
}

