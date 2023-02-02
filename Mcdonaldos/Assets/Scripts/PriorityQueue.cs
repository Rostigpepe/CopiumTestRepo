using System;
using System.Collections;
using System.Collections.Generic;



public class PriorityQueue <T>
{
    private List<(double, T)> heap;
    private int size;

	// Constructor
	PriorityQueue()
	{
		heap = new List<(double, T)>();
	}

	PriorityQueue(List<(double, T)> h)
	{
		heap = h;
	}
}
