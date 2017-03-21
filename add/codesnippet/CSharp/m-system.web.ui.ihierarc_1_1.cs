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