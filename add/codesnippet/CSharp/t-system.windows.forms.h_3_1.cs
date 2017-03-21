		private void webBrowser1_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
		{
			WebBrowser1.Document.MouseDown += new HtmlElementEventHandler(Document_MouseDown);
			WebBrowser1.Document.MouseMove += new HtmlElementEventHandler(Document_MouseMove);
			WebBrowser1.Document.MouseUp += new HtmlElementEventHandler(Document_MouseUp);
		}

		private void Document_MouseDown(object sender, HtmlElementEventArgs e)
		{
			// Insert your code here.
		}

		private void Document_MouseMove(object sender, HtmlElementEventArgs e)
		{
			// Insert your code here.
		}

		private void Document_MouseUp(object sender, HtmlElementEventArgs e)
		{
			// Insert your code here.
		}