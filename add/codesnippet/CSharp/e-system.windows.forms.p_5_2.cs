        void pictureBox1_LoadProgressChanged(object sender, 
            ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }