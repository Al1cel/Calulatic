using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Model
    {
        public double FirstNumber { get; set; }

        public double SecondNumber { get; set; }

        public string Operator { get; set; }

        public double Calculate()
        {
            return Operator switch
            {
                "+" => FirstNumber + SecondNumber,
                "-" => FirstNumber - SecondNumber,
                "*" => FirstNumber * SecondNumber,

                "/" => SecondNumber != 0 ? FirstNumber / SecondNumber : 0,
                _=> 0,
            };




        }




    }



}
