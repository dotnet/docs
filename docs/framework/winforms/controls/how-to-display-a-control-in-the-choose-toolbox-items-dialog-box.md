---
title: "How to: Display a Control in the Choose Toolbox Items Dialog Box"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "global assembly cache [Windows Forms], Choose Toolbox Items dialog box"
  - "AssemblyFoldersEx [Windows Forms], Choose Toolbox Items dialog box"
  - "controls [Windows Forms], display in Choose Toolbox Items dialog box"
  - "assembly folder registration [Windows Forms], Choose Toolbox Items dialog box"
  - "Choose Toolbox Items dialog box [Windows Forms], display control"
ms.assetid: 01ef6eba-d044-40f0-951d-78eff7ebd9a9
---
# How to: Display a Control in the Choose Toolbox Items Dialog Box
As you develop and distribute controls, you may want those controls to appear in the **Choose Toolbox Items** dialog box, which is displayed when you right-click the **Toolbox** and select **Choose Items**. You can enable your control to appear in this dialog box by using the AssemblyFoldersEx registration procedure.  
  
### To display your control in the Choose Toolbox Items dialog box  
  
- Install your control assembly to the global assembly cache. For more information, see [How to: Install an Assembly into the Global Assembly Cache](../../../standard/assembly/install-into-gac.md)  
  
     -or-  
  
- Register your control and its associated design-time assemblies by using the AssemblyFoldersEx registration procedure. AssemblyFoldersEx is a registry location where third-party vendors store paths for each version of the framework that they support. Design-time resolution can look in this registry location to find reference assemblies. The registry script can specify the controls you want to appear in the Toolbox. For more information, see [Deploying a Custom Control and Design-time Assemblies](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/ee849818(v=vs.100)).  
  
## See also

- [Choose Toolbox Items Dialog Box (Visual Studio)](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/dyca0t6t(v=vs.100))
- [Deploying a Custom Control and Design-time Assemblies](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/ee849818(v=vs.100))
- [Developing Windows Forms Controls at Design Time](developing-windows-forms-controls-at-design-time.md)
- [How to: Install an Assembly into the Global Assembly Cache](../../../standard/assembly/install-into-gac.md)
- [Walkthrough: Automatically Populating the Toolbox with Custom Components](walkthrough-automatically-populating-the-toolbox-with-custom-components.md)
