## Description:

Given an array of positive or negative integers.

```I= [i1,..,in]```

You have to produce a sorted array P of the form.

```[ [p, sum of all ij of I for which p is a prime factor (p positive) of ij] ...]```

P will be sorted by increasing order of the prime numbers. The final result has to be given as a string in Java, C#, C, C++ and as an array of arrays in other languages.

**Example:**
```C#
I = {12, 15}; // result = "(2 12)(3 27)(5 15)"
```
[2, 3, 5] is the list of all prime factors of the elements of I, hence the result.

**Notes:**

- It can happen that a sum is 0 if some numbers are negative!

**Example:** 
I = [15, 30, -45]
5 divides 15, 30 and (-45) so 5 appears in the result, the sum of the numbers for which 5 is a factor is 0 so we have [5, 0] in the result amongst others.

- In Fortran - as in any other language - the returned string is not permitted to contain any redundant trailing whitespace: you can use dynamically allocated character strings.
### My solution
``` C#
using System;
using System.Linq;
using System.Text;

public class SumOfDivided
{
    public static string sumOfDivided(int[] lst)
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

        return result.Select((v, i) => new { value = v, index = i }).
            Where(x => x.value).Select(x => x.index).ToArray();
    }
}
```
