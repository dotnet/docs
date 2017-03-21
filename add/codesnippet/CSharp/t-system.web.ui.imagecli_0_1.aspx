      // Define the event handler that uses coordinate information through ImageClickEventArgs.
      void ImageButton_Click(object sender, ImageClickEventArgs e) 
      {
         Label1.Text = "You clicked the ImageButton control at the coordinates: (" + 
                       e.X.ToString() + ", " + e.Y.ToString() + ")";
      }