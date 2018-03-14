// System.Web.UI.DataBinding.Expression
// System.Web.UI.DataBindingCollection.Remove(string)
// System.Web.UI.DataBindingCollection.Item
// System.Web.UI.DataBinding.DataBinding
// System.Web.UI.DataBinding.Expression
// System.Web.UI.DataBindingCollection.SyncRoot
// System.Web.UI.DataBindingCollection.Add(DataBinding)
// System.Web.UI.DataBindingCollection.DataBindingCollection
// System.Web.UI.DataBindingCollection.RemovedBindings
// System.Web.UI.DataBindingCollection.GetEnumerator
// System.Web.UI.DataBinding.PropertyName
// System.Web.UI.DataBinding.PropertyType
// System.Web.UI.DataBindingCollection.Count
// System.Web.UI.DataBindingCollection.IsReadOnly
// System.Web.UI.DataBindingCollection.IsSynchronized
// System.Web.UI.DataBindingCollection.CopyTo
// System.Web.UI.DataBindingCollection.GetHashCode
// System.Web.UI.DataBindingCollection.Remove(DataBinding)
// System.Web.UI.DataBindingCollection.Remove(string,true)
// System.Web.UI.DataBindingCollection.Clear()
// System.Web.UI.DataBindingHandlerAttribute
// System.Web.UI.DataBindingHandlerAttribute.IsDefaultAttribute().
/*The following example demonstrates the  members of 'DataBinding' and 
' 'DataBindingCollection'.A new control 'SimpleWebControl'  is created 
and a 'Designer' attribute is attached to it which actually refers to the 
DesignTimeClass.The 'OnBindingsCollectionChanged(string)' method  is overridden 
to actually capture the DataBindingCollection instance and add the 
DataBinding Expression to the property in the ASPX file. When 'Text' property of the 
SimpleWebControl is bound to the 'Text' property of 'Button1' at the DesignTime 
using the IDE, the 'OnBindingCollectionChanged' method is called and 
the 'Text' property of the 'SimpleWebControl' is updated in .aspx file.
The actual DataBinding is done at the runtime.The  properties of the 'DataBinding'
and 'DataBindingCollection' are written into a text file (DataBindingOutput.txt)
in drive C.The Output is written at the design time itself.

Note:This program has to be tested at "DesignTime".
These are the instructions to be followed to successfully test the functionality of the program.
1) Create a new "C# WebApplication" project.
2) Add Reference "System.Design.dll" to the project. 
3) Add the 'DataBinding.aspx' and 'WebCustomControl1.cs' files to the project, 
which are provided with this example.
4) In the 'DataBinding.aspx' file, make the assembly name same as the 
"Project Name", created in step1.
5)Build the project.
6)Go to the "DesignTab" of the 'DataBinding.aspx' file.
7)Go to the properties window of the SimpleWebcontrol, built in Step5.
8)Go to the DataBindings column.
9)Select the "Text" property.
10)Select the "CustomBindingExpression" option.
11)Associate the Text property to any property of any control which is of the 
type string.
12)Observe in "C:\" a file created with the name "DataBindingOutput.txt".
This file contains the properties of 'DataBinding' and 'DataBindingCollection' 
classes demonstrated. 
*/
#using <System.Design.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Web.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::UI;
using namespace System::Web::UI::WebControls;
using namespace System::ComponentModel;
using namespace System::Web::UI::Design;
using namespace System::IO;
using namespace System::Text;
using namespace System::Collections;

