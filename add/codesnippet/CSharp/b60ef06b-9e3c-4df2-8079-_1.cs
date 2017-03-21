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