namespace CloudComputingLabs
{
    public class Lab1
    {
        public int PureSum(int[] array, int sum = 0, int currentIndex = 0) => 
            currentIndex == array.Length ? sum : PureSum(array, sum + array[currentIndex], ++currentIndex);
    }
}
