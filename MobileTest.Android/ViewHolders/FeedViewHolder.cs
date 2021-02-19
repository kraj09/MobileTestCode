using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileTest.Android.ViewHolders
{
    public class FeedViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Avatar { get; private set; }
        public TextView Username { get; private set; }
        public TextView Caption { get; private set; }
        public ImageView MainImage { get; private set; }

        public FeedViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            Avatar = itemView.FindViewById<ImageView>(Resource.Id.imageAvatar);
            Username = itemView.FindViewById<TextView>(Resource.Id.lblUsername);
            Caption = itemView.FindViewById<TextView>(Resource.Id.lblCaption);
            MainImage = itemView.FindViewById<ImageView>(Resource.Id.imageMain);

            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}