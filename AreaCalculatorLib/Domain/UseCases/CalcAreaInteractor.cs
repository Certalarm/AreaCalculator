using AreaCalculatorLib.Domain.Entities.FigureEntity;
using AreaCalculatorLib.Domain.Entities.FigureEntity.Base;
using System.Runtime.CompilerServices;
using static AreaCalculatorLib.Utility.Txt;

[assembly: InternalsVisibleTo("AreaCalculatorLib.Tests")]
namespace AreaCalculatorLib.Domain.UseCases
{
    internal class CalcAreaInteractor
    {
        internal double Execute(string figureType, double[] values)
        {
            if (!Validate(figureType, values)) 
                return 0.0;
            var figure = CreateFigure(figureType, values);
            return figure.Area();
        }

        private static bool Validate(string figureType, double[] values)
        {
            if (string.IsNullOrEmpty(figureType))
                throw new ArgumentException(FigureTypeIsEmptyExMessage);
            if (values == null || !values.Any())
                throw new ArgumentException(AreaValuesIsEmptyExMessage);
            return true;
        }

        private static Figure CreateFigure(string figureType, double[] values) =>
            figureType.ToLower() switch
            {
                "circle" => new Circle(values),
                "triangle" => new Triangle(values),
                //
                // TODO: New Figure's type place HERE!
                //
                _ => throw new ArgumentException(UnknownFigureTypeExMessage)
            };
    }
}
