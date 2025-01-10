namespace SeparationOfConcerns.Test;

public class PrimeFactorsTest
{
    [Fact]
    public void FactorizeSmallNumber_ShouldReturnCorrectFactors()
    {
        int number = 42;
        var expected = new List<int> { 2, 3, 7 };
        var primesCache = PrimeFactors.GeneratePrimesUpTo(42);
        
        var factors = PrimeFactors.Factorize(number, primesCache);
        
        Assert.Equal(expected, factors);
    }

    [Fact]
    public void FactorizeLargeNumber_ShouldReturnCorrectFactors()
    {
        int number = 123456;
        var expected = new List<int> { 2, 2, 2, 2, 2, 2, 3, 643 };
        var primesCache = PrimeFactors.GeneratePrimesUpTo(number);

        var factors = PrimeFactors.Factorize(number, primesCache);

        Assert.Equal(expected, factors);
    }

    [Fact]
    public void FactorizeNegativeNumber_ShouldThrowException()
    {
        var numbers = new List<int> { -5 };

        var exception = Assert.Throws<ArgumentException>(() => PrimeFactors.Factor(numbers));
        Assert.Contains("Negative numbers are not supported", exception.Message);
    }

    [Fact]
    public void FactorizePrimeNumber_ShouldReturnPrimeItself()
    {
        int number = 19;
        var expected = new List<int> { 19 };
        var primesCache = PrimeFactors.GeneratePrimesUpTo(number);

        var factors = PrimeFactors.Factorize(number, primesCache);

        Assert.Equal(expected, factors);
    }
}