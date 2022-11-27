using AreaCalculatorLib.Domain.Entities.FigureEntity;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AreaCalculatorLib.Tests")]
namespace AreaCalculatorLib.Domain.UseCases
{
    internal class IsTriangleRightAngledInteractor
    {
        internal bool Execute(double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            return IsRightAngled(triangle);
        }

        private static bool IsRightAngled(Triangle triangle)
        {
            if (triangle.HasSideZeroLen())
                return false;
            var orderedSquareSides = BuildOrderedSquareSides(triangle);
            var maxSquareSide = orderedSquareSides.Last();              // square of Hypotenuse,
            var squareSidesWithoutMax = orderedSquareSides.Take(2);     // katet squares
            return maxSquareSide == squareSidesWithoutMax.Sum(x => x);  // Pythagorean theorem
        }

        private static IEnumerable<double> BuildOrderedSquareSides(Triangle triangle) =>
            BuildSquareSides(triangle)
                .OrderBy(x => x);

        private static double[] BuildSquareSides(Triangle triangle) =>
            new[]
            {
                triangle.SideA.SquareLength(),
                triangle.SideB.SquareLength(),
                triangle.SideC.SquareLength()
            };
    }
}
