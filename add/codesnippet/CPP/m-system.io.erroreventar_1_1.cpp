int main()
{
   
   //Creates an exception with an error message.
   Exception^ myException = gcnew Exception( "This is an exception test" );
   
   //Creates an ErrorEventArgs with the exception.
   ErrorEventArgs^ myErrorEventArgs = gcnew ErrorEventArgs( myException );
   
   //Extracts the exception from the ErrorEventArgs and display it.
   Exception^ myReturnedException = myErrorEventArgs->GetException();
   MessageBox::Show( String::Concat( "The returned exception is: ", myReturnedException->Message ) );
}
