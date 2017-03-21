		void button1_Click(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				Application.VisualStyleState =
					VisualStyleState.ClientAreaEnabled;
			}
			else if (radioButton2.Checked)
			{
				Application.VisualStyleState =
					VisualStyleState.NonClientAreaEnabled;
			}
			else if (radioButton3.Checked)
			{
				Application.VisualStyleState =
					VisualStyleState.ClientAndNonClientAreasEnabled;
			}
			else if (radioButton4.Checked)
			{
				Application.VisualStyleState =
					VisualStyleState.NoneEnabled;
			}

			// Repaint the form and all child controls.
			this.Invalidate(true);
		}