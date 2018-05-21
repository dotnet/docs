          Dim items As Array
          items = System.Enum.GetValues(GetType(FirstDayOfWeek))
          Dim item As String
          For Each item In items
              MsgBox(item)
          Next