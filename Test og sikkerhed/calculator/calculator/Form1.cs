using System;
using Xunit;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        string input;
        string[] parameters;
        string action;
        int value = 0;
        int first = 0;
        int sec = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            input = calculation.Text;

           label1.Text = Calculate(input);
            
        }
        string Calculate(string input)
        {
            parameters = input.Split(' ');
            first = Convert.ToInt32(parameters[0]);
            sec = Convert.ToInt32(parameters[2]);

            switch (parameters[1])
            {
                case "+":
                    value = first + sec;
                    break;
                case "-":
                    value = first - sec;
                    break;
                case "*":
                    value = first * sec;
                    break;
                case "/":
                    if(sec != 0 || first != 0)
                    {
                        value = first / sec;
                    }
                    else
                    {
                        return "Cannot divide by 0";
                    }
                    break;
                default:
                    value = first + sec;
                    break;
            }

            

            return value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
