// <Snippet1>
namespace Samples.AspNet.Controls.CS {
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Security.Permissions;
    using System.Web;
    using System.Web.UI;

    //
    // csc /t:library /out:Samples.AspNet.Controls.CS.dll SomeDataSource.cs
    //
    [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
    public class SomeDataSource : IDataSource, IListSource
    {
        public SomeDataSource() : base() {}

        private SomeDataSourceView view = null;
// <Snippet2>
        #region Implementation of IDataSource

        public virtual DataSourceView GetView(string viewName) {
            if (null == view) {
                view = new SomeDataSourceView(this);
            }
            return view;
        }

        public virtual ICollection GetViewNames() {
            ArrayList al = new ArrayList(1);
            al.Add(GetView(String.Empty).Name);
            return al as ICollection;
        }

        event EventHandler IDataSource.DataSourceChanged {
            add {
                ((IDataSource)this).DataSourceChanged += value;
            }
            remove {
                ((IDataSource)this).DataSourceChanged -= value;
            }
        }

        #endregion
// <Snippet3>
        #region Implementation of IListSource

        bool IListSource.ContainsListCollection {
            get {
                return ListSourceHelper.ContainsListCollection(this);
            }
        }

        IList IListSource.GetList() {
            return ListSourceHelper.GetList(this);
        }

        #endregion
// </Snippet3>
// </Snippet2>
    }

    public class SomeDataSourceView : DataSourceView
    {
        private static string defaultViewName = "_SomeDataSourceView" ;

        public SomeDataSourceView(IDataSource owner) : base (owner, defaultViewName) {
        }

        protected override IEnumerable ExecuteSelect(DataSourceSelectArguments selectArguments) {
            return null;
        }
    }
}
// </Snippet1>