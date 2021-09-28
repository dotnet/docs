//app.cpp file


using namespace System;
using namespace System::Windows;
using namespace System::Windows::Navigation;
using namespace System::Windows::Media;
using namespace System::Windows::Media::Animation;
using namespace System::Windows::Shapes;
using namespace System::Windows::Controls;
using namespace System::Windows::Input;


namespace Microsoft {
   namespace Samples {
      namespace Animation {
         namespace LocalAnimations {

            // Forward class declaration.
            public ref class LocalAnimationExample : Page {
            public:
               LocalAnimationExample () ;
            };

            // Forward class declaration.
            public ref class InteractiveAnimationExample : Page {
            public:
               InteractiveAnimationExample () ;
            private:
               TranslateTransform^ interactiveTranslateTransform;
               Border^ containerBorder;
               Ellipse^ interactiveEllipse;
               void border_mouseLeftButtonDown (System::Object^ sender, MouseButtonEventArgs^ e) ;
               void border_mouseRightButtonDown (System::Object^ sender, MouseButtonEventArgs^ e) ;
            };

            // SampleViewer class.
            public ref class SampleViewer : Window {
            public: 
               SampleViewer (){
                  TabControl^ tControl = gcnew TabControl();
                  TabItem^ tItem = gcnew TabItem();
                  tItem->Header = "Local Animation Example";
                  Frame^ contentFrame = gcnew Frame();
                  contentFrame->Content = gcnew LocalAnimationExample();
                  tItem->Content = contentFrame;
                  tControl->Items->Add(tItem);
                  tItem = gcnew System::Windows::Controls::TabItem();
                  tItem->Header = "Interactive Animation Example";
                  contentFrame = gcnew System::Windows::Controls::Frame();
                  contentFrame->Content = gcnew InteractiveAnimationExample();
                  tItem->Content = contentFrame;
                  tControl->Items->Add(tItem);
                  this->Content = tControl;
                  this->Title = "Local Animations Example";
               } ;
            };

            // Application class.
            public ref class app : Application {
            protected: 
               virtual void OnStartup (System::Windows::StartupEventArgs^ e) override 
               {
                  Application::OnStartup(e);
                  CreateAndShowMainWindow();
               };

            private: 
               void CreateAndShowMainWindow () 
               {
                  // Create the application's main window.
                  Window^ sViewer = gcnew SampleViewer();
                  MainWindow = sViewer;
                  sViewer->Show();
               };
            };

            private ref class EntryClass sealed {
            public: 
               [System::STAThread()]
               static void Main () 
               {
                  LocalAnimations::app^ app = gcnew LocalAnimations::app();
                  app->Run();
               }
               ;
            };

         }
      }
   }
}

//Entry Point:
[System::STAThreadAttribute()]
void main ()
{
   return Microsoft::Samples::Animation::LocalAnimations::EntryClass::Main();
}
