using AreaCalculatorLib.Domain.Entities.FigureEntity.Base;
using System;
using System.Linq;

namespace AreaCalculatorLib.Domain.Entities.FigureEntity
{
    internal class Circle : Figure
    {
        internal LineSegment Radius { get; }

        #region .ctors
        internal Circle(double radius)
        {
            Radius = new LineSegment(radius);
        }

        internal Circle(double[] values) : this(InitRadius(values))
        { }
        #endregion

        internal override double Area() => Math.PI * Radius.SquareLength();

        private static double InitRadius(double[] values) =>
            values == null || !values.Any()
                ? 0.0
                : values[0];
    }
}
