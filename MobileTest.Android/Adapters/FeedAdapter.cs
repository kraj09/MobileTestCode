using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using MobileTest.Android.ViewHolders;
using MobileTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MobileTest.Android.Adapters
{
    public class FeedAdapter : RecyclerView.Adapter
    {
        List<FeedModel> feeds;
        public event EventHandler<int> ItemClick;

        public FeedAdapter(List<FeedModel> feedModels)
        {
            feeds = feedModels;
        }

        public override int ItemCount => feeds.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            FeedViewHolder vh = holder as FeedViewHolder;

            vh.Avatar.SetImageBitmap(GetImageBitmapFromUrl(feeds[position].Avatar));
            vh.Username.Text = feeds[position].First + " " + feeds[position].Last;
            vh.Caption.Text = feeds[position].Caption;
            vh.MainImage.SetImageBitmap(GetImageBitmapFromUrl(feeds[position].Image));
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var x=feeds[0].Avatar;

            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_feed, parent, false);

            FeedViewHolder vh = new FeedViewHolder(itemView, OnClick);
            return vh;
        }

        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }
}