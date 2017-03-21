// Creates an Import object with namespace and location.
Import^ CreateImport( String^ targetNamespace, String^ targetlocation )
{
   Import^ myImport = gcnew Import;
   myImport->Location = targetlocation;
   myImport->Namespace = targetNamespace;
   return myImport;
}