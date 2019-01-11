using System;
using System.Collections.Generic;
namespace BrainfxxkRunner
{
    class Program
    {
        class WhilePair
        {
            public int L;
            public int R;
        }
        static void Main(string[] args)
        {
            int c_OutputID = 0;
            int c_CmdID = 0;
            string mInput = System.IO.File.ReadAllText("command.txt");
            List<WhilePair> whilePairs = new List<WhilePair>();
            List<int> output = new List<int>(new int[] { 0});
            Stack<int> pairsStack = new Stack<int>();
            for (int i = 0; i < mInput.Length; i++)
            {
                if (mInput[i] == '[') pairsStack.Push(i);
                if (mInput[i] == ']') whilePairs.Add(new WhilePair() { L = pairsStack.Pop(), R = i });
            }
            while (c_CmdID < mInput.Length)
            {
                if (mInput[c_CmdID] == '+') { output[c_OutputID]++; c_CmdID++; }
                else if (mInput[c_CmdID] == '-') { output[c_OutputID]--; c_CmdID++; }
                else if (mInput[c_CmdID] == '>') { c_OutputID++; if (output.Count <= c_OutputID) output.Add(0); c_CmdID++; }
                else if (mInput[c_CmdID] == '<') { c_OutputID--; c_OutputID = c_OutputID < 0 ? 0 : c_OutputID; c_CmdID++; }
                else if (mInput[c_CmdID] == '.') { Console.Write((char)output[c_OutputID]); c_CmdID++; }
                else if (mInput[c_CmdID] == ',') { int _in = 0; string _input = Console.ReadLine(); if (int.TryParse(_input, out _in)) output[c_OutputID] = _in; else _in = (int)_input[0]; c_CmdID++; }
                else if (mInput[c_CmdID] == '[') c_CmdID = output[c_OutputID] == 0 ? whilePairs.Find(s => s.L == c_CmdID).R + 1 : c_CmdID + 1;
                else if (mInput[c_CmdID] == ']') c_CmdID = output[c_OutputID] == 0 ? c_CmdID + 1 : whilePairs.Find(s => s.R == c_CmdID).L + 1;
                else c_CmdID++;
            }
            Console.ReadLine();
        }
    }
}