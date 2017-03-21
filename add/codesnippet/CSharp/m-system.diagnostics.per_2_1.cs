    private static void CollectSamples(ArrayList samplesList)
    {

        Random r = new Random( DateTime.Now.Millisecond );

        // Loop for the samples.
        for (int j = 0; j < 100; j++) 
        {

            int value = r.Next(1, 10);
            Console.Write(j + " = " + value);

            avgCounter64Sample.IncrementBy(value);

            avgCounter64SampleBase.Increment();

            if ((j % 10) == 9) 
            {
                OutputSample(avgCounter64Sample.NextSample());
                samplesList.Add( avgCounter64Sample.NextSample() );
            }
            else
                Console.WriteLine();

            System.Threading.Thread.Sleep(50);
        }

    }