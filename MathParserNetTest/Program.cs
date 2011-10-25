using System;
using System.Diagnostics;

namespace MathParserNetTest
{
    class Program
    {
        static string GetLineNumber(ref int ln, int inc)
        {
            ln += inc;

            return ln.ToString();
        }

        static string GetLineNumber(ref int ln)
        {
            return GetLineNumber(ref ln, 1);
        }

        static void Main()
        {
            bool isError = false;
            Exception lastException = null;
            int lineNumber = 24;

            var parser = new MathParserNet.Parser();

            Debug.Assert(parser != null, "parser should NOT be null", "Assertion #1, line " + GetLineNumber(ref lineNumber, 4));

            var retval = parser.Simplify("1 + 2");

            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Integer,
                         "Return Type should be an Integer", "Assertion #2, line " + GetLineNumber(ref lineNumber, 4) + "-" + GetLineNumber(ref lineNumber, 1));
            Debug.Assert(retval.IntValue == 3, "Return Value should be 3", "Assertion #3, line " + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.OriginalEquation == "1 + 2", "Original Equation should be \"1 + 2\"",
                         "Assertion #4, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.ToFraction() == "3", "Fraction should be 3", "Assertion #5, line " + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.ToFraction("z") == "3", "Fraction should be 3", "Assertion #6, line " + GetLineNumber(ref lineNumber));

            retval = parser.Simplify("3.8912 / 93.7543");

            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float,
                         "Return Type should be a Float",
                         "Assertion #7, line " + GetLineNumber(ref lineNumber, 4) + "-" + GetLineNumber(ref lineNumber, 2));
            Debug.Assert((decimal)retval.DoubleValue == 0.0415042296726657m, "Return Value should be 0.0415042296726657", "Assertion #8, line " + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.OriginalEquation == "3.8912 / 93.7543",
                         "Original Equation should be \"3.8912 / 93.7543\"",
                         "Assertion #9, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber, 2));
            Debug.Assert(retval.ToFraction() == "3822/92087", "Fraction should be 3822/92087", "Assertion #10, line " + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.ToFraction("/", 100) == "1/24", "Fraction should be 1/24", "Assertion #11, line " + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.ToFraction("/", 1000) == "32/771", "Fraction should be 32/771", "Assertion #12, line " + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.ToFraction("/", 10000) == "181/4361", "Fraction should be 181/4361", "Assertion #13, line " + GetLineNumber(ref lineNumber));

            Debug.Assert(retval.ToFraction("-") == "3822-92087", "Fraction should be 3822-92087", "Assertion #14, line " + GetLineNumber(ref lineNumber, 2));
            Debug.Assert(retval.ToFraction("-", 100) == "1-24", "Fraction should be 1-24", "Assertion #15, line " + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.ToFraction("-", 1000) == "32-771", "Fraction should be 32-771", "Assertion #16, line " + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.ToFraction("-", 10000) == "181-4361", "Fraction should be 181-4361", "Assertion #17, line " + GetLineNumber(ref lineNumber));

            retval = parser.Simplify("32 - (7+8) / 3*2-(9%2)");

            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float,
                         "Return Type should be float", "Assertion #18, line " + GetLineNumber(ref lineNumber, 4) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert(Math.Abs(retval.DoubleValue - 21f) < double.Epsilon, "Return Value should be 21", "Assertion #19, line " + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.OriginalEquation == "32 - (7+8) / 3*2-(9%2)",
                         "Original Equation should be \"32 - (7+8) / 3*2-(9%2)\"",
                         "Assertion #20, line  " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber, 2));

