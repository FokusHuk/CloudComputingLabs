using System;

namespace CloudComputingLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteLab1();
        }

        static void ExecuteLab1()
        {
            var lab1 = new Lab1();
            var array = new[] {1, 2, 3, 4, 5, 6, 7, 8};

            var result = lab1.PureSum(array);

            Console.WriteLine(result); // 36
        }
    }
}