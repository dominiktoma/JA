#include "pch.h"

extern "C" __declspec(dllexport) int AddCpp(int a, int b) {
    return a + b;
}