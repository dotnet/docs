// <Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace DesignerSerializationVisibilityTest
{
    // The code for this user control declares a public property of type DimensionData with a DesignerSerializationVisibility 
    // attribute set to DesignerSerializationVisibility.Content, indicating that the properties of the object should be serialized.

    // The public, not hidden properties of the object that are set at design time will be persisted in the initialization code
    // for the class object. Content persistence will not work for structs without a custom TypeConverter.		

    public class ContentSerializationExampleControl : System.Windows.Forms.UserControl
    {
	private System.ComponentModel.Container components = null;				
	
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DimensionData Dimensions
	{
	    get 
	    {
		return new DimensionData(this);
	    }		
	}

	public ContentSerializationExampleControl()
	{
    	    InitializeComponent();		
	}
		
	protected override void Dispose( bool disposing )
	{
	    if( disposing )
	    {
		if( components != null )
		    components.Dispose();
	    }
	    base.Dispose( disposing );
	}

	private void InitializeComponent()
	{
	    components = new System.ComponentModel.Container();
	}
    }

    [TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    // This attribute indicates that the public properties of this object should be listed in the property grid.
    public class DimensionData
    {		
	private Control owner;

	// This class reads and writes the Location and Size properties from the Control which it is initialized to.
	internal DimensionData(Control owner)
	{
    	    this.owner = owner;			
	}

	public Point Location
	{
	    get
	    {
		return owner.Location;
	    }
	    set
	    {
		owner.Location = value;
	    }
	}

	public Size FormSize
	{
	    get
    	    {
		return owner.Size;
	    }
	    set
	    {
		owner.Size = value;
	    }
	}
    }
}
// </Snippet1>