public static class TheaterConcertSimulation
{
    private const int MAX_ATTENDANCE = 1000;
    private const int EXPECTED_SALES = 850;
    
    public static void SimulateConcertAttendance()
    {
        Console.WriteLine("=== Royal Theater Concert Attendance Simulation ===");
        Console.WriteLine($"Venue Capacity: {MAX_ATTENDANCE} | Expected Sales: {EXPECTED_SALES}");
        Console.WriteLine("Concert: 'Symphony Under the Stars' - 7:30 PM\n");
        
        // Initialize theater gates
        var theaterGates = new TheaterGates();
        
        Console.WriteLine("--- Gate Status Before Concert ---");
        PrintTheaterStatus(theaterGates);
        
        // Simulate pre-concert arrival patterns
        SimulatePreConcertArrivals(theaterGates);
        
        Console.WriteLine("\n--- Gate Status After Pre-Concert Arrivals (6:30 PM) ---");
        PrintTheaterStatus(theaterGates);
        
        // Simulate main arrival rush
        SimulateMainArrivalRush(theaterGates);
        
        Console.WriteLine("\n--- Gate Status After Main Rush (7:15 PM) ---");
        PrintTheaterStatus(theaterGates);
        
        // Simulate late arrivals
        SimulateLateArrivals(theaterGates);
        
        Console.WriteLine("\n--- Final Attendance Report (7:30 PM - Concert Start) ---");
        GenerateFinalReport(theaterGates);
    }
    
    private static void SimulatePreConcertArrivals(TheaterGates gates)
    {
        Console.WriteLine("--- Pre-Concert Arrivals (6:00 PM - 6:30 PM) ---");
        Console.WriteLine("Early patrons and season ticket holders arriving...\n");
        
        // Early arrivals - mainly main floor, some balcony
        // Main floor gates - moderate traffic
        ++gates.MainFloorGates[0];                    // Single patron
        gates.MainFloorGates[0] += 2;                 // Couple
        gates.MainFloorGates[0] += 6;                 // Corporate early group
        gates.MainFloorGates[1] = gates.MainFloorGates[1] + 4;  // Family
        gates.MainFloorGates[1] += 8;                 // Season ticket holders
        ++gates.MainFloorGates[2];                    // Single patron
        gates.MainFloorGates[2] += 5;                 // Early dinner group
        gates.MainFloorGates[3] += 3;                 // Small group
        gates.MainFloorGates[3] += 7;                 // VIP early access
        ++gates.MainFloorGates[3];                    // Individual VIP
        
        // Balcony gates - lighter but increased traffic
        ++gates.BalconyGates[0];                      // Single patron
        gates.BalconyGates[0] += 4;                   // Early bird group
        gates.BalconyGates[1] += 2;                   // Couple
        gates.BalconyGates[1] += 6;                   // Student group with early tickets
        ++gates.BalconyGates[1];                      // Individual student
        
        Console.WriteLine("Early arrivals processed through all gates.");
    }
    
