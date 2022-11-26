using AreaCalculatorLib.Domain.UseCases;
using static AreaCalculatorLib.Utility.Txt;

namespace AreaCalculatorLib
{
    public class AreaCalculator
    {
        public double CalcArea(string figureType, double[] values)
        {
            var interactor = new CalcAreaInteractor();
            return interactor.Execute(figureType, values);
        }

        public bool IsTriangleRightAngled(double sideA, double sideB, double sideC)
        {
            var interactor = new IsTriangleRightAngledInteractor();
            return interactor.Execute(sideA, sideB, sideC);
        }

    }
}