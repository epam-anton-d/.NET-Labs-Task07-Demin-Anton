using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task_7_ErrorsAndLogs
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            List<Folder> folderList = new List<Folder>();
            //List<File> FileList = new List<File>();
            folderList.Add(new Folder("c:", ""));
            string read;
            string pattern = @"mkdir\s[cC]\:(\\[A-Za-z\-_0-9]+)+";
            int error;
            bool match;
            string[] commands;
            
            char[] space = new char[] { ' ' };
            //
            do
            {
                Console.Write((folderList[0].Name) + "\\>");
                read = Console.ReadLine();
                read = read.Trim();
                match = Regex.IsMatch(read, pattern);
                if (match)
                {
                    commands = read.Split(space);
                    error = folderList[0].CreateFolder(commands[1], folderList);
                    if (error == 0)
                    {
                        Console.WriteLine("good job!!!");
                    }
                    else
                    {
                        Console.WriteLine(error);
                    }
                }
                else
                {
                    Console.WriteLine("\"{0}\" не является внутренней или внешней\nкомандой, исполняемой программой или внешним файлом", read);
                }
            } while (read != "exit");
	
            Console.ReadKey();
        }
    }
}
