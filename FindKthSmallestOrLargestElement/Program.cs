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
        }
        public int FindKthLargest(int[] nums, int k)
        {
            //return (N-k)th index smallest, which is the kth largest element
            return QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
        }
        public int QuickSelect(int[] nums, int left, int right, int k)
        {
            int pivotIndex = partition(nums, left, right);
            //when k is pivotIndex, num[pivotIndex] has k-1 elements smaller than it
            if (k == pivotIndex) return nums[pivotIndex];
            //go left
            else if (k < pivotIndex) return QuickSelect(nums, left, pivotIndex - 1, k);
            //go right
            else return QuickSelect(nums, pivotIndex + 1, right, k);
        }


        public void Swap(ref int A, ref int B)
        {
            int temp = A;
            A = B;
            B = temp;
        }

        private int partition(int[] arr, int left, int right)
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
