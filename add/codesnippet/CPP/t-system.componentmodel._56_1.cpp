ActiveDesignerEventArgs^ CreateActiveDesignerEventArgs( IDesignerHost^ losingFocus, IDesignerHost^ gainingFocus )
{
   ActiveDesignerEventArgs^ e = gcnew ActiveDesignerEventArgs( losingFocus, gainingFocus );
   return e;
}