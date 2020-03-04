<%@ Page Language="C#" Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language="C#" runat="server">
      char[] boardColumns = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'};
      byte[] boardRows = {1, 2, 3, 4, 5, 6, 7, 8};
      
      void Page_Load(Object Src, EventArgs E) {
         if(!IsPostBack) {
            // Create list of remaining pieces
            StateBag bag = ViewState;
            bag.Add("h3", "white-king");
            bag.Add("d4", "white-bishop");
            bag.Add("c1", "black-king");
            bag.Add("e6", "black-pawn");
            RenderBoard();
         }
      }

      void MovePieceButton_Click(Object Src, EventArgs E) {
         try {
            MovePiece(FromPosition.Text, ToPosition.Text);
         }
         catch(InvalidPositionException e){
            ErrorMessage.Text = e.Message;
         }
      }

      /*
         This sample procedure is from a Web game that uses
         the StateBag to store the position of game pieces
         on a game board.
      */
      // System.Web.UI.StateBag.Remove
      // <Snippet3>
      void MovePiece(string fromPosition, string toPosition) {
         StateBag bag = ViewState;
         object piece = bag[fromPosition];
         if (piece != null) {
            bag.Remove(fromPosition);
            bag.Add(toPosition, piece);
            RenderBoard();
         }
         else {
            throw new InvalidPositionException("There is no game piece at the \"from\" position."); 
         }
      }
      // </Snippet3>
      
      void RenderBoard() {
         StringBuilder pieces = new StringBuilder();
         StateBag bag = ViewState;
         foreach(byte row in boardRows) {
            foreach(char column in boardColumns) {
               string position = column.ToString() + row.ToString();
               pieces.AppendFormat("position: {0}\t piece: {1}\r\n", position, bag[position]);
            }
         }
         PieceList.Text = pieces.ToString();
      }

      private class InvalidPositionException : Exception {
         public InvalidPositionException(string message):base(message) {}
      };
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
