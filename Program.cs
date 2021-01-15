using System;
using System.Diagnostics;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) Linear Search\n2) Binary Search\n3) Insertion Sort\n4) Merge Sort\n5) Heap Sort\n6) Quick Sort\n7) Counting Sort\n8) Radix Sort\n9) Bubble Sort\n");

            Console.Write("Enter the size of the array: ");
            int ArrayLength = int.Parse(Console.ReadLine());
            int[] Array = new int[ArrayLength];

            Console.Write("Enter the number of the algorithm you want to choose: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the number you want to search in the array: ");
                    int wanted = int.Parse(Console.ReadLine());
                    var time = Stopwatch.StartNew();
                    LinearSearch(Array, ArrayLength, wanted);
                    time.Stop();
                    Console.WriteLine("Time spent is " + time.ElapsedTicks + " Ticks");
                    break;
                case 2:
                    Console.Write("Enter the number you want to search in the array: ");
                    wanted = int.Parse(Console.ReadLine());
                    time = Stopwatch.StartNew();
                    Console.WriteLine(BinarySearch(Array, ArrayLength, wanted));
                    time.Stop();
                    Console.WriteLine("Time spent is " + time.ElapsedTicks + " Ticks");
                    break;
                case 3:
                    time = Stopwatch.StartNew();
                    InsertionSort(Array, ArrayLength);
                    time.Stop();
                    Console.WriteLine("Time spent is " + time.ElapsedMilliseconds + " Milliseconds" + "(1 millisecond = 10 000 ticks)");
                    break;
                case 4:
                    time = Stopwatch.StartNew();
                    PrintMerge(Array, ArrayLength, 0, ArrayLength - 1);
                    time.Stop();
                    Console.WriteLine("Time spent is " + time.ElapsedMilliseconds + " Milliseconds" + "(1 millisecond = 10 000 ticks)");
                    break;
                case 5:
                    time = Stopwatch.StartNew();
                    HeapSort(Array, ArrayLength);
                    time.Stop();
                    Console.WriteLine("Time spent is " + time.ElapsedMilliseconds + " Milliseconds" + "(1 millisecond = 10 000 ticks)");
                    break;
                case 6:
                    time = Stopwatch.StartNew();
                    PrintQuick(Array, ArrayLength, 0, ArrayLength - 1);
                    time.Stop();
                    Console.WriteLine("Time spent is " + time.ElapsedMilliseconds + " Milliseconds" + "(1 millisecond = 10 000 ticks)");
                    break;
                case 7:
                    time = Stopwatch.StartNew();
                    CountingSort(Array, ArrayLength);
                    time.Stop();
                    Console.WriteLine("Time spent is " + time.ElapsedMilliseconds + " Milliseconds" + "(1 millisecond = 10 000 ticks)");
                    break;
                case 8:
                    time = Stopwatch.StartNew();
                    RadixSort(Array, ArrayLength);
                    time.Stop();
                    Console.WriteLine("Time spent is " + time.ElapsedMilliseconds + " Milliseconds" + "(1 millisecond = 10 000 ticks)");
                    break;
                case 9:
                    time = Stopwatch.StartNew();
                    BubbleSort(Array, ArrayLength);
                    time.Stop();
                    Console.WriteLine("Time spent is " + time.ElapsedMilliseconds + " Milliseconds" + "(1 millisecond = 10 000 ticks)");
                    break;
            }
        }
        public static void LinearSearch(int[] Array, int ArrayLength, int wanted)
        {
            Random random = new Random();
            Console.WriteLine();
            for (int i = 0; i < ArrayLength; i++)
            {
                Array[i] = random.Next(100);
                Console.Write(Array[i] + " ");
            }
            Console.Write("\nChosen algorithm: Linear Search");
            for (int j = 0; j < ArrayLength; j++)
            {
                if (Array[j] == wanted)
                {
                    Console.WriteLine("\nThe index of the searched number is {1}", wanted, j + 1);
                    break;
                }
                else if (j == (ArrayLength - 1))
                {
                    Console.WriteLine("\nThe searched number was not found!!");
                }
            }
        }
        public static void Bubble(int[] Array, int ArrayLength, int wanted)
        {
            Random random = new Random();
            for (int k = 0; k < ArrayLength; k++)
            {
                Array[k] = random.Next(100);
            }
            for (int i = 0; i < ArrayLength - 1; i++)
            {
                for (int j = 0; j < ArrayLength - i - 1; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        int temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                    }
                }
            }
        }
        public static int BinarySearch(int[] Array, int ArrayLength, int wanted)
        {
            PrintBinary(Array, ArrayLength, wanted);
            int min = 0;
            int max = ArrayLength - 1;
            int mid;
            do
            {
                mid = (min + max) / 2;
                if (wanted > Array[mid])
                    min = mid + 1;
                else if (wanted < Array[mid])
                    max = mid - 1;
                else
                    return mid;
            }
            while (min <= max);
            return -1;
        }
        public static void PrintBinary(int[] Array, int ArrayLength, int wanted)
        {
            Bubble(Array, ArrayLength, wanted);
            Console.WriteLine("\nSorted Array");
            for (int k = 0; k < ArrayLength; k++)
            {
                Console.Write(Array[k] + " ");
            }
            Console.WriteLine("\nChosen algorithm: Binary Search");
            Console.Write("The index of the searched number is ");
        }
        public static void InsertionSort(int[] Array, int ArrayLength)
        {
            Random random = new Random();
            Console.WriteLine("\nOriginal Array");
            for (int k = 0; k < ArrayLength; k++)
            {
                Array[k] = random.Next(100);
                Console.Write(Array[k] + " ");
            }
            int j;
            int key;
            for (int i = 1; i < ArrayLength; i++)
            {
                key = Array[i];
                j = i - 1;
                while (j >= 0 && Array[j] > key)
                {
                    Array[j + 1] = Array[j];
                    j = j - 1;
                }
                Array[j + 1] = key;
                j--;
            }
            Console.WriteLine("\nSorted Array");
            for (int i = 0; i < ArrayLength; i++)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine("\nChosen algorithm: Insertion Sort");
        }
        public static void MergeSort(int[] Array, int ArrayLength, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(Array, ArrayLength, left, middle);
                MergeSort(Array, ArrayLength, middle + 1, right);
                Merge(Array, left, middle, right);
            }
        }
        public static void Merge(int[] Array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];

            int i, j;

            for (i = 0; i < n1; i++)
            {
                L[i] = Array[left + i];
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = Array[middle + j + 1];
            }

            i = 0;
            j = 0;

            int k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    Array[k] = L[i];
                    i++;
                }
                else
                {
                    Array[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                Array[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                Array[k] = R[j];
                j++;
                k++;
            }
        }
        public static void PrintMerge(int[] Array, int ArrayLength, int left, int right)
        {
            Random random = new Random();
            Console.Write("\nOrijinal array\n");
            for (int i = 0; i < ArrayLength; i++)
            {
                Array[i] = random.Next(100);
                Console.Write(Array[i] + " ");
            }
            MergeSort(Array, ArrayLength, left, right);
            Console.Write("\nSorted array\n");
            for (int j = 0; j < Array.Length; j++)
            {
                Console.Write(Array[j] + " ");
            }
            Console.WriteLine("\nChosen algorithm: Merge Sort");
        }
        public static void HeapSort(int[] Array, int ArrayLength)
        {
            Random random = new Random();
            Console.WriteLine("\nOriginal Array");
            for (int k = 0; k < ArrayLength; k++)
            {
                Array[k] = random.Next(100);
                Console.Write(Array[k] + " ");
            }
            int n = ArrayLength;
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(Array, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = Array[0];
                Array[0] = Array[i];
                Array[i] = temp;
                Heapify(Array, i, 0);
            }
            Console.WriteLine("\nSorted Array");
            for (int i = 0; i < ArrayLength; i++)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine("\nChosen algorithm: Heap Sort");
        }
        public static void Heapify(int[] Array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && Array[left] > Array[largest])
                largest = left;
            if (right < n && Array[right] > Array[largest])
                largest = right;
            if (largest != i)
            {
                int swap = Array[i];
                Array[i] = Array[largest];
                Array[largest] = swap;
                Heapify(Array, n, largest);
            }
        }
        public static int Partition(int[] Array, int p, int r)
        {
            int pivot = Array[r];
            int i = (p - 1);
            for (int j = p; j < r; j++)
            {
                if (Array[j] <= pivot)
                {
                    i++;
                    int temp = Array[i];
                    Array[i] = Array[j];
                    Array[j] = temp;
                }
            }
            int temp1 = Array[i + 1];
            Array[i + 1] = Array[r];
            Array[r] = temp1;

            return i + 1;
        }
        public static void QuickSort(int[] Array, int ArrayLength, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(Array, p, r);
                QuickSort(Array, ArrayLength, p, q - 1);
                QuickSort(Array, ArrayLength, q + 1, r);
            }
        }
        public static void PrintQuick(int[] Array, int ArrayLength, int p, int r)
        {
            Random random = new Random();
            Console.Write("\nOrijinal array\n");
            for (int i = 0; i < ArrayLength; i++)
            {
                Array[i] = random.Next(100);
                Console.Write(Array[i] + " ");
            }
            QuickSort(Array, ArrayLength, p, r);
            Console.WriteLine("\nSorted Array");
            for (int i = 0; i < ArrayLength; i++)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine("\nChosen algorithm: Quick Sort");
        }
        public static void CountingSort(int[] Array, int ArrayLength)
        {
            Random random = new Random();
            Console.WriteLine("\nOriginal Array");
            for (int k = 0; k < ArrayLength; k++)
            {
                Array[k] = random.Next(100);
                Console.Write(Array[k] + " ");
            }
            int[] C = new int[100000];
            for (int i = 0; i < C.Length; i++)
            {
                C[i] = 0;
            }
            for (int j = 0; j < ArrayLength; ++j)
            {
                ++C[Array[j]];
            }
            for (int i = 1; i < C.Length - 1; ++i)
            {
                C[i] += C[i - 1];
            }
            int[] B = new int[ArrayLength];
            for (int j = ArrayLength - 1; j >= 0; j--)
            {
                B[C[Array[j]] - 1] = Array[j];
                --C[Array[j]];
            }
            for (int i = 0; i < ArrayLength; i++)
            {
                Array[i] = B[i];
            }
            Console.WriteLine("\nSorted Array");
            for (int i = 0; i < ArrayLength; i++)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine("\nChosen algorithm: Counting Sort");
        }
        public static void Counting(int[] Array, int ArrayLength, int Exp)
        {
            int[] C = new int[10000];
            for (int i = 0; i < C.Length; i++)
            {
                C[i] = 0;
            }
            for (int j = 0; j < ArrayLength; j++)
            {
                C[(Array[j] / Exp) % 10]++;
            }
            for (int i = 1; i < C.Length - 1; ++i)
            {
                C[i] += C[i - 1];
            }
            int[] B = new int[ArrayLength];
            for (int j = ArrayLength - 1; j >= 0; j--)
            {
                B[C[(Array[j] / Exp) % 10] - 1] = Array[j];
                C[(Array[j] / Exp) % 10]--;
            }
            for (int i = 0; i < ArrayLength; i++)
            {
                Array[i] = B[i];
            }
        }
        public static void RadixSort(int[] Array, int ArrayLength)
        {
            Random random = new Random();
            Console.WriteLine("\nOriginal Array");
            for (int k = 0; k < ArrayLength; k++)
            {
                Array[k] = random.Next(100);
                Console.Write(Array[k] + " ");
            }
            int max = Array[0];
            for (int i = 0; i < ArrayLength; i++)
            {
                if (Array[i] > max)
                    max = Array[i];
            }
            for (int Exp = 1; (max / Exp) > 0; Exp *= 10)
            {
                Counting(Array, ArrayLength, Exp);
            }
            Console.WriteLine("\nSorted Array");
            for (int i = 0; i < ArrayLength; i++)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine("\nChosen algorithm: Radix Sort");
        }
        public static void BubbleSort(int[] Array, int ArrayLength)
        {
            Random random = new Random();
            Console.WriteLine("\nOriginal Array");
            for (int k = 0; k < ArrayLength; k++)
            {
                Array[k] = random.Next(100);
                Console.Write(Array[k] + " ");
            }
            for (int i = 0; i < ArrayLength - 1; i++)
            {
                for (int j = 0; j < ArrayLength - i - 1; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        int temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("\nSorted Array");
            for (int i = 0; i < ArrayLength; i++)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine("\nChosen algorithm: Bubble Sort");
        }
    }
}