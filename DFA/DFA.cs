using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DFA
{
    class DFA
    {
        private char[] States;
        private char[] FinalStates;
        private char StartState { get; }
        private char[,] Table;
        //alfabet={0,1}
        public DFA()
        {
            States = new char[] { 'A', 'B', 'C', 'D','E' };
            FinalStates = new char[] { 'E' };
            StartState = 'A';
            InitTable(@"../../table.txt");
            
        }
        private void InitTable(string path)
        {
            Table = new char[2, 5];
            TextReader tr = new StreamReader(path);
            string buffer;
            string[] elems;
            int row = 0;
            while ((buffer=tr.ReadLine())!=null)
            {
                //Console.WriteLine(buffer);
                elems=buffer.Split(' ');
                for (int col = 0; col < elems.Length; col++)
                {
                    //Console.Write(elems[col]);
                    Table[row, col] = char.Parse(elems[col]);
                    //Console.Write(Table[row, col] + " ");
                }
                //Console.WriteLine();
                row++;
            }
        }
        public bool CheckWord(string word)
        {
            char CurrentState = StartState;
            for (int i = 0; i < word.Length; i++)
            {
                switch(word[i])
                {
                    case '0':
                        CurrentState = Table[0, CurrentState - 65];
                        break;
                    case '1':
                        CurrentState = Table[1, CurrentState - 65];
                        break;
                    default:
                        Console.WriteLine("Wrong letters! (Only 0 or 1)");
                        return false;
                }
                
            }
            foreach (int State in FinalStates)
                if (CurrentState == State)
                    return true;
            return false;
        }
    }
}
