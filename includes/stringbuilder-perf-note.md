Using character-based indexing with the <xref:System.Text.StringBuilder.Chars%2A> property can be extremely slow under the following conditions:

- The <xref:System.Text.StringBuilder> instance is large (for example, it consists of several tens of thousands of characters).
- The <xref:System.Text.StringBuilder> is "chunky." That is, repeated calls to methods such as <xref:System.Text.StringBuilder.Append%2A?displayProperty=nameWithType> have automatically expanded the object's <xref:System.Text.StringBuilder.Capacity%2A?displayProperty=nameWithType> property and allocated new chunks of memory to it.

Performance is severely impacted because each character access walks the entire linked list of chunks to find the correct buffer to index into.

> [!NOTE]
>  Even for a large "chunky" <xref:System.Text.StringBuilder> object, using the <xref:System.Text.StringBuilder.Chars%2A> property for index-based access to one or a small number of characters has a negligible performance impact; typically, it is an **0(n)** operation. The significant performance impact occurs when iterating the characters in the <xref:System.Text.StringBuilder> object, which is an **O(n^2)** operation. 

If you encounter performance issues when using character-based indexing with <xref:System.Text.StringBuilder> objects, you can use any of the following workarounds:

- Convert the <xref:System.Text.StringBuilder> instance to a <xref:System.String> by calling the <xref:System.Text.StringBuilder.ToString%2A> method, then access the characters in the string.

- Copy the contents of the existing <xref:System.Text.StringBuilder> object to a new pre-sized <xref:System.Text.StringBuilder> object. Performance improves because the new <xref:System.Text.StringBuilder> object is not chunky. For example:

   ```csharp
   // sbOriginal is the existing StringBuilder object
   var sbNew = new StringBuilder(sbOriginal.ToString(), sbOriginal.Length);
   ```
   ```vb
   ' sbOriginal is the existing StringBuilder object
   Dim sbNew = New StringBuilder(sbOriginal.ToString(), sbOriginal.Length)
   ```
- Set the initial capacity of the <xref:System.Text.StringBuilder> object to a value that is approximately equal to its maximum expected size by calling the <xref:System.Text.StringBuilder.%23ctor(System.Int32)> constructor. Note that this allocates the entire block of memory even if the <xref:System.Text.StringBuilder> rarely reaches its maximum capacity.
