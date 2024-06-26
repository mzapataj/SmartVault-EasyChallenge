// See https://aka.ms/new-console-template for more information
 
 using TwistedFizzBuzz;
 
 IFizzBuzzService twistedFizzBuzz = new FizzBuzzService();
 
 var results = twistedFizzBuzz.CalculateFizzBuzz(1, 100);
 
 foreach (var result in results)
 {
     Console.WriteLine(result);    
 }