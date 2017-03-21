        private void startButton_Click(object sender, EventArgs e)
        {
            // Ensure WaitOnLoad is false.
            pictureBox1.WaitOnLoad = false;

            // Load the image asynchronously.
            pictureBox1.LoadAsync(@"http://localhost/print.gif");
        }