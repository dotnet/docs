//<snippet1>
/////////////////////////////////////////////////////////////////////
// Pull model smart tag example.
// Need references to System.dll, System.Windows.Forms.dll, 
// System.Design.dll, and System.Drawing.dll.
/////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Text;
using System.Reflection;


namespace SmartTags
{

public class Form1 : System.Windows.Forms.Form
{
    private ColorLabel colorLabel2;

    public Form1()
    {
        InitializeComponent();
    }

    // VS Forms Designer generated method
    private void InitializeComponent()
    {
        this.colorLabel2 = new SmartTags.ColorLabel();
        this.SuspendLayout();
        // 
        // colorLabel2
        // 
        this.colorLabel2.BackColor = System.Drawing.Color.Gold;
        this.colorLabel2.ColorLocked = false;
        this.colorLabel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.colorLabel2.Location = new System.Drawing.Point(41, 42);
        this.colorLabel2.Name = "colorLabel2";
        this.colorLabel2.Size = new System.Drawing.Size(117, 25);
        this.colorLabel2.TabIndex = 0;
        this.colorLabel2.Text = "colorLabel2";
        // 
        // Form1
        // 
        this.ClientSize = new System.Drawing.Size(292, 273);
        this.Controls.Add(this.colorLabel2);
        this.Name = "Form1";
        this.ResumeLayout(false);

    }

    [STAThread]
    static void Main()
    {
        Form1 f1 = new Form1();
        f1.ShowDialog();
    }


}

/////////////////////////////////////////////////////////////////
// ColorLabel is a simple extension of the standard Label control,
// with color property locking added.
/////////////////////////////////////////////////////////////////
[Designer(typeof(ColorLabelDesigner))]
public class ColorLabel : System.Windows.Forms.Label
{
    private bool colorLockedValue = false;

    public bool ColorLocked
    {
        get
        {
            return colorLockedValue;
        }
        set
        {
            colorLockedValue = value;
        }
    }

    public override Color BackColor
    {
        get
        {
            return base.BackColor;
        }
        set
        {
            if (ColorLocked)
                return;
            else
                base.BackColor = value;
        }
    }

