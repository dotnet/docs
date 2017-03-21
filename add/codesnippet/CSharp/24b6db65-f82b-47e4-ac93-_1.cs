		public ApplicationTrust DetermineApplicationTrust(ActivationContext appContext, TrustManagerContext context)
		{
			ApplicationTrust trust = new ApplicationTrust(appContext.Identity);
			trust.IsApplicationTrustedToRun = false;

			ApplicationSecurityInfo asi = new ApplicationSecurityInfo(appContext);
			trust.DefaultGrantSet = new PolicyStatement(asi.DefaultRequestSet, PolicyStatementAttribute.Nothing);
			if (context.UIContext == TrustManagerUIContext.Run)
			{
				string message = "Do you want to run " + asi.ApplicationId.Name + " ?";
				string caption = "MyTrustManager";
				MessageBoxButtons buttons = MessageBoxButtons.YesNo;
				DialogResult result;

				// Displays the MessageBox.

				result = MessageBox.Show(message, caption, buttons);

				if (result == DialogResult.Yes)
				{
					trust.IsApplicationTrustedToRun = true;
					if (context != null)
						trust.Persist = context.Persist;
					else
						trust.Persist = false;
				}
			}

			return trust;
		}