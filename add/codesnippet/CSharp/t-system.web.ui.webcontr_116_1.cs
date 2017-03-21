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