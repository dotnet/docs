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