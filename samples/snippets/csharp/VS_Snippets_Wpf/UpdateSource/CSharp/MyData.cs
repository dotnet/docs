using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace SDKSample
{
    //<SnippetChangeNotification>
	public class UserProfile : INotifyPropertyChanged
	{
        public UserProfile() {}
		
        private string itemName = "";
		private string bidPrice = "";

		public string ItemName
		{
			get
            {
                return itemName;
            }
            set
            {
                itemName=value;
                OnPropertyChanged("ItemName");
            }
		}

		public string BidPrice
		{
			get
            {
                return bidPrice;
            }
            set
            {
                bidPrice=value;
                OnPropertyChanged("BidPrice");
            }
		}

	//Declare event
	public event PropertyChangedEventHandler PropertyChanged;
	//OnPropertyChanged event handler to update property value in binding
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
    //</SnippetChangeNotification>
}
