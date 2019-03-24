using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        private FunctionsContainer.FunctionPtr calc;
        public string Name { get; }
        public string Type { get; }

        public SingleMission(FunctionsContainer.FunctionPtr func, String str)
        {
            calc = func;
            Name = str;
            Type = "Single";
        }
        

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            double val2calc = calc(value);
            if (OnCalculate != null)
            {
                OnCalculate.Invoke(this, val2calc);
            }
            return val2calc;
        }
    }
}
