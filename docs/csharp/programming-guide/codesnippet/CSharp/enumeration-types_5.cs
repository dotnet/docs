            // Initialize with two flags using bitwise OR.
            meetingDays = Days2.Tuesday | Days2.Thursday;

            // Set an additional flag using bitwise OR.
            meetingDays = meetingDays | Days2.Friday;

            Console.WriteLine("Meeting days are {0}", meetingDays);
            // Output: Meeting days are Tuesday, Thursday, Friday

            // Remove a flag using bitwise XOR.
            meetingDays = meetingDays ^ Days2.Tuesday;
            Console.WriteLine("Meeting days are {0}", meetingDays);
            // Output: Meeting days are Thursday, Friday