            // Valid.
            ec.exampleMethod2("a string");

            // The following statement does not cause a compiler error, even though ec is not
            // dynamic. A run-time exception is raised because the run-time type of d1 is int.
            ec.exampleMethod2(d1);
            // The following statement does cause a compiler error.
            //ec.exampleMethod2(7);