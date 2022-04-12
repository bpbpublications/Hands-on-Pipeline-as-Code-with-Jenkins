using Microsoft.VisualStudio.TestTools.UnitTesting;
using AngularJSForm.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJSForm.Models;

namespace AngularJSForm.Business.Tests
{
    [TestClass]
    public class EvaluatorTests
    {
        [TestMethod]
        public void Test_Evaluate_Validate_Checks_For_NegativeInputs()
        {
            double expected = double.NaN;
            Evaluator evaluator = GetEvaluator();
            CalculatorModel calculatorModel = null;
            double actual = evaluator.Evaluate(calculatorModel);
            Assert.AreEqual(expected, actual);

            calculatorModel =new CalculatorModel();
            calculatorModel.Number1 = 5;
            calculatorModel.Number2 = 7;
            calculatorModel.Operation = "";
            actual = evaluator.Evaluate(calculatorModel);
            Assert.AreEqual(expected, actual);

            calculatorModel.Operation = "mult++";
            actual = evaluator.Evaluate(calculatorModel);
            Assert.AreEqual(expected, actual);

            expected = double.PositiveInfinity;
            calculatorModel.Number1 = double.MaxValue;
            calculatorModel.Number2 = double.MaxValue;
            calculatorModel.Operation = "mult";
            actual = evaluator.Evaluate(calculatorModel);
            Assert.AreEqual(expected, actual);

            calculatorModel.Operation = "add";
            actual = evaluator.Evaluate(calculatorModel);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Test_Evaluate_Addition_ValidInput_Returns_Valid_Result()
        {
            double expected = 12;
            Evaluator evaluator = GetEvaluator();
            CalculatorModel calculatorModel = new CalculatorModel();
            calculatorModel.Number1 = 5;
            calculatorModel.Number2 = 7;
            calculatorModel.Operation = "add";
            double actual = evaluator.Evaluate(calculatorModel);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Test_Evaluate_Substraction_ValidInput_Returns_Valid_Result()
        {
            double expected = -2;
            Evaluator evaluator = GetEvaluator();
            CalculatorModel calculatorModel = new CalculatorModel();
            calculatorModel.Number1 = 5;
            calculatorModel.Number2 = 7;
            calculatorModel.Operation = "sub";
            double actual = evaluator.Evaluate(calculatorModel);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Test_Evaluate_Division_ValidInput_Returns_Valid_Result()
        {
            double expected = 2;
            Evaluator evaluator = GetEvaluator();
            CalculatorModel calculatorModel = new CalculatorModel();
            calculatorModel.Number1 = 14;
            calculatorModel.Number2 = 7;
            calculatorModel.Operation = "div";
            double actual = evaluator.Evaluate(calculatorModel);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Test_Evaluate_Division_DivideByZeroInput_Returns_Valid_Result()
        {
            double expected = double.PositiveInfinity;
            Evaluator evaluator = GetEvaluator();
            CalculatorModel calculatorModel = new CalculatorModel();
            calculatorModel.Number1 = 14;
            calculatorModel.Number2 = 0;
            calculatorModel.Operation = "div";
              double actual = evaluator.Evaluate(calculatorModel);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test_Evaluate_Multiplication_ValidInput_Returns_Valid_Result()
        {
            double expected = 35;
            Evaluator evaluator = GetEvaluator();
            CalculatorModel calculatorModel = new CalculatorModel();
            calculatorModel.Number1 = 5;
            calculatorModel.Number2 = 7;
            calculatorModel.Operation = "mult";
            double actual = evaluator.Evaluate(calculatorModel);
            Assert.AreEqual(expected, actual);
        }
        private Evaluator GetEvaluator()
        {
            Evaluator evaluator = new Evaluator();
            return evaluator;
        }
    }
}