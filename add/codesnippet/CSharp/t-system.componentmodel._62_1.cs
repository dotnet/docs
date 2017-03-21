string strM="1,2,3,4";
System.Drawing.Printing.Margins  m= new System.Drawing.Printing.Margins(1,2,3,4);
Console.WriteLine(TypeDescriptor.GetConverter(strM).CanConvertTo(typeof(System.Drawing.Printing.Margins))); 
Console.WriteLine(TypeDescriptor.GetConverter(m).ConvertToString(m)); 