      <%
         Dim charArray As Char() = {"H"c, "e"c, "l"c, "l"c, "o"c, ","c, " "c, _
                                 "w"c, "o"c, "r"c, "l"c, "d"c}
         ' Write a character array to the client.
         Response.Write(charArray, 0, charArray.Length)

         ' Write a single character.
         Response.Write(";"c)

         ' Write a sub-section of a character array to the client.
         Response.Write(charArray, 0, 5)
         ' Write an object to the client.
         Dim obj As Object
         obj = CType(13, Object)
         Response.Write(obj)
      %>
