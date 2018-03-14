using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace MultiSelectorEx
{
    /// <summary>
    /// Interaction logic for MyMultiSelector.xaml
    /// </summary>
   
    public partial class MyMultiSelector : MultiSelector
    {
        //<snippet1>
        public MyMultiSelector() : base() 
        {
            InitializeComponent();
            CanSelectMultipleItems = true;
        }
        //</snippet1>
        public void AddItemsToTheSelectedCollection(object[] itemsToAdd)
        {
           //<snippet2>
            if (!this.IsUpdatingSelectedItems)
            {
                this.BeginUpdateSelectedItems();
                foreach (object item in itemsToAdd)
                {
                    this.SelectedItems.Add(item);
                }
                this.EndUpdateSelectedItems();
            }
            //</snippet2>
        }
    }
    
}
