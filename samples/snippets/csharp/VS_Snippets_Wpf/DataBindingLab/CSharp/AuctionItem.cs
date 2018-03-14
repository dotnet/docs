using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataBindingLab
{
    public class AuctionItem : INotifyPropertyChanged
    {
        private string description;
        private int startPrice;
        private DateTime startDate;
        private ProductCategory category;
        private User owner;
        private SpecialFeatures specialFeatures;
        private ObservableCollection<Bid> bids;

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

        public int StartPrice
        {
            get { return this.startPrice; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be positive");
                }
                this.startPrice = value;
                OnPropertyChanged("StartPrice");
                OnPropertyChanged("CurrentPrice");
            }
        }

        public DateTime StartDate
        {
            get { return this.startDate; }
            set
            {
                this.startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public ProductCategory Category
        {
            get { return this.category; }
            set
            {
                this.category = value;
                OnPropertyChanged("Category");
            }
        }

        public User Owner
        {
            get { return this.owner; }
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

        public ReadOnlyObservableCollection<Bid> Bids
        {
            get { return new ReadOnlyObservableCollection<Bid>(this.bids); }
        }

        public int CurrentPrice
        {
            get
            {
                int price = 0;
                // There is at least on bid on this product
                if (this.bids.Count > 0)
                {
                    // Get the amount of the last bid
                    Bid lastBid = this.bids[this.bids.Count - 1];
                    price = lastBid.Amount;
                }
                // No bids on this product yet
                else
                {
                    price = this.startPrice;
                }
                return price;
            }
        }
        #endregion

        public AuctionItem(string description, ProductCategory category, int startPrice, DateTime startDate, User owner, SpecialFeatures specialFeatures)
        {
            this.description = description;
            this.category = category;
            this.startPrice = startPrice;
            this.startDate = startDate;
            this.owner = owner;
            this.specialFeatures = specialFeatures;
            this.bids = new ObservableCollection<Bid>();
        }

        // Exposing Bids as a ReadOnlyObservableCollection and adding an AddBid method so that CurrentPrice 
        // is updated when a new Bid is added
        public void AddBid(Bid bid)
        {
            this.bids.Add(bid);
            OnPropertyChanged("CurrentPrice");
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public enum ProductCategory
    {
        Books,
        Computers,
        DVDs,
        Electronics,
        Home,
        Sports,
    }

    public enum SpecialFeatures
    {
        None,
        Color,
        Highlight
    }

}

