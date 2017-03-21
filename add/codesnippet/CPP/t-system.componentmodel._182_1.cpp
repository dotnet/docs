   protected:
      [ReflectionPermission(SecurityAction::Demand, Flags=ReflectionPermissionFlag::MemberAccess)]
      virtual void PreFilterProperties( System::Collections::IDictionary^ properties ) override
      {
         properties->Add( "OutlineColor", TypeDescriptor::CreateProperty( TestControlDesigner::typeid, "OutlineColor", System::Drawing::Color::typeid, nullptr ) );
      }