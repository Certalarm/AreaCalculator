using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AreaCalculatorLib.Utility.Txt;

namespace AreaCalculatorLib.Domain.Entities.FigureEntity
{
    internal readonly struct LineSegment
    {
        internal readonly double Length;

        #region .ctors
        public LineSegment()
        {
            Length = 0.0;
        }

        public LineSegment(double length):this()
        {
            Length = initLength(length);
        }
        #endregion

        public double SquareLength() =>
            isZeroLength()
                ? 0.0
                : Length * Length;

        private bool isZeroLength() => Length == 0.0;

        private double initLength(double length) 
        {
            if(length < 0.0) 
            {
                throw new Exception(OnlyPositiveExMessage);
            }
            return length;
        }
    }
}
