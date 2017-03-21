      Dim thisDate As DateTimeOffset
      
      ' Show output for UTC time
      thisDate = DateTimeOffset.UtcNow
      Console.WriteLine(thisDate.ToString())  ' Displays 3/28/2007 7:13:50 PM +00:00
      
      ' Show output for local time 
      thisDate = DateTimeOffset.Now
      Console.WriteLine(thisDate.ToString())  ' Displays 3/28/2007 12:13:50 PM -07:00
      
      ' Show output for arbitrary time offset
      thisDate = thisDate.ToOffset(new TimeSpan(-5, 0, 0))
      Console.WriteLine(thisDate.ToString())  ' Displays 3/28/2007 2:13:50 PM -05:00