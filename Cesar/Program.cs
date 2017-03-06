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
        int[] tablica;
        int[] tablica3;
        string klucz = "abc";
        string slowo = "ALAMAKOTA"; // slowo wejsciowe
        string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string kodm = "CONVENIENCE";
        int k = 3,cesarn;
        int mck1=6;
        int[] kod;
        static void Main(string[] args)
        {
            Program pr;
            pr = new Program();
            pr.Wypisz();


        }
        private void Wypisz()
        {
            kod = new int[mck1-1];
            kod[0] = 2;
            kod[1] = 3;
            kod[2] = 0;
            kod[3] = 4;
            kod[4] = 1;
            string slowom = "HEREISASECRETMESSAGEENCIPHEREDBYTRANSPOSITION";
            //string slowom = "ABCDEFGHJIKLMNOPRSTUWXYZMVXNYVLKSADAKDAKAKAKKAKA";
            
           
            
            string macierzk1 = kodowanieMacierzowe1(slowo);
            Console.WriteLine("\nMacierzowe 2a\nKodowany: "+macierzk1);
            string macierzdk1 = DekodowanieMacierzowe1(macierzk1);
            Console.WriteLine("Dekodowany: " + macierzdk1);
            string macierzk2 = KodowanieMacierzowe2(kodm, slowom);
            Console.WriteLine("\nMacierzowe 2b\nKodowany: " + macierzk2);
            string macierzdk2 = DekodowanieMacierzowe2(slowom);
            Console.WriteLine("Dekodowany: " + macierzdk2);
            string macierzk3 = KodowanieMacierzowe3(slowom);
            Console.WriteLine("\nMacierzowe 2c\nKodowany: " + macierzk3);
            cesarn = slowo.Length;
            string cesark1 = KodowanieCesar1(slowo);
            Console.WriteLine();
            Console.WriteLine("Cesar\nKodowany: " + cesark1);
            string cesardk1 = DekodowanieCesar1(cesark1);
            Console.Write("Dekodowany: " + cesardk1);
            string cesark2 = KodowanieCesar2(slowo);
            Console.WriteLine();
            Console.WriteLine("\nCesar2\nKodowany: " + cesark2);
            string cesardk2 = DekodowanieCesar2(cesark2);
            Console.Write("Dekodowany: " + cesardk2);
            string viegenerk = KodowanieVigener(slowo);
            Console.WriteLine();
            Console.WriteLine("\nVigener\nKodowany: " + viegenerk);
            string viegenerdk = DekodowanieVigener(viegenerk);
            Console.WriteLine("Dekodowany: " + viegenerdk); 
            Console.ReadKey();
        }
        private string kodowanieMacierzowe1(string key)
        {
            string kodowany = "";
            int n = 5;
            int x = 0;
            int z = 0;
            char[,] tmp = new char[n,n];
            
            int znak = 0;
            for(int i = 0; i < n-1; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (znak++ < key.Length && key!=null)
                    {
                        
                        tmp[i,j] = Char.ToUpper(key[x++]);
                       
                    }
                    else
                    {
                        tmp[i, j] = '\0';
                    }
                    
                }
            }
            /*for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(tmp[i, j]);

                }
                Console.WriteLine();
            }*/
            for (int i =0;i<n-1;i++)
            {
                for(int j=0;j<n;j++)
                {
                    if (z>4)
                    {
                        z = 0;
                    }
                    if (tmp[i, kod[z]] != '\0')
                        kodowany += tmp[i, kod[z++]];
                    else if(tmp[i, kod[z]]=='\0')
                        z++;



                }
            }
            return kodowany;
        }
        private string DekodowanieMacierzowe1(string key)
        {
            string dekodowany = "";
            char[] c = new char[key.Length];
            int n = kod.Length;
            for (int j = 0, i = 0; i < key.Length; j += n)
            {
                if (kod[0] + j < key.Length)
                    c[kod[0] + j] = key[i++];
                if (kod[1] + j < key.Length)
                    c[kod[1] + j] = key[i++];
                if (kod[2] + j < key.Length)
                    c[kod[2] + j] = key[i++];
                if (kod[3] + j < key.Length)
                    c[kod[3] + j] = key[i++];
                if (kod[4] + j < key.Length)
                    c[kod[4] + j] = key[i++];
            }
            dekodowany = new string(c);
            return dekodowany;
        }
        private string KodowanieMacierzowe2(string key, string haslo)
        {
            int n = 5;
            char[,] tmp = new char[n,key.Length];
            tablica = new int[key.Length];
            int pocz2=0;
            int x = 0;
            string kodowany = "";
            int []tablica2 = new int[tablica.Length];
            char[] tmp2 =key.Distinct().ToArray();
            Array.Sort<char>(tmp2);
            for (int i = 0; i < alfabet.Length; i++)
            {
                for (int j = 0; j < key.Length ; j++)
                {
                    if (alfabet[i].ToString() == key[j].ToString())
                    {
                        tablica[j] = pocz2;
                        pocz2++;
                        
                    }
                }
            }
            tablica3 = new int[tablica.Length];
            int v=0;
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica3[tablica[i]] = v++;
            }
           /* for (int i = 0; i < tablica.Length; i++)
                Console.WriteLine(tablica3[i]);
            Console.WriteLine();*/
            int znak = 0;
            for(int i = 0;i < n;i++)
            {
                for(int j=0;j<key.Length;j++)
                {
                    if (znak++ < haslo.Length && haslo!=null)
                        tmp[i, j] = Char.ToUpper(haslo[x++]);
                    else
                        tmp[i, j] = '1';
                }
            }
            int asd = 0;
            int pocz = 0;
            for(int i=0;i<key.Length;i++)
            {
                
                asd = 0;
                for (int j=0; j <key.Length&& asd<n; j++)
                {
                    //Console.WriteLine("asd: " + asd + " tablicza[pocz]" + tablica[pocz]);
                    if (asd < n && tmp[asd, tablica[pocz]] != '1')
                        kodowany += tmp[asd++, tablica3[pocz]];
                    else
                        asd++;
                }
                pocz++;
                

            }

            return kodowany;
        }
        private string DekodowanieMacierzowe2(string key)
        {
            string dekodowany = "";
            int n = 5;
            char[,] tmp = new char[n, key.Length];
            int znak = 0;
            int x = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < kodm.Length; j++)
                {
                    //Console.WriteLine("i: " + i + "j: " + j);
                    if (znak++ < key.Length)
                        tmp[i, j] = Char.ToUpper(key[x++]);
                    else
                    {
                        tmp[i, j] = '1';
                    }
                }
            }
            //Console.WriteLine(key);
            /*for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    Console.Write(tmp[i, j]);

                }
                Console.WriteLine();
            }*/
            int asd=n-1;
            for (int i = 0; i < n; i++)
            {

                /*asd = n - 1;
                for (int j = 0; j < kodm.Length && asd < n; j++)
                {
                    /*Console.WriteLine("asd: " + asd + " tablicza[pocz]" + tablica[pocz]);
                    if (asd >=0 && tmp[asd, tablica[pocz]] != '1')
                        dekodowany += tmp[asd, tablica3[pocz]];
                    else
                        asd--;
                }
                pocz++;
                }*/
                for(int j = 0;j<kodm.Length;j++)
                {
                    if (tmp[i, j] != '1')
                        dekodowany += tmp[i, j];
                }
            }

            return dekodowany;
        }
        private string KodowanieMacierzowe3(string key)
        {
            string kodowany = "";
            int rozmiar = kodm.Length; // rozmiar KLUCZA
            char[,] tmp = new char[rozmiar,rozmiar];
            int x = 0;
            int zero = 0;
            int plus = 0;
            for(int i=0; i<7; i++) // Zapisanie do tablicy dwuwymiarowej
            {
                for(int j = 0; j<key.Length && j<=tablica3[plus]; j++)
                {


                    if (x < rozmiar && zero < key.Length)
                    {
                        tmp[x, j] = key[zero];
                    }
                    zero++;
                   // Console.WriteLine();
                }
                x++;
                plus++;
            }
            /*for (int i = 0; i < rozmiar; i++)
            {
                for (int j = 0; j < rozmiar; j++)
                {
                    Console.Write(tmp[i, j]);
                }
                Console.WriteLine();
            } *///Wypisywanie tablicy dwuwymiarowej!
            int pocz = 0,gora =0;
            int p2=0;
            // Console.WriteLine(tmp[0, 0]);
            /*for (int i = 0; i < tablica3.Length; i++)
                Console.Write(tablica[i]+1 + " ");*/
            for (int i = 0; i < 7; i++)
            {
                gora = 0;
                for (int j = 0; j < key.Length; j++)
                {
                    //Console.WriteLine("asd: " + asd + " tablicza[pocz]" + tablica[pocz]);

                    if (gora < rozmiar - 1 && tmp[gora, tablica[pocz]]!='\0')
                    {
                        //Console.WriteLine(kodm[tablica3[pocz]]);
                        kodowany += tmp[gora++, tablica[pocz]];
                    }
                    else
                        gora++;
                }
                pocz++;
                p2++;


            }

            return kodowany;
        }
        private string DekodowanieMacierzowe3(string key, string haslo)
        {
            string dekodowany = "";

            return dekodowany;
        }
        /*private string KodowanieRail(string tekst,int n)
        {
            string kodowany = "";
            char[] c = new char[tekst.Length];
            int k = 0;
            for (int poziom = 0; poziom <= n; poziom++)
            {
                for (int i = 0; i < tekst.Length; i++)
                {
                    if (poziom == 0 && (2 * (n - 1)) * i < tekst.Length)
                    {
                        c[k++] = tekst[(2 * (n - 1)) * i];
                    }
                    if (poziom == n && ((2 * (n - 1)) * i) + (n - 1) < tekst.Length)
                    {
                        c[k++] = tekst[((2 * (n - 1)) * i) + (n - 1)];
                    }
                    if (poziom != 0 && poziom < n - 1 && (2 * (n - 1)) * i - poziom < tekst.Length && i != 0)
                    {
                        c[k++] = tekst[(2 * (n - 1)) * i - poziom];
                    }
                    if (poziom != 0 && poziom < n - 1 && (2 * (n - 1)) * i + poziom < tekst.Length)
                    {
                        c[k++] = tekst[(2 * (n - 1)) * i + poziom];
                    }
                }
            }
                kodowany = new string(c);
                return kodowany;
        }
        public static string DekodowanieRail(string tekst, int n)
        {
            char[] c = new char[tekst.Length];
            int k = 0;
            for (int poziom = 0; poziom <= n; poziom++)
            {
                for (int i = 0; i < tekst.Length; i++)
                {
                    if (poziom == 0 && (2 * (n - 1)) * i < tekst.Length)
                    {
                        //  c[k++] = tekst[(2 * (n - 1)) * i];
                        c[(2 * (n - 1)) * i] = tekst[k++];
                    }
                    if (poziom == n && ((2 * (n - 1)) * i) + (n - 1) < tekst.Length)
                    {
                        //c[k++] = tekst[((2 * (n - 1)) * i) + (n - 1)];
                        c[((2 * (n - 1)) * i) + (n - 1)] = tekst[k++];
                    }
                    if (poziom != 0 && poziom < n - 1 && (2 * (n - 1)) * i - poziom < tekst.Length && i != 0)
                    {
                        //c[k++] = tekst[(2 * (n - 1)) * i - poziom];
                        c[(2 * (n - 1)) * i - poziom] = tekst[k++];
                    }
                    if (poziom != 0 && poziom < n - 1 && (2 * (n - 1)) * i + poziom < tekst.Length)
                    {
                        //c[k++] = tekst[(2 * (n - 1)) * i + poziom];
                        c[(2 * (n - 1)) * i + poziom] = tekst[k++];
                    }
                }
            }


            string s = new string(c);
            return s;
        }*/
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
            int rnd;
            for (int i = 0; i < key.Length; i++)
            {
                rnd = ((i * k0) + k1) % cesarn;
                j = alfabet.IndexOf(Char.ToUpper(key[rnd])) % alfabet.Length;
                kodowany += alfabet[j];

            }
            return kodowany;
        }
        private string DekodowanieCesar2(string key)
        {
            string dekodowany = "";
            int fi = 12;
            int k1 = 17, k0 = 11, j = 0;
            int last;
            for (int i = 0; i < key.Length; i++)
            {
                last = alfabet.IndexOf(key[i]);
                int rnd = 1;
                for (int k = 0; k<fi-1; k++)
                {
                    rnd *= k1;
                    rnd %= alfabet.Length;
                }
                double temp = ((last + (alfabet.Length - k0)) * rnd) % alfabet.Length;
                dekodowany += alfabet[(int)temp];
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
