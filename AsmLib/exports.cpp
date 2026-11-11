#include "pch.h"

extern "C" int AddAsm(long long a, long long b);

// Alternatywnie: eksport przez dllexport w pliku C++
extern "C" __declspec(dllexport) int CallAddAsm(long long a, long long b) {
    return AddAsm(a, b);
}