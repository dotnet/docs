			// MyMath is a proxy class.
			MyMath objMyMath = new MyMath();

			// Get the default user agent.
			Console.WriteLine("Default user agent is: " + objMyMath.UserAgent);
			objMyMath.UserAgent = "My Agent";
			Console.WriteLine("Modified user agent is: " + objMyMath.UserAgent);