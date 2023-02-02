using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrioQueueTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PriorityQueue<string> priorityQueue = new PriorityQueue<string>();

        priorityQueue.Insert(10, "Ogga");
        priorityQueue.Insert(42, "booga");
        priorityQueue.Insert(1, "chungus");

		Debug.Log(priorityQueue.Size);
		Debug.Log(priorityQueue.RemoveMax());
        Debug.Log(priorityQueue.Size);
		Debug.Log(priorityQueue.RemoveMax());
		Debug.Log(priorityQueue.Size);
		Debug.Log(priorityQueue.RemoveMax());
		Debug.Log(priorityQueue.Size);
	}
}
