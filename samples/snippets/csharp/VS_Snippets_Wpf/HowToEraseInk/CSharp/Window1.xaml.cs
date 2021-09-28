﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        InkEraser eraser;

        public Window1()
        {
            InitializeComponent();
            eraser = new InkEraser();
            this.Content = eraser;

            this.WindowState = WindowState.Maximized;
        }
    }
