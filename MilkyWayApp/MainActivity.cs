using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Xamarin.Android;
using System;
using Mono;
using Android.Content;

namespace MilkyWayApp
{
    [Activity(Label = "MilkyWayApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private const string TAG = "InfiniteScroll";
        private GridView _gridView;
        private MySimpleItemLoader _mySimpleItemLoader;
        private MyGridViewAdapter _gridviewAdapter;
        private readonly object _scrollLockObject = new object();
        private const int ItemsPerPage = 24;

        private const int LoadNextItemsThreshold = 6;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            SetupUiElements();

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
                Toast.MakeText(this, "Home Button Clicked", ToastLength.Short).Show();
            };
            map.Click += (e, o) => {
                Toast.MakeText(this, "Map Button Clicked", ToastLength.Short).Show();
            };
            camera.Click += (e, o) => {
                Toast.MakeText(this, "Camera Button Clicked", ToastLength.Short).Show();
            };
            profile.Click += (e, o) => {
                Toast.MakeText(this, "Profile Button Clicked", ToastLength.Short).Show();
            };
        }

        private void SetupUiElements()
        {
            _mySimpleItemLoader = new MySimpleItemLoader();
            _mySimpleItemLoader.LoadMoreItems(ItemsPerPage);

            _gridView = FindViewById<GridView>(Resource.Id.gridview);
            _gridviewAdapter = new MyGridViewAdapter(this, _mySimpleItemLoader);
            _gridView.Adapter = _gridviewAdapter;
            _gridView.Scroll += KeepScrollingInfinitely;
        }
        public void OnButtonClicked(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Other Buttons Clicked", ToastLength.Short).Show();
        }
        private void KeepScrollingInfinitely(object sender, AbsListView.ScrollEventArgs args)
        {
            lock (_scrollLockObject)
            {
                var mustLoadMore = args.FirstVisibleItem + args.VisibleItemCount >= args.TotalItemCount - LoadNextItemsThreshold;
                if (mustLoadMore && _mySimpleItemLoader.CanLoadMoreItems && !_mySimpleItemLoader.IsBusy)
                {
                    _mySimpleItemLoader.IsBusy = true;
                    Log.Info(TAG, "Requested to load more items");
                    _mySimpleItemLoader.LoadMoreItems(ItemsPerPage);
                    _gridviewAdapter.NotifyDataSetChanged();
                    _gridView.InvalidateViews();
                }
            }
        }


    }
}

