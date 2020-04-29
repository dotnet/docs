using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace ContextMenus
{

	public partial class Pane1
	{
        bool FlagForCustomContextMenu;
//<SnippetBuildMenu>
        ContextMenu BuildMenu()
        {
            ContextMenu theMenu = new ContextMenu();
            MenuItem mia = new MenuItem();
            mia.Header = "Item1";
            MenuItem mib = new MenuItem();
            mib.Header = "Item2";
            MenuItem mic = new MenuItem();
            mic.Header = "Item3";
            theMenu.Items.Add(mia);
            theMenu.Items.Add(mib);
            theMenu.Items.Add(mic);
            return theMenu;
        }
//</SnippetBuildMenu>
//<SnippetAddItemNoHandle>
        void AddItemToCM(object sender, ContextMenuEventArgs e)
        {
            //check if Item4 is already there, this will probably run more than once
            FrameworkElement fe = e.Source as FrameworkElement;
            ContextMenu cm = fe.ContextMenu;
            foreach (MenuItem mi in cm.Items)
            {
                if ((String)mi.Header == "Item4") return;
            }
            MenuItem mi4 = new MenuItem();
            mi4.Header = "Item4";
            fe.ContextMenu.Items.Add(mi4);
        }
//</SnippetAddItemNoHandle>
//<SnippetReplaceNoReopen>
        void HandlerForCMO(object sender, ContextMenuEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;
            fe.ContextMenu = BuildMenu();
        }
//</SnippetReplaceNoReopen>
//<SnippetReplaceReopen>
        void HandlerForCMO2(object sender, ContextMenuEventArgs e)
        {
            if (!FlagForCustomContextMenu)
            {
                e.Handled = true; //need to suppress empty menu
                FrameworkElement fe = e.Source as FrameworkElement;
                fe.ContextMenu = BuildMenu();
                FlagForCustomContextMenu = true;
                fe.ContextMenu.IsOpen = true;
            }
        }
	}
//</SnippetReplaceReopen>
//<SnippetClassHandler>
    public class MyButton : Button
    {
        protected override void OnContextMenuOpening(ContextMenuEventArgs e)
        {
            base.OnContextMenuOpening(e);
            ContextMenu buttonMenu = new ContextMenu();
            MenuItem mia = new MenuItem();
            mia.Header = "Item1";
            MenuItem mib = new MenuItem();
            mib.Header = "Item2";
            MenuItem mic = new MenuItem();
            mic.Header = "Item3";
            buttonMenu.Items.Add(mia);
            buttonMenu.Items.Add(mib);
            buttonMenu.Items.Add(mic);
            FrameworkElement fe = e.Source as FrameworkElement;
            fe.ContextMenu = buttonMenu;
        }
    }
//</SnippetClassHandler>
}