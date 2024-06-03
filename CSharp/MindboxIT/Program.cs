using Geometry;

class Program {
    static void Main(string[] args) {
        Triangle[] triangles = [
            new(5, 4, 6),
            new(3, 6, 4),
            new(5, 4, 3),
            new(1,2,1)
        ];

        Circle[] circles = [
            new(1),
            new(8.2),
            new(3 / Math.Sqrt(Math.PI)),
        ];

        foreach (Triangle triangle in triangles) {
            Console.WriteLine(
                string.Format(
                    "Triangle area is {0}. Triangle is{1} right.",
                    Shapes.GetArea(triangle),
                    triangle.IsRight() ? "" : " NOT"
                )
            );
        }
        foreach (Circle circle in circles) {
            Console.WriteLine($"Circle area is {circle.Area()}");
        }

        try {
            triangles[0].A *= 3;
        } catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }

        try {
            Triangle not_valid = new(3, 4, 9);
        } catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }
    }
}