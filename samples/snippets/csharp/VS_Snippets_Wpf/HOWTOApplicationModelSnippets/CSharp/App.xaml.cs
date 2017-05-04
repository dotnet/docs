//<SnippetPersistRestoreAppScopePropertiesCODEBEHIND1>
//<SnippetPersistAppScopePropertiesCODEBEHIND1>
using System.Windows;
using System.IO;
using System.IO.IsolatedStorage;

namespace SDKSample
{
    public partial class App : Application
    {
        string filename = "App.txt";

        //</SnippetPersistAppScopePropertiesCODEBEHIND1>
        //</SnippetPersistRestoreAppScopePropertiesCODEBEHIND1>
        public App()
        {
            // Initialize application-scope property
            this.Properties["NumberOfAppSessions"] = 0;
        }

        //<SnippetPersistRestoreAppScopePropertiesCODEBEHIND2>
        private void App_Startup(object sender, StartupEventArgs e)
        {
            // Restore application-scope property from isolated storage
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForDomain();
            try
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(filename, FileMode.Open, storage))
                using (StreamReader reader = new StreamReader(stream))
                {
                    // Restore each application-scope property individually
                    while (!reader.EndOfStream)
                    {
                        string[] keyValue = reader.ReadLine().Split(new char[] {','});
                        this.Properties[keyValue[0]] = keyValue[1];
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                // Handle when file is not found in isolated storage:
                // * When the first application session
                // * When file has been deleted
                //</SnippetPersistRestoreAppScopePropertiesCODEBEHIND2>
                //<SnippetPersistRestoreAppScopePropertiesCODEBEHIND3>
            }
        }

        //<SnippetPersistAppScopePropertiesCODEBEHIND2>
        private void App_Exit(object sender, ExitEventArgs e)
        {
            // Persist application-scope property to isolated storage
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForDomain();
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(filename, FileMode.Create, storage))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                // Persist each application-scope property individually
                foreach (string key in this.Properties.Keys)
                {
                    writer.WriteLine("{0},{1}", key, this.Properties[key]);
                }
            }
        }
    }
}
//</SnippetPersistAppScopePropertiesCODEBEHIND2>
//</SnippetPersistRestoreAppScopePropertiesCODEBEHIND3>