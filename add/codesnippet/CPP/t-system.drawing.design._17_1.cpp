      // PropertyValueUIHandler delegate that provides PropertyValueUIItem
      // objects to any properties named horizontalMargin or verticalMargin.
      void marginPropertyValueUIHandler( System::ComponentModel::ITypeDescriptorContext^ /*context*/, System::ComponentModel::PropertyDescriptor^ propDesc, ArrayList^ itemList )
      {
         // A PropertyValueUIHandler added to the IPropertyValueUIService
         // is queried once for each property of a component and passed
         // a PropertyDescriptor that represents the characteristics of
         // the property when the Properties window is set to a new
         // component. A PropertyValueUIHandler can determine whether
         // to add a PropertyValueUIItem for the object to its ValueUIItem
         // list depending on the values of the PropertyDescriptor.
         if ( propDesc->DisplayName->Equals( "horizontalMargin" ) )
         {
            Image^ img = DeserializeFromBase64Text( imageBlob1 );
            itemList->Add( gcnew PropertyValueUIItem( img,gcnew PropertyValueUIItemInvokeHandler( this, &PropertyUIComponent::marginInvoke ),"Test ToolTip" ) );
         }

         if ( propDesc->DisplayName->Equals( "verticalMargin" ) )
         {
            Image^ img = DeserializeFromBase64Text( imageBlob1 );
            img->RotateFlip( RotateFlipType::Rotate90FlipNone );
            itemList->Add( gcnew PropertyValueUIItem( img,gcnew PropertyValueUIItemInvokeHandler( this, &PropertyUIComponent::marginInvoke ),"Test ToolTip" ) );
         }
      }