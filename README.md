# Image Quantization

Image Quantization is a C# library that provides functionality for quantizing images by reducing the number of distinct colors while preserving visual quality. It uses Prim's algorithm to compute a minimum spanning tree (MST) of the distinct colors, and then clusters the colors to form representative clusters. The library supports automatic detection of the optimal number of clusters (k) based on the MST.

## Features

- Distinct color extraction: Extracts the distinct colors from an input image.
- Prim's algorithm: Computes the minimum spanning tree of the distinct colors.
- Cluster formation: Removes edges from the MST to form k clusters.
- Representative calculation: Finds representative colors for each cluster.
- Image recoloring: Recolors the image using the representative colors.

## Getting Started

To use the Image Quantization library in your C# project, follow these steps:

1. Clone the repository or download the source code.
2. Include the `PixelOperations.cs`, `PriorityQueue.cs`, and `ImageOperations.cs` files in your project.
3. Add the necessary namespaces: `ImageQuantization` and `System.Drawing`.
4. Use the `PixelOperations.Quantize(int k)` method to quantize an image, where `k` is the desired number of clusters.

```csharp
using ImageQuantization;
using System.Drawing;

// Load the image
Bitmap image = new Bitmap("input.jpg");

// Convert the image to a matrix of RGB pixels
RGBPixel[,] imageMatrix = ImageOperations.OpenImage(image);

// Create an instance of PixelOperations
PixelOperations pixelOperations = new PixelOperations();

// Quantize the image with k clusters
int k = 8; // Number of clusters
RGBPixel[,] quantizedImageMatrix = pixelOperations.Quantize(k);

// Save the quantized image
Bitmap quantizedImage = ImageOperations.CreateImage(quantizedImageMatrix);
quantizedImage.Save("output.jpg");
