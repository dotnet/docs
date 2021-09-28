---
description: "Learn more about: An invalid name was specified for the event log"
title: "An invalid name was specified for the event log"
ms.date: 07/20/2015
ms.assetid: b1b158bd-f13f-4371-a8af-31c0e86ae6be
---
# An invalid name was specified for the event log

An invalid name was specified for the event log. Usually this is a result of invalid characters in the name, a blank file name, or a file name that is too long.  
  
## To correct this error  
  
- If the specified name is more than eight characters, make sure there is no conflict with the names of other event logs. Only the first eight characters are evaluated when determining if the name is unique.  
  
- If supplying a path, make sure it is parsed correctly.  
  
- Check that there are no invalid characters in the name. Characters that cannot be used in a file name include `<`, `>`, `:`, `"`, `/`, `\`, and `|`.  
  
## See also

- [How to: Parse File Paths](../developing-apps/programming/drives-directories-files/how-to-parse-file-paths.md)
- [How to: Rename a File](../developing-apps/programming/drives-directories-files/how-to-rename-a-file.md)
