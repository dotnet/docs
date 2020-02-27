//SimpleExample.cpp file

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Data;
using namespace System::Windows::Documents;
using namespace System::Windows::Media;
using namespace System::Windows::Navigation;
using namespace System::Windows::Shapes;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         public ref class SimpleExample : Page {

         public: 
            SimpleExample () 
            {
               _initFields();
               StackPanel^ myPanel = gcnew StackPanel();
               Rectangle^ rect = gcnew Rectangle();

               rect->Width = 50;
               rect->Height = 50;
               rect->Fill = animatedBrush;

               CompositionTarget::Rendering += gcnew EventHandler(this, &Microsoft::Samples::PerFrameAnimations::SimpleExample::UpdateColor);

               myPanel->Children->Add(rect);
               this->Content = myPanel;
            };

         private: 
            System::Random^ rand;
            SolidColorBrush^ animatedBrush;

         protected: 
            void UpdateColor (Object^ sender, EventArgs^ e) 
            {
               animatedBrush->Color = Color::FromRgb(((System::Byte)rand->Next(255)), ((System::Byte)rand->Next(255)), ((System::Byte)rand->Next(255)));
            };

         private: 
            void _initFields() 
            {
               rand = gcnew Random();
               animatedBrush = gcnew SolidColorBrush();
            };

         };
      }
   }
}
