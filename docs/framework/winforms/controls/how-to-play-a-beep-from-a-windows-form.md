---
title: "How to: Play a Beep from a Windows Form"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "sounds [Windows Forms], beep"
  - "Windows Forms, sounds"
  - "sounds [Windows Forms], playing"
  - "forms [Windows Forms], sounds"
  - "examples [Windows Forms], sounds"
ms.assetid: 7ea5cded-4888-4f35-8f28-5cab1a55c973
---
# How to: Play a Beep from a Windows Form
This example plays a beep at run time.

## Example

```vb
Public Sub OnePing()
    Beep()
End Sub
```

```csharp
public void onePing()
{
    SystemSounds.Beep.Play();
}
```

> [!NOTE]
> The sound played in the C# code sample is determined by the <xref:System.Media.SystemSounds.Beep%2A> system sound setting. For more information, see <xref:System.Media.SystemSounds>.

## Compiling the Code
 For C#, this example requires  a reference to the <xref:System.Media?displayProperty=nameWithType> namespace.

## See also

- <xref:Microsoft.VisualBasic.Interaction.Beep%2A>
- <xref:System.Media.SoundPlayer>
- [How to: Play a System Sound from a Windows Form](how-to-play-a-system-sound-from-a-windows-form.md)
- [How to: Play a Sound from a Windows Form](how-to-play-a-sound-from-a-windows-form.md)
