    ' Display the text [Null] when the data field is empty.
    ' Also, convert empty string to null for storing.
    <DisplayFormat(ConvertEmptyStringToNull:=True, NullDisplayText:="[Null]")> _
    Public Size As Object