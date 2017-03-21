    Public Function GetList() As System.Collections.IList Implements System.ComponentModel.IListSource.GetList

        Dim ble As New BindingList(Of Employee)

        If Not Me.DesignMode Then
            ble.Add(New Employee("Aaberg, Jesper", 26000000))
            ble.Add(New Employee("Cajhen, Janko", 19600000))
            ble.Add(New Employee("Furse, Kari", 19000000))
            ble.Add(New Employee("Langhorn, Carl", 16000000))
            ble.Add(New Employee("Todorov, Teodor", 15700000))
            ble.Add(New Employee("Vereb�lyi, �gnes", 15700000))
        End If

        Return ble

    End Function