using MathLib;

class Program {
  static void Main() {
    int factorial = MathFuncitons.Factorial(4);
    Console.WriteLine($"Factorial: {factorial}");

    double triangleArea = MathFuncitons.TriangleArea(3, 4, 5);
    Console.WriteLine($"Triangle Area {triangleArea}");
  }
}
