        int p = 0;
        Console.WriteLine("\nCurrent evidence = ");
        if (null == myEvidence) return 0;
        IEnumerator list = myEvidence.GetEnumerator();
        while (list.MoveNext())
        {
            Console.WriteLine(list.Current.ToString());
        }