
//<snippet1>
#include "stdafx.h"
#include <windows.h>
#include <iostream>
#include <ppl.h>
#include <agents.h>
#include <stdio.h>
#include <concrtrm.h>
#include <vector>

CRITICAL_SECTION cs;

using namespace ::std;
using namespace ::std::tr1;
using namespace ::Concurrency;
task_group task4;
task_group task3;
task_group task2;

volatile long aa = 0;
volatile long bb = 0;
volatile long cc = 0;
static bool waitFor1 = true;
static bool waitFor5 = true;

#pragma optimize("", off)
void Spin()
{
   for(int i=0;i<50*50000;++i);
}
#pragma optimize("",on)

template<class Func>
class RunFunc
{
   Func& m_Func;
   int m_o;
public:
   RunFunc(Func func,int o):m_Func(func),m_o(o){

   };
   void operator()()const{
      m_Func(m_o);
   };
};

void T(int o)
{
   cout << "Scheduled run \n";

};

void R(int o)
{
   if (o == 2)
   {
      while (waitFor5) { ;}
      Spin();

      //use up all processors but 4 by scheduling 4 non-terminating tasks.
      int numProcsToBurn = GetProcessorCount() - 4;
      int i;
      vector<call<int>*> tasks;
      for (i = 0; i <  numProcsToBurn; i++)
      {
         tasks.push_back(new call<int>([](int i){while(true)Spin();}));
         asend(tasks[i],1);
         cout << "Started task  \n";
      }

      task_handle<RunFunc<decltype(T)>> t6(RunFunc<decltype(T)>(T,i + 1 + 5));
      task_handle<RunFunc<decltype(T)>> t7(RunFunc<decltype(T)>(T,i + 2 + 5));
      task_handle<RunFunc<decltype(T)>> t8(RunFunc<decltype(T)>(T,i + 3 + 5));
      task_handle<RunFunc<decltype(T)>> t9(RunFunc<decltype(T)>(T,i + 4 + 5));
      task_handle<RunFunc<decltype(T)>> t10(RunFunc<decltype(T)>(T,i + 5 + 5));
      task2.run(t6);
      task2.run(t7);
      task2.run(t8);
      task2.run(t9);
      task2.run(t10);
   
      //BP4 - 1 in M, 2 in R, 3 in J, 4 in R, 5 died   
      DebugBreak();
   }
   else
   {
      if (o!=4)
         throw;

      task3.wait();      
   }
};

void Q()
{
   // breaks here at the same time as N and M
   InterlockedIncrement(& cc);
   while (cc < 4)
   {
      ;
   }
   // task 5 dies here freeing task 4 (its parent)
   cout << "t5 dies\n";
   waitFor5 = false;
};

void P()
{
   cout << "t5 runs\n";
   Q();
};

void O(int o)
{   
   task_group t5;
   t5.run(&P);
   t5.wait();
   R(o);
};

void N(int o)
{
   // breaks here at the same time as M and Q
   InterlockedIncrement(&cc);
   while (cc < 4)
   {
      ;
   }
   R(o);
};

void M(int o)
{
   // breaks here at the same time as N and Q
   InterlockedIncrement(&cc);
   while (cc < 3)
   {
      ;
   }
   //BP3 - 1 in M, 2 in N, 3 still in J, 4 in O, 5 in Q
   DebugBreak();
   InterlockedIncrement(&cc);
   while (true)
      Sleep(500); // for ever
};

void L(int oo)
{
   int temp3 = oo;

   switch (temp3)
   {
   case 1:
      M(oo);
      break;
   case 2:
      N(oo);
      break;
   case 4:
      O(oo);
      break;
   default:
      throw; //fool3
      break;
   }
}
void K(int o)
{
   // break here at the same time as E and H
   InterlockedIncrement(&bb);
   EnterCriticalSection(&cs);
   while (bb < 3)
   {
      ;
   }
   LeaveCriticalSection(&cs);
   Spin();

   //after
   L(o);
}
void J(int o)
{
   int temp2 = o;

   switch (temp2)
   {
   case 3:
      task4.wait();
      break;
   case 4:
      K(o);
      break;
   default:
      throw; //fool2
      break;
   }
}
static void I(int o)
{
   J(o);
}
static void H(int o)
{
   // break here at the same time as E and K
   InterlockedIncrement(&bb);
   EnterCriticalSection(&cs);
   while (bb < 3)
   {
      ;
   }
   LeaveCriticalSection(&cs);
   Spin();

   //after
   L(o);
}
static void G(int o)
{
   H(o);
}
static void F(int o)
{
   G(o);
}

static void E(int o)
{
   // break here at the same time as H and K
   while (bb < 2)
   {
      ;
   }
   //BP2 - 1 in E, 2 in H, 3 in J, 4 in K   
   Spin(); // for native case only
   DebugBreak();
   InterlockedIncrement(&bb);

   //after
   L(o);

}

static void D(int o)
{
   E(o);
}

static void C(int o)
{
   int temp = o;

   InterlockedIncrement(&aa);
   while (aa < 4)
   {
      ;
   }

   if (temp == 1)
   {
      // BP1 - all tasks in C   
      DebugBreak();
      waitFor1 = false;
   }
   else
   {
      while (waitFor1)
      {
         ;
      }
   }
   switch (temp)
   {
   case 1:
      D(o);
      break;
   case 2:
      F(o);
      break;
   case 3:
   case 4:
      I(o);
      break;
   default:
      throw; //fool
      break;
   }
}
static void B(int o)
{
   C(o);
}

void A(int o)
{
   B(o);
}
int main()
{
   InitializeCriticalSection(&cs);

   task_group tasks;
   task_handle<RunFunc<decltype(A)>> t1(RunFunc<decltype(A)>(A,1));
   tasks.run(t1);
   task_handle<RunFunc<decltype(A)>> t2(RunFunc<decltype(A)>(A,2));
   task2.run(t2);
   task_handle<RunFunc<decltype(A)>> t3(RunFunc<decltype(A)>(A,3));
   task3.run(t3);
   task_handle<RunFunc<decltype(A)>> t4(RunFunc<decltype(A)>(A,4));
   task4.run(t4);
   
   getchar();
   return 1;
}
//</snippet1>

