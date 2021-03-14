using System.Linq;

namespace CloudComputingLabs
{
    public class Lab2
    {
        public string[] PureFilter(string[] array)
        {
            return array
                .Distinct()
                .Select(element => element[0])
                .Select(element => array
                    .Where(s => s.Contains(element))
                    .OrderByDescending(s => s.Length)
                    .First())
                .Distinct()
                .ToArray();
        }
    }
}
