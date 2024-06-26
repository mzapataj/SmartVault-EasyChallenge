// See https://aka.ms/new-console-template for more information

using TwistedFizzBuzz;

IFizzBuzzService twistedFizzBuzz = new FizzBuzzService();

Dictionary<long, string> altTokens = new()
{
    {5, "Fizz"},
    {9, "Buzz"},
    {27, "Bar"}
};

var results = twistedFizzBuzz.CalculateFizzBuzz(-20, 127, altTokens);

foreach (var result in results)
{
    Console.WriteLine(result);    
}