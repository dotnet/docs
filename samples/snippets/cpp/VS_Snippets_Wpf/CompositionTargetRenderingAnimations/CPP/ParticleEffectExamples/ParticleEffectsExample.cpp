//ParticleEffectsExample.cpp file

#include "FireworkEffect.h"
#include "MagnetismCanvas.h"
#include "SonicEffect.h"

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Data;
using namespace System::Windows::Documents;
using namespace System::Windows::Media;
using namespace System::Windows::Navigation;
using namespace System::Windows::Shapes;
using namespace System::Collections::Generic;
using namespace System::Collections;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         public ref class ParticleEffectExamples : Page {
         public:
            ParticleEffectExamples () 
            {

               Canvas^ pageCanvas = gcnew Canvas();
               MagnitismCanvas^ magCanvas = gcnew MagnitismCanvas();

               DockPanel^ mainPanel = gcnew DockPanel();
               Border^ panelBorder = gcnew Border();
               panelBorder->BorderBrush = Brushes::Black;
               panelBorder->Background = Brushes::Green;
               panelBorder->Padding = Thickness(10);
               DockPanel::SetDock(panelBorder, Dock::Top);

               StackPanel^ sliderPanel = gcnew StackPanel();
               sliderPanel->Orientation = Orientation::Vertical;
               // Drag Slider
               StackPanel^ sp1 = gcnew StackPanel();
               TextBlock^ sp1Label = gcnew TextBlock();
               sp1Label->Text = "Drag:";
               sp1->Children->Add(sp1Label);
               Slider^ slider1 = gcnew Slider();
               slider1->Orientation = Orientation::Horizontal;
               slider1->Minimum = 0.0;
               slider1->Maximum = 1.0;
               slider1->SmallChange = 0.05;
               slider1->LargeChange = 0.2;
               Binding^ theBinding = gcnew Binding("Drag");
               theBinding->Source = magCanvas;
               slider1->SetBinding(Slider::ValueProperty, theBinding);
               sp1->Children->Add(slider1);
               sliderPanel->Children->Add(sp1);

               // Border Force slider
               sp1 = gcnew StackPanel();
               sp1Label = gcnew TextBlock();
               sp1Label->Text = "Border Force:";
               sp1->Children->Add(sp1Label);
               slider1 = gcnew Slider();
               slider1->Orientation = Orientation::Horizontal;
               slider1->Minimum = 0.0;
               slider1->Maximum = 5000.0;
               slider1->SmallChange = 100;
               slider1->LargeChange = 500;
               theBinding = gcnew Binding("BorderForce");
               theBinding->Source = magCanvas;
               slider1->SetBinding(Slider::ValueProperty, theBinding);
               sp1->Children->Add(slider1);
               sliderPanel->Children->Add(sp1);

               // Border Force slider
               sp1 = gcnew StackPanel();
               sp1Label = gcnew TextBlock();
               sp1Label->Text = "Child Force:";
               sp1->Children->Add(sp1Label);
               slider1 = gcnew Slider();
               slider1->Orientation = Orientation::Horizontal;
               slider1->Minimum = 0.0;
               slider1->Maximum = 1000.0;
               slider1->SmallChange = 19;
               slider1->LargeChange = 100;
               theBinding = gcnew Binding("ChildForce");
               theBinding->Source = magCanvas;
               slider1->SetBinding(Slider::ValueProperty, theBinding);
               sp1->Children->Add(slider1);
               sliderPanel->Children->Add(sp1);
               panelBorder->Child = sliderPanel;
               mainPanel->Children->Add(panelBorder);

               // Setup the magnitism canvas.
               magCanvas->Drag = 0.8;
               magCanvas->BorderForce = 1000;
               magCanvas->ChildForce = 100;
               theBinding = gcnew Binding("ActualWidth");
               theBinding->Source = pageCanvas;
               magCanvas->SetBinding(MagnitismCanvas::WidthProperty, theBinding);
               theBinding = gcnew Binding("ActualHeight");
               theBinding->Source = pageCanvas;
               magCanvas->SetBinding(MagnitismCanvas::HeightProperty, theBinding);

               FireworkEffect^ fire1 = gcnew FireworkEffect();
               Canvas::SetTop(fire1, 100);
               Canvas::SetLeft(fire1, 100);
               Button^ effectBtn = gcnew Button();
               effectBtn->Content = "Click For Fireworks";
               fire1->Child = effectBtn;
               magCanvas->Children->Add(fire1);

               SonicEffect^ sonic1 = gcnew SonicEffect();
               Canvas::SetTop(sonic1, 200);
               Canvas::SetLeft(sonic1, 200);
               sonic1->RingThickness = 10;
               sonic1->RingRadius = 15;
               sonic1->RingDelay = TimeSpan(0, 0, 0, 0, 100);
               sonic1->RingColor = Color::FromArgb(22, 55, 33, 66);
               effectBtn = gcnew Button();
               effectBtn->Content = "Click For Sonic Burst";
               sonic1->Child = effectBtn;
               magCanvas->Children->Add(sonic1);

               fire1 = gcnew FireworkEffect();
               Canvas::SetTop(fire1, 300);
               Canvas::SetLeft(fire1, 100);
               effectBtn = gcnew Button();
               effectBtn->Content = "Click For Fireworks";
               fire1->Child = effectBtn;
               magCanvas->Children->Add(fire1);

               sonic1 = gcnew SonicEffect();
               Canvas::SetTop(sonic1, 400);
               Canvas::SetLeft(sonic1, 200);
               sonic1->RingThickness = 10;
               sonic1->RingRadius = 15;
               sonic1->RingDelay = TimeSpan(0, 0, 0, 0, 100);
               sonic1->RingColor = Color::FromArgb(22, 55, 33, 66);
               effectBtn = gcnew Button();
               effectBtn->Content = "Click For Sonic Burst";
               sonic1->Child = effectBtn;
               magCanvas->Children->Add(sonic1);

               fire1 = gcnew FireworkEffect();
               Canvas::SetTop(fire1, 500);
               Canvas::SetLeft(fire1, 100);
               effectBtn = gcnew Button();
               effectBtn->Content = "Click For Fireworks";
               fire1->Child = effectBtn;
               magCanvas->Children->Add(fire1);

               sonic1 = gcnew SonicEffect();
               Canvas::SetTop(sonic1, 100);
               Canvas::SetLeft(sonic1, 600);
               sonic1->RingThickness = 10;
               sonic1->RingRadius = 15;
               sonic1->RingDelay = TimeSpan(0, 0, 0, 0, 100);
               sonic1->RingColor = Color::FromArgb(22, 55, 33, 66);
               effectBtn = gcnew Button();
               effectBtn->Content = "Click For Sonic Burst";
               sonic1->Child = effectBtn;
               magCanvas->Children->Add(sonic1);

               fire1 = gcnew FireworkEffect();
               Canvas::SetTop(fire1, 200);
               Canvas::SetLeft(fire1, 500);
               effectBtn = gcnew Button();
               effectBtn->Content = "Click For Fireworks";
               fire1->Child = effectBtn;
               magCanvas->Children->Add(fire1);

               sonic1 = gcnew SonicEffect();
               Canvas::SetTop(sonic1, 300);
               Canvas::SetLeft(sonic1, 600);
               sonic1->RingThickness = 10;
               sonic1->RingRadius = 15;
               sonic1->RingDelay = TimeSpan(0, 0, 0, 0, 100);
               sonic1->RingColor = Color::FromArgb(22, 55, 33, 66);
               effectBtn = gcnew Button();
               effectBtn->Content = "Click For Sonic Burst";
               sonic1->Child = effectBtn;
               magCanvas->Children->Add(sonic1);

               fire1 = gcnew FireworkEffect();
               Canvas::SetTop(fire1, 400);
               Canvas::SetLeft(fire1, 500);
               effectBtn = gcnew Button();
               effectBtn->Content = "Click For Fireworks";
               fire1->Child = effectBtn;
               magCanvas->Children->Add(fire1);

               sonic1 = gcnew SonicEffect();
               Canvas::SetTop(sonic1, 500);
               Canvas::SetLeft(sonic1, 600);
               sonic1->RingThickness = 10;
               sonic1->RingRadius = 15;
               sonic1->RingDelay = TimeSpan(0, 0, 0, 0, 100);
               sonic1->RingColor = Color::FromArgb(22, 55, 33, 66);
               effectBtn = gcnew Button();
               effectBtn->Content = "Click For Sonic Burst";
               sonic1->Child = effectBtn;
               magCanvas->Children->Add(sonic1);

               pageCanvas->Children->Add(magCanvas);
               mainPanel->Children->Add(pageCanvas);
               this->Content = mainPanel;
            }
            ;
         };
      }
   }
}

