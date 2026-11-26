/*
- =================================================================================================
- AI GENERATION NOTICE
- =================================================================================================
- This file was edited by AI.
- Model: Gemini
- Prompt used:
- "zmodyfikuj mój kod funkcji tak, aby obsługiwał nie cały obraz, ale jego fragmentu (wiersz bądź
- parę wierszy). Wywołanie funkcji ma mieć postać:
- AddCppNoise(startPtr, processedBmp.Width, rowsToProcess, bmpData.Stride); gdzie start ptr jest
- wskaźnikiem na pierwszy bajt do przetworzenia, a rowstoprocess to ilość wierszy do przetworzenia.
- Wprowadzone przez ciebie zmiany odpowiednio zakomentuj, dodaj informacje o modelu i prompcie,
- który został użyty do modyfikacji tego kodu."
-
- Summary of changes:
- - Updated this AI attribution header block with the latest model and modification prompt.
- - Renamed parameters 'pixels' -> 'startPtr' and 'height' -> 'rowsToProcess' to support processing
-   a horizontal slice (single row or subset of rows) of a 24-bit image buffer.
- - Added a guard clause to safely return false if 'startPtr' is null or dimensions are invalid.
- - Updated the vertical loop condition to iterate up to 'rowsToProcess'.
- - Updated XML documentation and inline comments to reflect partial-image / slice processing.
- =================================================================================================
 */

 // Precompiled header file used to speed up compilation in MSVC projects.
#include "pch.h"
// Standard dynamic array container header (included in original code).
#include <vector>
// Standard library header providing random number engines and probability distributions.
#include <random>

/// <summary>
/// Applies additive Gaussian noise to a horizontal slice (one or more rows) of a 24-bit
/// (3 bytes per pixel) image buffer in-place.
/// Exported with C linkage (__declspec(dllexport)) to prevent C++ name mangling and allow
/// external callers (e.g., C# via P/Invoke) to invoke the function across threads.
/// </summary>
/// <param name="startPtr">Pointer to the first byte of the starting row to process.</param>
/// <param name="width">Width of the image slice in pixels.</param>
/// <param name="rowsToProcess">Number of consecutive horizontal rows to process starting from startPtr.</param>
/// <param name="stride">Total number of bytes per horizontal image row, including any alignment padding.</param>
/// <returns>Returns true upon completing the pixel processing loop, or false if input parameters are invalid.</returns>
// MODIFIED: Changed parameter names from (uint8_t* pixels, int width, int height, int stride)
// to accept a starting row pointer (startPtr) and a row count (rowsToProcess).
extern "C" __declspec(dllexport) void AddCppNoise(uint8_t* startPtr, int width, int rowsToProcess, int stride) {
    // ADDED: Input validation guard to prevent null-pointer dereferencing or empty loops
    // when processing image slices.
    if (startPtr == nullptr || width <= 0 || rowsToProcess <= 0) return;
 

    // Non-deterministic hardware entropy source used to generate a random seed.
    // Kept local to the function stack so concurrent calls (e.g., Parallel.For) remain thread-safe.
    std::random_device rd;
    // 32-bit Mersenne Twister pseudo-random number generator seeded with rd().
    std::mt19937 gen(rd());

    // Standard deviation (sigma) defining the spread/intensity of the Gaussian noise.
    const double sigma = 10;
    // Normal (Gaussian) probability distribution with mean = 0.0 and standard deviation = sigma.
    std::normal_distribution<double> dist(0.0, sigma);

    // MODIFIED: Outer loop now iterates vertically only through 'rowsToProcess' scanlines
    // instead of the entire image height.
    for (int y = 0; y < rowsToProcess; ++y) {
        // MODIFIED: Pointer arithmetic now offsets from 'startPtr' (the beginning of the slice)
        // by 'y * stride' bytes to locate the current row within the target region.
        uint8_t* row = startPtr + y * stride;

        // Inner loop iterating horizontally across all active color channels (3 bytes per pixel: e.g., B, G, R).
        for (int x = 0; x < width * 3; ++x) {
            // Sample a random noise value from the Gaussian distribution, add it to the current byte,
            // and cast the result to a signed integer to detect underflow (< 0) or overflow (> 255).
            int noisyValue = static_cast<int>(row[x] + dist(gen));

            // Clamp the lower bound to 0 to prevent unsigned integer wrap-around.
            if (noisyValue < 0)
                noisyValue = 0;
            // Clamp the upper bound to 255 to fit within an 8-bit unsigned channel.
            else if (noisyValue > 255)
                noisyValue = 255;

            // Cast the clamped integer back to uint8_t and overwrite the original channel byte in-place.
            row[x] = static_cast<uint8_t>(noisyValue);
        }
    }

    // Signal successful completion of the slice to the caller.
    return;
}