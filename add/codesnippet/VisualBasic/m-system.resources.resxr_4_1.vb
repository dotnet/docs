                ' Enumerate using GetMetadataEnumerator()
                Dim metadataEnumerator As IDictionaryEnumerator = reader.GetMetadataEnumerator()

                Console.WriteLine(vbNewLine + "  MetadataEnumerator:")
                While metadataEnumerator.MoveNext()
                    ShowResourceItem(metadataEnumerator.Entry, useDataNodes)
                End While