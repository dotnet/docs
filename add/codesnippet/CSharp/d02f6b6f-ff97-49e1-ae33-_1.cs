                // Create a Web control from the HTML markup.
                System.Web.UI.Control ctrl =
                    ControlParser.ParseControl(host, inputForm.TBox.Text.Trim());