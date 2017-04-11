// Class1.cpp
#include "pch.h"
#include "Class1.h"

using namespace PartialClassExample;
using namespace Platform;


int Inner::Base1::GetNumBase(){return 1;}

int Inner::N::GetNum() {return 2;}

int Inner::N::GetNum2() {return 2;}

int Inner::InnerInner::N::GetNum(){return 5;}

int Inner::InnerInner::N::GetNum2() {return 2;}