            retval = parser.Simplify("(((2^9 / 32) ^ 3) - (16 * 3) * 2 + 7.8 * .16) / .32 * ABS(-7.8) - 1");

            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float,
                         "Return Type should be float", "Assertion #21, line " + GetLineNumber(ref lineNumber, 4) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert((decimal)retval.DoubleValue == 97529.42m,
                "Return Value should be 97529.42", "Assertion #22, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert(
                retval.OriginalEquation == "(((2^9 / 32) ^ 3) - (16 * 3) * 2 + 7.8 * .16) / .32 * ABS(-7.8) - 1",
                "Original Equation should be \"(((2^9 / 32) ^ 3) - (16 * 3) * 2 + 7.8 * .16) / .32 * ABS(-7.8) - 1\"",
                "Assertion #23, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber, 3));

            retval = parser.Simplify("2/(3 * cos(3.14) + sin(3.14) + tan(3.14) + log(3.14) + logn(3.14) + sqrt(99))");

            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float,
                         "Return Type should be float", "Assertion #24, line " + GetLineNumber(ref lineNumber, 4) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert((decimal)retval.DoubleValue == 0.232800939495159m, "Return Value should be 0.232800939495159",
                         "Assertion #25, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.OriginalEquation == "2/(3 * cos(3.14) + sin(3.14) + tan(3.14) + log(3.14) + logn(3.14) + sqrt(99))",
                "Original Equation should be \"2/(3 * cos(3.14) + sin(3.14) + tan(3.14) + log(3.14) + logn(3.14) + sqrt(99))\"",
                "Assertion #26, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber, 2));

            try
            {
                parser.Simplify("3 * PI + 32");
            }
            catch (Exception ex)
            {
                lastException = ex;
                isError = true;
            }

            Debug.Assert(isError, "Error should have occured", "Assertion #27, line " + GetLineNumber(ref lineNumber, 12));
            Debug.Assert(lastException is MathParserNet.Exceptions.NoSuchVariableException,
                         "Expected an Exception of type NoSuchVariableException", "Exception #28, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));

            lastException = null;
            isError = false;

            parser.AddVariable("PI", 3.14159265);
            parser.AddVariable("x1", "PI / 2");
            parser.AddVariable("x2", "0.73274 * x1");
            try
            {
                parser.AddVariable("x3", "2/(3 * cos(x2) + sin(x2) + tan(x2)");
            }
            catch (Exception ex)
            {
                lastException = ex;
                isError = true;
            }

            Debug.Assert(isError, "Error should have occured", "Assertion #29, line " + GetLineNumber(ref lineNumber, 18));
            Debug.Assert(lastException is MathParserNet.Exceptions.MismatchedParenthesisException,
                         "Expected an Exception of type MismatchedParenthesisException", "Exception #30, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));

            lastException = null;
            isError = false;

            parser.AddVariable("x3", "2/(3 * cos(x2) + sin(x2) + tan(x2))");

            retval = parser.Simplify("3 * PI + 1 - sqrt(PI)");

            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float,
                "Return Type should be float", "Assertion #31, line " + GetLineNumber(ref lineNumber, 9) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert((decimal)retval.DoubleValue == 8.652324100107150m, "Return Value should be 8.652324100107150",
                         "Exception #32, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.OriginalEquation == "3 * PI + 1 - sqrt(PI)",
                         "Original Equation should be \"3 * PI + 1 - sqrt(PI)\"",
                         "Exception #33, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber, 2));
            Debug.Assert(retval.ToFraction() == "8 49666/76137", "Fraction should be \"8 49666/76137\"",
                         "Exception #34, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.ToFraction("-->", "->", 10000) == "8->2077-->3184", "Fraction should be \"8->2077-->3184\"",
                         "Exception #35, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));

            retval = parser.Simplify("(17 + x1 / 12) * x2 + x2");

            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float,
                "Return Type should be float", "Assertion #36, line " + GetLineNumber(ref lineNumber, 4) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert((decimal)retval.DoubleValue == 20.868399008422500m, "Return Value should be 20.868399008422500",
                         "Exception #37, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));

            retval = parser.Simplify("1 + sqrt(x3) / x3 * x2");

            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float,
              "Return Type should be float", "Assertion #38, line " + GetLineNumber(ref lineNumber, 4) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert((decimal)retval.DoubleValue == 2.70259177490216m, "Return Value should be 2.70259177490216",
                         "Exception #39, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));

            try
            {
                parser.Simplify("funcMyfunc(12,2)");
            }
            catch (Exception ex)
            {
                lastException = ex;
                isError = true;
            }

            Debug.Assert(isError, "Error Should have occured", "Assertion #40, line " + GetLineNumber(ref lineNumber, 14));
            Debug.Assert(lastException is MathParserNet.Exceptions.NoSuchFunctionException,
                         "Expected a NoSuchFunctionException",
                         "Exception #41, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber, 2));

            parser.AddFunction("TestFunc1", new MathParserNet.FunctionArgumentList { "p1" }, "p1 - (x3 * p1)");
            parser.AddFunction("TestFunc2", new MathParserNet.FunctionArgumentList { "p2", "p3" }, "7 + funcTestFunc1(p2) / p3");

            retval = parser.Simplify("funcTestFunc1(17.3821)");

            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float,
                    "Return Type should be float", "Assertion #42, line " + GetLineNumber(ref lineNumber, 5) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert((decimal)retval.DoubleValue == 9.43843839037866m, "Return Value should be 9.43843839037866",
                         "Exception #43, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));

            retval = parser.Simplify("funcTestFunc2(99, 7.3892)");

            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float,
                  "Return Type should be float", "Assertion #44, line " + GetLineNumber(ref lineNumber, 4) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert((decimal)retval.DoubleValue == 14.2750448361325m, "Return Value should be 14.2750448361325",
                         "Exception #45, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));

            parser.RemoveFunction("TestFunc2");

            lastException = null;
            isError = false;

            try
            {
                parser.Simplify("funcTestFunc2(99, 7.3892)");
            }
            catch (Exception ex)
            {
                lastException = ex;
                isError = true;
            }

            Debug.Assert(isError, "Error should have occurred",
                         "Assertion #46, line " + GetLineNumber(ref lineNumber, 17) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert(lastException is MathParserNet.Exceptions.NoSuchFunctionException,
                         "Expected NoSuchFunctionException", "Exception #47, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));

            parser.RemoveAllFunctions();
            parser.RemoveVariable("x3");

            lastException = null;
            isError = false;

            try
            {
                parser.Simplify("1 + sqrt(x3) / x3 * x2");
            }
            catch (Exception ex)
            {
                lastException = ex;
                isError = true;
            }

            Debug.Assert(isError, "Error should have occurred",
                        "Assertion #48, line " + GetLineNumber(ref lineNumber, 18) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert(lastException is MathParserNet.Exceptions.NoSuchVariableException,
                         "Expected NoSuchVariableException", "Exception #49, line " + GetLineNumber(ref lineNumber) + "-" + GetLineNumber(ref lineNumber));

            parser.RegisterCustomIntegerFunction("Doubler", Doubler);

            retval = parser.Simplify("Doubler(15 * 2 + 3)");

            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Integer,
                         "Return Type should be Integer", "Assertion #50, line " + GetLineNumber(ref lineNumber, 6) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.IntValue == 66, "Return Value should be 66", "Assertion #51, line " + GetLineNumber(ref lineNumber));
            Debug.Assert(retval.OriginalEquation == "Doubler(15 * 2 + 3)", "Original Equation should be \"Doubler(15 * 2 + 3)\"", "Assertion #52, line " + GetLineNumber(ref lineNumber));

            parser.RegisterCustomDoubleFunction("AreaCircle", AreaCircle);

            retval = parser.Simplify("AreaCircle(Doubler(3.2))"); // Note that the answer may NOT be what you expect. What is happening
                                                                  // is that Doubler was defined as an integer function and therefore,
                                                                  // when you double 3.2, you might expect 6.4, but whats happening is that
                                                                  // the integer Doubler function is truncating and returning just 6
            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float,
                         "Return Type should be Float", "Assertion #53, line " + GetLineNumber(ref lineNumber, 8) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert((decimal)retval.DoubleValue == 113.097335529233m, "Return Value should be 113.097335529233", "Assertion #54, line "+GetLineNumber(ref lineNumber));

            parser.RegisterCustomFunction("GetSlope", GetSlope);

            retval = parser.Simplify("GetSlope(-1.5, 2.5, 5, -1)");

            Debug.Assert(retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float,
                         "Return Type should be Float", "Assertion #55, line " + GetLineNumber(ref lineNumber, 6) + "-" + GetLineNumber(ref lineNumber));
            Debug.Assert((decimal) retval.DoubleValue == -1.5m, "Return Value should be -1.5", "Assertion #56, line " + GetLineNumber(ref lineNumber));

            Console.WriteLine(@"If there are no other messages on the screen, then ALL tests seem to be okay!");
        }

        private static int Doubler(int num)
        {
            return num * 2;
        }

        private static double AreaCircle(double radius)
        {
            return Math.PI * (radius * radius);
        }

        private static object GetSlope(object objx1, object objx2, object objy1, object objy2)
        {
            var vx1 = (MathParserNet.SimplificationReturnValue)objx1;
            var vx2 = (MathParserNet.SimplificationReturnValue)objx2;
            var vy1 = (MathParserNet.SimplificationReturnValue)objy1;
            var vy2 = (MathParserNet.SimplificationReturnValue)objy2;

            double x1 = vx1.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float ? vx1.DoubleValue : vx1.IntValue;
            double x2 = vx2.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float ? vx2.DoubleValue : vx2.IntValue;
            double y1 = vy1.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float ? vy1.DoubleValue : vy1.IntValue;
            double y2 = vy2.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float ? vy2.DoubleValue : vy2.IntValue;

            return (y1 - y2)/(x1 - x2);
        }
    }
}
