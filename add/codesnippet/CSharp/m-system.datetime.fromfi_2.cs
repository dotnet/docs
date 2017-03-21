		public System.TimeSpan FileAge(long fileCreationTime) {

			System.DateTime now = System.DateTime.Now;
			try {
				System.DateTime fCreationTime = 
					System.DateTime.FromFileTime(fileCreationTime);
				System.TimeSpan fileAge = now.Subtract(fCreationTime);
				return fileAge;				
			} 
			catch (ArgumentOutOfRangeException) {
				// fileCreationTime is not valid, so re-throw the exception.
				throw;
			}
		}