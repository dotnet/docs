            ' Test whether there is no guarantee (neither Stable nor Exchange).
            If (guarantee And (ComponentGuaranteesOptions.Stable Or ComponentGuaranteesOptions.Exchange)) = 0 Then
               Console.WriteLine("{0} has no compatibility guarantee.", typ.Name, guarantee)
            End If      