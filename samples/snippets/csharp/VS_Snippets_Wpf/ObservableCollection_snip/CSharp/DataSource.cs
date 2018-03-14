using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Data;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace SDKSample
{
    /// <summary>
    /// NumberListItem. This is the class that encapsulates each item
    /// in the numberlist.  The NLValue property is the property
    /// that is bound to by UI elements in the XAML markup.
    /// </summary>
    //<Snippet1>
    public class NumberListItem : INotifyPropertyChanged
    {
        private int _NLValue;

        public NumberListItem()
        {
        }

        public int NLValue
        {
            get
            {
                return _NLValue;
            }

            set
            {
                if (_NLValue != value)
                {
                    _NLValue = value;
                    OnPropertyChanged("NLValue");
                }
            }
        }

        // The following variable and method provide the support for
        // handling property changed events.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
    //</Snippet1>

    /// <summary>
    /// NumberList. In addition to serving as the datasource for the
    /// binding in this program, this class also exposes the methods
    /// through which a change to the list content can be initiated.
    /// </summary>
    //<Snippet3>
    public class NumberList : ObservableCollection<NumberListItem>
    {
        public NumberList()
            : base()
        {
            Add(new NumberListItem());
            Add(new NumberListItem());
            Add(new NumberListItem());
        }

        public void SetOdd()
        {
            // Each of these NLValue assignments causes an OnPropertyChanged event.
            for (int i = 0; i < Count; ++i)
            {
                NumberListItem nli = (NumberListItem)this[i];
                nli.NLValue = 2 * i + 1;
            }
        }

        public void SetEven()
        {
            // Each of these NLValue assignments causes an OnPropertyChanged event.
            for (int i = 0; i < Count; ++i)
            {
                NumberListItem nli = (NumberListItem)this[i];
                nli.NLValue = 2 * (i + 1);
            }
        }
        public void Snip()
        {
            //<SnippetBlockReentrancy>
            using (BlockReentrancy())
            {
                // OnCollectionChanged call
            }
            //</SnippetBlockReentrancy>
        }
    }
    //</Snippet3>
}
