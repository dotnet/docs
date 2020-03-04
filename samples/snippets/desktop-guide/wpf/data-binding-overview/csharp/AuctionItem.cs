using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace bindings
{
    public class AuctionItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int CurrentPrice { get; set; } = 0;

        public int StartPrice { get; set; } = 50;

        public DateTime StartDate { get; set; } = DateTime.Now;
    }
}
