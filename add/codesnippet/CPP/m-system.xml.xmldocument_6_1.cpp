void WriteXml( XmlDocument^ doc )
{
   XmlTextWriter^ writer = gcnew XmlTextWriter( Console::Out );
   writer->Formatting = Formatting::Indented;
   doc->WriteTo( writer );
   writer->Flush();
   Console::WriteLine();
}
