//ReusableFollowExample.cpp file

#include "FollowMouseCanvas.h"

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Data;
using namespace System::Windows::Documents;
using namespace System::Windows::Media;
using namespace System::Windows::Navigation;
using namespace System::Windows::Shapes;
using namespace System::Windows::Media::Animation;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         public ref class ReusableFollowExample : Page {
         public: 
            ReusableFollowExample () 
            {
               Canvas^ containerCanvas = gcnew System::Windows::Controls::Canvas();
               containerCanvas->Background = Brushes::Transparent;

               FollowMouseCanvas^ fmc1 = gcnew FollowMouseCanvas();
               fmc1->Background = Brushes::Red;
               fmc1->Width = 50;
               fmc1->Height = 50;
               Canvas::SetLeft(fmc1, 0);
               Canvas::SetTop(fmc1, 0);
               containerCanvas->Children->Add(fmc1);

               FollowMouseCanvas^ fmc2 = gcnew FollowMouseCanvas();
               fmc2->Background = Brushes::Green;
               fmc2->Width = 50;
               fmc2->Height = 50;
               Canvas::SetLeft(fmc2, 100);
               Canvas::SetTop(fmc2, 0);
               containerCanvas->Children->Add(fmc2);

               FollowMouseCanvas^ fmc3 = gcnew FollowMouseCanvas();
               fmc3->Background = Brushes::Blue;
               fmc3->Width = 50;
               fmc3->Height = 50;
               Canvas::SetLeft(fmc3, 0);
               Canvas::SetTop(fmc3, 100);
               containerCanvas->Children->Add(fmc3);

               this->Content = containerCanvas;
            };
         };
      }
   }
}