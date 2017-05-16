// <snippet100>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace WpfLayoutHostingWfWithXaml
{
    public partial class MainWindow : Window
    {
        // <snippet104>
        public MainWindow()
        {
            InitializeComponent();

            this.InitializeFlowLayoutPanel();
        }
        // </snippet104>

        // <snippet101>
        private void button1_Click(object sender, EventArgs e )
        {
            System.Windows.Forms.Button b = sender as System.Windows.Forms.Button;

            b.Top = 20;
            b.Left = 20;
        }
        // </snippet101>

        // <snippet102>
        private void button2_Click(object sender, EventArgs e)
        {
            this.host1.Visibility = Visibility.Hidden;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.host1.Visibility = Visibility.Collapsed;
        }
        // </snippet102>

        // <snippet103>
        private void InitializeFlowLayoutPanel()
        {
            System.Windows.Forms.FlowLayoutPanel flp =
                this.flowLayoutHost.Child as System.Windows.Forms.FlowLayoutPanel;

            flp.WrapContents = true;

            const int numButtons = 6;

            for (int i = 0; i < numButtons; i++)
            {
                System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                b.Text = "Button";
                b.BackColor = System.Drawing.Color.AliceBlue;
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

                flp.Controls.Add(b);
            }
        }
        // </snippet103>
    }
}
// </snippet100>