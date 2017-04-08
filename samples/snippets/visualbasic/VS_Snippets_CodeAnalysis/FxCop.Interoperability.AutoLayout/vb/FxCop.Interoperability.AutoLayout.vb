'<Snippet1>
Imports System
Imports System.Runtime.InteropServices

<Assembly: ComVisibleAttribute(False)>
Namespace InteroperabilityLibrary

   ' This violates the rule.
   <StructLayoutAttribute(LayoutKind.Auto)> _ 
   <ComVisibleAttribute(True)> _ 
   Public Structure AutoLayout
   
      Dim ValueOne As Integer
      Dim ValueTwo As Integer 

   End Structure

   ' This satisfies the rule.
   <StructLayoutAttribute(LayoutKind.Explicit)> _ 
   <ComVisibleAttribute(True)> _ 
   Public Structure ExplicitLayout
   
      <FieldOffsetAttribute(0)> _ 
      Dim ValueOne As Integer

      <FieldOffsetAttribute(4)> _ 
      Dim ValueTwo As Integer 

   End Structure

End Namespace
'</Snippet1>
