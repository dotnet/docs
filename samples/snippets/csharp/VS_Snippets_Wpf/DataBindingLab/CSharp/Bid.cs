using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataBindingLab
{
    public class Bid
    {
        private int amount;
        private User bidder;

        #region Property Getters and Setters
        public int Amount
        {
            get { return this.amount; }
        }

        public User Bidder
        {
            get { return this.bidder; }
        }
        #endregion

        public Bid(int amount, User bidder)
        {
            this.amount = amount;
            this.bidder = bidder;
        }
    }
}
