namespace IntegralCalculator;

delegate double FunctionDelegate(double x);

class Program
{
    static void Main()
    {
        FunctionDelegate f1 = x => 1 / (3 * Math.Sqrt(x));
        FunctionDelegate f2 = x => Math.Exp(x) / Math.Sqrt(x);
        FunctionDelegate f3 = x => Math.Log(x, 2);
        FunctionDelegate fSquare = x => x * x;

        double start = 1;
        double end = 2;
        int nRectangles = 1000;

        Console.WriteLine($"Integral of f1: {CalculateIntegral(f1, start, end, nRectangles)}");
        Console.WriteLine($"Integral of f2: {CalculateIntegral(f2, start, end, nRectangles)}");
        Console.WriteLine($"Integral of f3: {CalculateIntegral(f3, start, end, nRectangles)}");

        double analyticalValue = (1.0 / 3.0) * (end * end * end - start * start * start);
        double numericalValue = CalculateIntegral(fSquare, start, end, nRectangles);
        double error = Math.Abs(analyticalValue - numericalValue);

        Console.WriteLine($"Analytical value for f(x) = x^2: {analyticalValue}");
        Console.WriteLine($"Numerical value for f(x) = x^2: {numericalValue}");
        Console.WriteLine($"Error: {error}");
    }

    public static double CalculateIntegral(FunctionDelegate f, double a, double b, int n)
    {
        double width = (b - a) / n;
        double sum = 0.0;
        for (int i = 1; i <= n; i++)
        {
            sum += f(a + i * width);
        }
        return sum * width;
    }
}

