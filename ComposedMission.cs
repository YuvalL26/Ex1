using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        private FunctionsContainer.FunctionPtr dictFunc;
        private List<FunctionsContainer.FunctionPtr> funcLizt;
        public event EventHandler<double> OnCalculate;
        public string Name { get; }
        public string Type { get; }

        public ComposedMission(String str)
        {
            funcLizt = new List<FunctionsContainer.FunctionPtr>();
            Name = str;
            Type = "Composed";
        }
        public ComposedMission Add(FunctionsContainer.FunctionPtr add2dict)
        {
            funcLizt.Add(add2dict);
            return this;
        }
        public double Calculate(double value)
        {
            double val = value;
            foreach (var inFunc in funcLizt)
            {
                val = inFunc(val);
            }

            if(OnCalculate != null)
            {
                OnCalculate.Invoke(this, val);
            }
            return val;
        }
    }
}
