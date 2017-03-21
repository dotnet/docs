            ' Test whether guarantee is Stable or Exchange.
            If (guarantee And (ComponentGuaranteesOptions.Stable Or ComponentGuaranteesOptions.Exchange)) > 0 Then
               Console.WriteLine("{0} is marked as Stable or Exchange.", typ.Name, guarantee)
            End If