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
            Boolean isBold = false;
            Boolean isType = false;
            StreamReader sr = new StreamReader("table.txt");
            StreamWriter sw = new StreamWriter("tabular.txt", false);
            char[] buffer = { '\0' };
            sw.Write("\\centerline{\r\n\t\\begin{tabular*}{0.72\\textwidth}{cccc}\\toprule\r\n\t\t");
            while(sr.Peek() >= 0)
            {
                sr.Read(buffer, 0, 1);
                switch(buffer[0])
                {
                    case '*':
                        if(isBold) {
                            sw.Write("}");
                            isBold = false;
                        } else {
                            isBold = true;
                            sw.Write("\\textbf{");
                        }
                        break;
                    case '`':
                        if(isType) {
                            sw.Write("}");
                            isType = false;
                        } else {
                            isType = true;
                            sw.Write("\\texttt{");
                        }
                        break;
                    case '_':
                        sw.Write("\\_");
                        break;
                    case '%':
                        sw.Write("\\%");
                        break;
                    case '\t':
                        if(isBold) { sw.Write("}\t& \\textbf{"); }
                        else { sw.Write("\t& "); }
                        break;
                    case '\r':
                        if(isBold) { sw.Write("}\\\\\r"); }
                        else { sw.Write("\\\\\r"); }
                        break;
                    case '\n':
                        if(isBold) { sw.Write("\n\t\t\\textbf{"); }
                        else { sw.Write("\n\t\t"); }
                        break;
                    default:
                        sw.Write(buffer[0]);
                        break;
                }
            }
            sw.Write("\\bottomrule\n\t\\end{tabular*}\r\n}\r\n");
            sw.Flush();

        }
    }
}
