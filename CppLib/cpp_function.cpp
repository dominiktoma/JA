/*
 * =================================================================================================
 * AI GENERATION NOTICE
 * =================================================================================================
 * This file was edited by AI.
 * Model: Gemini
 * Prompt used:
 * "Do istniejącego kodu dopisz komentarze. Nie modyfikuj samego kodu. w komentarzach opisz
 * poszczególne elementy i wskaż zmiany, które wprowadziłeś (po angielsku) dodatkowo u góry kodu
 * zamieść komentarz, że te plik został edytowany przez ai (podaj konkretny model i prompta, który
 * został użyty do wygenerowania tego pliku)."
 *
 * Summary of changes:
 * - Added this AI attribution header block.
 * - Added English XML documentation and inline comments explaining all includes, function parameters,
 *   random number generators, loops, and clamping logic.
 * - Strictly preserved the original source code with zero functional or syntactic modifications.
 * =================================================================================================
 */

 // Precompiled header file used to speed up compilation in MSVC projects.
#include "pch.h"
// Standard dynamic array container header (included in original code).
#include <vector>
// Standard library header providing random number engines and probability distributions.
#include <random>

/// <summary>
/// Applies additive Gaussian noise to a 24-bit (3 bytes per pixel) image buffer in-place.
/// Exported with C linkage (__declspec(dllexport)) to prevent C++ name mangling and allow
/// external callers (e.g., C# via P/Invoke) to invoke the function.
/// </summary>
/// <param name="pixels">Pointer to the raw byte array containing image pixel data.</param>
/// <param name="width">Width of the image in pixels.</param>
/// <param name="height">Height of the image in pixels.</param>
/// <param name="stride">Total number of bytes per horizontal image row, including any alignment padding.</param>
/// <returns>Always returns true upon completing the pixel processing loop.</returns>
extern "C" __declspec(dllexport) bool AddCppNoise(uint8_t* pixels, int width, int height, int stride) {
    // Non-deterministic hardware entropy source used to generate a random seed.
    std::random_device rd;
    // 32-bit Mersenne Twister pseudo-random number generator seeded with rd().
    std::mt19937 gen(rd());

    // Standard deviation (sigma) defining the spread/intensity of the Gaussian noise.
    const double sigma = 10;
    // Normal (Gaussian) probability distribution with mean = 0.0 and standard deviation = sigma.
    std::normal_distribution<double> dist(0.0, sigma);

    // Outer loop iterating vertically through each row (scanline) of the image.
    for (int y = 0; y < height; ++y) {
        // Pointer arithmetic to locate the starting byte address of row 'y' using the row stride.
        uint8_t* row = pixels + y * stride;

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

    // Signal successful completion to the caller.
    return true;
}