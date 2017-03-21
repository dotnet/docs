        public void AddStripToCollection()
        {
            // Add the image strip.
            Bitmap bitmaps = new Bitmap(typeof(PrintPreviewDialog), "PrintPreviewStrip.bmp");
            imageList1.Images.AddStrip(bitmaps);
            
            // Iterate through the images and display them on the form.
            for (int i = 0; i < imageList1.Images.Count; i++) {
            
                imageList1.Draw(this.CreateGraphics(), new Point(10,10), i);
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                
            }
            

        }