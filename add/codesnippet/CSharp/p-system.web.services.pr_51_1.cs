// Set the URL property to a different Web server than that described in the
// service description.
math.Url = "http://www.contoso.com/math.asmx";
int total = math.Add(Convert.ToInt32(Num1.Text), Convert.ToInt32(Num2.Text));
