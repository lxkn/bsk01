using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Cesar
{
    class Program
    {

        string klucz = "abc";
        string slowo = "JesteMpsEm"; // slowo wejsciowe
        string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        int k = 3,cesarn;
        static void Main(string[] args)
        {
            Program pr;
            pr = new Program();
            pr.Wypisz();


        }
        private void Wypisz()
        {
            string rail = KodowanieRail(slowo);
            Console.Write("Rail\nKodowany: " + rail);
            /*cesarn = slowo.Length;
            string cesark1 = KodowanieCesar1(slowo);
            Console.WriteLine();
            Console.WriteLine("Cesar\nKodowany: " + cesark1);
            string cesardk1 = DekodowanieCesar1(cesark1);
            Console.Write("\nDekodowany: " + cesardk1);
            /*string cesark2 = KodowanieCesar2(slowo);
            Console.WriteLine();
            Console.WriteLine("Cesar2\nKodowany: " + cesark2);
            string cesardk2 = DekodowanieCesar2(cesark2);
            Console.Write("\nDekodowany: " + cesardk2);
            /*string viegenerk = KodowanieVigener(klucz2);
            Console.WriteLine();
            Console.WriteLine("Vigener\nKodowany: " + viegenerk);
            string viegenerdk = DekodowanieVigener(viegenerk);
            Console.WriteLine("Dekodowany: " + viegenerdk);*/ //na czas innych zakomentowane :)
            Console.ReadKey();
        }
        private string KodowanieRail(string key)
        {
            string kodowany = "";
            int n = 3;
            int x = 2 * (n - 1);
            int z;
            for (int i=0;i<key.Length;i++)
            {
                z = x * i;
                
                for (int j=0;j<n;j++)
                {
                    if (z>key.Length)
                    {
                        i++;
                        z--;
                    }
                    else
                        kodowany += Char.ToUpper(key[z]);

                }
            }
            
            return kodowany;
        }
        private string KodowanieCesar1(string key)
        {
            string kodowany = "";
            int rnd,j;
            for (int i = 0; i < key.Length; i++)
            {
                rnd = (i + k) % cesarn;
                j=alfabet.IndexOf(Char.ToUpper(key[rnd]));
                kodowany += alfabet[j];
            }
            return kodowany;
        }
        private string DekodowanieCesar1(string key)
        {
            string dekodowany = "";
            int rnd , j;
            for (int i = 0; i < key.Length; i++)
            {
                rnd = (i + (cesarn - k)) % cesarn;
                j = (alfabet.IndexOf(Char.ToUpper(key[rnd]))+alfabet.Length)%alfabet.Length;
                dekodowany += alfabet[j];
            }
            return dekodowany;
        }
        private string KodowanieCesar2(string key)
        {
            string kodowany = "";
            int k1 = 3, k0 = 1;
            int j = 0;
            char a;
            int rnd;
            for (int i = 0; i < key.Length; i++)
            {
                //a = Convert.ToChar(((Char.ToUpper(key[i]) * 1 + 3) + alfabet.Length));
                //a = Convert.ToChar((Char.ToUpper(key[i])*1 + 3)%3);
                //Console.WriteLine("a: " + a + "\nj:" + j);
                //j = (alfabet.IndexOf(a))%alfabet.Length;
                rnd = ((i * 1) + 3) % cesarn;
                j = alfabet.IndexOf(Char.ToUpper(key[rnd])) % alfabet.Length;
                kodowany += alfabet[j];

            }
            return kodowany;
        }
        private string DekodowanieCesar2(string key)
        {
            string dekodowany = "";
            int fi = 11;
            int k1 = 3, k0 = 1, j = 0;
            BigInteger rnd;
            int last;
            for (int i = 0; i < key.Length; i++)
            {
                rnd = i + ((cesarn - k0) * k1);
                for(int k = 0; k<=fi; k++)
                {
                   // Console.WriteLine(i + " "+n +" "+rnd);
                    rnd = rnd*rnd;
                }
                last = (int)(rnd % cesarn);

               // Console.WriteLine(last);
                j = (alfabet.IndexOf(Char.ToUpper(key[last])))%alfabet.Length;
                dekodowany += alfabet[j];
            }
            return dekodowany;
        } 
        private string KodowanieVigener(string klucz2)
        {
            
            //char[] a = new char[klucz2.Length];
            string kodowany=""; // zakodowany
            int j=0;
            int x = 0;
            for(int i = 0; i<klucz2.Length; i++)
            {
               // Console.WriteLine("j: " + j);
                while (klucz2.Length >= klucz.Length)
                {
                    klucz += klucz[x++];
                }
                // Console.WriteLine(klucz2[i]+" "+klucz[i]);

                //Console.WriteLine("klucz2[i]" + alfabet.IndexOf(Char.ToUpper(klucz2[i])) + " klucz2[i]]" + alfabet.IndexOf(Char.ToUpper(klucz[i % klucz.Length])));
                j =((alfabet.IndexOf(Char.ToUpper(klucz2[i])) + alfabet.IndexOf(Char.ToUpper(klucz[i%klucz.Length])))+alfabet.Length)%alfabet.Length;
               // Console.WriteLine(j);
                kodowany += alfabet[j];
            }
            return kodowany;
        }
        private string DekodowanieVigener(string zakodowany)
        {
            
            string dekodowany = "";
            int j = 0;
            for(int i = 0; i<zakodowany.Length;i++)
            {
                //Console.WriteLine((((alfabet.IndexOf(Char.ToUpper(zakodowany[i]))) - alfabet.IndexOf(Char.ToUpper(klucz[i]))) + alfabet.Length) % alfabet.Length);
                j = (((alfabet.IndexOf(Char.ToUpper(zakodowany[i]))) - alfabet.IndexOf(Char.ToUpper(klucz[i])))+alfabet.Length)%alfabet.Length;

                dekodowany += alfabet[j];
            }

            return dekodowany;
        }
    }
}
