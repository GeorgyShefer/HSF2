using System.IO;
using ConsoleApp1;
class DirectoryExtension
{
    public static long dirSize(DirectoryInfo d)
    {
        long size = 0;

        var f = d.GetFiles();

        foreach (var fi in f)
        {
            size += fi.Length;
        }

        DirectoryInfo[] dis = d.GetDirectories();

        foreach (DirectoryInfo di in dis)
        {
            size += dirSize(d);
        }
        return size;
    }
}
class Program
{
    public static void Main()
    {

        DriveInfo[] driveC = DriveInfo.GetDrives();
        foreach (DriveInfo c in driveC.Where(c => c.DriveType == DriveType.Fixed))
        {
            DirectoryInfo dirC = c.RootDirectory;

            WriteFileInfo(dirC);
        }

    }

    public static void WriteFileInfo(DirectoryInfo rootFolders)
    {
        Console.WriteLine("Файлы");
        Console.WriteLine();

        foreach (var folder in rootFolders.GetFiles())
        {
            Console.WriteLine(folder.Name + " " + folder.Length + " байт");
        }
    }

}

