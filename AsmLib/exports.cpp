#include "pch.h"

extern "C" {
    // Deklaracja funkcji zaimplementowanej w pliku .asm
    __declspec(dllexport) double AddAsm(double a, double b);
}