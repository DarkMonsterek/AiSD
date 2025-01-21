using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public int[] arr = { 19, 10, 128, 28, 189, 12 };
        public void InsertSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] arr1 = arr;
            InsertSort(arr1);
            string result = string.Join(", ", arr);
            MessageBox.Show(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] arr2 = arr;
            MergeSort(arr2, 0, arr2.Length-1);
            string result = string.Join(", ", arr2);
            MessageBox.Show(result);
        }
        public void MergeSort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);
                Merge(arr, left, middle, right);
            }
        }
        public void Merge(int[] arr,int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;
            int[] L = new int[n1];
            int[] R = new int[n2];

            Array.Copy(arr, left, L, 0, n1);
            Array.Copy(arr, middle + 1, R, 0, n2);

            int i = 0, j = 0;
            int k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] arr3 = arr;
            arr3=CountingSort(arr3);
            string result = string.Join(", ", arr3);
            MessageBox.Show(result);
        }
        public int[] CountingSort(int[] arr)
        {
            int max = FindMax(arr);
            int min = FindMin(arr);

            int range = max - min + 1;

            int[] count = new int[range];

            int[] output = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] - min]++;
            }

            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                output[count[arr[i] - min] - 1] = arr[i];
                count[arr[i] - min]--;
            }

            return output;
        }

        public int FindMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        public int FindMin(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] arr4 = arr;
            QuickSort(arr4,0,arr4.Length-1);
            string result = string.Join(", ", arr4);
            MessageBox.Show(result);
        }
        private void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;

                    Swap(ref arr[i], ref arr[j]);
                }
            }

            Swap(ref arr[i + 1], ref arr[high]);

            return i + 1;
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static int [] BubbleSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;
            for (int i = 0; i < n; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;

                    }
                }
                if (!swapped)
                    break;
            }
            return arr;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] arr5 = arr;
            var sorted = BubbleSort(arr5);
            var result = TabToString(sorted);
            MessageBox.Show(result);
        }
        string TabToString(int[] arr)
        {
            string result = string.Join (", ", arr);
            return result;
        }
    }
    
}
