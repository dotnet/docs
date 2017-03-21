            // Determine the foreground color.
            if ((e.State & DataGridViewElementStates.Selected) ==
                DataGridViewElementStates.Selected)
            {
                forebrush = new SolidBrush(e.InheritedRowStyle.SelectionForeColor);
            }
            else
            {
                forebrush = new SolidBrush(e.InheritedRowStyle.ForeColor);
            }