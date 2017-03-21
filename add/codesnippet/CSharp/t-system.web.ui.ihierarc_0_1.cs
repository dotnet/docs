    public class FileSystemHierarchyData : IHierarchyData
    {
        private FileSystemInfo fileSystemObject = null;

        public FileSystemHierarchyData(FileSystemInfo obj)
        {
            fileSystemObject = obj;
        }

        public override string ToString()
        {
            return fileSystemObject.Name;
        }
        // IHierarchyData implementation.
        public bool HasChildren
        {
            get
            {
                if (typeof(DirectoryInfo) == fileSystemObject.GetType())
                {
                    DirectoryInfo temp = (DirectoryInfo)fileSystemObject;
                    return (temp.GetFileSystemInfos().Length > 0);
                }
                else return false;
            }
        }
        // DirectoryInfo returns the OriginalPath, while FileInfo returns
        // a fully qualified path.
        public string Path
        {
            get
            {
                return fileSystemObject.ToString();
            }
        }
        public object Item
        {
            get
            {
                return fileSystemObject;
            }
        }
        public string Type
        {
            get
            {
                return "FileSystemData";
            }
        }
        public IHierarchicalEnumerable GetChildren()
        {
            FileSystemHierarchicalEnumerable children =
                new FileSystemHierarchicalEnumerable();

            if (typeof(DirectoryInfo) == fileSystemObject.GetType())
            {
                DirectoryInfo temp = (DirectoryInfo)fileSystemObject;
                foreach (FileSystemInfo fsi in temp.GetFileSystemInfos())
                {
                    children.Add(new FileSystemHierarchyData(fsi));
                }
            }
            return children;
        }

        public IHierarchyData GetParent()
        {
            FileSystemHierarchicalEnumerable parentContainer =
                new FileSystemHierarchicalEnumerable();

            if (typeof(DirectoryInfo) == fileSystemObject.GetType())
            {
                DirectoryInfo temp = (DirectoryInfo)fileSystemObject;
                return new FileSystemHierarchyData(temp.Parent);
            }
            else if (typeof(FileInfo) == fileSystemObject.GetType())
            {
                FileInfo temp = (FileInfo)fileSystemObject;
                return new FileSystemHierarchyData(temp.Directory);
            }
            // If FileSystemObj is any other kind of FileSystemInfo, ignore it.
            return null;
        }
    }