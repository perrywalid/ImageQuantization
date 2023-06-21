﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{
	// C# code to implement priority-queue
	// using array implementation of
	// binary heap
	public class PriorityQueue
	{

		Cut[] H = new Cut[600000];
		public int size = 0;
		int[] index = new int[600000];
		// Function to return the index of the
		// parent node of a given node

		public PriorityQueue()
        {
			H[0].distance = int.MinValue;
			H[0].index = -1;
        }
		public int parent(int i)
		{
			return (i) / 2;
		}

		// Function to return the index of the
		// left child of the given node
		public int leftChild(int i)
		{
			return ((2 * i));
		}

		// Function to return the index of the
		// right child of the given node
		public int rightChild(int i)
		{
			return ((2 * i) + 1);
		}

		// Function to shift up the
		// node in order to maintain
		// the heap property
		public void shiftUp(int i)
		{
			while (i > 0 && H[parent(i)].distance > H[i].distance)
			{

				// Swap parent and current node
				swap(parent(i), i);

				// Update i to parent of i
				i = parent(i);
			}
		}

		// Function to shift down the node in
		// order to maintain the heap property
		public void shiftDown(int i)
		{
			int maxIndex = i;

			// Left Child
			int l = leftChild(i);

			if (l < size &&
				H[l].distance < H[maxIndex].distance)
			{
				maxIndex = l;
			}

			// Right Child
			int r = rightChild(i);

			if (r < size &&
				H[r].distance < H[maxIndex].distance)
			{
				maxIndex = r;
			}

			// If i not same as maxIndex
			if (i != maxIndex)
			{
				swap(i, maxIndex);
				shiftDown(maxIndex);
			}
		}

		// Function to insert a
		// new element in
		// the Binary Heap
		public void insert(Cut e)
		{


			size = size + 1;
			H[size] = e;
			index[e.index] = size;

			// Shift Up to maintain
			// heap property
			shiftUp(size);
		}

		// Function to extract
		// the element with
		// maximum priority
		public Cut extractMin()
		{
			Cut result = H[1];
			// Replace the value
			// at the root with
			// the last leaf
			H[1] = H[size];
			index[H[size].index] = 1;
			H[size].distance = double.MaxValue;
			shiftDown(1);
			size = size - 1;

			// Shift down the replaced
			// element to maintain the
			// heap property
			return result;
		}

		// Function to change the priority
		// of an element
		public bool changePriority(int i,
								double p)
		{
			double oldp = H[index[i]].distance;
			if (p < oldp)
			{
				H[index[i]].distance = p;
                shiftUp(index[i]);
				return true;
			}
			return false;
		}

		public void swap(int i, int j)
		{
			int t = index[H[i].index];
			index[H[i].index] = index[H[j].index];
			index[H[j].index] = t;

			Cut temp = H[i];
			H[i] = H[j];
			H[j] = temp;


		}
		// This code is contributed by Amit Katiyar
	}
}
