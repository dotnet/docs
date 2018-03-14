---
title: "Creating the GamePiece Class"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 37a27a86-ac1c-47be-b477-cb4b819459d3
caps.latest.revision: 9
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Creating the GamePiece Class
The **GamePiece** class encapsulates all the functionality required to load a Microsoft XNA game piece image, track the state of the mouse in relation to the game piece, capture the mouse, provide manipulation and inertia processing, and provide bouncing capability when the game piece reaches the limits of the view port.  
  
## Private Members  
 At the top of the **GamePiece** class, several private members are declared.  
  
 [!code-csharp[ManipulationXNA#_GamePiece_PrivateMembers](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/gamepiece.cs#_gamepiece_privatemembers)]  
  
## Public Properties  
 Three of these private members are exposed through public properties. The **Scale** and **PieceColor** properties enable the application to specify the scale and the color of the piece, respectively. The **Bounds** property is exposed to enable one piece to use the bounds of another to render itself, such as when one piece should overlay another. The following code shows the declaration of the public properties.  
  
 [!code-csharp[ManipulationXNA#_GamePiece_PublicProperties](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/gamepiece.cs#_gamepiece_publicproperties)]  
  
## Class Constructor  
 The constructor for the **GamePiece** class accepts the following parameters:  
  
-   A [SpriteBatch](http://msdn.microsoft.com/library/microsoft.xna.framework.graphics.spritebatch.aspx) type. The reference passed here is assigned to the private member `spriteBatch`, and is used to access the [SpriteBatch.Draw](http://msdn.microsoft.com/library/microsoft.xna.framework.graphics.spritebatch.draw.aspx) method when the game piece renders itself. In addition, the [GraphicsDevice](http://msdn.microsoft.com/library/microsoft.xna.framework.graphics.spritebatch.graphicsdevice.aspx) property is used to create the [Texture](http://msdn.microsoft.com/library/microsoft.xna.framework.graphics.texture.aspx) object associated with the game piece, and to obtain the size of the view port in order to detect when the game piece encounters a window boundary so that the piece can bounce.  
  
-   A string that specifies the file name of the image to use for the game piece.  
  
 The constructor also creates a <xref:System.Windows.Input.Manipulations.ManipulationProcessor2D> object and an <xref:System.Windows.Input.Manipulations.InertiaProcessor2D> object, and establishes event handlers for their events.  
  
 The following code shows the constructor for the **GamePiece** class.  
  
 [!code-csharp[ManipulationXNA#_GamePiece_Constructor](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/gamepiece.cs#_gamepiece_constructor)]  
  
## Capturing Mouse Input  
 The **UpdateFromMouse** method is responsible for detecting when a mouse button is pressed while the mouse is within the boundaries of the game piece, and for detecting when the mouse button has been released.  
  
 When the left mouse button is pressed (while the mouse is inside the piece boundaries), this method sets a flag to indicate that this game piece has captured the mouse, and begins manipulation processing.  
  
 Manipulation processing is started by creating an array of <xref:System.Windows.Input.Manipulations.Manipulator2D> objects and passing them to the <xref:System.Windows.Input.Manipulations.ManipulationProcessor2D> object. This causes the manipulation processor to evaluate the manipulators (in this case a single manipulator), and raise manipulation events.  
  
 In addition, the point at which the drag is occurring is saved. This is used later during the <xref:System.Windows.Input.Manipulations.ManipulationProcessor2D.Delta> event to adjust the delta translation values so that the game piece swings into line behind the drag point.  
  
 Finally, this method returns the state of the mouse capture. This enables the [GamePieceCollection](../../../docs/framework/common-client-technologies/creating-the-gamepiececollection-class.md) object to manage capturing when there are multiple game pieces.  
  
 The following code shows the **UpdateFromMouse** method.  
  
 [!code-csharp[ManipulationXNA#_GamePiece_UpdateFromMouse](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/gamepiece.cs#_gamepiece_updatefrommouse)]  
  
## Processing Manipulations  
 When manipulation begins, the <xref:System.Windows.Input.Manipulations.ManipulationProcessor2D.Started> event is raised. The handler for this event stops inertia processing if it is occurring, and sets the *processInertia* flag to `false`.  
  
 [!code-csharp[ManipulationXNA#_GamePiece_OnManipulationStarted](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/gamepiece.cs#_gamepiece_onmanipulationstarted)]  
  
 As the values associated with the manipulation change, the <xref:System.Windows.Input.Manipulations.ManipulationProcessor2D.Delta> event is raised. The handler for this event uses the delta values passed in the event arguments to make changes to the position and rotation values of the game piece.  
  
 [!code-csharp[ManipulationXNA#_GamePiece_OnManipulationDelta](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/gamepiece.cs#_gamepiece_onmanipulationdelta)]  
  
 When all of the manipulators (in this case, a single manipulator) that are associated with a manipulation are removed, the manipulation processor raises the <xref:System.Windows.Input.Manipulations.ManipulationProcessor2D.Completed> event. The handler for this event begins inertia processing by setting the initial velocities of the inertia processor to those reported by the event arguments, and sets the *processInertia* flag to `true`.  
  
 [!code-csharp[ManipulationXNA#_GamePiece_OnManipulationCompleted](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/gamepiece.cs#_gamepiece_onmanipulationcompleted)]  
  
## Processing Inertia  
 As inertia processing extrapolates new values for angular and linear velocities, position (translation) coordinates, and rotation, the <xref:System.Windows.Input.Manipulations.InertiaProcessor2D.Delta> event is raised. The handler for this event uses the delta values passed in the event arguments to modify the position and rotation of the game piece.  
  
 If the new coordinates result in the game piece moving beyond the view port boundaries, the velocity of the inertia processing is reversed. This causes the game piece to bounce off the view port boundary that it has encountered.  
  
 You cannot change the properties of an <xref:System.Windows.Input.Manipulations.InertiaProcessor2D> object while it is running extrapolation. Therefore, when reversing the X or Y velocity, the event handler first stops inertia by calling the <xref:System.Windows.Input.Manipulations.InertiaProcessor2D.Complete%2A> method. It then assigns the new initial velocity values to be the current velocity values (adjusted for sponge behavior), and sets the *processInertia* flag to `true`.  
  
 The following code shows the event handler for the <xref:System.Windows.Input.Manipulations.InertiaProcessor2D.Delta> event.  
  
 [!code-csharp[ManipulationXNA#_GamePiece_OnInertiaDelta](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/gamepiece.cs#_gamepiece_oninertiadelta)]  
  
 When inertia processing is complete, the inertia processor raises the <xref:System.Windows.Input.Manipulations.InertiaProcessor2D.Completed> event. The handler for this event sets the *processInertia* flag to `false`.  
  
 [!code-csharp[ManipulationXNA#_GamePiece_OnInertiaCompleted](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/gamepiece.cs#_gamepiece_oninertiacompleted)]  
  
 None of the logic presented so far actually causes inertia extrapolation to occur. This is accomplished in the **ProcessInertia** method. This method, which is called repeatedly from the game update loop (the [Game.Update](http://msdn.microsoft.com/library/microsoft.xna.framework.game.update.aspx) method) checks to see if the *processInertia* flag is set to `true`, and if so, calls the <xref:System.Windows.Input.Manipulations.InertiaProcessor2D.Process%2A> method. Calling this method causes extrapolation to occur, and raises the <xref:System.Windows.Input.Manipulations.InertiaProcessor2D.Delta> event.  
  
 [!code-csharp[ManipulationXNA#_GamePiece_ProcessInertia](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/gamepiece.cs#_gamepiece_processinertia)]  
  
 The game piece is not actually rendered until one of the Draw method overloads is called. The first overload of this method is called repeatedly from the game draw loop (the [Game.Draw](http://msdn.microsoft.com/library/microsoft.xna.framework.game.draw.aspx) method). This renders the game piece with the current position, rotation, and scale factors.  
  
 [!code-csharp[ManipulationXNA#_GamePiece_Draw](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/gamepiece.cs#_gamepiece_draw)]  
  
## Additional Properties  
 Three private properties are used by the **GamePiece** class.  
  
1.  **Timestamp** – Gets a timestamp value to be used by the manipulation and inertia processors.  
  
2.  **X** – Gets or sets the X coordinate of the game piece. When setting, adjusts the bounds used for hit testing and the pivot location of the manipulation processor.  
  
3.  **Y** – Gets or sets the Y coordinate of the game piece. When setting, adjusts the bounds used for hit testing and the pivot location of the manipulation processor.  
  
 [!code-csharp[ManipulationXNA#_GamePiece_PrivateProperties](../../../samples/snippets/csharp/VS_Snippets_Misc/manipulationxna/cs/gamepiece.cs#_gamepiece_privateproperties)]  
  
## See Also  
 [Manipulations and Inertia](../../../docs/framework/common-client-technologies/manipulations-and-inertia.md)  
 [Using Manipulations and Inertia in an XNA Application](../../../docs/framework/common-client-technologies/use-manipulations-and-inertia-in-an-xna-application.md)  
 [Creating the GamePieceCollection Class](../../../docs/framework/common-client-technologies/creating-the-gamepiececollection-class.md)  
 [Creating the Game1 Class](../../../docs/framework/common-client-technologies/creating-the-game1-class.md)
