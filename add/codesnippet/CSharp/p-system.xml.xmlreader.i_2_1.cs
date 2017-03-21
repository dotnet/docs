// Display all attributes.
if (reader.HasAttributes) {
  Console.WriteLine("Attributes of <" + reader.Name + ">");
  for (int i = 0; i < reader.AttributeCount; i++) {
    Console.WriteLine("  {0}", reader[i]);
  }
  // Move the reader back to the element node.
  reader.MoveToElement(); 
}