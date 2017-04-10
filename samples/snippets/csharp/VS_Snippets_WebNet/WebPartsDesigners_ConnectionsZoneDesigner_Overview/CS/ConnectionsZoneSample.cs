//<snippet1>
using System;
using System.Security.Permissions;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.Design.WebControls.WebParts;
using System.ComponentModel;
using System.Collections;

/// <summary>
/// ConnectionsZoneSample provides a blank inheritance of
/// the ConnectionsZone class for the purpose of attaching
/// a custom designer.
/// ConnectionsZoneSampleDesigner shows how to edit the
/// PreFilterProperties() method to hide a specific property
/// at design time.
/// </summary>
namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(ConnectionsZoneSampleDesigner))]
    public class ConnectionsZoneSample : ConnectionsZone {}
    public class ConnectionsZoneSampleDesigner : ConnectionsZoneDesigner
    {
        // Here is the property we will hide.
        string propertyToHide = "BackColor";

        protected override void PreFilterProperties(IDictionary properties)
        {
            // Invoke the base method. This will hide those properties
            // specified in ConnectionsZoneDesigner.
            base.PreFilterProperties(properties);

            // Set attributes to remove it from the property grid and any editors.
            Attribute[] newAttributes = new Attribute[] 
            {   new BrowsableAttribute(false),
                new EditorBrowsableAttribute(EditorBrowsableState.Never)};

            PropertyDescriptor property = (PropertyDescriptor)properties[propertyToHide];
            if (property != null)
            {
                // Re-create the property with the attributes specified above.
                properties[propertyToHide] = TypeDescriptor.CreateProperty(property.ComponentType, property, newAttributes);
            }
        }
    }
}
//</snippet1>