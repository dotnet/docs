// <snippet1>
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

namespace ITypedListCS
{
    [Serializable()]
    public class SortableBindingList<T> : BindingList<T>, ITypedList
    {
        [NonSerialized()]
        private PropertyDescriptorCollection properties;

        public SortableBindingList() : base()
        {
            // Get the 'shape' of the list. 
            // Only get the public properties marked with Browsable = true.
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(
                typeof(T), 
                new Attribute[] { new BrowsableAttribute(true) });

            // Sort the properties.
            properties = pdc.Sort();
        }

        // <snippet2>
        #region ITypedList Implementation

        // <snippet3>
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            PropertyDescriptorCollection pdc;

            if (listAccessors!=null && listAccessors.Length>0)
            {
                // Return child list shape.
                pdc = ListBindingHelper.GetListItemProperties(listAccessors[0].PropertyType);
            }
            else
            {
                // Return properties in sort order.
                pdc = properties;
            }

            return pdc;
        }
        // </snippet3>

        // <snippet4>
        // This method is only used in the design-time framework 
        // and by the obsolete DataGrid control.
        public string GetListName(PropertyDescriptor[] listAccessors)
        {   
            return typeof(T).Name;
        }
        // </snippet4>

        #endregion
        // </snippet2>
    }
}
// </snippet1>