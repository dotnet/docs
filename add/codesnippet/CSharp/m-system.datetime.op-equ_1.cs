			System.DateTime april19 = new DateTime(2001, 4, 19);
			System.DateTime otherDate = new DateTime(1991, 6, 5);

			// areEqual gets false.
			bool areEqual = april19 == otherDate;
				
			otherDate = new DateTime(2001, 4, 19);
			// areEqual gets true.
			areEqual = april19 == otherDate;