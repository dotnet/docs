		try {
		    License licTest = null;
		    licTest = LicenseManager.Validate(typeof(Form1), this);
		}

		catch(LicenseException licE) {
		    Console.WriteLine(licE.Message);
		    Console.WriteLine(licE.LicensedType);
		    Console.WriteLine(licE.StackTrace);
		    Console.WriteLine(licE.Source);	
		}