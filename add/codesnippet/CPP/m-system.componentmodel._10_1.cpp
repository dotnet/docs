      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar1))->BeginInit();
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar2))->BeginInit();
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar3))->BeginInit();
      this->SuspendLayout();
      
      // 
      // trackBar1
      // 
      this->trackBar1->Location = System::Drawing::Point( 160, 400 );
      this->trackBar1->Name = "trackBar1";
      this->trackBar1->TabIndex = 1;
      this->trackBar1->Scroll += gcnew System::EventHandler( this, &Form1::trackBar_Scroll );
      
      // 
      // trackBar2
      // 
      this->trackBar2->Location = System::Drawing::Point( 608, 40 );
      this->trackBar2->Name = "trackBar2";
      this->trackBar2->TabIndex = 2;
      this->trackBar2->Scroll += gcnew System::EventHandler( this, &Form1::trackBar_Scroll );
      
      // 
      // trackBar3
      // 
      this->trackBar3->Location = System::Drawing::Point( 56, 40 );
      this->trackBar3->Name = "trackBar3";
      this->trackBar3->TabIndex = 3;
      this->trackBar3->Scroll += gcnew System::EventHandler( this, &Form1::trackBar_Scroll );
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar1))->EndInit();
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar2))->EndInit();
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar3))->EndInit();
      