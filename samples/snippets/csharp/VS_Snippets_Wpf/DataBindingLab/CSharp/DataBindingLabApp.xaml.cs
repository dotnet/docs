using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace DataBindingLab
{
    public partial class DataBindingLabApp : Application
    {        
        private User currentUser;
        private ObservableCollection<AuctionItem> auctionItems = new ObservableCollection<AuctionItem>();

        void AppStartup(object sender, StartupEventArgs args)
        {
            LoadAuctionData();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            //AddProductWindow addProductWindow = new AddProductWindow();
            //addProductWindow.Show();
        }

        public User CurrentUser
        {
            get { return this.currentUser; }
            set { this.currentUser = value; }
        }

        public ObservableCollection<AuctionItem> AuctionItems
        {
            get { return this.auctionItems; }
            set { this.auctionItems = value; }
        }

        private void LoadAuctionData()
        {
            CurrentUser = new User("John", 12, new DateTime(2003, 4, 20));

            #region Add Products to the auction
            User userMary = new User("Mary", 10, new DateTime(2000, 5, 2));
            User userAnna = new User("Anna", 5, new DateTime(2001, 9, 13));
            User userMike = new User("Mike", 13, new DateTime(1999, 11, 23));
            User userMark = new User("Mark", 15, new DateTime(2004, 6, 3));

            AuctionItem camera = new AuctionItem("Digital camera - good condition", ProductCategory.Electronics, 300, new DateTime(2005, 8, 23), userAnna, SpecialFeatures.None);
            camera.AddBid(new Bid(310, userMike));
            camera.AddBid(new Bid(312, userMark));
            camera.AddBid(new Bid(314, userMike));
            camera.AddBid(new Bid(320, userMark));

            AuctionItem snowBoard = new AuctionItem("Snowboard and bindings", ProductCategory.Sports, 120, new DateTime(2005, 7, 12), userMike, SpecialFeatures.Highlight);
            snowBoard.AddBid(new Bid(140, userAnna));
            snowBoard.AddBid(new Bid(142, userMary));
            snowBoard.AddBid(new Bid(150, userAnna));

            AuctionItem insideCSharp = new AuctionItem("Inside C#, second edition", ProductCategory.Books, 10, new DateTime(2005, 5, 29), this.currentUser, SpecialFeatures.Color);
            insideCSharp.AddBid(new Bid(11, userMark));
            insideCSharp.AddBid(new Bid(13, userAnna));
            insideCSharp.AddBid(new Bid(14, userMary));
            insideCSharp.AddBid(new Bid(15, userAnna));

            AuctionItem laptop = new AuctionItem("Laptop - only 1 year old", ProductCategory.Computers, 500, new DateTime(2005, 8, 15), userMark, SpecialFeatures.Highlight);
            laptop.AddBid(new Bid(510, this.currentUser));

            AuctionItem setOfChairs = new AuctionItem("Set of 6 chairs", ProductCategory.Home, 120, new DateTime(2005, 2, 20), userMike, SpecialFeatures.Color);

            AuctionItem myDVDCollection = new AuctionItem("My DVD Collection", ProductCategory.DVDs, 5, new DateTime(2005, 8, 3), userMary, SpecialFeatures.Highlight);
            myDVDCollection.AddBid(new Bid(6, userMike));
            myDVDCollection.AddBid(new Bid(8, this.currentUser));

            AuctionItem tvDrama = new AuctionItem("TV Drama Series", ProductCategory.DVDs, 40, new DateTime(2005, 7, 28), userAnna, SpecialFeatures.None);
            tvDrama.AddBid(new Bid(42, userMike));
            tvDrama.AddBid(new Bid(45, userMark));
            tvDrama.AddBid(new Bid(50, userMike));
            tvDrama.AddBid(new Bid(51, this.currentUser));

            AuctionItem squashRacket = new AuctionItem("Squash racket", ProductCategory.Sports, 60, new DateTime(2005, 4, 4), userMark, SpecialFeatures.Highlight);
            squashRacket.AddBid(new Bid(62, userMike));
            squashRacket.AddBid(new Bid(65, userAnna));

            this.AuctionItems.Add(camera);
            this.AuctionItems.Add(snowBoard);
            this.AuctionItems.Add(insideCSharp);
            this.AuctionItems.Add(laptop);
            this.AuctionItems.Add(setOfChairs);
            this.AuctionItems.Add(myDVDCollection);
            this.AuctionItems.Add(tvDrama);
            this.AuctionItems.Add(squashRacket);
            #endregion
        }

    }
}