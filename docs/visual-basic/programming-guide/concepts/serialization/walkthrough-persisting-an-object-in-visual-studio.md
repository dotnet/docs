---
description: "Learn more about: Walkthrough: Persisting an Object in Visual Studio (Visual Basic)"
title: "Persisting an Object in Visual Studio"
ms.date: 07/20/2015
ms.assetid: f1d0b562-e349-4dce-ab5f-c05108467030
---
# Walkthrough: Persisting an Object in Visual Studio (Visual Basic)

Although you can set an object's properties to default values at design time, any values entered at run time are lost when the object is destroyed. You can use serialization to persist an object's data between instances, which enables you to store values and retrieve them the next time that the object is instantiated.  
  
> [!NOTE]
> In Visual Basic, to store simple data, such as a name or number, you can use the `My.Settings` object. For more information, see [My.Settings Object](../../../language-reference/objects/my-settings-object.md).  
  
 In this walkthrough, you will create a simple `Loan` object and persist its data to a file. You will then retrieve the data from the file when you re-create the object.  
  
> [!IMPORTANT]
> This example creates a new file, if the file does not already exist. If an application must create a file, that application must `Create` permission for the folder. Permissions are set by using access control lists. If the file already exists, the application needs only `Write` permission, a lesser permission. Where possible, it is more secure to create the file during deployment, and only grant `Read` permissions to a single file (instead of Create permissions for a folder). Also, it is more secure to write data to user folders than to the root folder or the Program Files folder.  
  
> [!IMPORTANT]
> This example stores data in a binary. These formats should not be used for sensitive data, such as passwords or credit-card information.  
  
> [!NOTE]
> The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, click **Import and Export Settings** on the **Tools** menu. For more information, see [Personalize the Visual Studio IDE](/visualstudio/ide/personalizing-the-visual-studio-ide).  
  
## Creating the Loan Object  

 The first step is to create a `Loan` class and a test application that uses the class.  
  
### To create the Loan class  
  
1. Create a new Class Library project and name it "LoanClass". For more information, see [Creating Solutions and Projects](/visualstudio/ide/creating-solutions-and-projects).  
  
2. In **Solution Explorer**, open the shortcut menu for the Class1 file and choose **Rename**. Rename the file to `Loan` and press ENTER. Renaming the file will also rename the class to `Loan`.  
  
3. Add the following public members to the class:  
  
    ```vb  
    Public Class Loan  
        Implements System.ComponentModel.INotifyPropertyChanged  
  
        Public Property LoanAmount As Double  
        Public Property InterestRate As Double  
        Public Property Term As Integer  
  
        Private p_Customer As String  
        Public Property Customer As String  
            Get  
                Return p_Customer  
            End Get  
            Set(ByVal value As String)  
                p_Customer = value  
                RaiseEvent PropertyChanged(Me,  
                  New System.ComponentModel.PropertyChangedEventArgs("Customer"))  
            End Set  
        End Property  
  
        Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler _  
          Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged  
  
        Public Sub New(ByVal loanAmount As Double,  
                       ByVal interestRate As Double,  
                       ByVal term As Integer,  
                       ByVal customer As String)  
  
            Me.LoanAmount = loanAmount  
            Me.InterestRate = interestRate  
            Me.Term = term  
            p_Customer = customer  
        End Sub  
    End Class  
    ```  
  
 You will also have to create a simple application that uses the `Loan` class.  
  
### To create a test application  
  
1. To add a Windows Forms Application project to your solution, on the **File** menu, choose **Add**,**New Project**.  
  
2. In the **Add New Project** dialog box, choose **Windows Forms Application**, and enter `LoanApp` as the name of the project, and then click **OK** to close the dialog box.  
  
3. In **Solution Explorer**, choose the LoanApp project.  
  
4. On the **Project** menu, choose **Set as StartUp Project**.  
  
5. On the **Project** menu, choose **Add Reference**.  
  
6. In the **Add Reference** dialog box, choose the **Projects** tab and then choose the LoanClass project.  
  
7. Click **OK** to close the dialog box.  
  
8. In the designer, add four <xref:System.Windows.Forms.TextBox> controls to the form.  
  
9. In the Code Editor, add the following code:  
  
    ```vb  
    Private WithEvents TestLoan As New LoanClass.Loan(10000.0, 0.075, 36, "Neil Black")  
  
    Private Sub Form1_Load() Handles MyBase.Load  
        TextBox1.Text = TestLoan.LoanAmount.ToString  
        TextBox2.Text = TestLoan.InterestRate.ToString  
        TextBox3.Text = TestLoan.Term.ToString  
        TextBox4.Text = TestLoan.Customer  
    End Sub  
    ```  
  
