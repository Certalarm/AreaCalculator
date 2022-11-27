using AreaCalculatorLib.Domain.UseCases;
using System;
using System.Collections.Generic;
using Xunit;

namespace AreaCalculatorLib.Tests
{
    public class CalcAreaCommonTests
    {
        private readonly double[] values = new[] { 2.0, 3.0, 4.0 };
        private readonly CalcAreaInteractor _sut;

        #region .ctors
        public CalcAreaCommonTests()
        {
            _sut = new CalcAreaInteractor();
        }
        #endregion

        [Theory]
        [MemberData(nameof(KnownFigureTypesAnyCase))]
        public void Calc_area_when_known_figure_types_typed_any_case(string figureType)
        {
            var area = _sut.Execute(figureType, values);
            var isAreaCalc = area != 0.0;

            Assert.True(isAreaCalc);
        }

        public static List<object[]> KnownFigureTypesAnyCase()
        {
            return new List<object[]>
            {   // format: figureType
                new object[] { "circle" },             
                new object[] { "CiRcLe" },  
                new object[] { "CIRCLE" },  
                new object[] { "triangle" },
                new object[] { "TrIaNgLe" },
                new object[] { "TRIANGLE" },
            };
        }

        [Theory]
        [MemberData(nameof(BadFigureTypes))]
        public void Throw_exception_when_bad_figure_type(string figureType)
        {
            Assert.Throws<ArgumentException>(() => _sut.Execute(figureType, values));
        }

        public static List<object[]> BadFigureTypes()
        {
            return new List<object[]>
            {   // format: figureType
                new object[] { null! },
                new object[] { string.Empty },
                new object[] {" " },
                new object[] { "ellipse" },
                new object[] { "star" },
            };
        }
    }
}
