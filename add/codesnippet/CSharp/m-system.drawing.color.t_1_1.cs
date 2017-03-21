        public void ToArgbToStringExample2(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Color structure used for temporary storage.
            Color   someColor = Color.FromArgb(0);
                     
            // Array to store KnownColor values that match the criteria.
            KnownColor[]  colorMatches = new KnownColor[167];
            
            // Number of matches found.
            int  count = 0;   
                     
            // Iterate through the KnownColor enums to find all corresponding colors
            // that have a nonzero green component and zero-value red component and
            // that are not system colors.
            for (KnownColor enumValue = 0;
                enumValue <= KnownColor.YellowGreen; enumValue++)
            {
                someColor = Color.FromKnownColor(enumValue);
                if (someColor.G != 0 && someColor.R == 0 && !someColor.IsSystemColor)
                    colorMatches[count++] = enumValue;
            }
            SolidBrush  myBrush1 = new SolidBrush(someColor);
            Font        myFont = new Font("Arial", 9);
            int         x = 40;
            int         y = 40;
                     
            // Iterate through the matches that were found and display each color that
            // corresponds with the enum value in the array. also display the name of
            // the KnownColor and the ARGB components.
            for (int i = 0; i < count; i++)
            {
                // Display the color.
                someColor = Color.FromKnownColor(colorMatches[i]);
                myBrush1.Color = someColor;
                g.FillRectangle(myBrush1, x, y, 50, 30);
                     
                // Display KnownColor name and the four component values. To display the
                // component values:  Use the ToArgb method to get the 32-bit ARGB value
                // of someColor, which was created from a KnownColor. Then create a
                // Color structure from the 32-bit ARGB value and set someColor equal to
                // this new Color structure. Then use the ToString method to convert it to
                // a string.
                g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 55, y);
                someColor = Color.FromArgb(someColor.ToArgb());
                g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 55, y + 15);
                y += 40;
            }
        }