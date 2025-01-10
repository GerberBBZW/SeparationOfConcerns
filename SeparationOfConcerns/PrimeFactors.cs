public class PrimeFactors
{
    public static void Factor(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0)
        {
            throw new ArgumentException("The input list cannot be null or empty.");
        }

        var primesCache = GeneratePrimesUpTo(numbers.Max());

        foreach (var number in numbers)
        {
            if (number < 1)
            {
                throw new ArgumentException("Negative numbers are not supported.");
            }

            var factors = Factorize(number, primesCache);
            PrintFactors(number, factors);
        }
    }

    public static Dictionary<int, List<int>> GeneratePrimesUpTo(int max)
    {
        var primesUpToNumber = new Dictionary<int, List<int>>();

        for (var number = 2; number <= max; number++)
        {
            primesUpToNumber[number] = new List<int>();
            for (var candidate = 2; candidate <= number; candidate++)
            {
                if (IsPrime(candidate))
                {
                    primesUpToNumber[number].Add(candidate);
                }
            }
        }

        return primesUpToNumber;
    }

    public static bool IsPrime(int candidate)
    {
        if (candidate < 2) return false;

        for (var i = 2; i * i <= candidate; i++)
        {
            if (candidate % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static List<int> Factorize(int number, Dictionary<int, List<int>> primesCache)
    {
        var primes = primesCache[number];
        var factors = new List<int>();
        var remainder = number;

        foreach (var prime in primes)
        {
            while (remainder % prime == 0)
            {
                remainder /= prime;
                factors.Add(prime);
            }

            if (remainder == 1) break;
        }

        if (remainder > 1)
        {
            factors.Add(remainder);
        }

        return factors;
    }

    public static void PrintFactors(int number, List<int> factors)
    {
        Console.WriteLine($"{number}: {string.Join(" ", factors)}");
    }
}