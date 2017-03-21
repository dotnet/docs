            // Draw a custom 3D border if the ToolTip is for button1.
            if (e.AssociatedControl == button1)
            {
                // Draw the standard background.
                e.DrawBackground();

                // Draw the custom border to appear 3-dimensional.
                e.Graphics.DrawLines(SystemPens.ControlLightLight, new Point[] {
                    new Point (0, e.Bounds.Height - 1), 
                    new Point (0, 0), 
                    new Point (e.Bounds.Width - 1, 0)
                });
                e.Graphics.DrawLines(SystemPens.ControlDarkDark, new Point[] {
                    new Point (0, e.Bounds.Height - 1), 
                    new Point (e.Bounds.Width - 1, e.Bounds.Height - 1), 
                    new Point (e.Bounds.Width - 1, 0)
                });

                // Specify custom text formatting flags.
                TextFormatFlags sf = TextFormatFlags.VerticalCenter |
                                     TextFormatFlags.HorizontalCenter |
                                     TextFormatFlags.NoFullWidthCharacterBreak;

                // Draw the standard text with customized formatting options.
                e.DrawText(sf);
            }