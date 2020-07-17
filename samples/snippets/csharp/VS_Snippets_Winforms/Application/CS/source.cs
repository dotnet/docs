//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text;
using System.IO;

namespace MyApplication
{
    // A simple form that represents a window in our application
    public class AppForm2 : System.Windows.Forms.Form
    {
        public AppForm2()
        {
            this.Size = new System.Drawing.Size(300, 300);
            this.Text = "AppForm2";
        }
    }

    // A simple form that represents a window in our application
    public class AppForm1 : System.Windows.Forms.Form
    {
        public AppForm1()
        {
            this.Size = new System.Drawing.Size(300, 300);
            this.Text = "AppForm1";
        }
    }

    //<Snippet2>
    // The class that handles the creation of the application windows
    class MyApplicationContext : ApplicationContext
    {

        private int _formCount;
        private AppForm1 _form1;
        private AppForm2 _form2;

        private Rectangle _form1Position;
        private Rectangle _form2Position;

        private FileStream _userData;

        //<Snippet5>
        private MyApplicationContext()
        {
            _formCount = 0;

            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            try
            {
                // Create a file that the application will store user specific data in.
                _userData = new FileStream(Application.UserAppDataPath + "\\appdata.txt", FileMode.OpenOrCreate);
            }
            catch (IOException e)
            {
                // Inform the user that an error occurred.
                MessageBox.Show("An error occurred while attempting to show the application." +
                                "The error is:" + e.ToString());

                // Exit the current thread instead of showing the windows.
                ExitThread();
            }

            // Create both application forms and handle the Closed event
            // to know when both forms are closed.
            _form1 = new AppForm1();
            _form1.Closed += new EventHandler(OnFormClosed);
            _form1.Closing += new CancelEventHandler(OnFormClosing);
            _formCount++;

            _form2 = new AppForm2();
            _form2.Closed += new EventHandler(OnFormClosed);
            _form2.Closing += new CancelEventHandler(OnFormClosing);
            _formCount++;

            // Get the form positions based upon the user specific data.
            if (ReadFormDataFromFile())
            {
                // If the data was read from the file, set the form
                // positions manually.
                _form1.StartPosition = FormStartPosition.Manual;
                _form2.StartPosition = FormStartPosition.Manual;

                _form1.Bounds = _form1Position;
                _form2.Bounds = _form2Position;
            }

            // Show both forms.
            _form1.Show();
            _form2.Show();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            // When the application is exiting, write the application data to the
            // user file and close it.
            WriteFormDataToFile();

            try
            {
                // Ignore any errors that might occur while closing the file handle.
                _userData.Close();
            }
            catch { }
        }
        //</Snippet5>

        private void OnFormClosing(object sender, CancelEventArgs e)
        {
            // When a form is closing, remember the form position so it
            // can be saved in the user data file.
            if (sender is AppForm1)
                _form1Position = ((Form)sender).Bounds;
            else if (sender is AppForm2)
                _form2Position = ((Form)sender).Bounds;
        }

        //<Snippet3>
        private void OnFormClosed(object sender, EventArgs e)
        {
            // When a form is closed, decrement the count of open forms.

            // When the count gets to 0, exit the app by calling
            // ExitThread().
            _formCount--;
            if (_formCount == 0)
            {
                ExitThread();
            }
        }
        //</Snippet3>

        private bool WriteFormDataToFile()
        {
            // Write the form positions to the file.
            UTF8Encoding encoding = new UTF8Encoding();

            RectangleConverter rectConv = new RectangleConverter();
            string form1pos = rectConv.ConvertToString(_form1Position);
            string form2pos = rectConv.ConvertToString(_form2Position);

            byte[] dataToWrite = encoding.GetBytes("~" + form1pos + "~" + form2pos);

            try
            {
                // Set the write position to the start of the file and write
                _userData.Seek(0, SeekOrigin.Begin);
                _userData.Write(dataToWrite, 0, dataToWrite.Length);
                _userData.Flush();

                _userData.SetLength(dataToWrite.Length);
                return true;
            }
            catch
            {
                // An error occurred while attempting to write, return false.
                return false;
            }
        }

        private bool ReadFormDataFromFile()
        {
            // Read the form positions from the file.
            UTF8Encoding encoding = new UTF8Encoding();
            string data;

            if (_userData.Length != 0)
            {
                byte[] dataToRead = new byte[_userData.Length];

                try
                {
                    // Set the read position to the start of the file and read.
                    _userData.Seek(0, SeekOrigin.Begin);
                    _userData.Read(dataToRead, 0, dataToRead.Length);
                }
                catch (IOException e)
                {
                    string errorInfo = e.ToString();
                    // An error occurred while attempt to read, return false.
                    return false;
                }

                // Parse out the data to get the window rectangles
                data = encoding.GetString(dataToRead);

                try
                {
                    // Convert the string data to rectangles
                    RectangleConverter rectConv = new RectangleConverter();
                    string form1pos = data.Substring(1, data.IndexOf("~", 1) - 1);

                    _form1Position = (Rectangle)rectConv.ConvertFromString(form1pos);

                    string form2pos = data.Substring(data.IndexOf("~", 1) + 1);
                    _form2Position = (Rectangle)rectConv.ConvertFromString(form2pos);

                    return true;
                }
                catch
                {
                    // Error occurred while attempting to convert the rectangle data.
                    // Return false to use default values.
                    return false;
                }
            }
            else
            {
                // No data in the file, return false to use default values.
                return false;
            }
        }

        //<Snippet4>
        [STAThread]
        static void Main(string[] args)
        {

            // Create the MyApplicationContext, that derives from ApplicationContext,
            // that manages when the application should exit.

            MyApplicationContext context = new MyApplicationContext();

            // Run the application with the specific context. It will exit when
            // all forms are closed.
            Application.Run(context);
        }
        //</Snippet4>
    }
    //</Snippet2>
}
//</Snippet1>
