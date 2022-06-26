using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab_13
{
    static class SYODiskinfo
    {
        public static void FreeSpace(string DriveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.Name == DriveName && drive.IsReady)
                {
                    Console.WriteLine($"Доступный объем на диске {DriveName.First()}: {drive.AvailableFreeSpace / 1073741824} ГБ");
                    SYOLog.AddSign("SYODiskinfo", DriveName, $"Cвободное место на диске: {drive.AvailableFreeSpace / 1073741824} ГБ");
                }
            }
        }

        public static void FileSystem(string DriveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.Name == DriveName && drive.IsReady)
                {
                    Console.WriteLine($"Тип файловой системы и тип диска {DriveName.First()}: {drive.DriveType}, {drive.DriveFormat}");
                    SYOLog.AddSign("SYODiskinfo", DriveName, $"Тип файловой системы и тип диска {DriveName.First()}: {drive.DriveType}, {drive.DriveFormat}");
                }
            }
        }

        public static void DrivesFullInfo()                         ///инфа о каждом доступном диске
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    Console.WriteLine("Имя: {0}", drive.Name);
                    Console.WriteLine("Объем: {0}", drive.TotalSize);
                    Console.WriteLine("Доступный объем: {0}", drive.AvailableFreeSpace);
                    Console.WriteLine("Метка тома: {0}", drive.VolumeLabel);
                    SYOLog.AddSign("SYODiskInfo", drive.Name, $"Имя: {drive.Name} \n Объем: {drive.TotalSize} \n Доступный объем: {drive.AvailableFreeSpace} \n Метка тома: {drive.VolumeLabel}");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
