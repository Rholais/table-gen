using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tabular
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader sr = new StreamReader("table.txt");
			StreamWriter sw = new StreamWriter("tabular.txt",false);
			char[] buffer = {'\0'};
			sw.Write("\\centerline{\r\n\t\\begin{tabular*}{0.72\\textwidth}{cccc}\\toprule\r\n\t\t$ ");
			while(sr.Peek() >= 0)
			{
				sr.Read(buffer, 0, 1);
				switch(buffer[0])
				{
                    case '_':
                        sw.Write("\\_");
                        break;
                    case '%':
                        sw.Write("\\%");
                        break;
                    case '\t':
                        sw.Write("\t& ");
                        break;
                    case '\r':
						sw.Write("\\\\\r");
						break;
					case '\n':
						sw.Write("\n\t\t");
						break;
					default:
						sw.Write(buffer[0]);
						break;
				}
			}
			sw.Write("\b\b\\bottomrule\n\t\\end{tabular*}\r\n}\r\n");
			sw.Flush();

		}
	}
}
