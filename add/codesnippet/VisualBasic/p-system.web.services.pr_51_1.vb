' Set the URL property to a different Web server than that described in the
' service description.
math.Url = "http://www.contoso.com/math.asmx"
Dim total As Integer = math.Add(Convert.ToInt32(Num1.Text), _
                                 Convert.ToInt32(Num2.Text))
