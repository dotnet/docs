using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Collections.ObjectModel;


namespace SDKSample
{
    /// <summary>
    /// Interaction logic for app.xaml
    /// </summary>

    public partial class app : Application
    {
        void AppStartup(object sender, StartupEventArgs args)
        {
            LoadAuctionData();
            Window1 mainWindow = new Window1();

            mainWindow.Show();
        }

        private ObservableCollection<AuctionItem> auctionItems = new ObservableCollection<AuctionItem>();

        public ObservableCollection<AuctionItem> AuctionItems
        {
            get { return this.auctionItems; }
            set { this.auctionItems = value; }
        }

        public void LoadAuctionData()
        {
          AuctionItem item;
          item = new AuctionItem();
          item.Description = "SnowBoard";
          item.CurrentPrice = 500;
          this.AuctionItems.Add(item);

          item = new AuctionItem();
          item.Description = "Soccer"; 
          item.SpecialFeatures = SpecialFeatures.Color;
          item.CurrentPrice = 100;
          this.AuctionItems.Add(item);


          item = new AuctionItem();
          item.Description = "bike";
          item.SpecialFeatures = SpecialFeatures.Color;
          item.CurrentPrice = 530;
   
          this.AuctionItems.Add(item);


          item = new AuctionItem();
          item.Description = "Laptop";
          item.SpecialFeatures = SpecialFeatures.Color;
          item.CurrentPrice = 720;
   
          this.AuctionItems.Add(item);

          item = new AuctionItem();
          item.Description = "tennis";
          item.SpecialFeatures = SpecialFeatures.Color;
          item.CurrentPrice = 222;
          this.AuctionItems.Add(item);

          item = new AuctionItem();


          item = new AuctionItem();
          item.Description = "Digital camera";
          item.CurrentPrice = 680;

          this.AuctionItems.Add(item);


          item = new AuctionItem();
          item.Description = "Keyboard";
          item.CurrentPrice = 55;

          this.AuctionItems.Add(item);


        }
    }
}