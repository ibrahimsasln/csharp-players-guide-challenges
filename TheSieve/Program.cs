using System;
class Sieve(Func<int, bool> func)
{
    private readonly Func<int, bool> _func = func;

    public bool IsGood(int num)
    {
        return _func(num);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Pick one of those three filter: 1-Even, 2-Positive, 3-Multiple of Ten");
        int choice = Convert.ToInt32(Console.ReadLine());

        Sieve sieve = choice switch
        {
            1 => new Sieve(IsEven),
            2 => new Sieve(IsPositive),
            3 => new Sieve(IsMultTen),
            _ => throw new ArgumentException("Invalid choice")
        };

        bool IsEven(int num) => num % 2 == 0;
        bool IsPositive(int num) => num > 0;
        bool IsMultTen(int num) => num % 10 == 0;

        while (true)
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            string goodOrEvil = sieve.IsGood(number) ? "good" : "evil";
            Console.WriteLine($"That number is {goodOrEvil}.");
        }
    }
}
