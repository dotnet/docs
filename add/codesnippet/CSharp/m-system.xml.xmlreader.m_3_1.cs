if (reader.HasAttributes) {
  Console.WriteLine("Attributes of <" + reader.Name + ">");
  for (int i = 0; i < reader.AttributeCount; i++) {
    reader.MoveToAttribute(i);
    Console.Write(" {0}={1}", reader.Name, reader.Value);
  }
reader.MoveToElement(); // Moves the reader back to the element node.
}