#include "pch.h"

extern "C" __declspec(dllexport) double AddCpp(double a, double b)
{
    return a + b;
}