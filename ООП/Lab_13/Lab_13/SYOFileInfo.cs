using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab_13
{
    static class SYOFileInfo
    {
        public static void FullPath(string path)                
        {
            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine($"Полный путь к файлу {fileInfo.Name}: {fileInfo.FullName}");
            Console.WriteLine();
            SYOLog.AddSign("SYOFileInfo", fileInfo.Name, $"Полный путь к файлу {fileInfo.Name}: {fileInfo.FullName}");
        }


        public static void BasicFileInfo(string path)             
        {
            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine($"Имя файла: {fileInfo.Name}");
            Console.WriteLine($"Расширение файла: {fileInfo.Extension}");
            Console.WriteLine($"Размер файла: {fileInfo.Length}");
            Console.WriteLine();
            SYOLog.AddSign("SYOFileInfo", fileInfo.Name, $"Имя файла: {fileInfo.Name} \n Расширение файла: {fileInfo.Extension} \n Размер файла: {fileInfo.Length}");
        }


        public static void CreationTime(string path)                
        {
            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine($"Время создания файла {fileInfo.Name}: {fileInfo.CreationTime}");
            Console.WriteLine();
            SYOLog.AddSign("SYOFileInfo", fileInfo.FullName, $"Время создания файла {fileInfo.Name}: {fileInfo.CreationTime}");
        }
    }
}
