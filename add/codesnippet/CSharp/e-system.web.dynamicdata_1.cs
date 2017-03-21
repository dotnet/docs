        // Handle the filter change event.
        protected void OnFilterSelectedIndexChanged(object sender, EventArgs e) {
            // Reset the index of the page to display after 
            // the data filter value has been changed.
            GridView1.PageIndex = 0;
            
        }