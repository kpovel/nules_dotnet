abstract class Body
{
    public abstract double SurfaceArea();
    public abstract double Volume();

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Body otherBody = (Body)obj;
        return SurfaceArea() == otherBody.SurfaceArea() &&
               Volume() == otherBody.Volume();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(SurfaceArea(), Volume());
    }
}

class Balloon : Body
{
    private double Radius;

    public Balloon(double radius)
    {
        Radius = radius;
    }

    public override double SurfaceArea()
    {
        return 4 * Math.PI * Math.Pow(Radius, 2);
    }

    public override double Volume()
    {
        return 4 / 3 * Math.PI * Math.Pow(Radius, 3);
    }
}

class Parallelepiped : Body
{
    private double Width;
    private double Height;
    private double Length;

    public Parallelepiped(double width, double height, double length)
    {
        Width = width;
        Height = height;
        Length = length;
    }

    public override double SurfaceArea()
    {
        return 2 * (Width * Height + Height * Length + Width * Length);
    }

    public override double Volume()
    {
        return Width * Height * Length;
    }
}

class Tetrahedron : Body
{
    private double EdgeLength;

    public Tetrahedron(double edgeLength)
    {
        EdgeLength = edgeLength;
    }

    public override double SurfaceArea()
    {
        return Math.Sqrt(3) * Math.Pow(EdgeLength, 2);
    }

    public override double Volume()
    {
        return Math.Pow(EdgeLength, 3) / (6 * Math.Sqrt(2));
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Body> bodies = new List<Body>
        {
            new Balloon(3),
            new Parallelepiped(4, 5, 6),
            new Tetrahedron(7)
        };

        foreach (Body body in bodies)
        {
            Console.WriteLine($"Type: {body.GetType().Name}");
            Console.WriteLine($"Surface Area: {body.SurfaceArea()}");
            Console.WriteLine($"Volume: {body.Volume()}");
            Console.WriteLine();
        }
    }
}

