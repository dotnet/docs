---
title: "Creating the Game1 Class"
ms.date: "03/30/2017"
ms.assetid: 47932ce3-2ba5-476f-a26b-3ddfd5226f27
---
# Creating the Game1 Class
As with all Microsoft XNA projects, the Game1 class derives from the [Microsoft.Xna.Framework.Game](/previous-versions/windows/xna/bb197040%28v%3dxnagamestudio.41%29) class, which provides basic graphics device initialization, game logic, and rendering code for XNA games. The Game1 class is fairly simple because most of the work in done in the GamePiece and GamePieceCollection classes.  
  
## Creating the Code  
 The private members for the class consist of a **GamePieceCollection** object to hold the game pieces, a [GraphicsDeviceManager](/previous-versions/windows/xna/bb197317%28v%3dxnagamestudio.41%29) object, and a [SpriteBatch](/previous-versions/windows/xna/bb199034%28v%3dxnagamestudio.41%29) object used to render game pieces.  
  
 [!code-csharp[ManipulationXNA#_Game1_PrivateMembers](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/game1.cs#_game1_privatemembers)]  
  
 During game initialization, these objects are instantiated.  
  
 [!code-csharp[ManipulationXNA#_Game1_ConstructorInitialize](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/game1.cs#_game1_constructorinitialize)]  
  
 When the [LoadContent](/previous-versions/windows/xna/bb975766%28v%3dxnagamestudio.41%29) method is called, the game pieces are created and assigned to the **GamePieceCollection** object. There are two types of game pieces. The scale factor for the pieces is changed slightly so that there are some smaller and some larger pieces.  
  
 [!code-csharp[ManipulationXNA#_Game1_LoadContent](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/game1.cs#_game1_loadcontent)]  
  
 The [Update](/previous-versions/windows/xna/bb199616%28v%3dxnagamestudio.41%29) method is called repeatedly by the XNA Framework while the game is running. The [Update](/previous-versions/windows/xna/bb199616%28v%3dxnagamestudio.41%29) method calls the **ProcessInertia** and the **UpdateFromMouse** methods on the game piece collection. These methods are described in [Creating the GamePieceCollection Class](../../../docs/framework/common-client-technologies/creating-the-gamepiececollection-class.md).  
  
 [!code-csharp[ManipulationXNA#_Game1_UpdateGame](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/game1.cs#_game1_updategame)]  
  
 The [Draw](/previous-versions/windows/xna/bb196422%28v%3dxnagamestudio.41%29) method is also called repeatedly by the XNA Framework while the game is running. The [Draw](/previous-versions/windows/xna/bb196422%28v%3dxnagamestudio.41%29) method performs the rendering of game pieces by calling the **Draw** method of the **GamePieceCollection** object. This method is described in[Creating the GamePieceCollection Class](../../../docs/framework/common-client-technologies/creating-the-gamepiececollection-class.md).  
  
 [!code-csharp[ManipulationXNA#_Game1_DrawGame](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/game1.cs#_game1_drawgame)]  
  
## See Also  
 [Manipulations and Inertia](../../../docs/framework/common-client-technologies/manipulations-and-inertia.md)  
 [Using Manipulations and Inertia in an XNA Application](../../../docs/framework/common-client-technologies/use-manipulations-and-inertia-in-an-xna-application.md)  
 [Creating the GamePiece Class](../../../docs/framework/common-client-technologies/creating-the-gamepiece-class.md)  
 [Creating the GamePieceCollection Class](../../../docs/framework/common-client-technologies/creating-the-gamepiececollection-class.md)  
 [Full Code Listings](../../../docs/framework/common-client-technologies/full-code-listings.md)
