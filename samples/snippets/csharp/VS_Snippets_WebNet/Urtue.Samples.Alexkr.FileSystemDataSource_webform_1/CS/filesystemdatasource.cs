namespace Samples.AspNet
{
    // <Snippet2>
    // <Snippet1>
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class FileSystemDataSource :
        HierarchicalDataSourceControl, IHierarchicalDataSource
    {
        private FileSystemDataSourceView view = null;

        public FileSystemDataSource() : base() { }

        protected override HierarchicalDataSourceView
            GetHierarchicalView(string viewPath)
        {
            view = new FileSystemDataSourceView(viewPath);
            return view;
        }
    }
    // </Snippet1>
    // <Snippet3>
    public class FileSystemDataSourceView : HierarchicalDataSourceView
    {
        private string _viewPath;

        public FileSystemDataSourceView(string viewPath)
        {
            HttpRequest currentRequest = HttpContext.Current.Request;
            if (viewPath == "")
            {
                _viewPath = currentRequest.MapPath(currentRequest.ApplicationPath);
            }
            else
            {
                _viewPath = Path.Combine(
                    currentRequest.MapPath(currentRequest.ApplicationPath),
                    viewPath);
            }
        }

        // Starting with the rootNode, recursively build a list of
        // FileSystemInfo nodes, create FileSystemHierarchyData
        // objects, add them all to the FileSystemHierarchicalEnumerable,
        // and return the list.
        public override IHierarchicalEnumerable Select()
        {
            HttpRequest currentRequest = HttpContext.Current.Request;

            // SECURITY: There are many security issues that can be raised
            // SECURITY: by exposing the file system structure of a Web server
            // SECURITY: to an anonymous user in a limited trust scenario such as
            // SECURITY: a Web page served on an intranet or the Internet.
            // SECURITY: For this reason, the FileSystemDataSource only
            // SECURITY: shows data when the HttpRequest is received
            // SECURITY: from a local Web server. In addition, the data source
            // SECURITY: does not display data to anonymous users.
            if (currentRequest.IsAuthenticated &&
                (currentRequest.UserHostAddress == "127.0.0.1" ||
                 currentRequest.UserHostAddress == "::1"))
            {
                DirectoryInfo rootDirectory = new DirectoryInfo(_viewPath);
                if (!rootDirectory.Exists)
                {
                    return null;
                }

                FileSystemHierarchicalEnumerable fshe =
                    new FileSystemHierarchicalEnumerable();

                foreach (FileSystemInfo fsi
                    in rootDirectory.GetFileSystemInfos())
                {
                    fshe.Add(new FileSystemHierarchyData(fsi));
                }
                return fshe;
            }
            else
            {
                throw new NotSupportedException(
                    "The FileSystemDataSource only " +
                    "presents data in an authenticated, localhost context.");
            }
        }
    }
    // </Snippet3>
    // <Snippet4>
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

    // </Snippet4>
    // <Snippet5>
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
        // <Snippet6>
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
        // </Snippet6>
        // <Snippet7>
        // DirectoryInfo returns the OriginalPath, while FileInfo returns
        // a fully qualified path.
        public string Path
        {
            get
            {
                return fileSystemObject.ToString();
            }
        }
        // </Snippet7>
        // <Snippet8>
        public object Item
        {
            get
            {
                return fileSystemObject;
            }
        }
        // </Snippet8>
        // <Snippet9>
        public string Type
        {
            get
            {
                return "FileSystemData";
            }
        }
        // </Snippet9>
        // <Snippet10>
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
        // </Snippet10>
    }
    // </Snippet5>
    // </Snippet2>
}