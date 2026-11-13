
using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    // Min Heap for organising municipal service requests.
    // Priority 1 = Critical, 2 = High, 3 = Medium, 4 = Low.
    public class MinHeap
    {
        private readonly List<Issue> heap =
            new List<Issue>();

        public int Count
        {
            get { return heap.Count; }
        }

        public bool IsEmpty
        {
            get { return heap.Count == 0; }
        }

        // Add a service request to the heap.
        public void Insert(Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException("issue");

            heap.Add(issue);

            HeapifyUp(heap.Count - 1);
        }

        // Return the most urgent request without removing it.
        public Issue Peek()
        {
            if (IsEmpty)
                return null;

            return heap[0];
        }

        // Remove and return the most urgent request.
        public Issue ExtractMin()
        {
            if (IsEmpty)
                return null;

            Issue mostUrgent = heap[0];

            int lastIndex = heap.Count - 1;

            heap[0] = heap[lastIndex];

            heap.RemoveAt(lastIndex);

            if (!IsEmpty)
                HeapifyDown(0);

            return mostUrgent;
        }

        // Move a newly inserted request upwards.
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                if (heap[parentIndex].Priority <=
                    heap[index].Priority)
                    break;

                Swap(parentIndex, index);

                index = parentIndex;
            }
        }

        // Move the root down to restore heap order.
        private void HeapifyDown(int index)
        {
            while (true)
            {
                int leftChild = (2 * index) + 1;
                int rightChild = (2 * index) + 2;

                int smallest = index;

                if (leftChild < heap.Count &&
                    heap[leftChild].Priority <
                    heap[smallest].Priority)
                {
                    smallest = leftChild;
                }

                if (rightChild < heap.Count &&
                    heap[rightChild].Priority <
                    heap[smallest].Priority)
                {
                    smallest = rightChild;
                }

                if (smallest == index)
                    break;

                Swap(index, smallest);

                index = smallest;
            }
        }

        // Swap two heap elements.
        private void Swap(int first, int second)
        {
            Issue temporary = heap[first];

            heap[first] = heap[second];

            heap[second] = temporary;
        }

        // Clear all requests from the heap.
        public void Clear()
        {
            heap.Clear();
        }
    }
}
