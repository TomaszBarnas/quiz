using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;


namespace quiz_tworzenie
{
    class Save 
    {
        //zapis do pliku
        public static void save(Quiz tab,List<string> o)
        {
            string filePath = $@"C:\Users\kamil\Desktop\quiz_tworzenie\Quizy\{tab.nazwa}.txt";           
            File.WriteAllLines(filePath, o);
            Console.ReadLine();      
        }
    }
}
