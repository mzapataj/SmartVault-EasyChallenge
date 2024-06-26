using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using JetBrains.Annotations;
using Xunit;

namespace TwistedFizzBuzz.Tests;

[TestSubject(typeof(FizzBuzzService))]
public class FizzBuzzServiceTest
{
    private readonly IFizzBuzzService fizzBuzzService = new FizzBuzzService();

    [Fact]
    public void Throws_ArgumentException_minParameter_Greater_Than_maxParameter()
    {
        var exception = Record.Exception(() =>
        {
            var result = fizzBuzzService.CalculateFizzBuzz(100, 1);
            var first = result.First();
            return result;
        });
        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Calculate_FizzBuzz_In_Range()
    {
        var expectedResult = new[]
        { 
            "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz", "16", 
            "17","Fizz", "19", "Buzz", "Fizz", "22", "23", "Fizz", "Buzz", "26", "Fizz", "28", "29", "FizzBuzz"
        };
        
        var result = fizzBuzzService.CalculateFizzBuzz(1, 30);

        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public void Calculate_FizzBuzz_In_Range_Alt_Tokens()
    {
        Dictionary<long, string> altTokens = new()
        {
            { 4, "Poem" },
            { 2, "Writer" },
            { 10, "College" }
        };
        var expectedResult = new[] { "WriterCollege", "-9", "PoemWriter", "-7", "Writer", "-5", "PoemWriter" , "-3", "Writer" , 
                                     "-1", "PoemWriterCollege", "1", "Writer", "3" ,"PoemWriter" ,"5" };

        
        var result = fizzBuzzService.CalculateFizzBuzz(-10, 5, altTokens);
        
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public void Calculate_FizzBuzz_In_Array()
    {
        var expectedResult = new[]
        {
            "Buzz", "-2", "Buzz", "Buzz", "Fizz", "28", "FizzBuzz", "16"
        };
        var inputArr = new long[] { -10, -2, -5, 5, -9, 28, 15, 16 };

        var result = fizzBuzzService.CalculateFizzBuzz(inputArr);

        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public void Calculate_FizzBuzz_In_Array_Alt_Tokens()
    {
        Dictionary<long, string> altTokens = new()
        {
            { 7, "Poem" },
            { 17, "Writer" },
            { 3, "College" }
        };
        var expectedResult = new[] { "2", "PoemWriter", "WriterCollege", "1", "4", "PoemCollege", "PoemWriterCollege", "8", "College" };

        var result = fizzBuzzService.CalculateFizzBuzz(new long[] { 2 ,119, 51, 1, 4, 21, 357, 8, 9 }, altTokens);
        
        result.Should().BeEquivalentTo(expectedResult);
    }
}