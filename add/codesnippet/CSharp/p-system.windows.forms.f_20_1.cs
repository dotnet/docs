		private void ShowMyNonModalForm()
		{
			Form myForm = new Form();
			myForm.Text = "My Form";
			myForm.SetBounds(10,10,200,200);

			myForm.Show();
			// Determine if the form is modal.
			if(myForm.Modal == false)
			{
				// Change borderstyle and make it not a top level window.
				myForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
				myForm.TopLevel = false;
			}
		}