﻿using System;
using System.Collections.Generic;
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

namespace SDKSample
{
    /// <summary>
    /// Interaction logic for PageWithEvents.xaml
    /// </summary>

    public partial class PageWithEvents : System.Windows.Controls.Page
    {
        public PageWithEvents()
        {

            this.Loaded += new RoutedEventHandler(PageWithEvents_Loaded);
            this.Unloaded += new RoutedEventHandler(PageWithEvents_Unloaded);

            InitializeComponent();

            System.Console.WriteLine("PageWithEvents()");
        }

        void PageWithEvents_Unloaded(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("PageWithEvents_Unloaded");
        }

        void PageWithEvents_Loaded(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("PageWithEvents_Loaded");
        }
    }
}