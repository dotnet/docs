using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WebSiteRatings.ViewModels
{
    public class Site : ViewModelBase
    {
        Models.Site _site;

        public string Title { get => _site.Title; set { _site.Title = value; OnNotifyPropertyChanged(); } }
        public int Rating { get => _site.Rating; set { _site.Rating = value; OnNotifyPropertyChanged(); } }
        public string Url { get => _site.Url; set { _site.Url = value; OnNotifyPropertyChanged(); } }
        public long ID { get => _site.Id; set { _site.Id = value; OnNotifyPropertyChanged(); } }

        public override string ToString() =>
            Title;

        public Site(Models.Site site) =>
            _site = site;

        public Site()
        {
            _site = new Models.Site("", 0, "");
        }

        public static Site Create(string title, int rating, string url)
        {
            var site = new Site(new Models.Site(title, rating, url));
            site.Save();
            return site;
        }

        public void Save() =>
            _site.Save();

        public void Delete() =>
            _site.Delete();
    }
}
