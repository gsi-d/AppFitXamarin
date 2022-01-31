using AplicativoFit.Helpers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoFit
{
    public partial class App : Application
    {
        static SQLiteDataBaseHelper database;
        public static SQLiteDataBaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteDataBaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamAppFit.db3"));
                }

                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
