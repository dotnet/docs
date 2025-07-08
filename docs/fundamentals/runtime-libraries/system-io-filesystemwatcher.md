---
title: System.IO.FileSystemWatcher class
description: Learn about the System.IO.FileSystemWatcher class.
ms.date: 12/31/2023
---
# System.IO.FileSystemWatcher class

[!INCLUDE [context](includes/context.md)]

Use <xref:System.IO.FileSystemWatcher> to watch for changes in a specified directory. You can watch for changes in files and subdirectories of the specified directory. You can create a component to watch files on a local computer, a network drive, or a remote computer.

To watch for changes in all files, set the <xref:System.IO.FileSystemWatcher.Filter> property to an empty string ("") or use wildcards ("*.\*"). To watch a specific file, set the <xref:System.IO.FileSystemWatcher.Filter> property to the file name. For example, to watch for changes in the file MyDoc.txt, set the <xref:System.IO.FileSystemWatcher.Filter> property to "MyDoc.txt". You can also watch for changes in a certain type of file. For example, to watch for changes in text files, set the <xref:System.IO.FileSystemWatcher.Filter> property to "\*.txt".

There are several types of changes you can watch for in a directory or file. For example, you can watch for changes in `Attributes`, the `LastWrite` date and time, or the `Size` of files or directories. This is done by setting the <xref:System.IO.FileSystemWatcher.NotifyFilter> property to one of the <xref:System.IO.NotifyFilters> values. For more information on the type of changes you can watch, see <xref:System.IO.NotifyFilters>.

You can watch for renaming, deletion, or creation of files or directories. For example, to watch for renaming of text files, set the <xref:System.IO.FileSystemWatcher.Filter> property to "*.txt" and call the <xref:System.IO.FileSystemWatcher.WaitForChanged%2A> method with a <xref:System.IO.WatcherChangeTypes.Renamed> specified for its parameter.

The Windows operating system notifies your component of file changes in a buffer created by the <xref:System.IO.FileSystemWatcher>. If there are many changes in a short time, the buffer can overflow. This causes the component to lose track of changes in the directory, and it will only provide blanket notification. Increasing the size of the buffer with the <xref:System.IO.FileSystemWatcher.InternalBufferSize> property is expensive, as it comes from non-paged memory that cannot be swapped out to disk, so keep the buffer as small yet large enough to not miss any file change events. To avoid a buffer overflow, use the <xref:System.IO.FileSystemWatcher.NotifyFilter%2A> and <xref:System.IO.FileSystemWatcher.IncludeSubdirectories%2A> properties so you can filter out unwanted change notifications.

For a list of initial property values for an instance of <xref:System.IO.FileSystemWatcher>, see the <xref:System.IO.FileSystemWatcher.%23ctor%2A> constructor.

Considerations when using the <xref:System.IO.FileSystemWatcher> class:

- Hidden files are not ignored.
- In some systems, <xref:System.IO.FileSystemWatcher> reports changes to files using the short 8.3 file name format. For example, a change to  "LongFileName.LongExtension" could be reported as "LongFil~.Lon".
- This class contains a link demand and an inheritance demand at the class level that applies to all members. A <xref:System.Security.SecurityException> is thrown when either the immediate caller or the derived class does not have full-trust permission. For details about security demands, see [Link Demands](/dotnet/framework/misc/link-demands).
- The maximum size you can set for the <xref:System.IO.FileSystemWatcher.InternalBufferSize> property for monitoring a directory over the network is 64 KB.

## Copy and move folders

The operating system and <xref:System.IO.FileSystemWatcher> object interpret a cut-and-paste action or a move action as a rename action for a folder and its contents. If you cut and paste a folder with files into a folder being watched, the <xref:System.IO.FileSystemWatcher> object reports only the folder as new, but not its contents because they are essentially only renamed.

To be notified that the contents of folders have been moved or copied into a watched folder, provide <xref:System.IO.FileSystemWatcher.OnChanged%2A> and <xref:System.IO.FileSystemWatcher.OnRenamed%2A> event handler methods as suggested in the following table.

|Event Handler|Events Handled|Performs|
|-------------------|--------------------|--------------|
|<xref:System.IO.FileSystemWatcher.OnChanged%2A>|<xref:System.IO.FileSystemWatcher.Changed>, <xref:System.IO.FileSystemWatcher.Created>, <xref:System.IO.FileSystemWatcher.Deleted>|Report changes in file attributes, created files, and deleted files.|
|<xref:System.IO.FileSystemWatcher.OnRenamed%2A>|<xref:System.IO.FileSystemWatcher.Renamed>|List the old and new paths of renamed files and folders, expanding recursively if needed.|

## Events and buffer sizes

Note that several factors can affect which file system change events are raised, as described by the following:

- Common file system operations might raise more than one event. For example, when a file is moved from one directory to another, several <xref:System.IO.FileSystemWatcher.OnChanged%2A> and some <xref:System.IO.FileSystemWatcher.OnCreated%2A> and <xref:System.IO.FileSystemWatcher.OnDeleted%2A> events might be raised. Moving a file is a complex operation that consists of multiple simple operations, therefore raising multiple events. Likewise, some applications (for example, antivirus software) might cause additional file system events that are detected by <xref:System.IO.FileSystemWatcher>.
- The <xref:System.IO.FileSystemWatcher> can watch disks as long as they are not switched or removed. The <xref:System.IO.FileSystemWatcher> does not raise events for CDs and DVDs, because time stamps and properties cannot change. Remote computers must have one of the required platforms installed for the component to function properly.

Note that a <xref:System.IO.FileSystemWatcher> may miss an event when the buffer size is exceeded. To avoid missing events, follow these guidelines:

- Increase the buffer size by setting the <xref:System.IO.FileSystemWatcher.InternalBufferSize> property.
- Avoid watching files with long file names, because a long file name contributes to filling up the buffer. Consider renaming these files using shorter names.
- Keep your event handling code as short as possible.
