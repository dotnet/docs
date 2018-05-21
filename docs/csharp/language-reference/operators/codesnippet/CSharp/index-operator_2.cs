            fib[0] = fib[1] = 1;
            for (int i = 2; i < 100; ++i) fib[i] = fib[i - 1] + fib[i - 2];