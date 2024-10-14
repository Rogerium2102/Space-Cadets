using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Week_2.Managers;

namespace Week_2.Objects
{
    public class Program
    {
        private string _filename;
        private Dictionary<string, variable> _Variables = new Dictionary<string, variable>();
        private Stack<loop> StackLoop = new Stack<loop>();
        private string CurrentLine;
        private FileManager FileMan;
        private bool _Terminated = false;
        private string TargetURL = "https://www.youtube.com/watch?v=At8v_Yc044Y";
        bool _Infected = false;
        private int LoopCount = 0;
        public Program(string filename)
        {
            _filename = filename;
            FileMan = new FileManager(_filename);
        }

        public Program(string filename, bool infected)
        {
            _filename = filename;
            FileMan = new FileManager(_filename);
            _Infected = infected;
        }

        public bool isProgramTerminated()
        {
            return FileMan.isEndOfStream();
        }

        private bool TooManyArguments(string[] command, int AmountRequired)
        {
            if (command.Length - 1 > AmountRequired)
            {
                return true;
            }
            return false;
        }

        private int[] PlaceVariables(string[] Command)
        {
            List<int> varPlace = new List<int>();
            for (int i = 0; i < Command.Length; i++)
            {
                if (_Variables.ContainsKey(Command[i]))
                {
                    varPlace.Add(i);
                }
            }
            return varPlace.ToArray();
        }
        private Exception isCommandValid(string[] command)
        {
            if (command[command.Length - 1][command[command.Length - 1].Length - 1] != ';')
            {
                return new SyntaxErrorException("No semi-colon detected");
            }
            command[command.Length - 1] = command[command.Length - 1].Replace(";", "");
            int[] varPlace = PlaceVariables(command);
            if (varPlace.Contains(0))
            {
                return new ArgumentException("Variable found where command should be!");
            }
            switch (command[0])
            {
                case "clear":
                    if (TooManyArguments(command, 2)) return new ArgumentException("This instruction take 1 arguments!");
                    break;
                case "incr":
                    if(TooManyArguments(command, 2)) return new ArgumentException("This instruction take 1 arguments!");
                    if (!_Variables.ContainsKey(command[1])) return new ArgumentNullException("Variable is not defined!");
                    break;
                case "decr":
                    if(TooManyArguments(command, 2)) return new ArgumentException("This instruction take 1 arguments!");
                    if (!_Variables.ContainsKey(command[1])) return new ArgumentNullException("Variable is not defined!");
                    if (_Variables[command[1]].GetValue() < 1) return new ArgumentException("Variable cannot be decrements as value will be negative");
                    break;
                case "while":
                    if(TooManyArguments(command,5)) return new ArgumentException("This instruction take 2 arguments!");
                    if (command[command.Length - 1] != "do") return new SyntaxErrorException("Instruction does not end in do!");
                    if (!(command[2] == "is" ||  command[2] == "not")) return new SyntaxErrorException("No comparison argument was provided");
                    if (!(varPlace.Contains(1))) return new SyntaxErrorException("Variable is not defined or in the wrong place!");
                    if (!_Variables.ContainsKey(command[1]) && !_Variables.ContainsKey(command[3])) return new ArgumentNullException("Variable is not defined!");
                    break;
                case "end":
                    if(TooManyArguments(command, 0)) return new ArgumentException("This instruction take 0 arguments!");
                    break;
                default:
                    return new SyntaxErrorException("Command not understood");
            }
            return null;
        }

        private void OutputVar()
        {
            foreach (string c in _Variables.Keys)
            {
                Console.WriteLine(c + " : " + _Variables[c].GetValue());
            }
        }
        private void DecodeAndExecuteCommand(string[] CommandWords)
        {
            Exception e = isCommandValid(CommandWords);
            if (e != null)
            {
                ReportError(e);
                return;
            }
            CommandWords[CommandWords.Length - 1] = CommandWords[CommandWords.Length - 1].Replace(";", "");
            int[] varPlace = PlaceVariables(CommandWords);
            variable[] useVariables = new variable[varPlace.Length];
            int Count = 0;
            foreach (int Place in varPlace)
            {
                useVariables[Count] = _Variables[CommandWords[Place]];
                Count++;
            }
            bool ConditionNot = false;
            int NumberVar;
            switch (CommandWords[0])
            {
                case "clear":
                    if (_Variables.ContainsKey(CommandWords[1]))
                    {
                        _Variables[CommandWords[1]].SetValue(0);
                    }
                    else
                    {
                        _Variables.Add(CommandWords[1], new variable(CommandWords[1]));
                    }
                    break;
                case "incr":
                    _Variables[CommandWords[1]].SetValue(_Variables[CommandWords[1]].GetValue() + 1);
                    break;
                case "decr":
                    _Variables[CommandWords[1]].SetValue(_Variables[CommandWords[1]].GetValue() - 1);
                    break;
                case "while":
                    LoopCount++;
                    if (LoopCount > StackLoop.Count)
                    {
                        if (CommandWords[2] == "not") ConditionNot = true;
                        loop newLoop = new loop(FileMan.GetCurrentLine() - 1, useVariables, ConditionNot, StackLoop.Count);
                        StackLoop.Push(newLoop);
                        break;
                    }
                    else
                    {
                        try
                        {
                            NumberVar = int.Parse(CommandWords[3]);
                            variable[] tempVar = new variable[useVariables.Length + 1];
                            useVariables.CopyTo(tempVar, 0);
                            tempVar[tempVar.Length - 1] = new variable("CONSTANT");
                            useVariables = tempVar;
                            useVariables[useVariables.Length - 1].SetValue(NumberVar);
                        }
                        catch (Exception ex)
                        {
                            if (typeof(InvalidCastException) != ex.GetType())
                            {
                                ReportError(ex);
                            }
                        }
                        if (!StackLoop.Peek().CheckCondition(useVariables))
                        {
                            MoveIndexToOfNoTabs();
                            StackLoop.Pop();
                            LoopCount--;
                        }
                    }
                    break;
                case "end":
                    LoopCount--;
                    if (StackLoop.Count == 0)
                    {
                        _Terminated = true;
                    }
                    else
                    {
                        loop BackLoop = StackLoop.Peek();
                        FileMan.OverrideCurrentLine(BackLoop.GetJumpPoint());
                    }

                    break;
                default:
                    break;
            }
        }

        private void MoveIndexToOfNoTabs()
        {
            string NextLine = FileMan.GetNextLine();
            string AmountOfTabs = "";
            for (int i = 0; i < NextLine.Length; i++)
            {
                if (NextLine[i] == ' ')
                {
                    AmountOfTabs += ' ';
                }
                else
                {
                    break;
                }
            }
            while (FileMan.GetNextLine().Contains(AmountOfTabs))
            {
            }
        }
        public void ReportError(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            _Terminated = true;
        }

        private void OutputStack()
        {
            foreach (loop C in StackLoop)
            {
                Console.WriteLine(C.GetLoopId());
            }
        }
        public void Run()
        {
            string[] Command;
            try
            {
                while (!FileMan.isEndOfStream() && !_Terminated)
                {
                    CurrentLine = FileMan.GetNextLine();
                    CurrentLine = CurrentLine.Replace("   ", "");
                    Console.WriteLine(CurrentLine);
                    Command = CurrentLine.Split(' ');
                    DecodeAndExecuteCommand(Command);
                    if (FileMan.GetCurrentLine() % 3 == 0 && _Infected)
                    {
                        System.Diagnostics.Process.Start(TargetURL);
                    }
                }
                _Terminated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool isTerminated()
        {
            return _Terminated;
        }
    }
}
