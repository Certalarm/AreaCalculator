using AreaCalculatorLib.Domain.UseCases;
using System;
using System.Linq;
using Xunit;

namespace AreaCalculatorLib.Tests
{
    public class CalcAreaCircleTests
    {
        private const string figure = "circle";
        private readonly CalcAreaInteractor _sut;

        #region .ctors
        public CalcAreaCircleTests()
        {
            _sut = new CalcAreaInteractor();
        }
        #endregion

        [Fact]
        public void Calc_area_when_positive_radius()
        {
            var radius = 10.0;
            var values = new[] { radius };

            var area = _sut.Execute(figure, values);
            var resultArea = Math.PI * radius * radius;

            Assert.Equal(resultArea, area);
        }

        [Fact]
        public void Area_is_zero_when_values_is_null()
        {
            double[] values = null!;

            var area = _sut.Execute(figure, values);

            Assert.Equal(0.0, area);
        }

        [Fact]
        public void Area_is_zero_when_values_is_empty()
        {
            var values = new double[] { };

            var area = _sut.Execute(figure, values);

            Assert.Equal(0.0, area);
        }

        [Fact]
        public void Area_is_zero_when_radius_is_zero()
        {
            var values = new[] { 0.0 };

            var area = _sut.Execute(figure, values);

            Assert.Equal(0.0, area);
        }

        [Fact]
        public void Calc_area_by_first_value_when_values_more_1()
        {
            var values = new[] { 3.0, 4.0, 5.0, 6.0, 7.0, 8.0 };

            var area = _sut.Execute(figure, values);
            var resultArea = Math.PI * values.First() * values.First();

            Assert.Equal(resultArea, area);
        }

        [Fact]
        public void Throw_argument_exception_when_radius_is_negative()
        {
            var values = new[] { -5.0 };
            Assert.Throws<ArgumentException>(() => _sut.Execute(figure, values));
        }
    }
}
