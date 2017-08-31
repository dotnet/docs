using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.IO;

namespace LINQAndFiles
{
    //<snippet1>
    class FindFileByExtension
    {
        // This query will produce the full path for all .txt files
        // under the specified folder including subfolders.
        // It orders the list according to the file name.
        static void Main()
        {
            string startFolder = @"c:\program files\Microsoft Visual Studio 9.0\";

            // Take a snapshot of the file system.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

            // This method assumes that the application has discovery permissions
            // for all folders under the specified path.
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            //Create the query
            IEnumerable<System.IO.FileInfo> fileQuery =
                from file in fileList
                where file.Extension == ".txt"
                orderby file.Name
                select file;

            //Execute the query. This might write out a lot of files!
            foreach (System.IO.FileInfo fi in fileQuery)
            {
                Console.WriteLine(fi.FullName);
            }

            // Create and execute a new query by using the previous 
            // query as a starting point. fileQuery is not 
            // executed again until the call to Last()
            var newestFile =
                (from file in fileQuery
                 orderby file.CreationTime
                 select new { file.FullName, file.CreationTime })
                .Last();

            Console.WriteLine("\r\nThe newest .txt file is {0}. Creation time: {1}",
                newestFile.FullName, newestFile.CreationTime);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
    //</snippet1>

    
    //<snippet2>
    class QuerySize
    {
        public static void Main()
        {
            string startFolder = @"c:\program files\Microsoft Visual Studio 9.0\VC#";

            // Take a snapshot of the file system.
            // This method assumes that the application has discovery permissions
            // for all folders under the specified path.
            IEnumerable<string> fileList = System.IO.Directory.GetFiles(startFolder, "*.*", System.IO.SearchOption.AllDirectories);

            var fileQuery = from file in fileList
                            select GetFileLength(file);

            // Cache the results to avoid multiple trips to the file system.
            long[] fileLengths = fileQuery.ToArray();

            // Return the size of the largest file
            long largestFile = fileLengths.Max();

            // Return the total number of bytes in all the files under the specified folder.
            long totalBytes = fileLengths.Sum();

            Console.WriteLine("There are {0} bytes in {1} files under {2}",
                totalBytes, fileList.Count(), startFolder);
            Console.WriteLine("The largest files is {0} bytes.", largestFile);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // This method is used to swallow the possible exception
        // that can be raised when accessing the System.IO.FileInfo.Length property.
        static long GetFileLength(string filename)
        {
            long retval;
            try
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(filename);
                retval = fi.Length;
            }
            catch (System.IO.FileNotFoundException)
            {
                // If a file is no longer present,
                // just add zero bytes to the total.
                retval = 0;
            }
            return retval;
        }
    }
    //</snippet2>

    //<snippet3>
    class QueryBySize
    {
        static void Main(string[] args)
        {
            QueryFilesBySize();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void QueryFilesBySize()
        {
            string startFolder = @"c:\program files\Microsoft Visual Studio 9.0\";

            // Take a snapshot of the file system.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

            // This method assumes that the application has discovery permissions
            // for all folders under the specified path.
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            //Return the size of the largest file
            long maxSize =
                (from file in fileList
                 let len = GetFileLength(file)
                 select len)
                 .Max();

            Console.WriteLine("The length of the largest file under {0} is {1}",
                startFolder, maxSize);

            // Return the FileInfo object for the largest file
            // by sorting and selecting from beginning of list
            System.IO.FileInfo longestFile =
                (from file in fileList
                 let len = GetFileLength(file)
                 where len > 0
                 orderby len descending
                 select file)
                .First();

            Console.WriteLine("The largest file under {0} is {1} with a length of {2} bytes",
                                startFolder, longestFile.FullName, longestFile.Length);

            //Return the FileInfo of the smallest file
            System.IO.FileInfo smallestFile =
                (from file in fileList
                 let len = GetFileLength(file)
                 where len > 0
                 orderby len ascending
                 select file).First();

            Console.WriteLine("The smallest file under {0} is {1} with a length of {2} bytes",
                                startFolder, smallestFile.FullName, smallestFile.Length);

            //Return the FileInfos for the 10 largest files
            // queryTenLargest is an IEnumerable<System.IO.FileInfo>
            var queryTenLargest =
                (from file in fileList
                 let len = GetFileLength(file)
                 orderby len descending
                 select file).Take(10);

            Console.WriteLine("The 10 largest files under {0} are:", startFolder);

            foreach (var v in queryTenLargest)
            {
                Console.WriteLine("{0}: {1} bytes", v.FullName, v.Length);
            }


            // Group the files according to their size, leaving out
            // files that are less than 200000 bytes. 
            var querySizeGroups =
                from file in fileList
                let len = GetFileLength(file)
                where len > 0
                group file by (len / 100000) into fileGroup
                where fileGroup.Key >= 2
                orderby fileGroup.Key descending
                select fileGroup;


            foreach (var filegroup in querySizeGroups)
            {
                Console.WriteLine(filegroup.Key.ToString() + "00000");
                foreach (var item in filegroup)
                {
                    Console.WriteLine("\t{0}: {1}", item.Name, item.Length);
                }
            }
        }

        // This method is used to swallow the possible exception
        // that can be raised when accessing the FileInfo.Length property.
        // In this particular case, it is safe to swallow the exception.
        static long GetFileLength(System.IO.FileInfo fi)
        {
            long retval;
            try
            {
                retval = fi.Length;
            }
            catch (System.IO.FileNotFoundException)
            {
                // If a file is no longer present,
                // just add zero bytes to the total.
                retval = 0;
            }
            return retval;
        }

    }
    //</snippet3>

    //<snippet4>
    namespace QueryCompareTwoDirs
    {
        class CompareDirs
        {

            static void Main(string[] args)
            {

                // Create two identical or different temporary folders 
                // on a local drive and change these file paths.
                string pathA = @"C:\TestDir";
                string pathB = @"C:\TestDir2";

                System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(pathA);
                System.IO.DirectoryInfo dir2 = new System.IO.DirectoryInfo(pathB);

                // Take a snapshot of the file system.
                IEnumerable<System.IO.FileInfo> list1 = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
                IEnumerable<System.IO.FileInfo> list2 = dir2.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

                //A custom file comparer defined below
                FileCompare myFileCompare = new FileCompare();

                // This query determines whether the two folders contain
                // identical file lists, based on the custom file comparer
                // that is defined in the FileCompare class.
                // The query executes immediately because it returns a bool.
                bool areIdentical = list1.SequenceEqual(list2, myFileCompare);

                if (areIdentical == true)
                {
                    Console.WriteLine("the two folders are the same");
                }
                else
                {
                    Console.WriteLine("The two folders are not the same");
                }

                // Find the common files. It produces a sequence and doesn't 
                // execute until the foreach statement.
                var queryCommonFiles = list1.Intersect(list2, myFileCompare);

                if (queryCommonFiles.Count() > 0)
                {
                    Console.WriteLine("The following files are in both folders:");
                    foreach (var v in queryCommonFiles)
                    {
                        Console.WriteLine(v.FullName); //shows which items end up in result list
                    }
                }
                else
                {
                    Console.WriteLine("There are no common files in the two folders.");
                }

                // Find the set difference between the two folders.
                // For this example we only check one way.
                var queryList1Only = (from file in list1
                                      select file).Except(list2, myFileCompare);

                Console.WriteLine("The following files are in list1 but not list2:");
                foreach (var v in queryList1Only)
                {
                    Console.WriteLine(v.FullName);
                }

                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        // This implementation defines a very simple comparison
        // between two FileInfo objects. It only compares the name
        // of the files being compared and their length in bytes.
        class FileCompare : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
        {
            public FileCompare() { }

            public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
            {
                return (f1.Name == f2.Name &&
                        f1.Length == f2.Length);
            }

            // Return a hash that reflects the comparison criteria. According to the 
            // rules for IEqualityComparer<T>, if Equals is true, then the hash codes must
            // also be equal. Because equality as defined here is a simple value equality, not
            // reference identity, it is possible that two or more objects will produce the same
            // hash code.
            public int GetHashCode(System.IO.FileInfo fi)
            {
                string s = String.Format("{0}{1}", fi.Name, fi.Length);
                return s.GetHashCode();
            }
        }
    }
    //</snippet4>

    //<snippet5>
    class GroupByExtension
    {
        // This query will sort all the files under the specified folder
        //  and subfolder into groups keyed by the file extension.
        private static void Main()
        {
            // Take a snapshot of the file system.
            string startFolder = @"c:\program files\Microsoft Visual Studio 9.0\Common7";

            // Used in WriteLine to trim output lines.
            int trimLength = startFolder.Length;

            // Take a snapshot of the file system.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

            // This method assumes that the application has discovery permissions
            // for all folders under the specified path.
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            // Create the query.
            var queryGroupByExt =
                from file in fileList
                group file by file.Extension.ToLower() into fileGroup
                orderby fileGroup.Key
                select fileGroup;

            // Display one group at a time. If the number of 
            // entries is greater than the number of lines
            // in the console window, then page the output.
            PageOutput(trimLength, queryGroupByExt);
        }

        // This method specifically handles group queries of FileInfo objects with string keys.
        // It can be modified to work for any long listings of data. Note that explicit typing
        // must be used in method signatures. The groupbyExtList parameter is a query that produces
        // groups of FileInfo objects with string keys.
        private static void PageOutput(int rootLength,
                                        IEnumerable<System.Linq.IGrouping<string, System.IO.FileInfo>> groupByExtList)
        {
            // Flag to break out of paging loop.
            bool goAgain = true;

            // "3" = 1 line for extension + 1 for "Press any key" + 1 for input cursor.
            int numLines = Console.WindowHeight - 3;

            // Iterate through the outer collection of groups.
            foreach (var filegroup in groupByExtList)
            {
                // Start a new extension at the top of a page.
                int currentLine = 0;

                // Output only as many lines of the current group as will fit in the window.
                do
                {
                    Console.Clear();
                    Console.WriteLine(filegroup.Key == String.Empty ? "[none]" : filegroup.Key);

                    // Get 'numLines' number of items starting at number 'currentLine'.
                    var resultPage = filegroup.Skip(currentLine).Take(numLines);

                    //Execute the resultPage query
                    foreach (var f in resultPage)
                    {
                        Console.WriteLine("\t{0}", f.FullName.Substring(rootLength));
                    }

                    // Increment the line counter.
                    currentLine += numLines;

                    // Give the user a chance to escape.
                    Console.WriteLine("Press any key to continue or the 'End' key to break...");
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.End)
                    {
                        goAgain = false;
                        break;
                    }
                } while (currentLine < filegroup.Count());

                if (goAgain == false)
                    break;
            }
        }
    }
    //</snippet5>


    //<snippet6>
    class QueryDuplicateFileNames
    {
        static void Main(string[] args)
        {
            // Uncomment QueryDuplicates2 to run that query.
            QueryDuplicates();
            // QueryDuplicates2();

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void QueryDuplicates()
        {
            // Change the root drive or folder if necessary
            string startFolder = @"c:\program files\Microsoft Visual Studio 9.0\";

            // Take a snapshot of the file system.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

            // This method assumes that the application has discovery permissions
            // for all folders under the specified path.
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            // used in WriteLine to keep the lines shorter
            int charsToSkip = startFolder.Length;

            // var can be used for convenience with groups.
            var queryDupNames =
                from file in fileList
                group file.FullName.Substring(charsToSkip) by file.Name into fileGroup
                where fileGroup.Count() > 1
                select fileGroup;

            // Pass the query to a method that will
            // output one page at a time.
            PageOutput<string, string>(queryDupNames);
        }

        // A Group key that can be passed to a separate method.
        // Override Equals and GetHashCode to define equality for the key.
        // Override ToString to provide a friendly name for Key.ToString()
        class PortableKey
        {
            public string Name { get; set; }
            public DateTime CreationTime { get; set; }
            public long Length { get; set; }

            public override bool Equals(object obj)
            {
                PortableKey other = (PortableKey)obj;
                return other.CreationTime == this.CreationTime &&
                       other.Length == this.Length &&
                       other.Name == this.Name;
            }

            public override int GetHashCode()
            {
                string str = String.Format("{0}{1}{2}", this.CreationTime, this.Length, this.Name);
                return str.GetHashCode();
            }
            public override string ToString()
            {
                return String.Format("{0} {1} {2}", this.Name, this.Length, this.CreationTime);
            }
        }
        static void QueryDuplicates2()
        {
            // Change the root drive or folder if necessary.
            string startFolder = @"c:\program files\Microsoft Visual Studio 9.0\Common7";

            // Make the the lines shorter for the console display
            int charsToSkip = startFolder.Length;

            // Take a snapshot of the file system.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            // Note the use of a compound key. Files that match
            // all three properties belong to the same group.
            // A named type is used to enable the query to be
            // passed to another method. Anonymous types can also be used
            // for composite keys but cannot be passed across method boundaries
            // 
            var queryDupFiles =
                from file in fileList
                group file.FullName.Substring(charsToSkip) by
                    new PortableKey { Name = file.Name, CreationTime = file.CreationTime, Length = file.Length } into fileGroup
                where fileGroup.Count() > 1
                select fileGroup;

            var list = queryDupFiles.ToList();

            int i = queryDupFiles.Count();

            PageOutput<PortableKey, string>(queryDupFiles);
        }


        // A generic method to page the output of the QueryDuplications methods
        // Here the type of the group must be specified explicitly. "var" cannot
        // be used in method signatures. This method does not display more than one
        // group per page.
        private static void PageOutput<K, V>(IEnumerable<System.Linq.IGrouping<K, V>> groupByExtList)
        {
            // Flag to break out of paging loop.
            bool goAgain = true;

            // "3" = 1 line for extension + 1 for "Press any key" + 1 for input cursor.
            int numLines = Console.WindowHeight - 3;

            // Iterate through the outer collection of groups.
            foreach (var filegroup in groupByExtList)
            {
                // Start a new extension at the top of a page.
                int currentLine = 0;

                // Output only as many lines of the current group as will fit in the window.
                do
                {
                    Console.Clear();
                    Console.WriteLine("Filename = {0}", filegroup.Key.ToString() == String.Empty ? "[none]" : filegroup.Key.ToString());

                    // Get 'numLines' number of items starting at number 'currentLine'.
                    var resultPage = filegroup.Skip(currentLine).Take(numLines);

                    //Execute the resultPage query
                    foreach (var fileName in resultPage)
                    {
                        Console.WriteLine("\t{0}", fileName);
                    }

                    // Increment the line counter.
                    currentLine += numLines;

                    // Give the user a chance to escape.
                    Console.WriteLine("Press any key to continue or the 'End' key to break...");
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.End)
                    {
                        goAgain = false;
                        break;
                    }
                } while (currentLine < filegroup.Count());

                if (goAgain == false)
                    break;
            }
        }
    }
    //</snippet6>

    //<snippet7>
    class QueryContents
    {
        public static void Main()
        {
            // Modify this path as necessary.
            string startFolder = @"c:\program files\Microsoft Visual Studio 9.0\";

            // Take a snapshot of the file system.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

            // This method assumes that the application has discovery permissions
            // for all folders under the specified path.
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            string searchTerm = @"Visual Studio";

            // Search the contents of each file.
            // A regular expression created with the RegEx class
            // could be used instead of the Contains method.
            // queryMatchingFiles is an IEnumerable<string>.
            var queryMatchingFiles =
                from file in fileList
                where file.Extension == ".htm"
                let fileText = GetFileText(file.FullName)
                where fileText.Contains(searchTerm)
                select file.FullName;

            // Execute the query.
            Console.WriteLine("The term \"{0}\" was found in:", searchTerm);
            foreach (string filename in queryMatchingFiles)
            {
                Console.WriteLine(filename);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        // Read the contents of the file.
        static string GetFileText(string name)
        {
            string fileContents = String.Empty;

            // If the file has been deleted since we took 
            // the snapshot, ignore it and return the empty string.
            if (System.IO.File.Exists(name))
            {
                fileContents = System.IO.File.ReadAllText(name);
            }
            return fileContents;
        }
    }
    //</snippet7>
}

/*
 *   //<sn> old version of snippet 5 that had no paging
    class GroupByExtension
    {
        // This query will sort all the files under the specified folder
        //  and subfolder into groups keyed by the file extension.
        private static void Main()
        {
            // Take a snapshot of the file system.
            string startFolder = @"c:\program files\Microsoft Visual Studio 9.0\";

            // Used in WriteLine to skip over startfolder in output lines
            int rootLength = startFolder.Length;

            // Take a snapshot of the file system.
            IEnumerable<FileInfo> fileList = GetFiles(startFolder);

            //Create the query
            var queryGroupByExt = 
                from file in fileList
                group file by file.Extension.ToLower() into fileGroup
                orderby fileGroup.Key
                select fileGroup;           

            // Page the output. This is complicated by the fact that
            // our list itself contains lists.
            var groupByExtList = queryGroupByExt.ToList();

            const int numLines = Console.WindowHeight;
            int current = 0;
            do {

                var resultPage = groupByExtList.Skip(current).Take(numLines);
                current += numLines;
                Console.ReadKey();
            } while ( current < groupByExtList.Count());

            // Execute a group query with a nested foreach statement.
            // Note that "group" is not a keyword outside the context of a query.
            foreach (var extGroup in queryGroupByExt)
            {
                Console.WriteLine("Ext: {0}", extGgroup.Key);
                int counter = 0;
                foreach (var item in extGgroup)
                {
                    //keep the output lines short
                    Console.WriteLine("\t{0}", item.FullName.Substring(rootLength));
                    counter++;
                    //Page the output
                    if (counter > 30)
                    {
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        counter = 0;
                    }
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

       // This method assumes that the application has discovery 
       // permissions for all folders under the specified path.
        static IEnumerable<FileInfo> GetFiles(string path)
        {
            if (!System.IO.Directory.Exists(path))
                throw new System.IO.DirectoryNotFoundException();
          
            string[] fileNames = null;
            List<FileInfo> files = new List<FileInfo>();
                  
            fileNames = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories);            
            foreach (string name in fileNames)
            {
                files.Add(new FileInfo(name));
            }
            return files;
            }
        }
    //sn5
 * */

