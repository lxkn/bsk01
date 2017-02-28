using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesar
{
    class Program
    {
        
        char[] tabChar;
        string alfabet = "ABCDEFGHIJKLMNOPRSTWXYZ";
        static void Main(string[] args)
        {
            string zdanie = "aaaaa";
            Program pr;
            pr = new Program();
            string wynik;
            char z = 'a';
            wynik =pr.Kodowanie(zdanie);
            Console.Write(wynik);
            string zad2 = "";
            zad2 = pr.Kodowanie2();
            Console.WriteLine(zad2);
            Console.ReadKey();
        }
        private string Kodowanie(string c)
        {
            string wyn="";
            int k = 1;
            for(int i = 0; i < 5; i++)
            {
               // alfabet[i] == Convert.ToChar((c[i] + k));
               //alfabet.((c[i]+k)%3)
                
               
            }
            return wyn;
        }
        private string Kodowanie2()
        {
            string klucz1 = "pies";
            string klucz2 = "ala";
            //char[] a = new char[klucz2.Length];
            string a="";
            int j=0;
            for(int i = 0; i<klucz2.Length; i++)
            {
                //Console.WriteLine("j: " + j);
                if(klucz2.Length<klucz1.Length)
                {
                    klucz2 += klucz2[0];
                }
                j =(alfabet.IndexOf(Char.ToUpper(klucz2[i])) + alfabet.IndexOf(Char.ToUpper(klucz1[i%klucz1.Length])));
               // Console.WriteLine("klucz2[i]"+ alfabet.IndexOf(Char.ToUpper(klucz2[i]))+" klucz2[i]]"+ alfabet.IndexOf(Char.ToUpper(klucz1[i % klucz1.Length])));
                a += alfabet[j];
            }
            return a;
        }
    }
}
