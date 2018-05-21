            int i = 0;
            if (false & ++i == 1)
            {
                // i is incremented, but the conditional
                // expression evaluates to false, so
                // this block does not execute.
            }