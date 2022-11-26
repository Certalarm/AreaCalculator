using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AreaCalculatorLib.Domain.Entities.FigureEntity.Base;

namespace AreaCalculatorLib.Domain.Entities.FigureEntity
{
    internal class Triangle : Figure
    {
        internal LineSegment SideA { get; }
        internal LineSegment SideB { get; }
        internal LineSegment SideC { get; }

        #region .ctors
        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = new LineSegment(sideA);
            SideB = new LineSegment(sideB);
            SideC = new LineSegment(sideC);
        }
        #endregion

        internal bool HasSideZeroLen() => 
            SideA.Length == 0.0 || SideB.Length == 0.0 || SideC.Length == 0.0; 

        internal bool IsRightAngled()
        {
            if (HasSideZeroLen()) 
                return false;
            var sideSquareLens = new[] { SideA.SquareLength(), SideB.SquareLength(), SideC.SquareLength() };
            var orderedSideSquareLens = sideSquareLens.OrderBy(x => x);
            var maxSquareLen = orderedSideSquareLens.Last();
            var squareLensWithoutMax = orderedSideSquareLens.Take(2);
            return maxSquareLen == squareLensWithoutMax.Sum(x => x);
        }

        internal override double Area()
        {
            if (HasSideZeroLen()) 
                return 0.0;
            var p = SemiPerimeter();
            return Math.Sqrt(p * (p - SideA.Length) * (p - SideB.Length) * (p - SideC.Length));
        }

        private double SemiPerimeter() => (SideA.Length + SideB.Length + SideC.Length) / 2.0;
    }
}
