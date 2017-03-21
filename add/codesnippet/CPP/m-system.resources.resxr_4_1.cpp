            // Enumerate using GetMetadataEnumerator()
            IDictionaryEnumerator^ metadataEnumerator = reader->GetMetadataEnumerator();

            Console::WriteLine("\n  MetadataEnumerator:");
            while (metadataEnumerator->MoveNext())
            {
                ShowResourceItem(metadataEnumerator->Entry, useDataNodes);
            }