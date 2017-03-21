        private void OnFormClosed(object sender, EventArgs e) {
            // When a form is closed, decrement the count of open forms.

            // When the count gets to 0, exit the app by calling
            // ExitThread().
            formCount--;
            if (formCount == 0) {
                ExitThread();
            }
        }