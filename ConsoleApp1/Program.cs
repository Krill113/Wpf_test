using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(495 / 100);
            Console.WriteLine(495.01 / 100);
            Console.WriteLine((int)495.01 / 100);
            Console.WriteLine(495 % 100);
            Console.WriteLine(495.01 % 100);
            Console.WriteLine();

            Console.WriteLine($"{(int)495.01 / 100}+{495.01 % 100}");

            string computerName = Environment.UserDomainName;
            Console.WriteLine(computerName);

            string hostName = System.Net.Dns.GetHostName();
            Console.WriteLine("имя устройства (хоста): " + hostName);
            System.Net.Dns.GetHostEntry(hostName);

            //string hostName = System.Net.Dns.GetHostName();
            var hostEntry = System.Net.Dns.GetHostEntry(hostName);
            string fullHostName = hostEntry.HostName;
            Console.WriteLine("Полное имя устройства (хоста): " + fullHostName);

            Console.WriteLine(fullHostName.Substring(fullHostName.IndexOf(".")));

            Console.WriteLine(CheckPUl);
            Console.WriteLine();
            Console.WriteLine();

            //string[] userNames = Environment.GetEnvironmentVariable("ALLUSERS")?.Split(';');

            //foreach (string userName in userNames)
            //    Console.WriteLine(userName);
            string usersFolder = @"C:\Users";
            DirectoryInfo directoryInfo = new DirectoryInfo(usersFolder);

            //foreach (var userDirectory in directoryInfo.GetDirectories())
            //    Console.WriteLine(userDirectory.Name);
            foreach (var u in us)
                Console.WriteLine(u);

            Console.WriteLine();
            Console.WriteLine();

            Console.ReadKey();
        }
        public static bool CheckPUl =>
                        System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).HostName.ToLower().Contains(".project.client.loc");
        private static List<string> us =>
            new DirectoryInfo(@"C:\Users").GetDirectories().Select(d => d.Name).
            Where(userDir => !iskl.Any(exclude => userDir.Equals(exclude, StringComparison.OrdinalIgnoreCase) ||
            userDir.IndexOf(exclude, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();

        private static List<string> iskl = new List<string>()
        {
            "User",
            "Default",
            "Public",
            "Администратор",
            "пользовател",
        };

    }
}
