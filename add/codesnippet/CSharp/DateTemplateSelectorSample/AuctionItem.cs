using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SDKSample
{
    public class AuctionItem : INotifyPropertyChanged
    {
        private string description;
        private ObservableCollection<string> images;
        private SpecialFeatures specialFeatures;
        private int currentPrice;
      

        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties Getters and Setters
        public string Description
        {
            get { return this.description; }
            set
            {
                this.description = value;
                OnPropertyChanged("Description");
            }
        }


        public ObservableCollection<string> Images
        {
            get { return this.images; }
        }

        public SpecialFeatures SpecialFeatures
        {
            get { return this.specialFeatures; }
            set
            {
                this.specialFeatures = value;
                OnPropertyChanged("SpecialFeatures");
            }
        }

        public int CurrentPrice
        {
            get { return this.currentPrice; }
            set
            {
                this.currentPrice = value;
                OnPropertyChanged("CurrentPrice");
            }
        }
        #endregion

        public AuctionItem(string description, SpecialFeatures specialFeatures, int currentPrice)
        {
            this.description = description;
            this.specialFeatures = specialFeatures;
            this.currentPrice = currentPrice;
            this.images = new ObservableCollection<string>();
        }

        public AuctionItem()
        {
            this.images = new ObservableCollection<string>();
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    //<SnippetSpecialFeatureEnum>
    public enum SpecialFeatures
    {
        None,
        Color,
    }
    //</SnippetSpecialFeatureEnum>

}

