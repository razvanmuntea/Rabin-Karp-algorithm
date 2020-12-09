using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarpAlgorithm
{
    class Program
    {        
        static void Main(string[] args)
        {
            string myStr = "abc";
            string text = "abcabcahushduaygsduygaabababbcbcbcbcayscvyvauvyavsyudabcusyakndrnivitpopgerkpogkabczzz";
            double[] hashes = new double[text.Length];

            int alphSize = 29;
            int modNR = 7;// some prime number
            double s = 0 ; // the hash we will be searching for
            
            int n = myStr.Length;
            //calculate my text's hash
            for (int i = 0; i < n; i++)
            {
                s += (double)myStr[i] * Math.Pow(alphSize, n - i -1);
            }
            double c = 0; //variable for firstHas from text
            //calculate hash for first char
            for (int i = 0; i < n; i++)
            {
                c += (double)text[i] * Math.Pow(alphSize, n - i - 1);
            }
            hashes[0] = c;
            //calculate hashes
            //explination of algorithm here https://brilliant.org/wiki/rabin-karp-algorithm/
            for (int i = 1; i < text.Length-n; i++) //todo check if edgeCase
            {
                c = ((c - (double)text[i - 1] * Math.Pow(alphSize, n - 1)) * alphSize + (double)text[i + n - 1]);
                hashes[i] = c;
            }
            for (int i = 0; i < text.Length-n; i++)
            {
                if (hashes[i] == s)
                    Console.WriteLine("found string at position " + i);
            }

            Console.WriteLine("-----end------");

        }
    }
}
