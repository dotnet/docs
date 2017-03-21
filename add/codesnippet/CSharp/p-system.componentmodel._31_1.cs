                // Obtains and shows the size of the standard design-mode grid square.
                PropertyDescriptor pd;
                pd = designerOptionSvc.Options.Properties["GridSize"];
                e.Graphics.DrawString("GridSize", 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 4, ypos);
                e.Graphics.DrawString(pd.GetValue(null).ToString(), 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 200, ypos);
                ypos += 12;

                // Uncomment the following code to demonstrate that this
                // alternate syntax works the same as the previous syntax.

                //pd = designerOptionSvc.Options["WindowsFormsDesigner"].Properties["GridSize"];
                //e.Graphics.DrawString("GridSize",
                //    new Font("Arial", 8),
                //    new SolidBrush(Color.Black), 4, ypos);
                //e.Graphics.DrawString(pd.GetValue(null).ToString(),
                //    new Font("Arial", 8),
                //    new SolidBrush(Color.Black), 200, ypos);
                //ypos += 12;

                //pd = designerOptionSvc.Options["WindowsFormsDesigner"]["General"].Properties["GridSize"];
                //e.Graphics.DrawString("GridSize",
                //    new Font("Arial", 8),
                //    new SolidBrush(Color.Black), 4, ypos);
                //e.Graphics.DrawString(pd.GetValue(null).ToString(),
                //    new Font("Arial", 8),
                //    new SolidBrush(Color.Black), 200, ypos);
                //ypos += 12;