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