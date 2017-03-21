            // Test whether there is no guarantee (neither Stable nor Exchange).
            if ((guarantee & (ComponentGuaranteesOptions.Stable | ComponentGuaranteesOptions.Exchange)) == 0)
               Console.WriteLine("{0} has no compatibility guarantee.", typ.Name, guarantee);