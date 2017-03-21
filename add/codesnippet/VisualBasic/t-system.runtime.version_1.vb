            ' Test whether guarantee is Stable.
            If (guarantee And ComponentGuaranteesOptions.Stable) = ComponentGuaranteesOptions.Stable Then
               Console.WriteLine("{0} is marked as {1}.", typ.Name, guarantee)
            End If