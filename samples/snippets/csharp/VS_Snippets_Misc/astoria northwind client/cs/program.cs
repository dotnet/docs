using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
//using System.Windows.Forms;

namespace NorthwindClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //var newSync = new CustomerOrdersCustom();
                //newSync.Title = newSync.GetType().ToString();
                //newSync.ShowDialog();

                //var newAsync = new CustomerOrdersAsync();
                //newAsync.Title = newAsync.GetType().ToString();
                //newAsync.ShowDialog();

                //var newWpf = new CustomerOrdersWpf();
                //newWpf.Title = newWpf.GetType().ToString();
                //newWpf.ShowDialog();

                //var newWpf2 = new CustomerOrdersWpf2();
                //newWpf2.Title = newWpf2.GetType().ToString();
                //newWpf2.ShowDialog();

                //var newWpf3 = new CustomerOrdersWpf3();
                //newWpf3.Title = newWpf3.GetType().ToString();
                //newWpf3.ShowDialog();

                //var newSalesOrders = new SalesOrders();
                //newSalesOrders.Title = newSalesOrders.GetType().ToString();
                //newSalesOrders.ShowDialog();

                //var newClientCredentials = new ClientCredentials();
                //newClientCredentials.Title = newClientCredentials.GetType().ToString();
                //newClientCredentials.ShowDialog();

                Source.CallServiceOperationVoid();

                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("An error occured:" + ex.Message + ex.InnerException.Message ?? string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
