using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathParserNetTest
{
    [TestClass]
    public class ParserTests
    {
        private MathParserNet.Parser parser;

        [TestInitialize]
        public void Setup()
        {
            parser = new MathParserNet.Parser();
        }

        [TestMethod]
        public void Simplify_Addition_ReturnsInteger()
        {
            var retval = parser.Simplify("1 + 2");
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Integer, retval.ReturnType, "Return Type should be an Integer");
            Assert.AreEqual(3, retval.IntValue, "Return Value should be 3");
            Assert.AreEqual("1 + 2", retval.OriginalEquation, "Original Equation should be \"1 + 2\"");
            Assert.AreEqual("3", retval.ToFraction(), "Fraction should be 3");
            Assert.AreEqual("3", retval.ToFraction("z"), "Fraction should be 3");
        }

        [TestMethod]
        public void Simplify_Division_ReturnsFloatAndFractions()
        {
            var retval = parser.Simplify("3.8912 / 93.7543");
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Float, retval.ReturnType, "Return Type should be a Float");
            Assert.AreEqual(0.0415042296726657m, (decimal)retval.DoubleValue, "Return Value should be 0.0415042296726657");
            Assert.AreEqual("3.8912 / 93.7543", retval.OriginalEquation, "Original Equation should be \"3.8912 / 93.7543\"");
            Assert.AreEqual("3822/92087", retval.ToFraction(), "Fraction should be 3822/92087");
            Assert.AreEqual("1/24", retval.ToFraction("/", 100), "Fraction should be 1/24");
            Assert.AreEqual("32/771", retval.ToFraction("/", 1000), "Fraction should be 32/771");
            Assert.AreEqual("181/4361", retval.ToFraction("/", 10000), "Fraction should be 181/4361");
            Assert.AreEqual("3822-92087", retval.ToFraction("-"), "Fraction should be 3822-92087");
            Assert.AreEqual("1-24", retval.ToFraction("-", 100), "Fraction should be 1-24");
            Assert.AreEqual("32-771", retval.ToFraction("-", 1000), "Fraction should be 32-771");
            Assert.AreEqual("181-4361", retval.ToFraction("-", 10000), "Fraction should be 181-4361");
        }

        [TestMethod]
        public void Simplify_ComplexExpression_ReturnsExpectedFloat()
        {
            var retval = parser.Simplify("32 - (7+8) / 3*2-(9%2)");
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Float, retval.ReturnType, "Return Type should be float");
            Assert.IsTrue(Math.Abs(retval.DoubleValue - 21f) < double.Epsilon, "Return Value should be 21");
            Assert.AreEqual("32 - (7+8) / 3*2-(9%2)", retval.OriginalEquation, "Original Equation should be \"32 - (7+8) / 3*2-(9%2)\"");
        }

        [TestMethod]
        public void Simplify_ComplexPowerExpression_ReturnsExpectedFloat()
        {
            var retval = parser.Simplify("(((2^9 / 32) ^ 3) - (16 * 3) * 2 + 7.8 * .16) / .32 * ABS(-7.8) - 1");
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Float, retval.ReturnType, "Return Type should be float");
            Assert.AreEqual(97529.42m, (decimal)retval.DoubleValue, "Return Value should be 97529.42");
            Assert.AreEqual("(((2^9 / 32) ^ 3) - (16 * 3) * 2 + 7.8 * .16) / .32 * ABS(-7.8) - 1", retval.OriginalEquation, "Original Equation should be \"(((2^9 / 32) ^ 3) - (16 * 3) * 2 + 7.8 * .16) / .32 * ABS(-7.8) - 1\"");
        }

        [TestMethod]
        public void Simplify_WithMathFunctions_ReturnsExpectedFloat()
        {
            var retval = parser.Simplify("2/(3 * cos(3.14) + sin(3.14) + tan(3.14) + log(3.14) + logn(3.14) + sqrt(99))");
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Float, retval.ReturnType, "Return Type should be float");
            Assert.AreEqual(0.232800939495159m, (decimal)retval.DoubleValue, "Return Value should be 0.232800939495159");
            Assert.AreEqual("2/(3 * cos(3.14) + sin(3.14) + tan(3.14) + log(3.14) + logn(3.14) + sqrt(99))", retval.OriginalEquation, "Original Equation should be \"2/(3 * cos(3.14) + sin(3.14) + tan(3.14) + log(3.14) + logn(3.14) + sqrt(99))\"");
        }

        [TestMethod]
        public void Simplify_UnknownVariable_ThrowsNoSuchVariableException()
        {
            try
            {
                parser.Simplify("3 * PI + 32");
                Assert.Fail("Error should have occured");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(MathParserNet.Exceptions.NoSuchVariableException), "Expected an Exception of type NoSuchVariableException");
            }
        }

        [TestMethod]
        public void AddVariable_MismatchedParenthesis_ThrowsException()
        {
            parser.AddVariable("PI", 3.14159265);
            parser.AddVariable("x1", "PI / 2");
            parser.AddVariable("x2", "0.73274 * x1");
            try
            {
                parser.AddVariable("x3", "2/(3 * cos(x2) + sin(x2) + tan(x2)");
                Assert.Fail("Error should have occured");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(MathParserNet.Exceptions.MismatchedParenthesisException), "Expected an Exception of type MismatchedParenthesisException");
            }
        }

        [TestMethod]
        public void Simplify_WithVariablesAndFunctions_ReturnsExpectedResults()
        {
            parser.AddVariable("PI", 3.14159265);
            parser.AddVariable("x1", "PI / 2");
            parser.AddVariable("x2", "0.73274 * x1");
            parser.AddVariable("x3", "2/(3 * cos(x2) + sin(x2) + tan(x2))");

            var retval = parser.Simplify("3 * PI + 1 - sqrt(PI)");
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Float, retval.ReturnType, "Return Type should be float");
            Assert.AreEqual(8.652324100107150m, (decimal)retval.DoubleValue, "Return Value should be 8.652324100107150");
            Assert.AreEqual("3 * PI + 1 - sqrt(PI)", retval.OriginalEquation, "Original Equation should be \"3 * PI + 1 - sqrt(PI)\"");
            Assert.AreEqual("8 49666/76137", retval.ToFraction(), "Fraction should be \"8 49666/76137\"");
            Assert.AreEqual("8->2077-->3184", retval.ToFraction("-->", "->", 10000), "Fraction should be \"8->2077-->3184\"");

            retval = parser.Simplify("(17 + x1 / 12) * x2 + x2");
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Float, retval.ReturnType, "Return Type should be float");
            Assert.AreEqual(20.868399008422500m, (decimal)retval.DoubleValue, "Return Value should be 20.868399008422500");

            retval = parser.Simplify("1 + sqrt(x3) / x3 * x2");
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Float, retval.ReturnType, "Return Type should be float");
            Assert.AreEqual(2.70259177490215m, (decimal)retval.DoubleValue, "Return Value should be 2.70259177490215");
        }

        [TestMethod]
        public void Simplify_UnknownFunction_ThrowsNoSuchFunctionException()
        {
            try
            {
                parser.Simplify("funcMyfunc(12,2)");
                Assert.Fail("Error Should have occured");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(MathParserNet.Exceptions.NoSuchFunctionException), "Expected a NoSuchFunctionException");
            }
        }

        [TestMethod]
        public void AddAndRemoveFunction_WorksAsExpected()
        {
            parser.AddVariable("PI", 3.14159265);
            parser.AddVariable("x1", "PI / 2");
            parser.AddVariable("x2", "0.73274 * x1");
            parser.AddVariable("x3", "2/(3 * cos(x2) + sin(x2) + tan(x2))");

            parser.AddFunction("TestFunc1", new MathParserNet.FunctionArgumentList { "p1" }, "p1 - (x3 * p1)");
            parser.AddFunction("TestFunc2", new MathParserNet.FunctionArgumentList { "p2", "p3" }, "7 + funcTestFunc1(p2) / p3");

            var retval = parser.Simplify("funcTestFunc1(17.3821)");
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Float, retval.ReturnType, "Return Type should be float");
            Assert.AreEqual(9.43843839037864m, (decimal)retval.DoubleValue, "Return Value should be 9.43843839037864");

            retval = parser.Simplify("funcTestFunc2(99, 7.3892)");
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Float, retval.ReturnType, "Return Type should be float");
            Assert.AreEqual(14.2750448361325m, (decimal)retval.DoubleValue, "Return Value should be 14.2750448361325");

            parser.RemoveFunction("TestFunc2");

            try
            {
                parser.Simplify("funcTestFunc2(99, 7.3892)");
                Assert.Fail("Error should have occurred");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(MathParserNet.Exceptions.NoSuchFunctionException), "Expected NoSuchFunctionException");
            }
        }

        [TestMethod]
        public void RemoveAllFunctionsAndVariable_ThrowsNoSuchVariableException()
        {
            parser.AddVariable("PI", 3.14159265);
            parser.AddVariable("x1", "PI / 2");
            parser.AddVariable("x2", "0.73274 * x1");
            parser.AddVariable("x3", "2/(3 * cos(x2) + sin(x2) + tan(x2))");

            parser.RemoveAllFunctions();
            parser.RemoveVariable("x3");

            try
            {
                parser.Simplify("1 + sqrt(x3) / x3 * x2");
                Assert.Fail("Error should have occurred");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(MathParserNet.Exceptions.NoSuchVariableException), "Expected NoSuchVariableException");
            }
        }

        [TestMethod]
        public void RegisterCustomIntegerFunction_Works()
        {
            parser.RegisterCustomIntegerFunction("Doubler", Doubler);
            var retval = parser.Simplify("Doubler(15 * 2 + 3)");
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Integer, retval.ReturnType, "Return Type should be Integer");
            Assert.AreEqual(66, retval.IntValue, "Return Value should be 66");
            Assert.AreEqual("Doubler(15 * 2 + 3)", retval.OriginalEquation, "Original Equation should be \"Doubler(15 * 2 + 3)\"");
        }

        [TestMethod]
        public void RegisterCustomDoubleFunction_Works()
        {
            parser.RegisterCustomIntegerFunction("Doubler", Doubler);
            parser.RegisterCustomDoubleFunction("AreaCircle", AreaCircle);
            var retval = parser.Simplify("AreaCircle(Doubler(3.2))");
            // Note that the answer may NOT be what you expect. What is happening
            // is that Doubler was defined as an integer function and therefore,
            // when you double 3.2, you might expect 6.4, but whats happening is that
            // the integer Doubler function is truncating and returning just 6
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Float, retval.ReturnType, "Return Type should be Float");
            Assert.AreEqual(113.097335529233m, (decimal)retval.DoubleValue, "Return Value should be 113.097335529233");
        }

        [TestMethod]
        public void RegisterCustomFunction_ObjectSignature_Works()
        {
            parser.RegisterCustomFunction("GetSlope", GetSlope);
            var retval = parser.Simplify("GetSlope(-1.5, 2.5, 5, -1)");
            Assert.AreEqual(MathParserNet.SimplificationReturnValue.ReturnTypes.Float, retval.ReturnType, "Return Type should be Float");
            Assert.AreEqual(-1.5m, (decimal)retval.DoubleValue, "Return Value should be -1.5");
        }

        // Helper methods
        private static int Doubler(int num) => num * 2;

        private static double AreaCircle(double radius) => Math.PI * (radius * radius);

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

            return (y1 - y2) / (x1 - x2);
        }
    }
}
