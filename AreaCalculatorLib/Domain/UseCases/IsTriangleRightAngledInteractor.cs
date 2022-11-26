using AreaCalculatorLib.Domain.Entities.FigureEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            var maxSquareLen = orderedSquareSides.Last();
            var squareLensWithoutMax = orderedSquareSides.Take(2);
            return maxSquareLen == squareLensWithoutMax.Sum(x => x);
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
