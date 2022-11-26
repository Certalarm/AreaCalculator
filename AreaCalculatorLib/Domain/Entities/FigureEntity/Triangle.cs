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
        private Triangle()
        {
            SideA = new LineSegment(0.0);
            SideB = new LineSegment(0.0);
            SideC = new LineSegment(0.0);
        }

        internal Triangle(double sideA, double sideB, double sideC)
        {
            SideA = new LineSegment(sideA);
            SideB = new LineSegment(sideB);
            SideC = new LineSegment(sideC);
        }

        internal Triangle(double[] values): this()
        {
            if (!Validate(values)) return;
            SideA = new LineSegment(values[0]);
            SideB = new LineSegment(values[1]);
            SideC = new LineSegment(values[2]);
        }
        #endregion

        private bool Validate(double[] values) => 
            values != null && values.Length >= 3; // 3 is triangle side count

        internal bool HasSideZeroLen() => 
            SideA.Length == 0.0 || SideB.Length == 0.0 || SideC.Length == 0.0; 

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
