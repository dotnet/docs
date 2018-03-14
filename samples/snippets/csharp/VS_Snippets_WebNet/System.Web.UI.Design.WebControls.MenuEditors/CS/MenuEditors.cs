// MenuEditors.cs
// <snippet1>
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Security.Permissions;
using System.Drawing.Design;

namespace Examples.CS.WebControls.Design
{
    // The MyMenuControl has some properties of the Menu.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class MyMenuControl : WebControl
    {
        // <snippet2>
        private MenuItemBindingCollection localBindings;

        // Associate the MenuBindingsEditor with the DataBindings. 
        [Editor(typeof(System.Web.UI.Design.WebControls.MenuBindingsEditor),
            typeof(UITypeEditor))]
        public MenuItemBindingCollection DataBindings
        {
            get { return localBindings; }
            set { localBindings = value; }
        } // DataBindings
        // </snippet2>

        // <snippet3>
        private MenuItemCollection menuItems;

        // Associate the MenuItemCollectionEditor with the Items. 
        [Editor(typeof(System.Web.UI.Design.WebControls.
            MenuItemCollectionEditor),
            typeof(UITypeEditor))]
        public MenuItemCollection Items
        {
            get
            {
                // If there is no menuItems collection, create it.
                if (menuItems == null)
                    menuItems = new MenuItemCollection();

                return menuItems;
            }
            set { menuItems = value; }
        } // Items
        // </snippet3>

        // <snippet4>
        private MenuItemStyleCollection menuItemStyles;

        // Associate the MenuItemStyleCollectionEditor with the 
        // LevelMenuItemStyles. 
        [Editor(typeof(System.Web.UI.Design.WebControls.
            MenuItemStyleCollectionEditor),
            typeof(UITypeEditor))]
        public MenuItemStyleCollection LevelMenuItemStyles
        {
            get { return menuItemStyles; }
            set { menuItemStyles = value; }
        } // LevelMenuItemStyles
        // </snippet4>

        // <snippet5>
        private SubMenuStyleCollection subMenuStyles;

        // Associate the SubMenuStyleCollectionEditor with the 
        // LevelSubMenuStyles. 
        [Editor(typeof(System.Web.UI.Design.WebControls.
            SubMenuStyleCollectionEditor),
            typeof(UITypeEditor))]
        public SubMenuStyleCollection LevelSubMenuStyles
        {
            get { return subMenuStyles; }
            set { subMenuStyles = value; }
        } // LevelSubMenuStyles
        // </snippet5>

    } // MyMenuControl
} // Examples.CS.WebControls.Design
// </snippet1>

