using RomanNumerals;

var a = new RomanNumber(500);
var b = new RomanNumber("IV");
var c = new RomanNumber("D");

Console.WriteLine($"a = {a}");
Console.WriteLine($"a = {a.ArabicValue}");

Console.WriteLine($"b = {b}");
Console.WriteLine($"b = {b.ArabicValue}");

Console.WriteLine($"c = {c}");
Console.WriteLine($"c = {c.ArabicValue}");

Console.WriteLine($"a+b = {a + b} or {(a + b).ArabicValue}");
Console.WriteLine($"a-b = {a - b} or {(a - b).ArabicValue}");
Console.WriteLine($"a*b = {a * b} or {(a * b).ArabicValue}");
Console.WriteLine($"a/b = {a / b} or {(a / b).ArabicValue}");
Console.WriteLine($"a==c : {a == c}");
Console.WriteLine($"a!=b : {a != b}");

