    // A collection of FileSystemHierarchyData objects
    public class FileSystemHierarchicalEnumerable :
        ArrayList, IHierarchicalEnumerable
    {
        public FileSystemHierarchicalEnumerable()
            : base()
        {
        }

        public IHierarchyData GetHierarchyData(object enumeratedItem)
        {
            return enumeratedItem as IHierarchyData;
        }
    }
