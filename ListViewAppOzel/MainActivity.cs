using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ListViewAppOzel
{
    [Activity(Label = "ListViewAppOzel", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        ListView _listView;
        JavaList<Kisi> _list;
        Button button;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += OnButtonClicked;
            //button.Click += (object o, EventArgs e) =>
            //{
            //    button.Text = string.Format("{0} clicks!", count++);
            //};

            _listView = FindViewById<ListView>(Resource.Id.customListView);
            _list = new JavaList<Kisi>
            {
                new Kisi { Ad = "Murat", Soyad = "ÖNER", Yas = 25, Cinsiyet = "E"  },
                new Kisi { Ad = "Sakine", Soyad = "SALMANLI", Yas = 22, Cinsiyet = "K"  },
                new Kisi { Ad = "Hüseyin", Soyad = "TURAK", Yas = 24, Cinsiyet = "E"  },
                new Kisi { Ad = "Mustafa", Soyad = "ÖNER", Yas = 25, Cinsiyet = "E"  }
            };

            MyListViewAdapter adapter = new MyListViewAdapter(this, _list);
            _listView.Adapter = adapter;

            _listView.ItemClick += _listView_ItemClick;
            _listView.ItemLongClick += _listView_ItemLongClick;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            button.Text = string.Format("{0} clicks!", count++);
        }

        private void _listView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            var kisi = _list[e.Position];
            Toast.MakeText(this, string.Format("LongClick: {0} {1}", kisi.Yas, kisi.Cinsiyet), ToastLength.Long).Show();
        }

        private void _listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var kisi = _list[e.Position];
            Toast.MakeText(this, string.Format("Click: {0} {1}", kisi.Ad, kisi.Soyad), ToastLength.Long).Show();
        }
    }
}

