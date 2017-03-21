        private void AddMetafileCommentBytes(PaintEventArgs e)
        {
            // Create temporary Graphics object for metafile
            //  creation and get handle to its device context.
            Graphics newGraphics = this.CreateGraphics();
            IntPtr hdc = newGraphics.GetHdc();
                     
            // Create metafile object to record.
            Metafile metaFile1 = new Metafile("SampMeta.emf", hdc);
                     
            // Create graphics object to record metaFile.
            Graphics metaGraphics = Graphics.FromImage(metaFile1);
                     
            // Draw rectangle in metaFile.
            metaGraphics.DrawRectangle(new Pen(Color.Black, 5), 0, 0, 100, 100);
                     
            // Create comment and add to metaFile.
            byte[] metaComment = {(byte)'T', (byte)'e', (byte)'s', (byte)'t'};
            metaGraphics.AddMetafileComment(metaComment);
                     
            // Dispose of graphics object.
            metaGraphics.Dispose();
                     
            // Dispose of metafile.
            metaFile1.Dispose();
                     
            // Release handle to temporary device context.
            newGraphics.ReleaseHdc(hdc);
                     
            // Dispose of scratch graphics object.
            newGraphics.Dispose();
                     
            // Create existing metafile object to draw.
            Metafile metaFile2 = new Metafile("SampMeta.emf");
                     
            // Draw metaFile to screen.
            e.Graphics.DrawImage(metaFile2, new Point(0, 0));
                     
            // Dispose of metafile.
            metaFile2.Dispose();
        }