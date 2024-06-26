namespace TwistedFizzBuzz;


public interface IFizzBuzzService
{
    IEnumerable<string> CalculateFizzBuzz(long minRange, long maxRange, Dictionary<long, string>? altTokens = null);
    IEnumerable<string> CalculateFizzBuzz(IEnumerable<long> inputArray, Dictionary<long, string>? altTokens = null);
}

public class FizzBuzzService : IFizzBuzzService
{
    private readonly Dictionary<long, string> defaultTokens = new()
    {
        {3 , "Fizz"},
        {5 , "Buzz"}
    };
    
    public IEnumerable<string> CalculateFizzBuzz(long minRange, long maxRange, Dictionary<long, string>? altTokens = null)
    {
        if (minRange > maxRange) throw new ArgumentException($"minRange parameter '{minRange}' is greater than maxRange parameter '{maxRange}'.");
        
        altTokens ??= defaultTokens;
        
        for (var i = minRange; i <= maxRange; i++)
            yield return GetFizzBuzz(i, altTokens);
    }

    public IEnumerable<string> CalculateFizzBuzz(IEnumerable<long> inputArray, Dictionary<long, string>? altTokens = null)
    {
        altTokens ??= defaultTokens;
        
        foreach (var i in inputArray)
            yield return GetFizzBuzz(i, altTokens);
    }
    
    
    private string GetFizzBuzz(long i, Dictionary<long, string> altTokens)
    {
        var itemAux = "";

        foreach (var altToken in altTokens)
        {
            if (i % altToken.Key == 0)
                itemAux += altToken.Value;
        }
        if (string.IsNullOrEmpty(itemAux))
            itemAux = i.ToString();

        return itemAux;
    }
}