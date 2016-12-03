            // Test value of flags using bitwise AND.
            bool test = (meetingDays & Days2.Thursday) == Days2.Thursday;
            Console.WriteLine("Thursday {0} a meeting day.", test == true ? "is" : "is not");
            // Output: Thursday is a meeting day.