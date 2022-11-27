using AreaCalculatorLib.Domain.UseCases;
using System;
using System.Collections.Generic;
using Xunit;

namespace AreaCalculatorLib.Tests
{
    public class CalcAreaTriangleTests
    {
        private const string figure = "triangle";
        private readonly CalcAreaInteractor _sut;

        #region .ctors
        public CalcAreaTriangleTests()
        {
            _sut = new CalcAreaInteractor();
        }
        #endregion

        [Fact] 
        public void Calc_area_when_sides_positive()
        {
            var values = new[] { 3.0, 4.0, 5.0 };

            var area = _sut.Execute(figure, values);
 
            Assert.Equal(6.0, area);
        }

        [Theory]
        [MemberData(nameof(NotEnoughValues))]
        public void Area_is_zero_when_not_enough_values(double[] values)
        {
            var zeroArea = _sut.Execute(figure, values);

            Assert.Equal(0.0, zeroArea);
        }

        public static List<object[]> NotEnoughValues()
        {
            return new List<object[]>
            {   // format: [value1, ... , valueN]
                new object[] { null! },                 // null values
                new object[] { new double[] { }},       // empty values
                new object[] { new[] { 4.0 }},          // one value
                new object[] { new[] { 4.0, 5.0 }},     // two values
            };
        }

        [Fact]
        public void Calc_area_by_first_3_value_when_values_more_3()
        {
            var values = new[] { 3.0, 4.0, 5.0, 6.0, 7.0, 8.0 };

            var area = _sut.Execute(figure, values);

            Assert.Equal(6.0, area);
        }

        [Theory]
        [MemberData(nameof(TriangleSidesWithNegativeLen))]
        public void Throw_argument_exception_when_any_side_is_negative(double[] values)
        {
            Assert.Throws<ArgumentException>(() => _sut.Execute(figure, values));
        }

        public static List<object[]> TriangleSidesWithNegativeLen()
        {
            return new List<object[]>
            {   // format: [sideA, sideB, sideC]
                new object[] { new[] { -4.0, 5.0, 6.0 }},  // sideA is Negative
                new object[] { new[] { 4.0, -5.0, 6.0 }},  // sideB is Negative
                new object[] { new[] { 4.0, 5.0, -6.0 }},  // sideC is Negative
                new object[] { new[] { -4.0, -5.0, 6.0 }}, // sideA and SideB is Negative
                new object[] { new[] { 4.0, -5.0, -6.0 }}, // sideB and SideC is Negative
                new object[] { new[] { -4.0, 5.0, -6.0 }}, // sideA and SideC is Negative
                new object[] { new[] { -4.0, -5.0, -6.0 }},// all sides is Negative
            };
        }

        [Theory]
        [MemberData(nameof(TriangleSidesWithZeroLen))]
        public void Area_is_zero_when_any_side_is_zero(double[] values, bool isZeroArea)
        {
            var area = _sut.Execute(figure, values);
            var isZeroResultArea = area == 0.0;

            Assert.Equal(isZeroArea, isZeroResultArea);
        }

        public static List<object[]> TriangleSidesWithZeroLen()
        {
            return new List<object[]>
            {   // format: [sideA, sideB, sideC], isZeroArea?
                new object[] { new[] { 0.0, 5.0, 6.0 }, true },  // sideA is Zero
                new object[] { new[] { 5.0, 0.0, 6.0 }, true },  // sideB is Zero
                new object[] { new[] { 5.0, 6.0, 0.0 }, true },  // sideC is Zero
                new object[] { new[] { 0.0, 0.0, 6.0 }, true },  // sideA and SideB is Zero
                new object[] { new[] { 5.0, 0.0, 0.0 }, true },  // sideB and SideC is Zero
                new object[] { new[] { 0.0, 5.0, 0.0 }, true },  // sideA and SideC is Zero
                new object[] { new[] { 0.0, 0.0, 0.0 }, true },  // all sides is Zero
                new object[] { new[] { 4.0, 5.0, 6.0 }, false }, // no sides is Zero
            };
        }
    }
}