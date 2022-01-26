using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WebSiteRatings.ViewModels
{
    public class SiteCollection: ViewModelBase
    {
        private Site _selectedSite;


        public ICommand AddSiteCommand { get; }
        public ICommand EditSiteCommand { get; }
        public ICommand DeleteSiteCommand { get; }


        public ObservableCollection<Site> Sites { get; set; } = new ObservableCollection<Site>();

        public Site SelectedSite { get => _selectedSite; set { _selectedSite = value; OnNotifyPropertyChanged(); } }

        public void Load()
        {
            foreach (var item in Models.Database.ReadSites())
                Sites.Add(new Site(item));
        }

        public void CreateSite(string title, int rating, string url) =>
            Sites.Add(Site.Create(title, rating, url));


        public SiteCollection()
        {
            AddSiteCommand = new ActionCommand(ShowAddItemWindow);
            EditSiteCommand = new PredicateCommand(ShowEditItemWindow, () => _selectedSite != null);
            DeleteSiteCommand = new PredicateCommand(ShowDeleteItemWindow, () => _selectedSite != null);
        }

        private void ShowAddItemWindow()
        {
            AddItem window = new AddItem() { DataContext = new Site(), Owner = App.Current.MainWindow };
            if (window.ShowDialog() == true)
            {
                var site = (Site)window.DataContext;
                site.Save();
                Sites.Add(site);
            }
        }

        private void ShowEditItemWindow()
        {
            AddItem window = new AddItem() { DataContext = _selectedSite, Owner = App.Current.MainWindow };

            if (window.ShowDialog() == true)
                _selectedSite.Save();
        }

        private void ShowDeleteItemWindow()
        {
            if (System.Windows.MessageBox.Show("Are you sure you want to delete this site?", "Delete", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                _selectedSite.Delete();
                Sites.Remove(_selectedSite);
                SelectedSite = Sites.FirstOrDefault();
            }
        }
    }
}
