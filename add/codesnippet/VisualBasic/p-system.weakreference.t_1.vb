            Dim d As Data = TryCast(_cache(index).Target, Data)
            ' If the object was reclaimed, generate a new one.
            If d Is Nothing Then 
                Console.WriteLine("Regenerate object at {0}: Yes", index)
                d = New Data(index)
                _cache(index).Target = d
                regenCount += 1
           Else 
                ' Object was obtained with the weak reference.
                Console.WriteLine("Regenerate object at {0}: No", index.ToString())
            End If 
            Return d