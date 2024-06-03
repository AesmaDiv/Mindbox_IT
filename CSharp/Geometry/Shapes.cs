namespace Geometry {
    public static class Shapes {
        // ...
        public static double GetArea(IShape shape) {
            return shape.Area();
        }
        // ...
    }
    /// <summary>
    /// Интерфейс для фигуры
    /// </summary>
    public interface IShape {
        /// <summary>
        /// Площадь фигуры
        /// </summary>
        public double Area();
    }
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : IShape {
        // Мнение: длины сторон удобнее хранить в массиве
        // Ибо: проще посчитать периметр, найти самую длинную, опредить прямоугольность и расчитать площадь
        private readonly double[] _edges; // стороны треугольника
        public Triangle(double a, double b, double c) {
            _edges = [a, b, c];
            _CheckValid(_edges);
        }

        // Стороны треугольника возможно изменить после создания экземпляра,
        // но новые значения должны пройти проверку на корректность.
        // Есть два варианта:
        // - выбрасывать исключение при провале проверки на корректность и обрабатывать его выше
        // - оставить длины неизменными или присвоить значение по умолчанию, но никто об этом не узнает.
        // Я выбрал первый вариант
        public double A {
            get { return _edges[0]; }
            set {
                _CheckValid([value, B, C]);
                _edges[0] = value;
            }
        }
        public double B {
            get { return _edges[1]; }
            set {
                _CheckValid([A, value, C]);
                _edges[1] = value;
            }
        }
        public double C {
            get { return _edges[2]; }
            set {
                _CheckValid([A, B, value]);
                _edges[2] = value;
            }
        }
        /// <summary>
        /// Проверка на прямоугольность
        /// </summary>
        public bool IsRight() {
            double[] squares = Array.ConvertAll(_edges, x => x * x);
            Array.Sort(squares);
            return squares[0] + squares[1] == squares[2];
        }
        /// <summary>
        /// Площадь треугольника
        /// </summary>
        public double Area() {
            double p = _edges.Sum() / 2.0;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
        /// <summary>
        /// Проверка на корректность длин сторон
        /// </summary>
        private void _CheckValid(double[] edges) {
            double[] sorted = [.. edges.OrderBy(x => x)];
            if (sorted[0] < 0)
                throw new ArgumentException($"Cтороны треугольника не могут принимать отрицательные значения: {edges[0]}, {edges[1]}, {edges[2]}");
            if ((sorted[0] + sorted[1]) < sorted[2])
                throw new ArgumentException($"Ни одна из сторон треугольника не может быть больше суммы двух других: {edges[0]}, {edges[1]}, {edges[2]}");
        }
    }
    /// <summary>
    /// Окружность
    /// </summary>
    public class Circle : IShape {
        private double _r;
        public Circle(double r) {
            _r = r;
            _CheckValid();
        }
        /// <summary>
        /// Радиус окружности
        /// </summary>
        public double Radius {
            get { return _r; }
            set {
                _r = value;
                _CheckValid();
            }
        }
        /// <summary>
        /// Площадь окружности
        /// </summary>
        public double Area() {
            return Math.PI * _r * _r;
        }
        /// <summary>
        /// Проверка корректности параметров окружности
        /// </summary>
        private void _CheckValid() {
            if (_r < 0) {
                throw new ArgumentException($"Радиус окружности не может принимать отрицательное значение: {_r}");
            }
        }
    }

}