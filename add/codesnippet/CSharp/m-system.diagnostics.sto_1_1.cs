                    long ticksThisTime = 0;
                    int inputNum;
                    Stopwatch timePerParse;

                    switch (operation)
                    {
                        case 0:
                            // Parse a valid integer using
                            // a try-catch statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            try 
                            {
                                inputNum = Int32.Parse("0");
                            }
                            catch (FormatException)
                            {
                                inputNum = 0;
                            }

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.

                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;
                        case 1:
                            // Parse a valid integer using
                            // the TryParse statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            if (!Int32.TryParse("0", out inputNum))
                            { 
                                inputNum = 0;
                            }

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.
                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;
                        case 2:
                            // Parse an invalid value using
                            // a try-catch statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            try 
                            {
                                inputNum = Int32.Parse("a");
                            }
                            catch (FormatException)
                            {
                                inputNum = 0;
                            }

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.
                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;
                        case 3:
                            // Parse an invalid value using
                            // the TryParse statement.

                            // Start a new stopwatch timer.
                            timePerParse = Stopwatch.StartNew();

                            if (!Int32.TryParse("a", out inputNum))
                            { 
                                inputNum = 0;
                            }

                            // Stop the timer, and save the
                            // elapsed ticks for the operation.
                            timePerParse.Stop();
                            ticksThisTime = timePerParse.ElapsedTicks;
                            break;

                        default:
                            break;
                    }