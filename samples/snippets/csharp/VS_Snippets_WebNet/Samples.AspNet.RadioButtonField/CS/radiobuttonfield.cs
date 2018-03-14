// <Snippet1>
namespace Samples.AspNet.CS {

  using System;
  using System.Collections;
  using System.Collections.Specialized;
  using System.ComponentModel;
  using System.Security.Permissions;
  using System.Web;
  using System.Web.UI;
  using System.Web.UI.WebControls;

  [AspNetHostingPermission(SecurityAction.Demand, 
      Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class RadioButtonField : CheckBoxField {

    public RadioButtonField() {
    }

    // Gets a default value for a basic design-time experience. 
    // Since it would look odd, even at design time, to have 
    // more than one radio button selected, make sure that none
    // are selected.
    protected override object GetDesignTimeValue() {
        return false;
    }
// <Snippet2>
    // This method is called by the ExtractRowValues methods of 
    // GridView and DetailsView. Retrieve the current value of the 
    // cell from the Checked state of the Radio button.
    public override void ExtractValuesFromCell(IOrderedDictionary dictionary,
                                               DataControlFieldCell cell,
                                               DataControlRowState rowState,
                                               bool includeReadOnly)
    {

      // Determine whether the cell contains a RadioButton 
      // in its Controls collection.
      if (cell.Controls.Count > 0) {
        RadioButton radio = cell.Controls[0] as RadioButton;

        object checkedValue = null;
        if (null == radio) {
          // A RadioButton is expected, but a null is encountered.
          // Add error handling.
          throw new InvalidOperationException
              ("RadioButtonField could not extract control.");
        }
        else {
            checkedValue = radio.Checked;
        }


        // Add the value of the Checked attribute of the
        // RadioButton to the dictionary.
        if (dictionary.Contains(DataField))
          dictionary[DataField] = checkedValue;
        else
          dictionary.Add(DataField, checkedValue);
      }
    }
// </Snippet2>
// <Snippet3>
    // This method adds a RadioButton control and any other 
    // content to the cell's Controls collection.
    protected override void InitializeDataCell
        (DataControlFieldCell cell, DataControlRowState rowState) {

      RadioButton radio = new RadioButton();

      // If the RadioButton is bound to a DataField, add
      // the OnDataBindingField method event handler to the
      // DataBinding event.
      if (DataField.Length != 0) {
        radio.DataBinding += new EventHandler(this.OnDataBindField);
      }

      radio.Text = this.Text;

      // Because the RadioButtonField is a BoundField, it only
      // displays data. Therefore, unless the row is in edit mode,
      // the RadioButton is displayed as disabled.
      radio.Enabled = false;
      // If the row is in edit mode, enable the button.
      if ((rowState & DataControlRowState.Edit) != 0 ||
          (rowState & DataControlRowState.Insert) != 0) {
        radio.Enabled = true;
      }

      cell.Controls.Add(radio);
    }
// </Snippet3>
  }
}
// </Snippet1>