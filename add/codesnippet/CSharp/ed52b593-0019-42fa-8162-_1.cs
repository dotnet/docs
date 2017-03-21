        // Create a new clerk using the AccountCompensator class.
        Clerk clerk = new Clerk(typeof(AccountCompensator),
          "An account transaction compensator", CompensatorOptions.AllPhases);