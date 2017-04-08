using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using System.IO;

namespace basicvalues_markup
{


    public partial class app : Application
    {

        public app()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }
        

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            
            try {
                StreamWriter wr = new StreamWriter("error.txt");
                wr.Write(args.ExceptionObject.ToString());
                wr.Close();
            
            }catch(IOException ex)
            {
                MessageBox.Show("Unable to write error file:" + ex.ToString());
            }
            
            
            MessageBox.Show("Unhandled exception: " + args.ExceptionObject.ToString());
        }   

    }
}