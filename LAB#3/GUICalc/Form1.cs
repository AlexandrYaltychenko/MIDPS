using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUICalc.CalcCore;

namespace GUICalc
{
    public partial class Form1 : Form
    {
        public static bool prevOp = false;
        public static bool singleOp = false;
        public static bool prevEq = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            field.TextAlign = HorizontalAlignment.Right;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            putNum(0);
        }

        private void putNum(int num)
        {
            if (field.Text.Equals("0") || prevOp || singleOp || prevEq)
                field.Text = "" + num;
            else field.Text = field.Text + num + "";
            prevOp = false;
            singleOp = false;
            prevEq = false;
        }

        private void plus_Click(object sender, EventArgs e)
        {
            prevEq = false;
            double d;
            Double.TryParse(field.Text, out d);
            if (prevOp == false)
            {
                Processor.setVal(d);
                setText("" + Processor.mem1);
            }
            Processor.curOp = Processor.operations.plus;
            prevOp = true;
        }

        private void c_Click(object sender, EventArgs e)
        {
            prevEq = false;
            field.Text = "0";
            prevOp = false;
            Processor.mem1 = Processor.mem2 = 0;
            Processor.v1 = Processor.v2 = false;
            Processor.curOp = Processor.operations.none;
        }

        private void val1_Click(object sender, EventArgs e)
        {
            putNum(1);
        }

        private void val2_Click(object sender, EventArgs e)
        {
            putNum(2);
        }

        private void val3_Click(object sender, EventArgs e)
        {
            putNum(3);
        }

        private void val4_Click(object sender, EventArgs e)
        {
            putNum(4);
        }

        private void val5_Click(object sender, EventArgs e)
        {
            putNum(5);
        }

        private void val6_Click(object sender, EventArgs e)
        {
            putNum(6);
        }

        private void val7_Click(object sender, EventArgs e)
        {
            putNum(7);
        }

        private void val8_Click(object sender, EventArgs e)
        {
            putNum(8);
        }

        private void val9_Click(object sender, EventArgs e)
        {
            putNum(9);
        }

        private void equ_Click(object sender, EventArgs e)
        {
            double d;
            if (prevEq == true)
            {
                Console.WriteLine("SECOND = " + Processor.mem1 + "   " + Processor.mem2);
                Double.TryParse(field.Text, out d);
                Processor.mem1 = d;
                if (Processor.curOp != Processor.operations.none)
                    setText(Processor.getResult(Processor.curOp) + "");
                return;
            }
            Double.TryParse(field.Text, out d);
            Processor.mem2 = d;
            Console.WriteLine("TTT "+Processor.mem1+"   "+Processor.mem2);
            if (Processor.curOp != Processor.operations.none)
            setText(Processor.getResult(Processor.curOp) + "");
            Processor.v1 = Processor.v2 = false;
            prevOp = false;
            prevEq = true;
        }

        private void div_Click(object sender, EventArgs e)
        {
            prevEq = false;
            double d;
            Double.TryParse(field.Text, out d);
            if (prevOp == false)
            {
                Processor.setVal(d);
                setText("" + Processor.mem1);
            }
            Processor.curOp = Processor.operations.div;
            prevOp = true;
        }

        private void mult_Click(object sender, EventArgs e)
        {
            prevEq = false;
            double d;
            Double.TryParse(field.Text, out d);
            if (prevOp == false)
            {
                Processor.setVal(d);
                setText("" + Processor.mem1);
            }
            Processor.curOp = Processor.operations.mult;
            prevOp = true;
        }

        private void minus_Click(object sender, EventArgs e)
        {
            prevEq = false;
            double d;
            Double.TryParse(field.Text, out d);
            if (prevOp == false)
            {
                Processor.setVal(d);
                setText("" + Processor.mem1);
            }
            Processor.curOp = Processor.operations.minus;
            prevOp = true;
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            Console.WriteLine("BC = "+field.Text);
            if (prevEq == false)
                equ.PerformClick();
            Console.WriteLine("AC = " + field.Text);
            singleOp = true;
            prevEq = false;
            Processor.curOp = Processor.operations.sqrt;
            double d;
            Double.TryParse(field.Text, out d);
            Console.WriteLine("PARSED " + d);
            Processor.mem1 = d;
            setText("" + Processor.getResult(Processor.curOp));
            Processor.curOp = Processor.operations.none;
        }

        private void inv_Click(object sender, EventArgs e)
        {
            if (prevEq == false)
            equ.PerformClick();
            singleOp = true;
            prevEq = false;
            Processor.curOp = Processor.operations.inv;
            double d;
            Double.TryParse(field.Text, out d);
            Processor.mem1 = d;
            field.Text = "" + Processor.getResult(Processor.curOp);
            setText("" + Processor.getResult(Processor.curOp));
            Processor.curOp = Processor.operations.none;
        }

        private void pow_Click(object sender, EventArgs e)
        {
            prevEq = false;
            double d;
            Double.TryParse(field.Text, out d);
            if (prevOp == false)
            {
                Processor.setVal(d);
                setText("" + Processor.mem1);
            }
            Processor.curOp = Processor.operations.pow;
            prevOp = true;
        }

        private void dot_Click(object sender, EventArgs e)
        {
            prevEq = false;
            if (field.Text.Contains(",")) return;
            if (field.Text.Equals("0") || prevOp)
                setText("0,");
            else setText(field.Text + ",");
            prevOp = false;
        }


        private void setText(String s)
        {
            if (Double.IsNaN(Processor.last))
            {
                field.Text = "Invalid operation";
                Processor.last = 0;
            }
            else if (Double.IsNegativeInfinity(Processor.last) || Double.IsPositiveInfinity(Processor.last))
            {
                field.Text = "Division by zero is not allowed";
                Processor.last = 0;
            }
            else field.Text = s;
            if (field.Text.Contains("-0"))
                field.Text = "0";
        }
    }
}