    public override Color ForeColor
    {
        get
        {
            return base.ForeColor;
        }
        set
        {
            if (ColorLocked)
                return;
            else
                base.ForeColor = value;
        }
    }
}

/////////////////////////////////////////////////////////////////
// Designer for the ColorLabel control with support for a smart 
// tag panel.
// Must add reference to System.Design.dll
/////////////////////////////////////////////////////////////////
[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
public class ColorLabelDesigner : 
         System.Windows.Forms.Design.ControlDesigner
{
//<snippet8>
    private DesignerActionListCollection actionLists;
//</snippet8>

    // Use pull model to populate smart tag menu.
//<snippet9>
    public override DesignerActionListCollection ActionLists
    {
        get
        {
            if (null == actionLists)
            {
                actionLists = new DesignerActionListCollection();
                actionLists.Add(
                    new ColorLabelActionList(this.Component));
            }
            return actionLists;
        }
    }
//</snippet9>
}

/////////////////////////////////////////////////////////////////
// DesignerActionList-derived class defines smart tag entries and
// resultant actions.
/////////////////////////////////////////////////////////////////
//<snippet2>
public class ColorLabelActionList :
          System.ComponentModel.Design.DesignerActionList
//</snippet2>
{
//<snippet3>
    private ColorLabel colLabel;
//</snippet3>

    //<snippet10>
    private DesignerActionUIService designerActionUISvc = null;
    //</snippet10>

    //The constructor associates the control 
    //with the smart tag list.
//<snippet4>
    public ColorLabelActionList( IComponent component ) : base(component) 
    {
        this.colLabel = component as ColorLabel;

        // Cache a reference to DesignerActionUIService, so the
        // DesigneractionList can be refreshed.
        this.designerActionUISvc =
            GetService(typeof(DesignerActionUIService))
            as DesignerActionUIService;
    }
//</snippet4>

    // Helper method to retrieve control properties. Use of 
    // GetProperties enables undo and menu updates to work properly.
    private PropertyDescriptor GetPropertyByName(String propName)
    {
        PropertyDescriptor prop;
        prop = TypeDescriptor.GetProperties(colLabel)[propName];
        if (null == prop)
             throw new ArgumentException(
                  "Matching ColorLabel property not found!",
                   propName);
        else
            return prop;
    }

    // Properties that are targets of DesignerActionPropertyItem entries.
    public Color BackColor
    {
        get
        {
            return colLabel.BackColor;
        }
        set
        {
            GetPropertyByName("BackColor").SetValue(colLabel, value);
        }
    }

//<snippet5>
    public Color ForeColor
    {
        get
        {
            return colLabel.ForeColor;
        }
        set
        {
            GetPropertyByName("ForeColor").SetValue(colLabel, value);
        }
    }
//</snippet5>


    //<snippet11>
    // Boolean properties are automatically displayed with binary 
    // UI (such as a checkbox).
    public bool LockColors
    {
        get
        {
            return colLabel.ColorLocked;
        }
        set
        {
            GetPropertyByName("ColorLocked").SetValue(colLabel, value);

            // Refresh the list.
            this.designerActionUISvc.Refresh(this.Component);
        }
    }
    //</snippet11>

    public String Text
    {
        get
        {
            return colLabel.Text;
        }
        set
        {
            GetPropertyByName("Text").SetValue(colLabel, value);
        }
    }

    // Method that is target of a DesignerActionMethodItem
//<snippet6>
    public void InvertColors()
    {
        Color currentBackColor = colLabel.BackColor;
        BackColor = Color.FromArgb(
            255 - currentBackColor.R, 
            255 - currentBackColor.G, 
            255 - currentBackColor.B);

        Color currentForeColor = colLabel.ForeColor;
        ForeColor = Color.FromArgb(
            255 - currentForeColor.R, 
            255 - currentForeColor.G, 
            255 - currentForeColor.B);
    }
//</snippet6>

    // Implementation of this abstract method creates smart tag  
    // items, associates their targets, and collects into list.
//<snippet7>
    public override DesignerActionItemCollection GetSortedActionItems()
    {
        DesignerActionItemCollection items = new DesignerActionItemCollection();

        //Define static section header entries.
        items.Add(new DesignerActionHeaderItem("Appearance"));
        items.Add(new DesignerActionHeaderItem("Information"));

        //Boolean property for locking color selections.
        items.Add(new DesignerActionPropertyItem("LockColors",
                         "Lock Colors", "Appearance",
                         "Locks the color properties."));
        if (!LockColors)
        {
            items.Add(new DesignerActionPropertyItem("BackColor",
                             "Back Color", "Appearance",
                             "Selects the background color."));
            items.Add(new DesignerActionPropertyItem("ForeColor",
                             "Fore Color", "Appearance",
                             "Selects the foreground color."));

            //This next method item is also added to the context menu 
            // (as a designer verb).
            items.Add(new DesignerActionMethodItem(this,
                             "InvertColors", "Invert Colors",
                             "Appearance",
                             "Inverts the fore and background colors.",
                              true));
        }
        items.Add(new DesignerActionPropertyItem("Text",
                         "Text String", "Appearance",
                         "Sets the display text."));

        //Create entries for static Information section.
        StringBuilder location = new StringBuilder("Location: ");
        location.Append(colLabel.Location);
        StringBuilder size = new StringBuilder("Size: ");
        size.Append(colLabel.Size);
        items.Add(new DesignerActionTextItem(location.ToString(),
                         "Information"));
        items.Add(new DesignerActionTextItem(size.ToString(),
                         "Information"));

        return items;
    }
    //</snippet7>
}


}
//</snippet1>
