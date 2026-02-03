
// desarrollar un programa que le solicite al usuario un numero y el programa indique si es par o impar.

try
{
    Console.Write("Please enter a whole number to determine if it is even or odd: ");


    int number = Convert.ToInt32(Console.ReadLine());

    if (number % 2 == 0)
    {

        Console.WriteLine($"The number: {number} is even.");

    }
    else
    {
        Console.WriteLine($"The number: {number} is odd.");
        
    }
}
catch (Exception)
{

  Console.WriteLine("Error: You must enter a whole number");
}

