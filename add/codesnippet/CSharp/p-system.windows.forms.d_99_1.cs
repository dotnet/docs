 // The specified IDesigner implements IUIService.
 Font GetFont(IDesigner designer)
 {      
       Font        hostfont;
 
       // Gets the dialog box font from the host environment. 
       hostfont = (Font)((IUIService)designer).Styles["DialogFont"];
       
       return hostfont;
 }
    