using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        Label label1 = new Label();
        Button button1 = new Button();
        //<Snippet200>
        // Event handler that accepts a parameter of the EventArgs type.
        private void MultiHandler(object sender, System.EventArgs e)
        {
            label1.Text = System.DateTime.Now.ToString();
        }

        public Form1()
        {
            InitializeComponent();

            // You can use a method that has an EventArgs parameter,
            // although the event expects the KeyEventArgs parameter.
            this.button1.KeyDown += this.MultiHandler;

            // You can use the same method
            // for an event that expects the MouseEventArgs parameter.
            this.button1.MouseClick += this.MultiHandler;
        }
        //</Snippet200>
    }
}
namespace w1
{
    //<Snippet201>
    class Mammals{}
    class Dogs : Mammals{}

    class Program
    {
        // Define the delegate.
        public delegate Mammals HandlerMethod();

        public static Mammals MammalsHandler()
        {
            return null;
        }

        public static Dogs DogsHandler()
        {
            return null;
        }

        static void Test()
        {
            HandlerMethod handlerMammals = MammalsHandler;

            // Covariance enables this assignment.
            HandlerMethod handlerDogs = DogsHandler;
        }
    }
    //</Snippet201>
}
