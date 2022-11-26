using AreaCalculatorLib.Domain.Entities.FigureEntity;
using AreaCalculatorLib.Domain.Entities.FigureEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
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
            return figure == null
                ? 0.0
                : figure.Area();
        }

        private static bool Validate(string figureType, double[] values)
        {
            if (string.IsNullOrEmpty(figureType))
                throw new Exception(FigureTypeIsEmptyExMessage);
            if (values == null || !values.Any())
                throw new Exception(AreaValuesIsEmptyExMessage);
            return true;
        }

        private static Figure CreateFigure(string figureType, double[] values) =>
            figureType.ToLower() switch
            {
                "circle" => new Circle(values),
                "triangle" => new Triangle(values),
                //
                // TODO: New Figure type place HERE!
                //
                _ => null
            };
    }
}
