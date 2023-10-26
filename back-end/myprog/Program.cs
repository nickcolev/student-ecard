using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace student
{
    internal class student
    {
        static void Main(string[] args)
        {
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
                    if (line == null)
                        err_response("out of range");
                    else
                    {
                        // Делим резултата на елементи (CSV)
                        string[] a = line.Split(',');
                        //restPlain(a);
                        restTemplate(a);
                        Environment.Exit(0);
                    }
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
        // REST response
        public static void restPlain(string[] a)
        {
            Console.Write("Content-Type: text/html; charset=cp1251\r\n\r\n");
            Console.WriteLine("<html><head><title>student-ecard</title></head>\n</body>\n");
            Console.WriteLine("<center>");
            Console.WriteLine("<p>ПГМЕТТ \"Хр. Ботев\" Шумен<hr size=1></p>");
            Console.WriteLine("<table><tr><td><img src=\"/img/"+a[1]+".png\"></td><td>" + a[0] + " "+a[2]+"</td></tr></table>");
            Console.WriteLine("</center>");
            Console.WriteLine("\n</body></html>");
        }
        // Alt REST response
        public static void restTemplate(string[] a)
        {
            // HTML template
            string tpl = @"Content-Type: text/html; charset=cp1251

<html><head><title>Student e-card</title>
</head>
<body>
<center>
ПГМЕТТ ""Хр. Ботев"" Шумен<hr size=1>
<table>
<tr>
<td><img src=""/img/{1}.png""></td>
<td>{0}, {2}</td>
</tr>
</table>
</body>
</html>";
            // Форматираме (populate) HTML изход (REST)
            string htm = String.Format(tpl, a[0], a[1], a[2]);
            // Връщаме HTML на клиента
            Console.WriteLine(htm);
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
