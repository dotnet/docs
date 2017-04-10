 ' <snippet1>
Imports System


' <snippet2>
' <snippet3>
' This interface defines the contract for any class that is to
' be used in constructing a MarqueeControl.
Public Interface IMarqueeWidget
    ' </snippet2>

   ' This method starts the animation. If the control can 
   ' contain other classes that implement IMarqueeWidget as
   ' children, the control should call StartMarquee on all
   ' its IMarqueeWidget child controls.
   Sub StartMarquee()
   
   ' This method stops the animation. If the control can 
   ' contain other classes that implement IMarqueeWidget as
   ' children, the control should call StopMarquee on all
   ' its IMarqueeWidget child controls.
   Sub StopMarquee()
   
   ' This method specifies the refresh rate for the animation,
   ' in milliseconds.
   Property UpdatePeriod() As Integer

End Interface
' </snippet3>
' </snippet1>