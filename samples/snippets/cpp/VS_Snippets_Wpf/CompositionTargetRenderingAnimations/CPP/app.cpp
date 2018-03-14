//app.cpp file

#include "FollowExample/FollowExample.h"
#include "FrameIndependentFollowExample/FrameIndependentFollowExample.h"
#include "ReusableFollowExample/ReusableFollowExample.h"
#include "ParticleEffectExamples/ParticleEffectsExample.h"
#include "SimpleExample/SimpleExample.h"

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         ref class app;
         ref class SampleViewer;
      }
   }
}

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Navigation;
using namespace System::Windows::Media;
using namespace System::Windows::Media::Animation;
using namespace System::Windows::Shapes;
using namespace System::Windows::Controls;
using namespace System::IO;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {

         public ref class SampleViewer : Page {
         public: 
            SampleViewer () 
            {
               TabControl^ tControl = gcnew TabControl();
               TabItem^ tItem = gcnew TabItem();
               tItem->Header = "Color Changing Example";
               Frame^ contentFrame = gcnew Frame();
               contentFrame->Content = gcnew SimpleExample();
               tItem->Content = contentFrame;
               tControl->Items->Add(tItem);

               tItem = gcnew TabItem();
               tItem->Header = "Follow Animation";
               contentFrame = gcnew Frame();
               contentFrame->Content = gcnew FollowExample();
               tItem->Content = contentFrame;
               tControl->Items->Add(tItem);

               tItem = gcnew TabItem();
               tItem->Header = "Frame-Independent Follow Animation";
               contentFrame = gcnew Frame();
               contentFrame->Content = gcnew FrameIndependentFollowExample();
               tItem->Content = contentFrame;
               tControl->Items->Add(tItem);

               tItem = gcnew TabItem();
               tItem->Header = "Reusable Frame-Independent Follow Animation";
               contentFrame = gcnew Frame();
               contentFrame->Content = gcnew ReusableFollowExample();
               tItem->Content = contentFrame;
               tControl->Items->Add(tItem);
         
               tItem = gcnew TabItem();
               tItem->Header = "Particle Effect Examples";
               contentFrame = gcnew Frame();
               contentFrame->Content = gcnew ParticleEffectExamples();
               tItem->Content = contentFrame;
               tControl->Items->Add(tItem);

               this->Content = tControl;
               this->Title = "Per-Frame Animation Sample";
            };

         };


         public ref class app : Application {
         public: 
            app () 
            {
               AppDomain::CurrentDomain->UnhandledException += gcnew System::UnhandledExceptionEventHandler(this, &app::currentDomain_UnhandledException);
            };

         protected:
            virtual void OnStartup (StartupEventArgs^ e) override 
            {
               Window^ w = gcnew Window();
               w->Content = gcnew SampleViewer();
               w->Show();
               Application::OnStartup(e);
            };

         private: 
            void currentDomain_UnhandledException (System::Object^ sender, System::UnhandledExceptionEventArgs^ args) 
            {
               MessageBox::Show("Unhandled exception: " + args->ExceptionObject->ToString());
               System::IO::StreamWriter^ s = gcnew System::IO::StreamWriter("error.txt");
               s->Write(args->ExceptionObject->ToString());
               s->Flush();
               s->Close();
            };
         };

         private ref class EntryClass sealed {
         public: 
            [System::STAThread()]
            static void Main () 
            {
               PerFrameAnimations::app^ app = gcnew PerFrameAnimations::app();
               app->Run();
            };
         };
      }
   }
}

//Entry Point:
[System::STAThreadAttribute()]
void main ()
{
   return Microsoft::Samples::PerFrameAnimations::EntryClass::Main();
}
