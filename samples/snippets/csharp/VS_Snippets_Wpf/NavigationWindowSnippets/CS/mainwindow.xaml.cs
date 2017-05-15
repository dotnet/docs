using System;
using System.Windows;
using System.Windows.Navigation;

    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.LoadCompleted += new LoadCompletedEventHandler(MainWindow_LoadCompleted);
        }

        void MainWindow_LoadCompleted(object sender, NavigationEventArgs e)
        {
            this.Title = this.Content.ToString();
        }
    }