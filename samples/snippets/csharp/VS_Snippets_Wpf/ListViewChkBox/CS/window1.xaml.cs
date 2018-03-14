using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;
using System.Xml;


namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
      void mySelectionChanged(object sender, 
                              SelectionChangedEventArgs e)
      {            
         XmlElement mySelectedElement = 
             (XmlElement)myPlaylist.SelectedItem;
         NowPlaying.Text = mySelectedElement.GetAttribute("Name").ToString()
          + " by " +mySelectedElement.GetAttribute("Artist").ToString();
      }   
    }
    }
