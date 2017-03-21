        private void button1_Click(object sender, EventArgs e)
        {
            // If items remain in the list, remove the first item. 
            if (states.Count > 0)
            {
                states.RemoveAt(0);

                // Call ResetBindings to update the textboxes.
                bindingSource1.ResetBindings(false);
            }
        }