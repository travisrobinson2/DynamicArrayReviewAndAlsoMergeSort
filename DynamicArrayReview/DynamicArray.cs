

namespace DynamicArrayReview
{
    public class DynamicArray : DataStructure
    {
        public override void Add(int value)
        {
            if (Count == _values.Length)
            {
                Resize();
            }
            _values[Count] = value;
            _count++;
        }

        private void Resize()
        {
            var newArr = new int[_values.Length * 2];

            for (int i = 0; i < _values.Length; i++)
            {
                newArr[i] = _values[i];
            }

            _values = newArr;
        }

        public override void Clear()
        {
            for (int i = 0; i < _values.Length; i++)
            {
                _values[i] = -1;
            }

            //alternative method
            _values = new int[8];

        }

        public override bool Remove (int target)//O(N)
        {
            for (int i = 0; i < _values.Length; i++)
            {
                if (_values[i] == target)
                {
                    for (int j = i; j < _values.Length; j++)
                    {
                        _values[j] = _values[j + 1];
                    }
                     return true;
                }
            }
            return false;
        }

        public override void Sort() //Bubble Sort O(n^2)
        {
            for (int i = 0; i < _values.Length; i++)
            {
                for (int j = 0; j < _values.Length; j++)
                {
                    if (_values[j] == _values[j + 1])
                    {
                        //perform swap
                        var temp = _values[j];
                        _values[j] = _values[j + 1];
                        _values[j + 1] = temp;
                    }
                }

            }
        }

        public override int BinarySearch(int target)
        {
            int low = 0;
            int high = Count;

            while (low <= high)
            {
                //int mid = (low + high) / 2; // don't do this            
                int mid = low + (high - low) / 2;

                if (_values[mid] == target)
                {
                    return mid;
                }
                else if (_values[mid] < target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return -1;
        }

        public void MergeSort()
        {
            MergeSort(_values, 0, Count);
        }

        private void MergeSort(int[] arr, int left, int right)
        {

            if(left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);
                Merge(arr, left,middle,right);
            }
        }
        private void Merge(int[] arr, int left, int middle, int right)
        {
            int leftLenght = middle - left + 1;
            int rightLength = right - middle;
            int[] leftArr = new int[leftLenght];
            int[] rightArr = new int[rightLength];

            for (int idx = 0; idx < leftLenght; idx++)
            {
                leftArr[idx] = arr[left + idx];
            }
            for (int idx = 0; idx < rightLength; idx++)
            {
                rightArr[idx] = arr[middle + 1 + idx];
            }

            int i = 0, j = 0, k = left;
            while (i < leftLenght && j < rightLength)
            {
                if (leftArr[i] <= rightArr[j]){
                    arr[k] = leftArr[i];
                    k++;
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    k++;
                    j++;
                }
                while(i < leftLenght)
                {
                    arr[k] = leftArr[i];
                    k++;
                    i++;
                }
                while (j < rightLength)
                {
                    arr[k] = leftArr[j];
                    k++;
                    j++;
                }
            }
        }


    }
}
