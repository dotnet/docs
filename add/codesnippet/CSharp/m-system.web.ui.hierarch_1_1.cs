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