using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AreaCalculatorLib.Domain.Entities.FigureEntity.Base;

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

        internal Circle(double[] values):this(values == null || !values.Any() ? 0.0 : values[0])
        { }
        #endregion

        internal override double Area() => Math.PI * Radius.SquareLength();
    }
}
