		    // Applies styles based on the Name of the AutoFormat
            public override void Apply(Control inLabel)
            {
                if (inLabel is IndentLabel)
                {
                    IndentLabel ctl = (IndentLabel)inLabel;

				    // Apply formatting according to the Name
                    if (this.Name == "MyClassic")
                    {
					    // For MyClassic, apply style elements directly to the control
                        ctl.ForeColor = Color.Gray;
                        ctl.BackColor = Color.LightGray;
                        ctl.Font.Size = FontUnit.XSmall;
                        ctl.Font.Name = "Verdana,Geneva,Sans-Serif";
                    }
                    else if (this.Name == "MyBright")
                    {
					    // For MyBright, apply style elements to the Style property
                        this.Style.ForeColor = Color.Maroon;
					    this.Style.BackColor = Color.Yellow;
					    this.Style.Font.Size = FontUnit.Medium;

					    // Merge the AutoFormat style with the control's style
					    ctl.MergeStyle(this.Style);
                    }
                    else
                    {
					    // For the Default format, apply style elements to the control
                        ctl.ForeColor = Color.Black;
                        ctl.BackColor = Color.Empty;
                        ctl.Font.Size = FontUnit.XSmall;
                    }
                }
            }