    private static void SimulateMainArrivalRush(TheaterGates gates)
    {
        Console.WriteLine("\n--- Main Arrival Rush (6:30 PM - 7:15 PM) ---");
        Console.WriteLine("Peak arrival time - all gates busy...\n");
        
        var random = new Random();

        // Heavy traffic through main floor gates
        for (int i = 0; i < 3; i++)
        {
            // <Simulation>
            // Gate 1 - busiest entrance (target: ~100-130 people)
            gates.MainFloorGates[0] += random.Next(8, 15);     // Corporate group
            ++gates.MainFloorGates[0];                          // Single patron
            gates.MainFloorGates[0] += random.Next(20, 30);    // Tour/large group arrival
            gates.MainFloorGates[0] += random.Next(5, 12);     // Family groups
            ++gates.MainFloorGates[0];                          // Solo attendee

            // Gate 2 - second busiest (target: ~85-115 people)
            gates.MainFloorGates[1] = gates.MainFloorGates[1] + random.Next(6, 12);  // Group booking
            ++gates.MainFloorGates[1];                          // Single patron
            gates.MainFloorGates[1] += random.Next(18, 28);    // Large family/reunion
            gates.MainFloorGates[1] += random.Next(8, 15);     // Corporate/business group
            gates.MainFloorGates[1] += random.Next(4, 8);      // Couples/small groups
            ++gates.MainFloorGates[1];                          // Individual patron
            // </Simulation>
            
            // Gate 3 - moderate traffic (target: ~70-95 people)
            ++gates.MainFloorGates[2];                          // Individual
            gates.MainFloorGates[2] += random.Next(4, 8);      // Small group
            gates.MainFloorGates[2] += random.Next(15, 22);    // Community/organization group
            gates.MainFloorGates[2] += random.Next(10, 16);    // Club/society members
            ++gates.MainFloorGates[2];                          // Solo attendee
            gates.MainFloorGates[2] += random.Next(6, 12);     // Friends/social group

            // Gate 4 - lighter but steady (target: ~60-85 people)
            gates.MainFloorGates[3] += random.Next(3, 6);      // Family group
            gates.MainFloorGates[3] += random.Next(8, 15);     // Celebration/event group
            ++gates.MainFloorGates[3];                          // Individual attendee
            gates.MainFloorGates[3] += random.Next(5, 10);     // Couples/pairs

            // Balcony gates - steady increased flow
            // Left balcony gate (target: ~80-100 people)
            ++gates.BalconyGates[0];                            // Single patron
            gates.BalconyGates[0] += random.Next(5, 10);       // Small group
            gates.BalconyGates[0] += random.Next(15, 25);      // Student/educational group
            gates.BalconyGates[0] += random.Next(10, 18);      // Budget-conscious attendees
            ++gates.BalconyGates[0];                            // Individual
            gates.BalconyGates[0] += random.Next(6, 12);       // Senior/community group

            // Right balcony gate (target: ~70-95 people)
            gates.BalconyGates[1] += random.Next(4, 8);        // Small group
            ++gates.BalconyGates[1];                            // Individual
            gates.BalconyGates[1] += random.Next(16, 24);      // Academic/institutional group
            gates.BalconyGates[1] += random.Next(10, 16);      // Community organization
            gates.BalconyGates[1] += random.Next(4, 8);        // Young professionals/friends
            ++gates.BalconyGates[1];                            // Solo patron
        }
        
        Console.WriteLine("Peak rush period completed - all gates processed heavy traffic.");
    }
    
    private static void SimulateLateArrivals(TheaterGates gates)
    {
        Console.WriteLine("\n--- Late Arrivals (7:15 PM - 7:30 PM) ---");
        Console.WriteLine("Final patrons arriving before curtain...\n");
        
        var random = new Random();

        // Light but varied traffic as concert approaches
        // Main floor gates - scattered late arrivals (1-8 people per gate)
        ++gates.MainFloorGates[0];                          // Last-minute arrival
        gates.MainFloorGates[0] += random.Next(2, 6);      // Delayed group

        gates.MainFloorGates[1] += random.Next(1, 4);      // Rushing small group
        gates.MainFloorGates[1] += random.Next(2, 7);      // Traffic/parking delayed group

        ++gates.MainFloorGates[2];                          // Single late arrival
        gates.MainFloorGates[2] += random.Next(1, 5);      // Delayed couple/small group

        gates.MainFloorGates[3] += random.Next(1, 4);      // Late couple
        gates.MainFloorGates[3] += random.Next(2, 6);      // Last-minute purchasers
        ++gates.MainFloorGates[3];                          // Solo rush arrival

        // Balcony gates - lighter late traffic (1-5 people per gate)
        ++gates.BalconyGates[0];                            // Late balcony patron
        gates.BalconyGates[0] += random.Next(1, 4);        // Delayed small group

        gates.BalconyGates[1] += random.Next(1, 3);        // Final arrivals
        gates.BalconyGates[1] += random.Next(2, 5);        // Work-delayed group
        ++gates.BalconyGates[1];                            // Individual latecomer

        Console.WriteLine("Final arrivals processed - concert about to begin!");
    }
    
