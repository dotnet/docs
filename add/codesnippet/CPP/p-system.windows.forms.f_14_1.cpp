public:
   void MoveMyForm()
   {
      // Create a Point object that will be used as the location of the form.
      Point tempPoint = Point( 100, 100 );
      // Set the location of the form using the Point object.
      this->DesktopLocation = tempPoint;
   }