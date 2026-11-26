#include "pch.h"
#include <vector>
#include <random>



extern "C" __declspec(dllexport) bool AddCppNoise(uint8_t* pixels, int width, int height, int stride) {
    std::random_device rd;
    std::mt19937 gen(rd());

    const double sigma = 10;
    std::normal_distribution<double> dist(0.0, sigma);
    for (int y = 0; y < height; ++y) {
        uint8_t* row = pixels + y * stride;

        for (int x = 0; x < width * 3; ++x) {
            int noisyValue = static_cast<int>(row[x] + dist(gen));
            if (noisyValue < 0)
                noisyValue = 0;
            else if (noisyValue > 255)
                noisyValue = 255;

            row[x] = static_cast<uint8_t>(noisyValue);
        }
    }

    return true;
}
