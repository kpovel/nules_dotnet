namespace MathLib;
public class MathFuncitons
{
    public static int Factorial(int n)
    {
        if (n < 2)
        {
            return 1;
        }

        int res = 1;
        while (n > 1)
        {
            res *= n;
            n -= 1;
        }

        return res;
    }

    public static double TriangleArea(double a, double b, double c)
    {
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            return -1;
        }

        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
}
