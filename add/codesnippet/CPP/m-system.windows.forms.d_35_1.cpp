   protected:
      virtual void ConcedeFocus() override
      {
         // Hide the TextBox when conceding focus.
         DataGridTextBoxColumn::TextBox->Visible = false;
      }