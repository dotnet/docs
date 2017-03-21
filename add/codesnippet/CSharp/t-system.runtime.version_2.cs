            // Test whether guarantee is Stable or Exchange.
            if ((guarantee & (ComponentGuaranteesOptions.Stable | ComponentGuaranteesOptions.Exchange)) > 0)
               Console.WriteLine("{0} is marked as Stable or Exchange.", typ.Name, guarantee);