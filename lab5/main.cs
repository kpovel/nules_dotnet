using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
class Vector
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }

    public Vector() : this(0.0, 0.0, 0.0) { }

    public Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = AdjustZSign(x, y, z);
    }

    private double AdjustZSign(double x, double y, double z)
    {
        if (x * y * z < 0) {
            return -Math.Abs(z);
        }

        return Math.Abs(z);
    }

    public void Draw()
    {
        Console.WriteLine("Малюємо еліпс з координатами: X={0}, Y={1}, Z={2}", X, Y, Z);
        Console.WriteLine("Малюємо правильний п'ятикутник з координатами: X={0}, Y={1}, Z={2}", X, Y, Z);
    }
}

class Program
{
    static void Main()
    {
        Vector vector = new Vector(1.0, 2.0, 3.0);
        vector.Draw();

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream("vector.dat", FileMode.Create))
        {
            formatter.Serialize(stream, vector);
        }

        Vector deserializedVector;
        using (FileStream stream = new FileStream("vector.dat", FileMode.Open))
        {
            deserializedVector = (Vector)formatter.Deserialize(stream);
        }

        Console.WriteLine("Десеріалізований вектор:");
        deserializedVector.Draw();
    }
}

