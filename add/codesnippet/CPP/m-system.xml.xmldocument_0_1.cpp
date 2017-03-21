void WriteXml( XmlDocument^ doc )
{
   XmlTextWriter^ writer = gcnew XmlTextWriter( Console::Out );
   writer->Formatting = Formatting::Indented;
   doc->WriteContentTo( writer );
   writer->Flush();
   Console::WriteLine();
}
