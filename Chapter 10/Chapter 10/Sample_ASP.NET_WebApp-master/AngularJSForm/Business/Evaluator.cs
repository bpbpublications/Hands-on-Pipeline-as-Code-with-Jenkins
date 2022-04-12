using AngularJSForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSForm.Business
{
    public class Evaluator
    {
        public double Evaluate(CalculatorModel model)
        {
            double result = double.NaN;
            if (model != null && !string.IsNullOrEmpty(model.Operation))
            {
                switch (model.Operation)
                {
                    case "add":
                        result = model.Number1 + model.Number2;
                        break;
                    case "sub":
                        result = model.Number1 - model.Number2;
                        break;
                    case "div":
                        result = model.Number1 / model.Number2;
                        break;
                    case "mult":
                        result = model.Number1 * model.Number2;
                        break;
                }
            }
            return result;
        }
    }
}