using System;

using Android.OS;
using Android.App;
using Android.Views;
using Android.Runtime;

using AndroidX.Core.View;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.DrawerLayout.Widget;

using Google.Android.Material.Snackbar;
using Google.Android.Material.Navigation;
using Google.Android.Material.FloatingActionButton;

namespace LegiDiffUI
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var floatingActionButton = FindViewById<FloatingActionButton>(Resource.Id.fab);

            if (floatingActionButton != null)
            {
                floatingActionButton.Click += FabOnClick;
            }

            var drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var toggle = new ActionBarDrawerToggle(this, drawer, toolbar, 
                                                   Resource.String.navigation_drawer_open, 
                                                   Resource.String.navigation_drawer_close);
            drawer?.AddDrawerListener(toggle);
            toggle.SyncState();

            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            
            navigationView?.SetNavigationItemSelectedListener(this);
        }

        public override void OnBackPressed()
        {
            var drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if(drawer != null && drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return item.ItemId == Resource.Id.action_settings || base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            var view = (View) sender;

            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            var id = item.ItemId;

            switch (id)
            {
                case Resource.Id.nav_camera:
                    // Handle the camera action
                    break;
                case Resource.Id.nav_gallery:
                    break;
                case Resource.Id.nav_slideshow:
                    break;
                case Resource.Id.nav_manage:
                    break;
                case Resource.Id.nav_share:
                    break;
                case Resource.Id.nav_send:
                    break;
            }

            var drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            drawer?.CloseDrawer(GravityCompat.Start);

            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, 
                                                        [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

