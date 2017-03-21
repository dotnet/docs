// <SnippetSpellerCustomContextMenuCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class SpellerCustomContextMenu : Page
    {

        void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            //This is required for the first time ContextMenu invocation so that TextEditor doesnt handle it.
            myTextBox.ContextMenu = GetContextMenu();
        }
        void tb_ContextMenuOpening(object sender, RoutedEventArgs e)
        {
            int caretIndex, cmdIndex;
            SpellingError spellingError;

            myTextBox.ContextMenu = GetContextMenu();
            caretIndex = myTextBox.CaretIndex;

            cmdIndex = 0;
            spellingError = myTextBox.GetSpellingError(caretIndex);
            if (spellingError != null)
            {
                foreach (string str in spellingError.Suggestions)
                {
                    MenuItem mi = new MenuItem();
                    mi.Header = str;
                    mi.FontWeight = FontWeights.Bold;
                    mi.Command = EditingCommands.CorrectSpellingError;
                    mi.CommandParameter = str;
                    mi.CommandTarget = myTextBox;
                    myTextBox.ContextMenu.Items.Insert(cmdIndex, mi);
                    cmdIndex++;
                }
                Separator separatorMenuItem1 = new Separator();
                myTextBox.ContextMenu.Items.Insert(cmdIndex, separatorMenuItem1);
                cmdIndex++;
                MenuItem ignoreAllMI = new MenuItem();
                ignoreAllMI.Header = "Ignore All";
                ignoreAllMI.Command = EditingCommands.IgnoreSpellingError;
                ignoreAllMI.CommandTarget = myTextBox;
                myTextBox.ContextMenu.Items.Insert(cmdIndex, ignoreAllMI);
                cmdIndex++;
                Separator separatorMenuItem2 = new Separator();
                myTextBox.ContextMenu.Items.Insert(cmdIndex, separatorMenuItem2);
            }
        }

        // Gets a fresh context menu. 
        private ContextMenu GetContextMenu()
        {
            ContextMenu cm = new ContextMenu();

            //Can create STATIC custom menu items if exists here...
            MenuItem m1, m2, m3, m4;
            m1 = new MenuItem();
            m1.Header = "File";
            m2 = new MenuItem();
            m2.Header = "Save";
            m3 = new MenuItem();
            m3.Header = "SaveAs";
            m4 = new MenuItem();
            m4.Header = "Recent Files";

            //Can add functionality for the custom menu items here...

            cm.Items.Add(m1);
            cm.Items.Add(m2);
            cm.Items.Add(m3);
            cm.Items.Add(m4);

            return cm;
        }

    }
}
// </SnippetSpellerCustomContextMenuCodeExampleWholePage>