using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace KVKApp
{
    public static class AppSettings
    {
        static string kvkEndPoint;

        const string root = "https://api.kvk.nl/api/v2/";
        static AppSettings()
        {
            kvkEndPoint = $"{root}";
        }

        //public static string KVKEndpoint
        //{
        //    get => Preferences.Get(nameof(kvkEndPoint), kvkEndPoint);
        //    set => Preferences.Set(nameof(kvkEndPoint), value);
        //}

        public static string KVKEndpoint
        {
            get => kvkEndPoint;            
        }
    }
}
