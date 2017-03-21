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