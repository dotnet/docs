        private void CheckEveryOther_Click(object sender, System.EventArgs e) {
            // Cycle through every item and check every other.

            // Set flag to true to know when this code is being executed. Used in the ItemCheck
            // event handler.
            insideCheckEveryOther = true;

            for (int i = 0; i < checkedListBox1.Items.Count; i++) {
                // For every other item in the list, set as checked.
                if ((i % 2) == 0) {
                    // But for each other item that is to be checked, set as being in an
                    // indeterminate checked state.
                    if ((i % 4) == 0)
                        checkedListBox1.SetItemCheckState(i, CheckState.Indeterminate);
                    else
                        checkedListBox1.SetItemChecked(i, true);
                }
            }        

            insideCheckEveryOther = false;
        }