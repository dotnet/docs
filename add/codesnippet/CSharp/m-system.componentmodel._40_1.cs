    private void downloadButton_Click(object sender, EventArgs e)
    {
        // Start the download operation in the background.
        this.backgroundWorker1.RunWorkerAsync();

        // Disable the button for the duration of the download.
        this.downloadButton.Enabled = false;

        // Once you have started the background thread you 
        // can exit the handler and the application will 
        // wait until the RunWorkerCompleted event is raised.

        // Or if you want to do something else in the main thread,
        // such as update a progress bar, you can do so in a loop 
        // while checking IsBusy to see if the background task is
        // still running.

        while (this.backgroundWorker1.IsBusy)
        {
            progressBar1.Increment(1);
            // Keep UI messages moving, so the form remains 
            // responsive during the asynchronous operation.
            Application.DoEvents();
        }
    }