namespace JumpStatements;

public static class ContinueStatement
{
    public static void Examples()
    {
        BasicExample();
        LabeledContinue();
    }

    private static void BasicExample()
    {
        // <BasicExample>
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Iteration {i}: ");
            
            if (i < 3)
            {
                Console.WriteLine("skip");
                continue;
            }
            
            Console.WriteLine("done");
        }
        // Output:
        // Iteration 0: skip
        // Iteration 1: skip
        // Iteration 2: skip
        // Iteration 3: done
        // Iteration 4: done
        // </BasicExample>
    }

    private static void LabeledContinue()
    {
        // <LabeledContinue>
        string[][] dailyRoutes =
        [
            ["North", "West"],
            ["South", "Bridge closed", "East"],
            ["Central", "Harbor"]
        ];

        outer: for (int day = 0; day < dailyRoutes.Length; day++)
        {
            Console.WriteLine($"Day {day + 1}:");

            foreach (string route in dailyRoutes[day])
            {
                if (route == "Bridge closed")
                {
                    Console.WriteLine("  Bridge closed; move to the next day.");
                    continue outer;
                }

                Console.WriteLine($"  Schedule the {route} route.");
            }

            Console.WriteLine("  All routes scheduled.");
        }
        // Output:
        // Day 1:
        //   Schedule the North route.
        //   Schedule the West route.
        //   All routes scheduled.
        // Day 2:
        //   Schedule the South route.
        //   Bridge closed; move to the next day.
        // Day 3:
        //   Schedule the Central route.
        //   Schedule the Harbor route.
        //   All routes scheduled.
        // </LabeledContinue>
    }
}
