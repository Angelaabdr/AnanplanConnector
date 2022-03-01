using System;
using System.IO;
namespace Hello_World
{
    public class Client: IAnaplanClient
    { 
 
        public void SetImportFile(string path, byte[] array, int count)
        { 
            string textFromFile = System.Text.Encoding.Default.GetString(array); 
            Console.WriteLine("Текст из чанка №:" + count + " " + textFromFile); 
 
 //Текст из каждого чанка
        }

 
        public void StartAction(string taskId)
        {

            Console.WriteLine("Процесс " + taskId + " начат");
 
 
 
        }

      

    }


    public class ClientForFile: IAnaplanClient
    {

         public void SetImportFile(string path, byte[] array, int count)
        { 
            string textFromFile = System.Text.Encoding.Default.GetString(array); 
            string InfoAboutChunk = $"Текст из чанка {count} ";
            File.AppendAllText($"{path}\\WriteText.txt", InfoAboutChunk);
            File.AppendAllText($"{path}\\WriteText.txt", textFromFile);

 
 //Текст из каждого чанка
        }

         public void StartAction(string taskId)
        {

            Console.WriteLine("Процесс " + taskId + " начат");
 
 
 
        }


    }




}
