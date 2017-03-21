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