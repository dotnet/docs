# <snippet00>
# Create new hash table
# Create as ordered
$OpenWith = @{}

# Add some elements to the hash table. There are no
# duplicate keys but some of the values are duplicated
$OpenWith.Add('txt', 'notepad.exe')
$openWith.Add('dib', 'paint.exe')

# Add in a PowerShell way!
$OpenWith['bmp'] = 'paint.exe'
$OpenWith.rtf    = 'wordpad.exe'

# The Add method throws an exception if the new key is 
# already in the hash table.
try
{
  $OpenWith.Add("txt", "winword.exe")
}
catch
{
  "An element with Key = 'txt' already exists."
}
 
# The Item property is the default property, so you 
# can omit its name when accessing elements. 
"For key = 'rtf', value = {0}." -f $OpenWith["rtf"]

# The default Item property can be used to change the value
# associated with a key.
$OpenWith.rtf = "winword.exe";
"For key = 'rtf', value = {0}." -f $openWith["rtf"]
        
# If a key does not exist, setting the default Item property
# for that key adds a new key/value pair.
$OpenWith.doc = "winword.exe";

# ContainsKey can be used to test keys before inserting 
# them.
if (-Not $openWith.ContainsKey("ht"))
{
   $OpenWith.Add("ht", "hypertrm.exe")
   "Value added for key = 'ht' [{0}]" -f $openWith["ht"]
}

# When you use foreach to enumerate hash table elements,
# the elements are retrieved as KeyValuePair objects.
""
foreach($de in ($OpenWith.getenumerator() ) )
{
  "Key = {0}, Value = {1}" -f $de.Key, $de.Value
}

# To get the values alone, use the Values property.
$ValueColl = $OpenWith.Values

# The elements of the ValueCollection are strongly typed
# with the type that was specified for hash table values.
""
foreach( $s in $ValueColl )
{
  "Value = {0}" -f  $s
}

# To get the keys alone, use the Keys property.
$KeyColl = $OpenWith.Keys;

# The elements of the KeyCollection are strongly typed
# with the type that was specified for hash table keys.
""
foreach( $s in $KeyColl )
{
  "Key = {0}" -f $s
}

# Use the Remove method to remove a key/value pair.
"Remove('doc')"
$openWith.Remove("doc")
if (-NOT $OpenWith.ContainsKey("doc"))
{
  "Key 'doc' is not found"
}

<#
This PowerShell sample produces the following output:

An element with Key = 'txt' already exists.
For key = 'rtf', value = wordpad.exe.
For key = 'rtf', value = winword.exe.
Value added for key = 'ht' [hypertrm.exe]

Key = dib, Value = paint.exe
Key = doc, Value = winword.exe
Key = txt, Value = notepad.exe
Key = ht, Value = hypertrm.exe
Key = rtf, Value = winword.exe
Key = bmp, Value = paint.exe

Value = paint.exe
Value = winword.exe
Value = notepad.exe
Value = hypertrm.exe
Value = winword.exe
Value = paint.exe

Key = dib
Key = doc
Key = txt
Key = ht
Key = rtf
Key = bmp
Remove('doc')
Key 'doc' is not found
#>
# </snippet00>
