using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars2012
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //4. feladat
            List<Versenyzo> list = new List<Versenyzo>();
            StreamReader sr = new StreamReader("Source\\Selejtezo2012.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                list.Add(new Versenyzo(sr.ReadLine()));
            }
            sr.Close();
            //5.feladat
            Console.WriteLine($"5. feladat: Versenyzők száma a selejtezőben: {list.Count}");

            //6. feladat
            Console.WriteLine($"6. feladat: 78,00 méter feletti eredménnyel továbbjutott: {list.Count(x => x.Results.Contains(-2.0))} fő");

            //9.
            Versenyzo best = list.OrderByDescending(x => x.Result).First();
            string row = "";
            foreach (var item in best.Results)
            {
                if (item == -1)
                {
                    row += $"X;";
                }
                else if (item == -2)
                {
                    row += $"-;";
                }
                else
                    row += $"{item};";
            }
            Console.WriteLine($"9. feladat: A selejtező nyertese:\r\n" +
                $"\tNév: {best.Name}\r\n" +
                $"\tCsoport: {best.Group}\r\n" +
                $"\tNemzet: {best.Country}\r\n" +
                $"\tNemzeti kód: {best.CountryCode}\r\n" +
                $"\tSorozat: {row.Substring(0, row.Length-1)}\r\n" +
                $"\tEredmény: {best.Result}\r\n");

            //11.
            StreamWriter sw = new StreamWriter("Dontos2012.txt");
            sw.WriteLine("Helyezés;Név;Csoport;Nemzet;NemzetKód;Sorozat;Eredmény");
            List<Versenyzo> ordered = list.OrderByDescending(x => x.Result).ToList();

            for (int i = 0; i < 12; i++)
            {
                row = "";
                foreach (var item in ordered[i].Results)
                {
                    if (item == -1)
                    {
                        row += $"X;";
                    }
                    else if (item == -2)
                    {
                        row += $"-;";
                    }
                    else
                        row += $"{item};";
                }
                sw.WriteLine($"{i + 1};{ordered[i].Name};{ordered[i].Group};{ordered[i].Country};{ordered[i].CountryCode};{row}{ordered[i].Result}");
            }
            sw.Close();
        }
    }
}