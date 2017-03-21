        public void SetBrushRemapTableExample(PaintEventArgs e)
        {
                     
            // Create a color map.
            ColorMap[] myColorMap = new ColorMap[1];
            myColorMap[0] = new ColorMap();
            myColorMap[0].OldColor = Color.Red;
            myColorMap[0].NewColor = Color.Green;
                     
            // Create an ImageAttributes object, passing it to the myColorMap
                     
            // array.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetBrushRemapTable(myColorMap);
        }