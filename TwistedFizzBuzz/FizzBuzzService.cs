using System.Collections;
using System.Runtime.Versioning;

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
        
        var resulList = new List<string>();
        
        for (var i = minRange; i <= maxRange; i++)
        {
            var item = GetFizzBuzz(i, altTokens);
            resulList.Add(item);
        }

        return resulList;
    }

    public IEnumerable<string> CalculateFizzBuzz(IEnumerable<long> inputArray, Dictionary<long, string>? altTokens = null)
    {
        altTokens ??= defaultTokens;
        
        var resulList = new List<string>();

        foreach (var i in inputArray)
        {
            var item = GetFizzBuzz(i, altTokens);
            resulList.Add(item);
        }

        return resulList;
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