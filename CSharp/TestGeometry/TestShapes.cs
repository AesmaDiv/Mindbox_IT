using Geometry;
namespace TestGeometry {
    [TestClass]
    public class TestShapes {
        [TestMethod]
        public void TriangleTest_Area_n_Right() {
            Triangle triangle = new(6, 10, 8);
            Assert.IsTrue(triangle.IsRight(), "Неверное определение прямоугольности");
            Assert.AreEqual(24.0, triangle.Area(), "Неверный расчёт площади треугольника");

            triangle.A /= 2;
            triangle.B /= 2;
            triangle.C /= 2;
            Assert.IsTrue(triangle.IsRight(), "Неверное определение прямоугольности");
            Assert.AreEqual(6.0, triangle.Area(), "Неверный расчёт площади треугольника");

            triangle.B = 6.0;
            Assert.IsFalse(triangle.IsRight(), "Неверное определение прямоугольности");
            Assert.AreEqual(5.332682251925386, triangle.Area(), "Неверный расчёт площади треугольника");

            triangle.C = 9.0;
            Assert.IsFalse(triangle.IsRight(), "Неверное определение прямоугольности");
            Assert.AreEqual(0, triangle.Area(), "Неверный расчёт площади треугольника");
        }
        [TestMethod]
        public void TriangleTest_ValidA() {
            Triangle triangle = new(4, 5, 6);
            triangle.A = 7;
        }
        [TestMethod]
        public void TriangleTest_ValidB() {
            Triangle triangle = new(4, 5, 6);
            triangle.B = 9;
        }
        [TestMethod]
        public void TriangleTest_ValidC() {
            Triangle triangle = new(4, 5, 6);
            triangle.C = 8;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка валидации: A > B + C")]
        public void TriangleTest_InvalidA() {
            Triangle triangle = new(4, 5, 6);
            triangle.A = 12;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка валидации: C > A + B")]
        public void TriangleTest_InvalidB() {
            Triangle triangle = new(4, 5, 6);
            triangle.B = 1;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка валидации: C > A + B")]
        public void TriangleTest_InvalidC() {
            Triangle triangle = new(4, 5, 6);
            triangle.C = 10;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка валидации: A < 0")]
        public void TriangleTest_NegativeA() {
            Triangle triangle = new(4, 5, 6);
            triangle.A = -4;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка валидации: B < 0")]
        public void TriangleTest_NegativeB() {
            Triangle triangle = new(4, 5, 6);
            triangle.B = -5;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка валидации: C < 0")]
        public void TriangleTest_NegativeC() {
            Triangle triangle = new(4, 5, 6);
            triangle.C = -6;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка валидации: некорректные длины сторон в конструкторе")]
        public void TriangleTest_InvalidConstruct() {
            Triangle triangle = new(2, 4, 7);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка валидации: отрицательная длина стороны в конструкторе")]
        public void TriangleTest_NegativeConstruct() {
            Triangle triangle = new(2, -4, 7);
        }

        [TestMethod]
        public void CircleTest_Area() {
            Circle[] circles = [
                new(1),
                new(8.2),
                new(3 / Math.Sqrt(Math.PI)),
            ];
            var pairs = circles.Zip([
                3.141592653589793,
                211.24069002737764,
                9,
            ]);
            foreach (var (circle, area) in pairs) {
                Assert.AreEqual(circle.Area(), area, "Неверный расчёт площади окружности");
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка валидации: R < 0")]
        public void CircleTest_NegativeRadius() {
            Circle circle = new(10);
            circle.Radius = -5;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Ошибка валидации: отрицательный радиус в конструкторе")]
        public void CircleTest_NegativeConstruct() {
            Circle circle = new(-5);
        }
    }
}