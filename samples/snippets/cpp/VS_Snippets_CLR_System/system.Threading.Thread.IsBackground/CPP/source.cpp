
// <Snippet1>
using namespace System;
using namespace System::Threading;

ref class BackgroundTest
{
private:
   int maxIterations;

public:
   BackgroundTest(int maxIterations)
   {
      this->maxIterations = maxIterations;
   }

   void RunLoop()
   {
      for (int i = 0; i < maxIterations; i++ )
      {
         Console::WriteLine("{0} count: {1}", 
              Thread::CurrentThread->IsBackground ? 
              "Background Thread" : "Foreground Thread", i);
         Thread::Sleep(250);

      }
      Console::WriteLine("{0} finished counting.", 
                         Thread::CurrentThread->IsBackground ? 
                         "Background Thread" : "Foreground Thread");
   }
};

int main()
{
   BackgroundTest^ shortTest = gcnew BackgroundTest( 10 );
   Thread^ foregroundThread = gcnew Thread( gcnew ThreadStart( shortTest, &BackgroundTest::RunLoop ) );
   foregroundThread->Name =  "ForegroundThread";
   BackgroundTest^ longTest = gcnew BackgroundTest( 50 );
   Thread^ backgroundThread = gcnew Thread( gcnew ThreadStart( longTest, &BackgroundTest::RunLoop ) );
   backgroundThread->Name =  "BackgroundThread";
   backgroundThread->IsBackground = true;
   foregroundThread->Start();
   backgroundThread->Start();
}

// </Snippet1>
