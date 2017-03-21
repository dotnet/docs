  // Using the NowWhiteSpaceControlBuilder with a simple control.
  // When created on a page this control will not allow white space
  // to be converted into a literal control.     
  [ControlBuilderAttribute(typeof(NoWhiteSpaceControlBuilder))]
  [AspNetHostingPermission(SecurityAction.Demand, 
     Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class MyNonWhiteSpaceControl : Control
  {}

  // A simple custom control to compare with MyNonWhiteSpaceControl.
  [AspNetHostingPermission(SecurityAction.Demand, 
     Level=AspNetHostingPermissionLevel.Minimal)]
  public sealed class WhiteSpaceControl : Control 
  {}