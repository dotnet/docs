                // Override the OnLoad method to check if the 
                // page that uses this control has posted back.
                // If so, check whether this controls contains
                // only literal content, and if it does,
                // it gets the UniqueID property and writes it
                // to the page. Otherwise, it writes a message
                // that the control contains more than literal content.
                protected override void OnLoad(EventArgs e)
                {
                        if (Page.IsPostBack)
                        {
                                String s;

                                if (this.IsLiteralContent())
                                {
                                        s = Controls[0].UniqueID;
                                        Context.Response.Write(s);
                                }
                                else
                                {
                                        Context.Response.Write(
                                                "The control contains more than literal content.");
                                }
                        }
                }