namespace DataBindingTest
{
   public ref class SimpleDesigner: public System::Web::UI::Design::ControlDesigner
   {
   public:

      property String^ Text 
      {

         // The DesigneTime manipulation is done by this class.
         String^ get()
         {
            // <Snippet1>
            DataBinding^ myBinding = DataBindings[ "Text" ];
            if ( myBinding != nullptr )
            {
               return myBinding->Expression;
            }

            return String::Empty;
            // </Snippet1>
         }

         void set( String^ value )
         {
            // <Snippet2>
            if ( (value == nullptr) || (value->Length == 0) )
            {
               DataBindings->Remove( "Text" );
            }
            // </Snippet2>
            else
            {
               // <Snippet3>
               DataBinding^ binding = DataBindings[ "Text" ];
               // </Snippet3>

               // <Snippet4>
               if ( binding == nullptr )
               {
                  binding = gcnew DataBinding( "Text",String::typeid,value );
               }
               // </Snippet4>
               // <Snippet5>
               else
               {
                  binding->Expression = value;
               }
               //</Snippet5>
               // <Snippet7>
               // <Snippet6>
               DataBinding^ binding1 = dynamic_cast<DataBinding^>(DataBindings->SyncRoot);
               DataBindings->Add( binding );
               DataBindings->Add( binding1 );
               
               // </Snippet6>
               // </Snippet7>
            }

            OnBindingsCollectionChanged( "Text" );
         }
      }

   protected:
      virtual void OnBindingsCollectionChanged( String^ propName ) override
      {
         // This method actually forms an DataBindingExpression of the design time and associates it to the Property of the Control.
         IHtmlControlDesignerBehavior^ myHtmlControlDesignBehavior = Behavior;
         DataBindingCollection^ myDataBindingCollection;
         DataBinding^ myDataBinding1;
         DataBinding^ myDataBinding2;
         String^ myStringReplace1;
         String^ myDataBindingExpression1;
         String^ removedBinding;
         String^ removedBindingAfterReplace;
         String^ myDataBindingExpression2;
         String^ myStringReplace2;
         array<String^>^removedBindings1;
         array<String^>^removedBindings2;
         Int32 temp;
         IEnumerator^ myEnumerator;
         if ( myHtmlControlDesignBehavior == nullptr )
                  return;

         // <Snippet8>
         DataBindingCollection^ myDataBindingCollection1 = gcnew DataBindingCollection;
         myDataBindingCollection1 = myDataBindingCollection = DataBindings;
         // </Snippet8>
         if ( propName != nullptr )
         {
            myDataBinding1 = myDataBindingCollection[ propName ];
            myStringReplace1 = propName->Replace( ".", "-" );
            if ( myDataBinding1 == nullptr )
            {
               myHtmlControlDesignBehavior->RemoveAttribute( myStringReplace1, true );
               return;
            }
            
            // DataBinding is not null.
            myDataBindingExpression1 = String::Concat( "<%#", myDataBinding1->Expression, "%>" );
            myHtmlControlDesignBehavior->SetAttribute( myStringReplace1, myDataBindingExpression1, true );
            int index = myStringReplace1->IndexOf( "-" );
         }
         else
         {
            // <Snippet9>
            removedBindings2 = removedBindings1 = DataBindings->RemovedBindings;
            // </Snippet9>

            temp = 0;
            while ( removedBindings2->Length > temp )
            {
               removedBinding = removedBindings2[ temp ];
               removedBindingAfterReplace = removedBinding->Replace( '.', '-' );
               myHtmlControlDesignBehavior->RemoveAttribute( removedBindingAfterReplace, true );
               temp = temp + 1;
            }
            myDataBindingCollection = DataBindings;
            myEnumerator = myDataBindingCollection->GetEnumerator();
            while ( myEnumerator->MoveNext() )
            {
               // <Snippet11>
               // <Snippet12>
               myDataBinding2 = dynamic_cast<DataBinding^>(myEnumerator->Current);
               String^ dataBindingOutput1;
               String^ dataBindingOutput2;
               String^ dataBindingOutput3;
               dataBindingOutput1 = String::Concat( "The property name is ", myDataBinding2->PropertyName );
               dataBindingOutput2 = String::Concat( "The property type is ", myDataBinding2->PropertyType->ToString(), "-", dataBindingOutput1 );
               dataBindingOutput3 = String::Concat( "The expression is ", myDataBinding2->Expression, "-", dataBindingOutput2 );
               WriteToFile( dataBindingOutput3 );
               // </Snippet12>
               // </Snippet11>

               myDataBindingExpression2 = String::Concat( "<%#", myDataBinding2->Expression, "%>" );
               myStringReplace2 = myDataBinding2->PropertyName->Replace( ".", "-" );
               myHtmlControlDesignBehavior->SetAttribute( myStringReplace2, myDataBindingExpression2, true );
               int index = myStringReplace2->IndexOf( '-' );
            }
            // <Snippet13>
            // <Snippet14>
            // <Snippet15>
            String^ dataBindingOutput4;
            String^ dataBindingOutput5;
            String^ dataBindingOutput6;
            String^ dataBindingOutput7;
            String^ dataBindingOutput8;
            dataBindingOutput4 = String::Concat( "The Count of the collection is ", myDataBindingCollection1->Count );
            dataBindingOutput5 = String::Concat( "The IsSynchronised property of the collection is ", myDataBindingCollection1->IsSynchronized, "-", dataBindingOutput4 );
            dataBindingOutput6 = String::Concat( "The IsReadOnly property of the collection is ", myDataBindingCollection1->IsReadOnly, "-", dataBindingOutput5 );
            WriteToFile( dataBindingOutput6 );
            
            // </Snippet15>
            // </Snippet14>
            // </Snippet13>
            // <Snippet16>
            System::Array^ dataBindingCollectionArray = Array::CreateInstance( Object::typeid, myDataBindingCollection1->Count );
            myDataBindingCollection1->CopyTo( dataBindingCollectionArray, 0 );
            dataBindingOutput7 = String::Concat( "The count of DataBindingArray is  ", dataBindingCollectionArray->Length );
            WriteToFile( dataBindingOutput7 );
            
            // </Snippet16>
            IEnumerator^ myEnumerator1 = myDataBindingCollection1->GetEnumerator();
            if ( myEnumerator1->MoveNext() )
            {
               // <Snippet17>
               myDataBinding1 = dynamic_cast<DataBinding^>(myEnumerator1->Current);
               dataBindingOutput8 = String::Concat( "The HashCode is", myDataBinding1->GetHashCode().ToString() );
               WriteToFile( dataBindingOutput8 );
               
               // <Snippet18>
               myDataBindingCollection1->Remove( myDataBinding1 );
               dataBindingOutput8 = String::Concat( "The Count of the collection after DataBinding is removed is  ", myDataBindingCollection1->Count );
               WriteToFile( dataBindingOutput8 );
               // </Snippet18>
               // </Snippet17>
            }
            else
            {
               myDataBinding1 = dynamic_cast<DataBinding^>(myEnumerator1->Current);
               
               // <Snippet19>
               myDataBindingCollection1->Remove( "Text", true );
               dataBindingOutput8 = String::Concat( "The Count of the collection after DataBinding is removed is  ", myDataBindingCollection1->Count );
               WriteToFile( dataBindingOutput8 );
               // </Snippet19>

               // <Snippet20>
               myDataBindingCollection1->Clear();
               dataBindingOutput8 = String::Concat( "The Count of the collection after clear method is called  ", myDataBindingCollection1->Count );
               WriteToFile( dataBindingOutput8 );
               // </Snippet20>
            }
         }
      }

   public:
      void WriteToFile( String^ input )
      {
         // This method writes the values of the properties at the design time into a Text file DataBindingOutput.txt in the "C"  of the system.
         StreamWriter^ myFile = File::AppendText( "C:\\DataBindingOutput.txt" );
         ASCIIEncoding^ encoder = gcnew ASCIIEncoding;
         array<Byte>^ByteArray = encoder->GetBytes( input );
         array<Char>^CharArray = encoder->GetChars( ByteArray );
         myFile->WriteLine( CharArray, 0, input->Length );
         myFile->Close();
      }
   };
   // <Snippet21>
   [DefaultProperty("Text"),
   ToolboxData("<{0}:Simple runat=server></{0}:Simple>"),
   Designer("DataBindingTest.SimpleDesigner"),
   DataBindingHandlerAttribute(System::Web::UI::Design::TextDataBindingHandler::typeid)
   ]
   // </Snippet21>
   public ref class SimpleWebControl: public WebControl
   {
   private:

      //A control derived from 'System.Web.UI.WebControl' class with single property 'Text'.
      String^ _Text;

   public:
      property String^ Text 
      {

         [Bindable(true)]
         String^ get()
         {
            return _Text;
         }

         void set( String^ value )
         {
            _Text = value;
         }
      }

   protected:
      // <Snippet22>
      virtual void Render( HtmlTextWriter^ output ) override
      {
         output->Write( "<br>This is the Text of SimpleWebControl : {0}", _Text );
         IEnumerator^ myEnum = SimpleWebControl::typeid->GetCustomAttributes( true )->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Object^ attribute = safe_cast<Object^>(myEnum->Current);
            if ( dynamic_cast<DataBindingHandlerAttribute^>(attribute) )
            {
               DataBindingHandlerAttribute^ myDataBindingHandlerAttribute = dynamic_cast<DataBindingHandlerAttribute^>(attribute);
               output->Write( "<br><br><br>The IsDefaultAttribute of DataBindingHandlerAttribute is :{0}", myDataBindingHandlerAttribute->IsDefaultAttribute() );
               output->Write( "<br><br><br>DataBinding HandlerTypeName:{0}", myDataBindingHandlerAttribute->HandlerTypeName );
            }
         }
      }
      // </Snippet22>
   };
}
