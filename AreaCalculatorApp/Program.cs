using AreaCalculatorLib;

var rn = Environment.NewLine;
AreaCalculator areaCalculator = new();

var reportTriangleRightAngled = TriangleExample(new[] { 3.0, 4.0, 5.0 });
var reportTriangleNonRightAngled = TriangleExample(new[] { 5.0, 6.0, 7.0 });
var reportCircle = CircleExample(7.0);
var report = $"{reportTriangleRightAngled}{rn}{rn}{reportTriangleNonRightAngled}{rn}{rn}{reportCircle}";

Console.WriteLine(report);
Console.ReadKey();

string TriangleExample(double[] values)
{
    var figureType = "triangle";
    var triangleArea = areaCalculator.CalcArea(figureType, values);
    var isTriangleRightAngled = areaCalculator.IsTriangleRightAngled(values[0], values[1], values[2]);
    var reportValues = new string[] 
        { 
            figureType, 
            values[0].ToString(), 
            values[1].ToString(), 
            values[2].ToString(), 
            triangleArea.ToString(), 
            isTriangleRightAngled.ToString()
        };
    return ReportTriangle(reportValues);
}

string ReportTriangle(string[] values) =>
      $"Тип фигуры: {values[0]}" + rn
    + $"длина стороны А: {values[1]} ед." + rn
    + $"длина стороны B: {values[2]} ед." + rn
    + $"длина стороны C: {values[3]} ед." + rn
    + $"площадь фигуры: {values[4]} кв. ед." + rn
    + $"Треугольник прямоугольный: {values[5]}"
    ;

string CircleExample(double radius)
{
    var figureType = "circle";
    var circleArea = areaCalculator.CalcArea(figureType, new[] { radius });
    var reportValues = new string[]
    {
        figureType,
        radius.ToString(),
        circleArea.ToString()
    };
    return ReportCircle(reportValues);
}

string ReportCircle(string[] values) =>
      $"Тип фигуры: {values[0]}" + rn
    + $"радиус: {values[1]} ед." + rn
    + $"площадь фигуры: {values[2]} кв. ед."
    ;
