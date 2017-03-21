            demoAdorner = gcnew Adorner();
            BehaviorService->Adorners->Add(demoAdorner);
            demoAdorner->Glyphs->Add 
                (gcnew DemoGlyph(BehaviorService, Control));