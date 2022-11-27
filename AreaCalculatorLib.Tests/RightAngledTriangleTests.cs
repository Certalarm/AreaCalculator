using AreaCalculatorLib.Domain.UseCases;
using System;
using System.Collections.Generic;
using Xunit;

namespace AreaCalculatorLib.Tests
{
    public class RightAngledTriangleTests
    {
        private readonly IsTriangleRightAngledInteractor _sut;

        #region .ctors
        public RightAngledTriangleTests()
        {
            _sut = new IsTriangleRightAngledInteractor();
        }
        #endregion

        [Theory]
        [MemberData(nameof(TriangleSides))]
        public void Done_when_triangle_is_right_angled_only(double sideA, double sideB, double sideC, bool isRightAngled)
        {
            var isResultRightAngled = _sut.Execute(sideA, sideB, sideC);

            Assert.Equal(isRightAngled, isResultRightAngled);
        }

        public static List<object[]> TriangleSides()
        {
            return new List<object[]>
            {   // format: sideA, sideB, sideC, isRightAngled?
                new object[] { 1.0, 2.0, 3.0, false }, 
                new object[] { 2.0, 3.0, 4.0, false },  
                new object[] { 3.0, 4.0, 5.0, true  },  // this RightAngled Only 
                new object[] { 4.0, 5.0, 6.0, false },  
                new object[] { 5.0, 6.0, 7.0, false },  
                new object[] { 6.0, 7.0, 8.0, false },  
                new object[] { 0.0, 8.0, 9.0, false },  // with zero side len
                new object[] { 8.0, 9.0, null!, false },// with null side len
            };
        }

        [Theory]
        [MemberData(nameof(TriangleSidesWithNegativeLen))]
        public void Throw_argument_exception_when_any_side_is_negative(double sideA, double sideB, double sideC)
        {
            Assert.Throws<ArgumentException>(() => _sut.Execute(sideA, sideB, sideC));
        }

        public static List<object[]> TriangleSidesWithNegativeLen()
        {
            return new List<object[]>
            {   // format: sideA, sideB, sideC
                new object[] { -4.0, 5.0, 6.0 },  // sideA is Negative
                new object[] { 4.0, -5.0, 6.0 },  // sideB is Negative
                new object[] { 4.0, 5.0, -6.0 },  // sideC is Negative
                new object[] { -4.0, -5.0, 6.0 }, // sideA and SideB is Negative
                new object[] { 4.0, -5.0, -6.0 }, // sideB and SideC is Negative
                new object[] { -4.0, 5.0, -6.0 }, // sideA and SideC is Negative
                new object[] { -4.0, -5.0, -6.0 },// all sides is Negative
            };
        }
    }
}
