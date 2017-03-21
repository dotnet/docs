 ' Using the NowWhiteSpaceControlBuilder with a simple control.
 ' When created on a page this control will not allow white space
 ' to be converted into a literal control.     
 <ControlBuilderAttribute(GetType(NoWhiteSpaceControlBuilder))>  _
 <AspNetHostingPermission(SecurityAction.Demand, _
   Level:=AspNetHostingPermissionLevel.Minimal)> _
 Public NotInheritable Class MyNonWhiteSpaceControl
   Inherits Control
 End Class 'MyNonWhiteSpaceControl

 ' A simple custom control to compare with MyNonWhiteSpaceControl.
 <AspNetHostingPermission(SecurityAction.Demand, _
   Level:=AspNetHostingPermissionLevel.Minimal)> _
 Public NotInheritable Class WhiteSpaceControl
   Inherits Control
 End Class 'WhiteSpaceControl 