    private static void PrintTheaterStatus(TheaterGates gates)
    {
        Console.WriteLine("Main Floor Gates:");
        for (int i = 0; i < gates.MainFloorGates.Length; i++)
        {
            var gate = gates.MainFloorGates[i];
            Console.WriteLine($"  {gate.GateId}: {gate.Count,3} attendees");
        }
        
        var mainFloorTotal = gates.MainFloorGates.Sum(g => g.Count);
        Console.WriteLine($"  Main Floor Subtotal: {mainFloorTotal,3} attendees");
        
        Console.WriteLine("\nBalcony Gates:");
        for (int i = 0; i < gates.BalconyGates.Length; i++)
        {
            var gate = gates.BalconyGates[i];
            Console.WriteLine($"  {gate.GateId}: {gate.Count,3} attendees");
        }
        
        var balconyTotal = gates.BalconyGates.Sum(g => g.Count);
        Console.WriteLine($"  Balcony Subtotal: {balconyTotal,3} attendees");
        
        var totalAttendance = mainFloorTotal + balconyTotal;
        Console.WriteLine($"\nTotal Current Attendance: {totalAttendance,3} / {MAX_ATTENDANCE}");
    }
    
    private static void GenerateFinalReport(TheaterGates gates)
    {
        var mainFloorTotal = gates.MainFloorGates.Sum(g => g.Count);
        var balconyTotal = gates.BalconyGates.Sum(g => g.Count);
        var totalAttendance = mainFloorTotal + balconyTotal;
        
        PrintTheaterStatus(gates);
        
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("FINAL CONCERT ATTENDANCE REPORT");
        Console.WriteLine(new string('=', 50));
        
        Console.WriteLine($"Expected Sales:        {EXPECTED_SALES,3}");
        Console.WriteLine($"Actual Attendance:     {totalAttendance,3}");
        Console.WriteLine($"Venue Capacity:        {MAX_ATTENDANCE,3}");
        
        var attendanceRate = (double)totalAttendance / EXPECTED_SALES * 100;
        var capacityUtilization = (double)totalAttendance / MAX_ATTENDANCE * 100;
        
        Console.WriteLine($"Attendance Rate:       {attendanceRate,5:F1}% of expected");
        Console.WriteLine($"Capacity Utilization:  {capacityUtilization,5:F1}% of maximum");
        
        // Gate distribution analysis
        Console.WriteLine($"\nGate Distribution:");
        Console.WriteLine($"Main Floor:            {mainFloorTotal,3} ({(double)mainFloorTotal/totalAttendance*100:F1}%)");
        Console.WriteLine($"Balcony:              {balconyTotal,3} ({(double)balconyTotal/totalAttendance*100:F1}%)");
        
        // Performance indicators using switch expression
        var performanceMessage = totalAttendance switch
        {
            var t when t >= EXPECTED_SALES * 0.95 => "\n✅ Excellent attendance! Concert exceeded expectations.",
            var t when t >= EXPECTED_SALES * 0.85 => "\n✅ Good attendance! Concert met expectations.", 
            var t when t >= EXPECTED_SALES * 0.70 => "\n⚠️  Moderate attendance. Consider marketing review.",
            _ => "\n❌ Low attendance. Significant marketing review needed."
        };
        
        Console.WriteLine(performanceMessage);
            
        Console.WriteLine("\nConcert begins! 🎼");
    }
}

public struct TheaterGates
{
    // Main floor gates (4 gates) - initialized with default gate instances
    public GateAttendance[] MainFloorGates { get; } =
    [
        new GateAttendance("Main-Floor-Gate-1"),
        new GateAttendance("Main-Floor-Gate-2"), 
        new GateAttendance("Main-Floor-Gate-3"),
        new GateAttendance("Main-Floor-Gate-4")
    ];
    
    // Balcony gates (2 gates) - initialized with default gate instances
    public GateAttendance[] BalconyGates { get; } =
    [
        new GateAttendance("Balcony-Gate-Left"),
        new GateAttendance("Balcony-Gate-Right")
    ];
    
    // Explicit constructor required when using field initializers in structs
    public TheaterGates()
    {
    }
}