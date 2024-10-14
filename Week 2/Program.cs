using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Week_2.Managers;

namespace Week_2
{
    internal class Program
    {
        static string TargetProgram = "Program2.txt";
        static string[] _instructionSet;
        static FileManager FileMan;
        static List<Objects.Program> _programList;
        static void Main(string[] args)
        {
            _programList = new List<Objects.Program>();
            FileMan = new FileManager("instruction_set.txt");
            _instructionSet = FileMan.ReadAll();
            FileMan.SetFilename(TargetProgram);
            _programList.Add(new Objects.Program(TargetProgram, false));
            Run();
            Console.ReadKey();
        }

        static void Run()
        {
            foreach (Objects.Program program in _programList)
            {
                program.Run();
                Console.WriteLine("Done!");
            }
        }
    }
}
