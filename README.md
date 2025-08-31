> [!NOTE]
> MathParserNet was originally written and published in 2011 by icemanind at https://www.codeproject.com/Articles/274093/Math-Parser-NET
> The following is a copy of the original description

# Introduction

A while back, I wrote an article on CodeProject called [TokenIcer](https://www.codeproject.com/Articles/274093/TokenIcer.aspx). TokenIcer was a program that would automatically create a lexical parser in either C# or VB.NET, based on RegEx rules created in the program.

Since the time that I wrote the article, I have gotten some very good feedback and I wanted to take it a step further. I decided to use TokenIcer to create a mathematical equation parser. That math parser is presented here in this article and it is called Math Parser .NET. It is a .NET Class Library project that can be used with your own programs.
Background

There are several math parsers that exist already. The goal of my math parser is to keep it as simple to use and operate as possible. One of my biggest pet peeves is when a good library goes "bad" because its simplicity gets overshadowed by its own feature list. I feel that my math parser does its job well while keeping the basic functionality and usage simple.
Using the Code

Before I go into how to use the library, I would like to first go through how the internals of the library work. The library itself first consists of a lexical analyzer. The lexical analyzer, I created automatically, by using TokenIcer. The lexical analyzer will take an input string like this:

```
1 + 2 * 3 + (9 / 3) 
```

and convert it into enumerated tokens, like this:

```
{Integer}{WhiteSpace}{Add}{WhiteSpace}{Integer}{WhiteSpace}{Multiply}
  {WhiteSpace}{Integer}{WhiteSpace}{Add}{WhiteSpace}{LParen}
  {Integer}{WhiteSpace}{Divide}{WhiteSpace}{Integer}{RParen}
```

Once there are no more tokens to process, the lexical analyzer will return a null token.

The next job is to create a loop to cycle through each token until the null token is received. The input received by the parser will be in what's called Infix notation. Infix notation means that numbers are separated by mathematical operators. Like the example above, `1` and `2` is separated by a plus sign. `2` and `3` is separated by a multiplication sign. In addition, math operators have a specific order of precedence. In the example above, `9 / 3` should be evaluated first since it is in parenthesis. `2 * 3` should be evaluated secondly since multiplication and division have higher precedence than addition. In order to more easily parse math expressions, I convert the equation from Infix notation to Reverse Polish Notation. In Reverse Polish Notation, or RPN, the math symbols come **after** the numbers. So after the conversion, the example input above would look similar to this:

```
1 2 3 * 9 3 / + +
```

Once the equation is in RPN notation, it is a simple matter of reading it left to right and doing the actual math.

To use the MathNetLib library in your own program, all you have to do is add a reference to the MathNetLib DLL file. After doing that, you need to instantiate a new instance of the `MathNetLib.Parser` class. There are three main methods for solving equations. The first is called `SimplifyInt()`. `SimplifyInt()` will take a mathematical equation, solve it, and return an integer answer. There are two overloads to this method. Here is the first and easiest example:

```C#
static void Main()
{
    MathParserNet.Parser parser = new MathParserNet.Parser();
    int retval;

    try {
        retval = parser.SimplifyInt("3.2 + 7.6");
    } catch (Exception ex) {
        throw ex;
    }
}
```

This example will return a value of 11. The thing to keep in mind about SimplifyInt() is that it will always return an integer answer and by default, it will round the answer. `SimplifyInt()` has an overloaded method signature that will also allow you to specify what you want to do with the fractional part of the answer, if there is one. Here is an example:

```C#
static void Main()
{
    MathParserNet.Parser parser = new MathParserNet.Parser();
    int retval;

    try {
        retval = parser.SimplifyInt("3.2 + 7.6", 
                 MathParserNet.Parser.RoundingMethods.Truncate);
    } catch (Exception ex) {
        throw ex;
    }
}
```

`RoundingMethods` is an enum with the following values and descriptions:

* `Round` -- This is the default. Rounds the fraction to the nearest whole number. If the number after the decimal point is a 5 or higher, it will round the whole number up. If it is 4 or lower, it will round the whole number down.
* `RoundDown` -- This will always round the whole number down regardless of the number after the decimal point.
* `RoundUp` -- This will always round the whole number up regardless of the number after the decimal point.
* `Truncate` -- This will not do any rounding at all and will simply "cut off" the decimal point and any numbers after it.

The second main method for solving equations is called `SimplifyDouble()`. This method, like `SimplifyInt()`, will solve the equation, but will always return a `double` answer. Here is an example of this method in action:

```C#
static void Main()
{
    MathParserNet.Parser parser = new MathParserNet.Parser();
    double retval;

    try {
        retval = parser.SimplifyDouble("3.2 + 7.6");
    } catch (Exception ex) {
        throw ex;
    }
}
```

This would return an answer of 10.8.

The third and final version for solving math equations is called, simply, `Simplify()`. `Simplify()` will solve an equation and then automatically determine if it is an integer or a floating point answer. `Simplify()` returns a `MathParserNet.SimplificationReturnValue` object. You can check the `ReturnType` property of this object to determine if the answer is a floating point or a whole integer number. Here is an example of its use:

```C#
static void Main()
{
    MathParserNet.Parser parser = new MathParserNet.Parser();
    MathParserNet.SimplificationReturnValue retval;

    try {
        retval = parser.Simplify("3.2 + 7.2");
    } catch (Exception ex)
        throw ex;
    }
    if (retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float)
    {
        Console.WriteLine("The answer is a Floating point number!");
        Console.WriteLine(retval.DoubleValue);
    }
    if (retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Integer)
    {
        Console.WriteLine("The answer is an Integer!");
        Console.WriteLine(retval.IntValue);
    }
```

Anytime you use any of the simplify functions, you should always wrap it in a try/catch block. MathParserNet implements five exceptions. Here is a description of each one:

* `MismatchedParenthesisException` -- This exception is thrown if the equation you are trying to solve has more opening parenthesis than closing parenthesis or vice versa.
* `NoSuchFunctionException` -- This exception is thrown if you try to use a function that has not yet been defined. Functions are described below.
* `NoSuchVariableException` -- This exception is thrown if you try to use a variable that has not yet been defined. Variables are described below.
* `VariableAlreadyDefinedException` -- This exception is thrown if you try to define a variable that has already been defined earlier. Variables are described below.
* `CouldNotParseExpressionException` -- This exception is thrown if any other problem arises while trying to parse your expression. Passing an empty equation to any of the simplify functions will cause this exception to be raised.

The parser can parse the following things:

* () -- Parenthesis
* + -- Add symbol (3 + 2)
* - -- Subtract symbol (3 - 2)
* * -- Multiplication symbol (3 * 2)
* / -- Divide symbol (3 / 2)
* % -- Modulus symbol (3 % 2)(divides the two numbers, but returns the remainder)
* ^ -- Exponent symbol (3 ^ 2)(squares 3)
* ABS -- Function returns the absolute of a number (ABS(-3))
* SIN -- Returns the sine of a number (SIN(3.14))
* COS -- Returns the cosine of a number (COS(3.14))
* TAN -- Returns the tangent of a number (TAN(3.14))
* LOG -- Returns the base 10 logarithm of a number
* LOGN -- Returns the natural logarithm of a number
* func<name> -- Calls a user defined function (see Functions below)

# Variables

MathParserNet supports the use of variables. You define a variable in MathParserNet using the AddVariable() method. Here is an example of adding three variables to the parser:

```C#
static void Main()
{
    MathParserNet.Parser parser = new MathParserNet.Parser();

    try {
        parser.AddVariable("PI", 3.14159265);
        parser.AddVariable("Three", 3);
        parser.AddVariable("HalfPI", "PI / 2");

        parser.SimplifyDouble("HalfPI * Three + 7");
    } catch (Exception ex) {
        throw ex;
    }
}
```

Variables are kind of like cut and paste in a word processor. When the parser sees a variable, it looks up the value and replaces the variable name with the actual value. So `HalfPI` actually becomes "3.14159265 / 2" and the equation passed into the `SimplifyDouble()` method actually becomes "3.14159265 / 3 + 7".

Variables that have been defined can also be removed by calling the `RemoveVariable()` method. You simply pass the variable name as an argument to `RemoveVariable()` and the variable gets removed. Keep in mind that any variable that has been defined with a removed variable becomes invalid. For example, in the code above, if I remove the `PI` variable, then the `HalfPI` variable also becomes invalid. In addition, you can also remove **all** variables created by calling the `RemoveAllVariables()` method.

Another thing to keep in mind is that variable names **are** case-sensitive. PI is different from Pi or pI or pi.

# Functions

In addition to variables, MathParserNet also supports functions. You can define a function to do pretty much anything you want. Here is an example:

```C#
static void Main()
{
    MathParserNet.Parser parser = new MathParserNet.Parser();

    try {
        parser.AddFunction("GetSlope", 
          new MathParserNet.FunctionArgumentList {"x1", "x2", 
          "y1", "y2"}, "(y1-y2)/(x1-x2)");

        parser.SimplifyDouble("3 * funcGetSlope(3.2 * (9/3), 4.5, 6, 9.2)");
    } catch (Exception ex) {
        throw ex;
    }
}
```

This example creates a function called `GetSlope`. The function takes four parameters (x1,x2,y1,y2). Functions must take at least one parameter and can be defined to take as many as you want. Keep in mind though that function parameter names can **not** have the same name as a defined variable. To call a function, you must prefix the function name with "func" (without quotes, of course). Another thing to keep in mind is that, like variables, functions are also case-sensitive (as is the "func" prefix).

Functions, just like variables, can similarly be undefined by calling the `RemoveFunction()` method. As with variables, you simply pass the function name in as a parameter of `RemoveFunction()`. In addition, you can remove **all** functions created by calling the `RemoveAllFunctions()` method.

# Delegate Functions

Perhaps the coolest, and arguably, the most handy feature of MathParserNet is the ability to create your own custom function in any .NET language and use it as a custom function in the math parser. Here is an example that shows our `GetSlope` function as a delegate function:

```C#
static void Main()
{
    MathParserNet.Parser parser = new MathParserNet.Parser();
    int myDouble;
    double area;
    double slope;

    try {
        parser.RegisterCustomFunction("GetSlope", GetSlope);
        parser.RegisterCustomFunction("Doubler", Doubler);
        parser.RegisterCustomFunction("AreaCircle", AreaCircle);

        area = parser.SimplifyInt("AreaCircle(3.7)");
        myDouble = parser.SimplifyDouble("Doubler(7)");
        slope = parser.SimplifyDouble("GetSlope(-3.2, 12, 8, 13)");
    } catch (Exception ex) {
        throw ex;
    }
}

static int Doubler(int num)
{
    return num * 2;
}

static double AreaCircle(double radius)
{
    return Math.PI * (radius * radius);
}

static double GetSlope(double x1,double x2,double y1, double y2)
{
    return (y1-y2)/(x1-x2);
}
```

Delegate functions can have up to 4 parameters. The return type **must** also be the same as the parameters and the parameters must all be of the same type. The parameters can be `int`, `double`, or `object`. Integer and double types are self-explanatory. If you declare `object` type parameters, then the objects will be of type `MathParserNet.SimplificationReturnValue`. This way your function can take both integer and double parameters. In addition, your return type must be `object`, but that object can be either integer or double. The math parser will take care of everything else!

As with variables and functions, delegate functions can be removed by using the `UnregisterCustomFunction()` method. You simply pass the function name as a parameter. In addition, you can remove **all** delegate functions defined by calling the `UnregisterAllCustomFunctions()` method.

# Miscellaneous Methods

There is also a `Reset()` method. By calling this method, the parser will remove **all** variables and **all** functions and **all** delegate functions created. It is like starting with a brand new, freshly instantiated `Parser` class.

One last minor feature to talk about is the `ToFraction()` function. Whenever a function returns a `SimplificationReturnValue`, that object has a method called `ToFraction()` which will convert the returned value into a fraction. For example, if your `SimplificationReturnValue` object had a `DoubleValue` of 0.25, then calling `ToFraction()` would return "1/4". I will leave it up to you to play around with that.

# Extras

I have included a unit test project for testing out the math parsing library. Also, there is a demo Windows Forms project that showcases a lot of the features (if not all) of MathParserNET. If anyone has any questions or feedback, I would always love to hear!

# History

* 10/30/2011 -- Version 1.1 released. This version now throws exceptions instead of returning values, in the case of an error. In addition, delegate methods have been introduced into this version. Also, the SimplifyInt and SimplifyDouble methods have been created. In addition, I have created a true unit testing project for the Math library and a demo application. Thanks for all the feedback and keep it coming guys!
* 10/26/2011 -- Initial version released.