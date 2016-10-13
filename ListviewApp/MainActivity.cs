using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ListviewApp
{
    [Activity(Label = "ListviewApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        ListView listView;
        JavaList<string> list;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            listView = FindViewById<ListView>(Resource.Id.listView);
            list = new JavaList<string> {
                "Murat", "Sakine", "Hüseyin", "Mustafa"
            };

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,list);
            listView.Adapter = adapter;

        }
    }
}

