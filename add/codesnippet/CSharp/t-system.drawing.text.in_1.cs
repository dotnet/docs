        InstalledFontCollection ifc = new InstalledFontCollection();
        private void EnumerateInstalledFonts(PaintEventArgs e)
        {
            FontFamily[] families = ifc.Families;
            float x = 0.0F;
            float y = 0.0F;
            for (int i = 0; i < ifc.Families.Length; i++)
            {
                if (ifc.Families[i].IsStyleAvailable(FontStyle.Regular))
                {
                    e.Graphics.DrawString(ifc.Families[i].Name, new Font(ifc.Families[i], 12), 
			            Brushes.Black, x, y);
                    y += 20;
                    if (y % 700 == 0)
                    {
                        x += 140;
                        y = 0;
                    }
                }
            }
        }