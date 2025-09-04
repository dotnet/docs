using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EventSampleCode
{
    /// <summary>
    /// The main program class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            var lister = new FileSearcher();
            int filesFound = 0;

            EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs.FoundFile);
                filesFound++;
                //eventArgs.CancelRequested = true;
            };

            lister.FileFound += onFileFound;

            lister.DirectoryChanged += (sender, eventArgs) =>
            {
                Console.Write($"Entering '{eventArgs.CurrentSearchDirectory}'.");
                Console.WriteLine($" {eventArgs.CompletedDirs} of {eventArgs.TotalDirs} completed...");
            };

            lister.Search(".", "*.dll", true);

            lister.FileFound -= onFileFound;
        }
    }

    /// <summary>
    /// Provides data for the <see cref="FileSearcher.FileFound"/> event.
    /// </summary>
    public class FileFoundArgs : EventArgs
    {
        /// <summary>
        /// The name of the found file.
        /// </summary>
        public string FoundFile { get; }
        /// <summary>
        /// Gets or sets a value indicating whether the search should be canceled.
        /// </summary>
        public bool CancelRequested { get; set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="FileFoundArgs"/> class.
        /// </summary>
        /// <param name="fileName">The name of the found file.</param>
        public FileFoundArgs(string fileName)
        {
            FoundFile = fileName;
        }
    }

    /// <summary>
    /// Provides data for the <see cref="FileSearcher.DirectoryChanged"/> event.
    /// </summary>
    internal struct SearchDirectoryArgs 
    {
        /// <summary>
        /// The current directory being searched.
        /// </summary>
        internal string CurrentSearchDirectory { get; }
        /// <summary>
        /// The total number of directories to search.
        /// </summary>
        internal int TotalDirs { get; }
        /// <summary>
        /// The number of directories that have been searched.
        /// </summary>
        internal int CompletedDirs { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchDirectoryArgs"/> struct.
        /// </summary>
        /// <param name="dir">The current directory being searched.</param>
        /// <param name="totalDirs">The total number of directories to search.</param>
        /// <param name="completedDirs">The number of directories that have been searched.</param>
        internal SearchDirectoryArgs(string dir, int totalDirs, int completedDirs)
        {
            CurrentSearchDirectory = dir;
            TotalDirs = totalDirs;
            CompletedDirs = completedDirs;
        }
    }

    /// <summary>
    /// Searches for files in a directory.
    /// </summary>
    public class FileSearcher
    {
        /// <summary>
        /// Occurs when a file is found.
        /// </summary>
        public event EventHandler<FileFoundArgs> FileFound;
        internal event EventHandler<SearchDirectoryArgs> DirectoryChanged
        {
            add { directoryChanged += value; }
            remove { directoryChanged -= value; }
        }
        private EventHandler<SearchDirectoryArgs> directoryChanged;

        /// <summary>
        /// Searches for files in a directory.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <param name="searchPattern">The search string to match against the names of files in <paramref name="directory"/>.</param>
        /// <param name="searchSubDirs">Specifies whether to search subdirectories.</param>
        public void Search(string directory, string searchPattern, bool searchSubDirs = false)
        {
            if (searchSubDirs)
            {
                var allDirectories = Directory.GetDirectories(directory, "*.*", SearchOption.AllDirectories);
                var completedDirs = 0;
                var totalDirs = allDirectories.Length + 1;
                foreach (var dir in allDirectories)
                {
                    directoryChanged?.Invoke(this,
                        new SearchDirectoryArgs(dir, totalDirs, completedDirs++));
                    // Recursively search this child directory:
                    SearchDirectory(dir, searchPattern);
                }
                // Include the Current Directory:
                directoryChanged?.Invoke(this,
                    new SearchDirectoryArgs(directory, totalDirs, completedDirs++));
                SearchDirectory(directory, searchPattern);
            }
            else
            {
                SearchDirectory(directory, searchPattern);
            }
        }

        private void SearchDirectory(string directory, string searchPattern)
        {
            foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
            {
                var args = new FileFoundArgs(file);
                FileFound?.Invoke(this, args);
                if (args.CancelRequested)
                    break;
            }
        }
    }
}
