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
    public class AppForm2 : System.Windows.Forms.Form {
        public AppForm2(){ 
            this.Size = new System.Drawing.Size(300,300);
            this.Text = "AppForm2";
        }
    }

    // A simple form that represents a window in our application
    public class AppForm1 : System.Windows.Forms.Form {
        public AppForm1(){ 
            this.Size = new System.Drawing.Size(300,300);
            this.Text = "AppForm1";
        }
    }

    //<Snippet2>
    // The class that handles the creation of the application windows
    class MyApplicationContext : ApplicationContext {
    
        private int formCount;
        private AppForm1 form1;
        private AppForm2 form2;

        private Rectangle form1Position;
        private Rectangle form2Position;

        private FileStream userData;

        //<Snippet5>
        private MyApplicationContext() {
            formCount = 0;

            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            try {
                // Create a file that the application will store user specific data in.
                userData = new FileStream(Application.UserAppDataPath + "\\appdata.txt", FileMode.OpenOrCreate);

            } catch(IOException e) {
                // Inform the user that an error occurred.
                MessageBox.Show("An error occurred while attempting to show the application." + 
                                "The error is:" + e.ToString());

                // Exit the current thread instead of showing the windows.
                ExitThread();
            }

            // Create both application forms and handle the Closed event
            // to know when both forms are closed.
            form1 = new AppForm1();
            form1.Closed += new EventHandler(OnFormClosed);            
            form1.Closing += new CancelEventHandler(OnFormClosing);            
            formCount++;

            form2 = new AppForm2();
            form2.Closed += new EventHandler(OnFormClosed);            
            form2.Closing += new CancelEventHandler(OnFormClosing);            
            formCount++;

            // Get the form positions based upon the user specific data.
            if (ReadFormDataFromFile()) {
                // If the data was read from the file, set the form
                // positions manually.
                form1.StartPosition = FormStartPosition.Manual;
                form2.StartPosition = FormStartPosition.Manual;
                
                form1.Bounds = form1Position;
                form2.Bounds = form2Position;
            }

            // Show both forms.
            form1.Show();
            form2.Show();
        }

        private void OnApplicationExit(object sender, EventArgs e) {
            // When the application is exiting, write the application data to the
            // user file and close it.
            WriteFormDataToFile();

            try {
                // Ignore any errors that might occur while closing the file handle.
                userData.Close();
            } catch {}
        }
        //</Snippet5>

        private void OnFormClosing(object sender, CancelEventArgs e) {
            // When a form is closing, remember the form position so it
            // can be saved in the user data file.
            if (sender is AppForm1) 
                form1Position = ((Form)sender).Bounds;
            else if (sender is AppForm2)
                form2Position = ((Form)sender).Bounds;
        }

        //<Snippet3>
        private void OnFormClosed(object sender, EventArgs e) {
            // When a form is closed, decrement the count of open forms.

            // When the count gets to 0, exit the app by calling
            // ExitThread().
            formCount--;
            if (formCount == 0) {
                ExitThread();
            }
        }
        //</Snippet3>

        private bool WriteFormDataToFile(){
            // Write the form positions to the file.
            UTF8Encoding encoding = new UTF8Encoding();

            RectangleConverter rectConv = new RectangleConverter();
            String form1pos = rectConv.ConvertToString(form1Position);
            String form2pos = rectConv.ConvertToString(form2Position);

            byte[] dataToWrite = encoding.GetBytes("~" + form1pos + "~" + form2pos);

            try {
                // Set the write position to the start of the file and write
                userData.Seek(0,SeekOrigin.Begin);
                userData.Write(dataToWrite, 0, dataToWrite.Length);
                userData.Flush();

                userData.SetLength(dataToWrite.Length);
                return true;

            } catch {
                // An error occurred while attempting to write, return false.
                return false;
            }

        }

        private bool ReadFormDataFromFile(){
            // Read the form positions from the file.
            UTF8Encoding encoding = new UTF8Encoding();
            String data;

            if (userData.Length != 0) {
                byte[] dataToRead = new Byte[userData.Length];

                try {
                    // Set the read position to the start of the file and read.
                    userData.Seek(0, SeekOrigin.Begin);
                    userData.Read(dataToRead, 0, dataToRead.Length);

                } catch (IOException e) {
                    String errorInfo = e.ToString();
                    // An error occurred while attempt to read, return false.
                    return false;
                }

                // Parse out the data to get the window rectangles
                data = encoding.GetString(dataToRead);

                try {
                    // Convert the string data to rectangles
                    RectangleConverter rectConv = new RectangleConverter();
                    String form1pos = data.Substring(1,data.IndexOf("~",1)-1);

                    form1Position = (Rectangle)rectConv.ConvertFromString(form1pos);

                    String form2pos = data.Substring(data.IndexOf("~",1)+1);
                    form2Position = (Rectangle)rectConv.ConvertFromString(form2pos);

                    return true;

                } catch {
                    // Error occurred while attempting to convert the rectangle data.
                    // Return false to use default values.
                    return false;
                }

            } else {
                // No data in the file, return false to use default values.
                return false;
            }
        }        
        
        //<Snippet4>
        [STAThread]
        static void Main(string[] args) {
            
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