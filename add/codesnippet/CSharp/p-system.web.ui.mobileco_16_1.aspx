    void Form_Paginated(object sender, EventArgs e)
    {
        // Set the background color based on 
        // the number of pages
        if (ActiveForm.PageCount > 1)
            ActiveForm.BackColor = Color.LightBlue;
        else
            ActiveForm.BackColor = Color.LightGray;

        // Check to see if the Footer template has been chosen
        if (DevSpec.HasTemplates)
        {   
            System.Web.UI.MobileControls.Label lbl = null;
            
            // Get the Footer panel
            System.Web.UI.MobileControls.Panel pan = Form1.Footer;

            // Get the Label from the panel
            lbl = (System.Web.UI.MobileControls.Label)pan.FindControl("lblCount");
            // Set the text in the Label
            lbl.Text = "Page #" + Form1.CurrentPage.ToString();
        }
    }