---
title: System.Collections.ObjectModel.KeyedCollection<TKey,TItem>.ChangeItemKey method
description: Learn about the System.Collections.ObjectModel.KeyedCollection<TKey,TItem>.ChangeItemKey method.
ms.date: 01/24/2024
---
# System.Collections.ObjectModel.KeyedCollection<TKey,TItem>.ChangeItemKey method

[!INCLUDE [context](includes/context.md)]

The <xref:System.Collections.ObjectModel.KeyedCollection%602.ChangeItemKey(%601,%600)> method does not modify the key embedded in `item`; it simply replaces the key saved in the lookup dictionary. Therefore, if `newKey` is different from the key that is embedded in `item`, you cannot access `item` by using the key returned by <xref:System.Collections.ObjectModel.KeyedCollection%602.GetKeyForItem%2A>.

This method does nothing if the <xref:System.Collections.ObjectModel.KeyedCollection%602> does not have a lookup dictionary.

Every key in a <xref:System.Collections.ObjectModel.KeyedCollection%602> must be unique. A key cannot be `null`.

This method is an O(1) operation.

## Notes for implementers

Before modifying the key embedded in an item, you must call this method to update the key in the lookup dictionary. If the dictionary creation threshold is -1, calling this method is not necessary.

Do not expose the <xref:System.Collections.ObjectModel.KeyedCollection%602.ChangeItemKey%2A> method as a public method of a derived class. Misuse of this method puts the lookup dictionary out of sync with item keys. For example, setting the key to `null` and then setting it to another value adds multiple keys for an item to the lookup dictionary. Expose this method internally to allow mutable item keys: When the key for an item changes, this method is used to change the key in the lookup dictionary.
