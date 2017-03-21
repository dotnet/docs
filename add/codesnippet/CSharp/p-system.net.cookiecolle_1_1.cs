		// Get the cookies in the 'CookieCollection' object using the 'Item' property.
		// The 'Item' property in C# is implemented through Indexers. 
      // The class that implements indexers is usually a collection of other objects. 
      // This class provides access to those objects with the '<class-instance>[i]' syntax. 
		try {
			if(cookies.Count == 0) {
				Console.WriteLine("No cookies to display");
				return;
			}
			for(int j = 0; j < cookies.Count; j++)
				Console.WriteLine("{0}", cookies[j].ToString());
			Console.WriteLine("");
		}
		catch(Exception e) {
			Console.WriteLine("Exception raised.\nError : " + e.Message);
		}