        public void SetScrollBarValues()
        {
            //Set the following scrollbar properties:

            //Minimum: Set to 0

            //SmallChange and LargeChange: Per UI guidelines, these must be set
            //    relative to the size of the view that the user sees, not to
            //    the total size including the unseen part.  In this example,
            //    these must be set relative to the picture box, not to the image.

            //Maximum: Calculate in steps:
            //Step 1: The maximum to scroll is the size of the unseen part.
            //Step 2: Add the size of visible scrollbars if necessary.
            //Step 3: Add an adjustment factor of ScrollBar.LargeChange.


            //Configure the horizontal scrollbar
            //---------------------------------------------
            if (this.hScrollBar1.Visible)
            {
                this.hScrollBar1.Minimum = 0;
                this.hScrollBar1.SmallChange = this.pictureBox1.Width / 20;
                this.hScrollBar1.LargeChange = this.pictureBox1.Width / 10;

                this.hScrollBar1.Maximum = this.pictureBox1.Image.Size.Width - pictureBox1.ClientSize.Width;  //step 1

                if (this.vScrollBar1.Visible) //step 2
                {
                    this.hScrollBar1.Maximum += this.vScrollBar1.Width;
                }

                this.hScrollBar1.Maximum += this.hScrollBar1.LargeChange; //step 3
            }

            //Configure the vertical scrollbar
            //---------------------------------------------
            if (this.vScrollBar1.Visible)
            {
                this.vScrollBar1.Minimum = 0;
                this.vScrollBar1.SmallChange = this.pictureBox1.Height / 20;
                this.vScrollBar1.LargeChange = this.pictureBox1.Height / 10;

                this.vScrollBar1.Maximum = this.pictureBox1.Image.Size.Height - pictureBox1.ClientSize.Height; //step 1

                if (this.hScrollBar1.Visible) //step 2
                {
                    this.vScrollBar1.Maximum += this.hScrollBar1.Height;
                }

                this.vScrollBar1.Maximum += this.vScrollBar1.LargeChange; //step 3
            }
        }