    // A transformer that transforms a row to a string.
    [AspNetHostingPermission(SecurityAction.Demand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [WebPartTransformer(typeof(IWebPartRow), typeof(IString))]
    public class RowToStringTransformer : WebPartTransformer, IString
    {

        private IWebPartRow _provider;
        private StringCallback _callback;

        private void GetRowData(object rowData)
        {
            PropertyDescriptorCollection props = _provider.Schema;
            if (props != null && props.Count > 0 && rowData != null)
            {
                string returnValue = String.Empty;
                foreach (PropertyDescriptor prop in props)
                {
                    if (prop != props[0])
                    {
                        returnValue += ", ";
                    }
                    returnValue += prop.DisplayName + ": " + prop.GetValue(rowData);
                }
                _callback(returnValue);
            }
            else
            {
                _callback(null);
            }
        }
        
        public override object Transform(object providerData)
        {
            _provider = (IWebPartRow)providerData;
            return this;
        }

        void IString.GetStringValue(StringCallback callback)
        {
            if (callback == null)
            {
                throw new ArgumentNullException("callback");
            }

            if (_provider != null)
            {
                _callback = callback;
                _provider.GetRowData(new RowCallback(GetRowData));
            }
            else
            {
                callback(null);
            }
        }
    }