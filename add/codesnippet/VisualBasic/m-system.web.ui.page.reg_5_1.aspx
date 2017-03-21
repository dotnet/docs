  
        Dim scriptString As String = "<script language=""JavaScript""> function doClick() {"
   scriptString += "for(var index=0;index < myArray.length;index++)"
   scriptString += " myArray[index].show(); } <"
   scriptString += "/" + "script>"
     
   RegisterStartupScript("arrayScript", scriptString)
   RegisterArrayDeclaration("myArray", "new obj('x'),new obj('y'),new obj('z')")