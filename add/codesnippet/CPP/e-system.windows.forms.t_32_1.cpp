        ToolStripButton^ changeDirectionButton;

        void InitializeMovingToolStrip()
        {
            changeDirectionButton = gcnew ToolStripButton;
            movingToolStrip->AutoSize = true;
            movingToolStrip->RenderMode = ToolStripRenderMode::System;
            changeDirectionButton->TextDirection = 
                ToolStripTextDirection::Vertical270;
            changeDirectionButton->Overflow = 
                ToolStripItemOverflow::Never;
            changeDirectionButton->Text = "Change Alignment";
            movingToolStrip->Items->Add(changeDirectionButton);
            changeDirectionButton->Click += gcnew EventHandler(this, 
                &Form1::changeDirectionButtonClick);
        }

        void changeDirectionButtonClick(Object^ sender, EventArgs^ e)
        {
            ToolStripItem^ item = (ToolStripItem^) sender;
            if ((item->TextDirection == ToolStripTextDirection::Vertical270) 
                || (item->TextDirection == ToolStripTextDirection::Vertical90))
            {
                item->TextDirection = ToolStripTextDirection::Horizontal;
                movingToolStrip->Raft = RaftingSides::Top;
            }
            else
            {
                item->TextDirection = 
                    ToolStripTextDirection::Vertical270;
                movingToolStrip->Raft = RaftingSides::Left;
            }
        }

