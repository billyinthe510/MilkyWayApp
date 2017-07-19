using Android.Content;
using Android.Views;
using Android.Widget;

namespace MilkyWayApp
{
    public class MyGridViewAdapter : BaseAdapter<MySimpleItem>
    {
        private readonly MySimpleItemLoader _mySimpleItemLoader;
        private readonly Context _context;

        public MyGridViewAdapter(Context context, MySimpleItemLoader mySimpleItemLoader)
        {
            _context = context;
            _mySimpleItemLoader = mySimpleItemLoader;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _mySimpleItemLoader.MySimpleItems[position];

            View itemView = convertView ?? LayoutInflater.From(_context).Inflate(Resource.Layout.MyGridViewCell, parent, false);
         //   var tvDisplayName = itemView.FindViewById<TextView>(Resource.Id.tvDisplayName);
            ImageButton imgThumbail = itemView.FindViewById<ImageButton>(Resource.Id.imgThumbnail);
            imgThumbail.Click += (e, o) => {
                Toast.MakeText(_context, "Img Button Clicked", ToastLength.Short).Show();
            };
            imgThumbail.SetScaleType(ImageView.ScaleType.CenterCrop);
            imgThumbail.SetPadding(8, 8, 8, 8);

          //  tvDisplayName.Text = item.DisplayName;
            imgThumbail.SetImageResource(Resource.Drawable.quoted);

            return itemView;
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return _mySimpleItemLoader.MySimpleItems.Count; }
        }

        public override MySimpleItem this[int position]
        {
            get { return _mySimpleItemLoader.MySimpleItems[position]; }
        }
    }
}