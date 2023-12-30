using System.Data;

namespace Lab1Bychko.Lab1.DomainModel
{
    internal class EvaluatingSystem
    {

        // Evaluates current expression
        public string EvaluateExpression(string inp)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            var _expression = inp.Split(' ');
            if (_expression[1] == "/" && _expression[2] == "0")
                throw new Exception("Error Division by 0");

            // Due to my specific way of computing expressions
            // I need this conditional operator, cause if
            // values are bigger than INT32, this dumb way of
            // evaluating number can not compute this expressions
            // as decimal
            if (!_expression[0].Contains("."))
                _expression[0] += ".";

            DataTable dt = new DataTable();
            var v = dt.Compute($"{_expression[0]} {_expression[1]} {_expression[2]}", "");

            if (v == null)
                throw new Exception("Expression is null");

            v = Convert.ToDecimal(v);


            if (v.GetType() != decimal.One.GetType())
                throw new Exception("Something wrong with inut string");

            return Convert.ToString(v);
        }

        // Evaluates 1/x
        public string EvaluateFraction(string number)
        {
            if (number != "0")
                return Convert.ToString(1 / Convert.ToDecimal(number));
            else
                throw new Exception("Error Division by 0");
        }

        // Evaluates x^2
        public string Square(string number)
        {
            return
                Convert.ToString(
                    Math.Pow(
                        Convert.ToDouble(number), 2));
        }

        // Evaluates sqrt(x)
        public string Sqrt(string number)
        {
            var num = Convert.ToDouble(number);
            if (num >= 0)
                return Convert.ToString(Math.Sqrt(num));
            else
                throw new Exception("Error negative number");
        }

        // Evaluates number * (-1)
        public string Negate(string number)
        {
            return Convert.ToString(Convert.ToDecimal(number) * -1);
        }

        // Evaluates percent
        public string EvaluatrPercent(string number)
        {
            return Convert.ToString(Convert.ToDecimal(number) / 100);
        }

        public string Task(string number)
        {
            return Convert.ToString(Convert.ToDecimal(Math.Pow(10, Convert.ToDouble(number))));
        }
    }
}
