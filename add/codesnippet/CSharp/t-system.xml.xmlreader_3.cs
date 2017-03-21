if (reader.HasAttributes) {
  Console.WriteLine("Attributes of <" + reader.Name + ">");
  while (reader.MoveToNextAttribute()) {
    Console.WriteLine(" {0}={1}", reader.Name, reader.Value);
  }
  // Move the reader back to the element node.
  reader.MoveToElement();
}