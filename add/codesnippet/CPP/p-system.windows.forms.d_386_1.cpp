    public ref class DemoDesigner : public ControlDesigner
    {
    private:
        Adorner^ demoAdorner;

    protected:
        ~DemoDesigner()
        {
            if (demoAdorner != nullptr)
            {
                System::Windows::Forms::Design::Behavior::BehaviorService^ b = 
                    this->BehaviorService;
                if (b != nullptr)
                {
                    b->Adorners->Remove(demoAdorner);
                }
            }
        }

    public:
        virtual void Initialize(IComponent^ component) override
        {
            __super::Initialize(component);

            // Get a hold of the behavior service and add our own set
            // of glyphs.  Glyphs live on adorners.
            demoAdorner = gcnew Adorner();
            BehaviorService->Adorners->Add(demoAdorner);
            demoAdorner->Glyphs->Add 
                (gcnew DemoGlyph(BehaviorService, Control));
        }
    };