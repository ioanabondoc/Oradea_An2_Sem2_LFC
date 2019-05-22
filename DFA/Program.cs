using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This automat checks all the words that contain '1011'");
            while (true)
            {
                Console.Write("Give the word: ");
                string word = Console.ReadLine();
                //Console.WriteLine(word);
                DFA dfa = new DFA();
                Console.WriteLine(dfa.CheckWord(word)); 
            }
        }
    }
}
