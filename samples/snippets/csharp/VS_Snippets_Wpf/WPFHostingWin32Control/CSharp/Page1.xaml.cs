using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace WPF_Hosting_Win32_Control
{
//<SnippetHostWindowClass>
	public partial class HostWindow : Window
	{
    int selectedItem;
    IntPtr hwndListBox;
    ControlHost listControl;
    Application app;
    Window myWindow;
    int itemCount;

    private void On_UIReady(object sender, EventArgs e)
    {
      app = System.Windows.Application.Current;
      myWindow = app.MainWindow;
      myWindow.SizeToContent = SizeToContent.WidthAndHeight;
      listControl = new ControlHost(ControlHostElement.ActualHeight, ControlHostElement.ActualWidth);
      ControlHostElement.Child = listControl;
      listControl.MessageHook += new HwndSourceHook(ControlMsgFilter);
      hwndListBox = listControl.hwndListBox;
      for (int i = 0; i < 15; i++) //populate listbox
      {
        string itemText = "Item" + i.ToString();
        SendMessage(hwndListBox, LB_ADDSTRING, IntPtr.Zero, itemText);
      }
      itemCount = SendMessage(hwndListBox, LB_GETCOUNT, IntPtr.Zero, IntPtr.Zero);
      numItems.Text = "" +  itemCount.ToString();
    }
//</SnippetHostWindowClass>
//<SnippetAppendDeleteText>
    private void AppendText(object sender, EventArgs args)
    {
      if (!string.IsNullOrEmpty(txtAppend.Text))
      {
        SendMessage(hwndListBox, LB_ADDSTRING, IntPtr.Zero, txtAppend.Text);
      }
      itemCount = SendMessage(hwndListBox, LB_GETCOUNT, IntPtr.Zero, IntPtr.Zero);
      numItems.Text = "" + itemCount.ToString();
    }
    private void DeleteText(object sender, EventArgs args)
    {
      selectedItem = SendMessage(listControl.hwndListBox, LB_GETCURSEL, IntPtr.Zero, IntPtr.Zero);
      if (selectedItem != -1) //check for selected item
      {
        SendMessage(hwndListBox, LB_DELETESTRING, (IntPtr)selectedItem, IntPtr.Zero);
      }
      itemCount = SendMessage(hwndListBox, LB_GETCOUNT, IntPtr.Zero, IntPtr.Zero);
      numItems.Text = "" + itemCount.ToString();
    }
//</SnippetAppendDeleteText>
//<SnippetControlMsgFilterSendMessage>

//<SnippetControlMsgFilter>
    private IntPtr ControlMsgFilter(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
      int textLength;

      handled = false;
      if (msg == WM_COMMAND)
      {
        switch ((uint)wParam.ToInt32() >> 16 & 0xFFFF) //extract the HIWORD
        {
          case LBN_SELCHANGE : //Get the item text and display it
            selectedItem = SendMessage(listControl.hwndListBox, LB_GETCURSEL, IntPtr.Zero, IntPtr.Zero);
            textLength = SendMessage(listControl.hwndListBox, LB_GETTEXTLEN, IntPtr.Zero, IntPtr.Zero);
            StringBuilder itemText = new StringBuilder();
            SendMessage(hwndListBox, LB_GETTEXT, selectedItem, itemText);
            selectedText.Text = itemText.ToString();
            handled = true;
            break;
        }
      }
      return IntPtr.Zero;
    }
//</SnippetControlMsgFilter>
    internal const int
      LBN_SELCHANGE = 0x00000001,
      WM_COMMAND = 0x00000111,
      LB_GETCURSEL = 0x00000188,
      LB_GETTEXTLEN = 0x0000018A,
      LB_ADDSTRING = 0x00000180,
      LB_GETTEXT = 0x00000189,
      LB_DELETESTRING = 0x00000182,
      LB_GETCOUNT = 0x0000018B;

    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
    internal static extern int SendMessage(IntPtr hwnd,
                                           int msg,
                                           IntPtr wParam,
                                           IntPtr lParam);

    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
    internal static extern int SendMessage(IntPtr hwnd,
                                           int msg,
                                           int wParam,
                                           [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lParam);

    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
    internal static extern IntPtr SendMessage(IntPtr hwnd,
                                              int msg,
                                              IntPtr wParam,
                                              String lParam);
//</SnippetControlMsgFilterSendMessage>
  }
}