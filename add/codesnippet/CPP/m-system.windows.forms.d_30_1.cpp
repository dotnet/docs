    public:
        DemoGlyph(BehaviorService^ behavior, Control^ control):
          Glyph(gcnew BehaviorServiceSample::DemoBehavior)
          {
              this->behavior = behavior;
              this->control = control;
          }