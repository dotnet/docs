
    // Display exception handling clauses.
    Console::WriteLine();
    for each(ExceptionHandlingClause^ exhc in mb->ExceptionHandlingClauses)
    {
        Console::WriteLine(exhc->Flags.ToString());

        // The FilterOffset property is meaningful only for Filter
        // clauses. The CatchType property is not meaningful for 
        // Filter or Finally clauses. 
        switch(exhc->Flags)
        {
        case ExceptionHandlingClauseOptions::Filter:
            Console::WriteLine("        Filter Offset: {0}", 
                exhc->FilterOffset);
            break;
        case ExceptionHandlingClauseOptions::Finally:
            break;
        default:
            Console::WriteLine("    Type of exception: {0}", 
                exhc->CatchType);
            break;
        }

        Console::WriteLine("       Handler Length: {0}",
            exhc->HandlerLength);
        Console::WriteLine("       Handler Offset: {0}", 
            exhc->HandlerOffset);
        Console::WriteLine("     Try Block Length: {0}", exhc->TryLength);
        Console::WriteLine("     Try Block Offset: {0}", exhc->TryOffset);
    }