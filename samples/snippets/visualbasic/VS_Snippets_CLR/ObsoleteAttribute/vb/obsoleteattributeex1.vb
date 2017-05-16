' <Snippet1>
Imports System.Reflection

Public Module Example
   ' Mark OldProperty As Obsolete.
   <ObsoleteAttribute("This property is obsolete. Use NewProperty instead.", False)> 
   Public ReadOnly Property OldProperty As String
      Get
         Return "The old property value."
      End Get
   End Property
   
   Public ReadOnly Property NewProperty As String
      Get
         Return "The new property value."
      End Get
   End Property
   
   ' Mark OldMethod As Obsolete.
   <ObsoleteAttribute("This method is obsolete. Call CallNewMethod instead.", True)> 
   Public Function CallOldMethod() As String
      Return "You have called CallOldMethod."
   End Function
      
   Public Function CallNewMethod() As String   
      Return "You have called NewMethod."
   End Function   
   
   Public Sub Main()
      Console.WriteLine(OldProperty)
      Console.WriteLine()
      Console.WriteLine(CallOldMethod())
   End Sub  
End Module
'  The attempt to compile this example produces output like the following:
'    Example.vb(30) : warning BC40000: 'Public ReadOnly Property OldProperty As String' is obsolete: 
'                     'This property is obsolete. Use NewProperty instead.'.
'    
'          Console.WriteLine(OldProperty)
'                            ~~~~~~~~~~~
'    Example.vb(32) : error BC30668: 'Public Function CallOldMethod() As String' is obsolete: 
'                     'This method is obsolete. Call CallNewMethod instead.'.
'    
'          Console.WriteLine(CallOldMethod())
'                            ~~~~~~~~~~~~~
' </Snippet1>
