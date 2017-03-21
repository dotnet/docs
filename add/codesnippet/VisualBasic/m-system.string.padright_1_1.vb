 Dim str As String
 Dim pad As Char
 str = "forty-two"
 pad = Convert.ToChar(".") 
 Console.WriteLine(str.PadRight(15, pad)) ' Displays "|forty-two......|".
 Console.WriteLine(str.PadRight(2,  pad)) ' Displays "|forty-two|".