      public override ObjRef CreateObjRef(Type ServerType)
      {  
         Console.WriteLine ("CreateObjRef Method Called ..."); 
         CustomObjRef myObjRef = new CustomObjRef(myMarshalByRefObject,ServerType);
         myObjRef.URI = myUri ;
         return myObjRef;
      }