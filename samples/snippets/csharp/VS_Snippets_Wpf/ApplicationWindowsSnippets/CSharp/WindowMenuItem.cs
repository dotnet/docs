//<SnippetWindowMenuItemCODE>
using System;
using System.Windows;
using System.Windows.Controls;

namespace CSharp
{
    // Custom menu item that stores a reference to a window
    public class WindowMenuItem : MenuItem
    {
        public Window Window = null;
    }
}
//</SnippetWindowMenuItemCODE>