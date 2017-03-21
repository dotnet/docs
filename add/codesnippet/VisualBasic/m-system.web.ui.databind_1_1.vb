        ' Create a Text property with accessors that obtain 
        ' the property value from and set the property value
        ' to the Text key in the DataBindingCollection class.

        Public Property [Text]() As String
            Get
                Dim myBinding As DataBinding = DataBindings("Text")
                If Not (myBinding Is Nothing) Then
                    Return myBinding.Expression
                End If
                Return String.Empty
            End Get
            Set(ByVal value As String)

                If value Is Nothing OrElse value.Length = 0 Then
                    DataBindings.Remove("Text")
                Else

                    Dim binding As DataBinding = DataBindings("Text")

                    If binding Is Nothing Then
                        binding = New DataBinding("Text", GetType(String), value)
                    Else
                        binding.Expression = value
                    End If
                    ' Call the DataBinding constructor, then add
                    ' the initialized DataBinding object to the 
                    ' DataBindingCollection for this custom designer.
                    Dim binding1 As DataBinding = CType(DataBindings.SyncRoot, DataBinding)
                    DataBindings.Add(binding)
                    DataBindings.Add(binding1)
                End If
                PropertyChanged("Text")
            End Set
        End Property
