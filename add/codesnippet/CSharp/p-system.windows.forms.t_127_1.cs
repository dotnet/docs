        // This utility method creates a RolloverItem 
        // and adds it to a ToolStrip control.
        private RolloverItem CreateRolloverItem(
            ToolStrip owningToolStrip,
            string txt,
            Font f,
            string imgKey,
            TextImageRelation tir,
            string backImgKey)
        {
            RolloverItem item = new RolloverItem();

            item.Alignment = ToolStripItemAlignment.Left;
            item.AllowDrop = false;
            item.AutoSize = true;

            item.BackgroundImage = owningToolStrip.ImageList.Images[backImgKey];
            item.BackgroundImageLayout = ImageLayout.Center;
            item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            item.DoubleClickEnabled = true;
            item.Enabled = true;
            item.Font = f;

            // These assignments are equivalent. Each assigns an
            // image from the owning toolstrip's image list.
            item.ImageKey = imgKey;
            //item.Image = owningToolStrip.ImageList.Images[infoIconKey];
            //item.ImageIndex = owningToolStrip.ImageList.Images.IndexOfKey(infoIconKey);
            item.ImageScaling = ToolStripItemImageScaling.None;

            item.Owner = owningToolStrip;
            item.Padding = new Padding(2);
            item.Text = txt;
            item.TextAlign = ContentAlignment.MiddleLeft;
            item.TextDirection = ToolStripTextDirection.Horizontal;
            item.TextImageRelation = tir;

            return item;
        }