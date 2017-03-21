        // Create a new clerk using the AccountCompensator class.
        Clerk^ clerk = gcnew Clerk(AccountCompensator::typeid,
            "An account transaction compensator", CompensatorOptions::AllPhases);