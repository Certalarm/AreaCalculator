using AreaCalculatorLib;

AreaCalculator areaCalculator = new AreaCalculator();
var circleArea = areaCalculator.CalcArea("circle", new[] { 10.0 });

var triangleArea = areaCalculator.CalcArea("triangle", new[] { 3.0, 4.0, 5.0 });

var isTriangleRightAngled = areaCalculator.IsTriangleRightAngled(3.0, 4.0, 5.0);

Console.WriteLine($"{nameof(circleArea)} = {circleArea} кв.ед.{Environment.NewLine}");
Console.WriteLine($"{nameof(triangleArea)} = {triangleArea} кв.ед.{Environment.NewLine}");
Console.WriteLine($"{nameof(isTriangleRightAngled)} = {isTriangleRightAngled}");

Console.ReadKey();
