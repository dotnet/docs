		internal ToolStripButton boldButton;

		private void InitializeBoldButton()
		{
			boldButton = new ToolStripButton();
			boldButton.Text = "B";
			boldButton.CheckOnClick = true;
			toolStrip1.Items.Add(boldButton);

		}

		private void boldButton_CheckedChanged(object sender, EventArgs e)
		{
			if (boldButton.Checked)
			{
				this.Font = new Font(this.Font, FontStyle.Bold);
			}
			else
			{
				this.Font = new Font(this.Font, FontStyle.Regular);
			}

		}
