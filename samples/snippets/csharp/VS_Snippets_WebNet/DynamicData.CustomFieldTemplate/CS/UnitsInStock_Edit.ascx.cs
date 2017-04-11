using System;
// <Snippet4> 
using System.Web.DynamicData;
using System.Collections.Specialized;

public partial class DynamicData_FieldTemplates_UnitsInStock_Edit :  
FieldTemplateUserControl 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.ToolTip = Column.Description;

        // Set the required validation.
        SetUpValidator(RequiredFieldValidator1);
        SetUpValidator(CompareValidator1);

        // This validator is used to customize the
        // data field editing. The range is defined
        // in the Product partial class.
        SetUpValidator(RangeValidator1);

        SetUpValidator(DynamicValidator1);
    }

    protected override void ExtractValues(IOrderedDictionary dictionary)
    {
        // Assign the new value entered by the user.
        dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text);
    }
}
// </Snippet4>