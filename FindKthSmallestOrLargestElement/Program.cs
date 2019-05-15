using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindKthSmallestOrLargestElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find 2nd largest in  [3,2,1,5,6,4]");
            Console.WriteLine(FindKthLargest(new int[] { 3, 2, 1, 5, 6, 4 }, 2));
            Console.WriteLine("Find 2nd smallest in [3,2,1,5,6,4]");
            Console.WriteLine(FindKthSmallest(new int[] { 3, 2, 1, 5, 6, 4 }, 2));
            Console.WriteLine("Find 4th largest in  [3,2,3,1,2,4,5,5,6]");
            Console.WriteLine(FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4));
            Console.WriteLine("Find 4th smallest in [3,2,3,1,2,4,5,5,6]");
            Console.WriteLine(FindKthSmallest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4));
            Console.WriteLine("Find 5th smallest in [3,2,3,1,2,4,5,5,6]");
            Console.WriteLine(FindKthSmallest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 5));
            Console.WriteLine("Find 6th smallest in [3,2,3,1,2,4,5,5,6]");
            Console.WriteLine(FindKthSmallest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 6));
        }
        public static int FindKthLargest(int[] nums, int k)
        {
            //return (N-k)th index smallest, which is the kth largest element
            return QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
        }

        public static int FindKthSmallest(int[] nums, int k)
        {
            //return (k-1)th index smallest (counting from 0), which is the kth smallest element
            return QuickSelect(nums, 0, nums.Length - 1, k-1);
        }
        public static int QuickSelect(int[] nums, int left, int right, int k)
        {
            int pivotIndex = partition(nums, left, right);
            //when k is pivotIndex, num[pivotIndex] has k-1 elements smaller than it
            if (k == pivotIndex) return nums[pivotIndex];
            //go left
            else if (k < pivotIndex) return QuickSelect(nums, left, pivotIndex - 1, k);
            //go right
            else return QuickSelect(nums, pivotIndex + 1, right, k);
        }


        public static void Swap(ref int A, ref int B)
        {
            int temp = A;
            A = B;
            B = temp;
        }

        private static int partition(int[] arr, int left, int right)
        {
            //randomly choose a pivot
            int pivotIndex = new Random().Next(left, right);
            int pivotValue = arr[pivotIndex];
            //put pivot index to the far right
            Swap(ref arr[pivotIndex], ref arr[right]);

            int originalRight = right;


            while (left < right)
            {
                if (arr[left].CompareTo(pivotValue) > 0)
                {
                    Swap(ref arr[left], ref arr[--right]);
                }
                else left++;
            }

            //put pivotvalue to correct location
            Swap(ref arr[right], ref arr[originalRight]);

            //return updated pivot index
            return right;
        }
    }
}
