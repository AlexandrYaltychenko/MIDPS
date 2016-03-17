using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalc.CalcCore
{
    public abstract class Processor
    {
        public static double last = 0;
        public static double mem1 = 0;
        public static double mem2 = 0;
        public static bool v1 = false;
        public static bool v2 = false;
        public static operations curOp = operations.none;
        public static int opCount;
        public enum operations {plus, minus, mult, div, sqrt, pow, inv, none };

        public static double getResult(operations op)
        {
            switch (op)
            {
                case operations.plus: return last = mem1 + mem2;
                case operations.minus: return last = mem1 - mem2;
                case operations.mult: return last = mem1*mem2;
                case operations.div: return last = mem1/mem2;
                case operations.sqrt: return last = Math.Sqrt(mem1);
                case operations.pow: return last = Math.Pow(mem1,mem2);
                case operations.inv: return last = -mem1;
            }
            return 0;
        }

        public static bool setVal(double val)
        {
            if (v1 == false) {
            mem1 = val;
                v1 = true;
                Console.WriteLine("1");
                return false;
            } else 
            {
                mem2 = val;
                Console.WriteLine("2");
                mem1 = getResult(curOp);
                return true;
            }
        }
    }
}
