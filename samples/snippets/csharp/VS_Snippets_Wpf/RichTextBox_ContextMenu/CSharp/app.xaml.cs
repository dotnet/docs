using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace SDKSample
{
    public partial class app : Application
    {
        protected override void OnStartup(StartupEventArgs args)
        {
            Window w = new Window();
            w.Width = 640; w.Height = 480;

            StackPanel panel = new StackPanel();

            RichTextBox richTextBox = new RichTextBox();
            richTextBox.ContextMenu = new MyContextMenu(richTextBox);
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(
                "Right-click or use the Shift-F10 context menu shortcut to open the custom context menu."
            )));

            // When custom context menu is invoked via keyboard {Shift+F10} or properties key,
            // default ContextMenuOpening event places it in center of the RichTextBox window.
            // Listen to the ContextMenuOpening event to override this behavior.
            // <Snippet_AddListener>
            richTextBox.ContextMenuOpening += new ContextMenuEventHandler(richTextBox_ContextMenuOpening);
            // </Snippet_AddListener>

            panel.Children.Add(richTextBox);
            w.Content = panel;
            w.Show();
        }

        // <Snippet_ListenerBody>
        // This method is intended to listen for the ContextMenuOpening event from a RichTextBox.
        // It will position the custom context menu at the end of the current selection.
        void richTextBox_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            // Sender must be RichTextBox.
            RichTextBox rtb = sender as RichTextBox;
            if (rtb == null) return;

            ContextMenu contextMenu = rtb.ContextMenu;
            contextMenu.PlacementTarget = rtb;

            // This uses HorizontalOffset and VerticalOffset properties to position the menu,
            // relative to the upper left corner of the parent element (RichTextBox in this case).
            contextMenu.Placement = PlacementMode.RelativePoint;

            // Compute horizontal and vertical offsets to place the menu relative to selection end.
            TextPointer position = rtb.Selection.End;

            if (position == null) return;
            
            Rect positionRect = position.GetCharacterRect(LogicalDirection.Forward);
            contextMenu.HorizontalOffset = positionRect.X;
            contextMenu.VerticalOffset = positionRect.Y;

            // Finally, mark the event has handled.
            contextMenu.IsOpen = true;
            e.Handled = true;
        }
        // </Snippet_ListenerBody>
    }

    public class MyContextMenu : ContextMenu
    {
        private RichTextBox _rtb;

        public MyContextMenu(RichTextBox rtb)
            : base()
        {
            _rtb = rtb;

            // Add menu items for formatting selected text
            MenuItem menuItemBold = new MenuItem();
            menuItemBold.Header = "Bold";
            menuItemBold.Command = EditingCommands.ToggleBold;
            this.Items.Add(menuItemBold);

            MenuItem menuItemItalic = new MenuItem();
            menuItemItalic.Header = "Italic";
            menuItemItalic.Command = EditingCommands.ToggleItalic;
            this.Items.Add(menuItemItalic);

            MenuItem menuItemUnderline = new MenuItem();
            menuItemUnderline.Header = "Underline";
            menuItemUnderline.Command = EditingCommands.ToggleUnderline;
            this.Items.Add(menuItemUnderline);
        }
    }
}