10. Add an event handler for the `PropertyChanged` event to the form by using the following code:  
  
    ```vb  
    Public Sub CustomerPropertyChanged(  
          ByVal sender As Object,  
          ByVal e As System.ComponentModel.PropertyChangedEventArgs  
        ) Handles TestLoan.PropertyChanged  
  
        MsgBox(e.PropertyName & " has been changed.")  
    End Sub  
    ```  
  
 At this point, you can build and run the application. Note that the default values from the `Loan` class appear in the text boxes. Try to change the interest-rate value from 7.5 to 7.1, and then close the application and run it again—the value reverts to the default of 7.5.  
  
 In the real world, interest rates change periodically, but not necessarily every time that the application is run. Rather than making the user update the interest rate every time that the application runs, it is better to preserve the most recent interest rate between instances of the application. In the next step, you will do just that by adding serialization to the Loan class.  
  
## Using Serialization to Persist the Object  

 In order to persist the values for the Loan class, you must first mark the class with the `Serializable` attribute.  
  
### To mark a class as serializable  
  
- Change the class declaration for the Loan class as follows:  
  
    ```vb  
    <Serializable()>  
    Public Class Loan  
    ```  
  
 The `Serializable` attribute tells the compiler that everything in the class can be persisted to a file. Because the `PropertyChanged` event is handled by a Windows Form object, it cannot be serialized. The `NonSerialized` attribute can be used to mark class members that should not be persisted.  
  
### To prevent a member from being serialized  
  
- Change the declaration for the `PropertyChanged` event as follows:  
  
    ```vb  
    <NonSerialized()>  
    Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler _  
      Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged  
    ```  
  
 The next step is to add the serialization code to the LoanApp application. In order to serialize the class and write it to a file, you will use the <xref:System.IO> and <xref:System.Xml.Serialization> namespaces. To avoid typing the fully qualified names, you can add references to the necessary class libraries.  
  
### To add references to namespaces  
  
- Add the following statements to the top of the `Form1` class:  
  
    ```vb  
    Imports System.IO  
    Imports System.Runtime.Serialization.Formatters.Binary  
    ```  
  
     In this case, you are using a binary formatter to save the object in a binary format.  
  
 The next step is to add code to deserialize the object from the file when the object is created.  
  
### To deserialize an object  
  
1. Add a constant to the class for the serialized data's file name.  
  
    ```vb  
    Const FileName As String = "..\..\SavedLoan.bin"  
    ```  
  
2. Modify the code in the `Form1_Load` event procedure as follows:  
  
    ```vb  
    Private WithEvents TestLoan As New LoanClass.Loan(10000.0, 0.075, 36, "Neil Black")  
  
    Private Sub Form1_Load() Handles MyBase.Load  
        If File.Exists(FileName) Then  
            Dim TestFileStream As Stream = File.OpenRead(FileName)  
            Dim deserializer As New BinaryFormatter  
            TestLoan = CType(deserializer.Deserialize(TestFileStream), LoanClass.Loan)  
            TestFileStream.Close()  
        End If  
  
        AddHandler TestLoan.PropertyChanged, AddressOf Me.CustomerPropertyChanged  
  
        TextBox1.Text = TestLoan.LoanAmount.ToString  
        TextBox2.Text = TestLoan.InterestRate.ToString  
        TextBox3.Text = TestLoan.Term.ToString  
        TextBox4.Text = TestLoan.Customer  
    End Sub  
    ```  
  
     Note that you first must check that the file exists. If it exists, create a <xref:System.IO.Stream> class to read the binary file and a <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> class to translate the file. You also need to convert from the stream type to the Loan object type.  
  
 Next you must add code to save the data entered in the text boxes to the `Loan` class, and then you must serialize the class to a file.  
  
### To save the data and serialize the class  
  
- Add the following code to the `Form1_FormClosing` event procedure:  
  
    ```vb  
    Private Sub Form1_FormClosing() Handles MyBase.FormClosing  
        TestLoan.LoanAmount = CDbl(TextBox1.Text)  
        TestLoan.InterestRate = CDbl(TextBox2.Text)  
        TestLoan.Term = CInt(TextBox3.Text)  
        TestLoan.Customer = TextBox4.Text  
  
        Dim TestFileStream As Stream = File.Create(FileName)  
        Dim serializer As New BinaryFormatter  
        serializer.Serialize(TestFileStream, TestLoan)  
        TestFileStream.Close()  
    End Sub  
    ```  
  
 At this point, you can again build and run the application. Initially, the default values appear in the text boxes. Try to change the values and enter a name in the fourth text box. Close the application and then run it again. Note that the new values now appear in the text boxes.  
  
## See also

- [Serialization (Visual Basic)](index.md)
- [Visual Basic Programming Guide](../../index.md)
