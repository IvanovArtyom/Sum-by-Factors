using System;
using System.Linq;
using System.Text;

public class SumByFactors

{
    public static void Main()
    {
        // Test
        var t = SumOfDivided(new int[] { 12, 15 });
        // ...should return "(2 12)(3 27)(5 15)"
    }

    public static string SumOfDivided(int[] lst)
    {
        int[] primes = FindPrimes(Math.Max(lst.Max(), Math.Abs(lst.Min())));
        var result = new StringBuilder();

        foreach (int prime in primes)
        {
            long sum = 0;
            bool isSumChanged = false;

            foreach (int item in lst)
            {
                if (item % prime == 0)
                {
                    sum += item;
                    isSumChanged = true;
                }
            }

            if (isSumChanged)
                result.Append($"({prime} {sum})");
        }

        return result.ToString();
    }

    public static int[] FindPrimes(int distance)
    {
        if (distance < 2)
            return Array.Empty<int>();

        bool[] result = new bool[distance + 1];
        Array.Fill(result, true);
        result[0] = result[1] = false;

        for (int i = 2; i <= distance; i++)
        {
            if (!result[i])
                continue;

            for (int j = i * 2; j <= distance; j += i)
                result[j] = false;
        }

        return result.Select((v, i) => new { value = v, index = i }).Where(x => x.value).Select(x => x.index).ToArray();
    }
}