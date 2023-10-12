using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myprog
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Environment.SetEnvironmentVariable("QUERY_STRING", "3");
#endif
            string qs = Environment.GetEnvironmentVariable("QUERY_STRING");
            if (qs == null)
            {
                err_response("usage: prog number");
            }
            else
            {
                try
                {
                    int r = int.Parse(qs);
                    string line = GetRowFromTextFile("student.csv", r);
                    // Изпращаме резултат на клиента (Front-End)
                    if( line == null )
                        err_response("out of range");
                    else
                        Console.Write("Content-Type: text/plain\n\n" + line);
                }
                catch (Exception e) { err_response("bad argument"); }
            }
        }
        // Общ метод за връщане на грешка на клиента
        public static void err_response(string msg)
        {
            // CGI изисква да се изпрати Mime-Type
            Console.Write("Content-Type: text/plain\n\n" + msg);
            Environment.Exit(1);
        }
        // Метод за четене на ред от файл
        public static string GetRowFromTextFile(string fileName, int rowNumber)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                for (int i = 1; i < rowNumber; i++)
                {
                    reader.ReadLine();
                }

                return reader.ReadLine();
            }
        }

    }
}
