//<SnippetHandleExitCODEBEHIND>
using System;
using System.Collections;
using System.Windows;
using System.IO;
using System.IO.IsolatedStorage;

namespace CSharp
{
    public enum ApplicationExitCode
    {
        Success = 0,
        Failure = 1,
        CantWriteToApplicationLog = 2,
        CantPersistApplicationState = 3
    }

    public partial class App : Application
    {
        void App_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                // Write entry to application log
                if (e.ApplicationExitCode == (int)ApplicationExitCode.Success)
                {
                    WriteApplicationLogEntry("Failure", e.ApplicationExitCode);
                }
                else
                {
                    WriteApplicationLogEntry("Success", e.ApplicationExitCode);
                }
            }
            catch
            {
                // Update exit code to reflect failure to write to application log
                e.ApplicationExitCode = (int)ApplicationExitCode.CantWriteToApplicationLog;
            }

            // Persist application state
            try
            {
                PersistApplicationState();
            }
            catch
            {
                // Update exit code to reflect failure to persist application state
                e.ApplicationExitCode = (int)ApplicationExitCode.CantPersistApplicationState;
            }
        }

        void WriteApplicationLogEntry(string message, int exitCode)
        {
            // Write log entry to file in isolated storage for the user
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForAssembly();
            using (Stream stream = new IsolatedStorageFileStream("log.txt", FileMode.Append, FileAccess.Write, store))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                string entry = string.Format("{0}: {1} - {2}", message, exitCode, DateTime.Now);
                writer.WriteLine(entry);
            }
        }

        void PersistApplicationState()
        {
            // Persist application state to file in isolated storage for the user
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForAssembly();
            using (Stream stream = new IsolatedStorageFileStream("state.txt", FileMode.Create, store))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                foreach (DictionaryEntry entry in this.Properties)
                {
                    writer.WriteLine(entry.Value);
                }
            }
        }
    }
}
//</SnippetHandleExitCODEBEHIND>