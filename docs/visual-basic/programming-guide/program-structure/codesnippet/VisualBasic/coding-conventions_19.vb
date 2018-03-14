  Private Function GetHtmlDocument( 
      ByVal items As IEnumerable(Of XElement)) As String

    Dim htmlDoc = <html>
                    <body>
                      <table border="0" cellspacing="2">
                        <%= 
                          From item In items 
                          Select <tr>
                                   <td style="width:480">
                                     <%= item.<title>.Value %>
                                   </td>
                                   <td><%= item.<pubDate>.Value %></td>
                                 </tr> 
                        %>
                      </table>
                    </body>
                  </html>

    Return htmlDoc.ToString()
  End Function