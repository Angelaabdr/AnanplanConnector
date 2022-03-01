using System;

namespace Hello_World
{
    class Program
    {
        static void Main(string[] args)
        {
          
            IBuilder Task1 = new Builder(); 
 
            string path = "C:\\Users\\aabdrashitova\\Documents\\Actions"; 
            //string pathofActions = $"/home/anzhela/helloworld/{actionId}"; 
            Console.WriteLine("Если хотите записать данные в файл введите - f, вывести в консоль - c, оба случая - both");
            string symb = Console.ReadLine();
            

            if (symb == "f") 
                Task1.BuildForFile(path); 
            
            if (symb == "c") 
                Task1.BuildForConsole(path); 

            if (symb == "both") 
                Task1.BuildForConsoleandFile(path); 
        
        
 

        }
    }
}
