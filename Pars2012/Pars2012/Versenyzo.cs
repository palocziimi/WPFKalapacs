using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars2012
{
    internal class Versenyzo
    {
        String name;
        char group;
        String country;
        String countryCode;
        double?[] results;

        public Versenyzo(string line)
        {
            string[] temp = line.Split(';');
            this.name = temp[0];
            this.group = Convert.ToChar(temp[1]);
            this.country = temp[2].Substring(0, temp[2].IndexOf('(')).Trim();
            this.countryCode = temp[2].Substring((temp[2].IndexOf('(')) + 1, (temp[2].IndexOf(')')) - (temp[2].IndexOf('(')) - 1);
            //X => -1; - => null
            double?[] tempDo = new double?[3];
            for (int i = 0; i < tempDo.Length; i++)
            {
                if (temp[i+3] == "X")
                {
                    tempDo[i] = -1;
                }
                else if (temp[i + 3] == "-")
                {
                    tempDo[i] = -2;
                }
                else
                {
                    tempDo[i] = Convert.ToDouble(temp[i + 3]);
                }
            }
            this.results = tempDo;
        }

        public string Name { get => name; }
        public char Group { get => group; }
        public string Country { get => country; }
        public string CountryCode { get => countryCode; }
        public double?[] Results { get => results; }
        public double Result { get => results.Max(x => x.Value); }
    }
}
