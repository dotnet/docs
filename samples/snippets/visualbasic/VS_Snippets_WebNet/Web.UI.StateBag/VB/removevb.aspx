<%@ Page Language="vb" Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language="vb" runat="server">
    Dim boardColumns As Char() =  {"a"c, "b"c, "c"c, "d"c, "e"c, "f"c, "g"c, "h"c}
    Dim boardRows As Byte() =  {1, 2, 3, 4, 5, 6, 7, 8}

    Sub Page_Load(Src As Object, E As EventArgs)
       If Not IsPostBack Then
          ' Create list of remaining pieces
          Dim bag As StateBag = ViewState
          bag.Add("h3", "white-king")
          bag.Add("d4", "white-bishop")
          bag.Add("c1", "black-king")
          bag.Add("e6", "black-pawn")
          RenderBoard()
       End If
    End Sub 'Page_Load

    Sub MovePieceButton_Click(Src As Object, E As EventArgs)
       Try
          MovePiece(FromPosition.Text, ToPosition.Text)
       Catch e1 As InvalidPositionException
          ErrorMessage.Text = e1.Message
       End Try
    End Sub 'MovePieceButton_Click

    ' This sample procedure is from a Web game that uses
    ' the StateBag to store the position of game pieces
    ' on a game board.
    ' System.Web.UI.StateBag.Remove
    ' <Snippet3>
    Sub MovePiece(fromPosition As String, toPosition As String)
       Dim bag As StateBag = ViewState
       Dim piece As Object = bag(fromPosition)
       If Not (piece Is Nothing) Then
          bag.Remove(fromPosition)
          bag.Add(toPosition, piece)
          RenderBoard()
       Else
          Throw New InvalidPositionException("There is no game piece at the ""from"" position.")
       End If
    End Sub 'MovePiece
    ' </Snippet3>

    Sub RenderBoard()
       Dim pieces As New StringBuilder()
       Dim bag As StateBag = ViewState
       Dim row As Byte
       For Each row In  boardRows
          Dim column As Char
          For Each column In  boardColumns
             Dim position As String = column.ToString() + row.ToString()
             pieces.AppendFormat("position: {0}" + ControlChars.Tab + " piece: {1}" + ControlChars.CrLf, position, bag(position))
          Next column
       Next row
       PieceList.Text = pieces.ToString()
    End Sub 'RenderBoard

    Private Class InvalidPositionException
       Inherits Exception
       
       Public Sub New(message As String)
          MyBase.New(message)
       End Sub 'New 
    End Class 'InvalidPositionException
   </script>
<head runat="server">
    <title>StateBag.Remove Example</title>
</head>
<body>
   <form id="form1" runat="server">
 
   <h3>StateBag.Remove Example</h3>
   <br />
   <table border="0" cellspacing="0" cellpadding="4">
      <tr>
         <td>
         <asp:TextBox id="PieceList" 
            Text=""
            TextMode="MultiLine"
            Wrap="true"
            Height="350px"
            Width="350px"
            runat="server"/></td>
         <td>
         Move piece from position
         <asp:TextBox id="FromPosition"
            Text=""
            Columns="2"
            MaxLength="2"
            runat="server"/>
         to
         <asp:TextBox id="ToPosition"
            Text=""
            Columns="2"
            MaxLength="2"
            runat="server"/>
         <br />
         <asp:Button id="MovePieceButton"
           Text="Move Piece"
           OnClick="MovePieceButton_Click" 
           runat="server"/>
         <br />
         <asp:Label id="ErrorMessage"
            EnableViewState="false"
            ForeColor="red"
            runat="server"/>
         
         </td>
      </tr>
   </table>
   </form>
 
</body>
</html>
