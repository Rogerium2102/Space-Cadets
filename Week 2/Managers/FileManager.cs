using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2.Managers
{
    public class FileManager
    {
        private string _filename;
        private string[] lines;
        private int CurrentLine = 0;

        public FileManager(string filename)
        {
            _filename = filename;
            LoadFile();
        }

        private void LoadFile()
        {
            List<string> LineList = new List<string>();
            using (StreamReader SR = new StreamReader(_filename))
            {
                while (!SR.EndOfStream)
                {
                    LineList.Add(SR.ReadLine());
                }
            }
            lines = LineList.ToArray();
        }

        public string GetNextLine()
        {
            if (CurrentLine < lines.Length)
            {
                CurrentLine++;
                return lines[CurrentLine - 1];
            }
            else
            {
                return "";
            }
        }

        public bool isEndOfStream()
        {
            if (CurrentLine >= lines.Length)
            {
                return true;
            }
            return false;
        }

        public string[] ReadAll()
        {
            return lines;
        }

        public void SetFilename(string filename)
        {
            _filename = filename;
            LoadFile();
        }

        public void OverrideCurrentLine(int line)
        {
            CurrentLine = line;
        }

        public int GetCurrentLine()
        {
            return CurrentLine;
        }
    }
}
