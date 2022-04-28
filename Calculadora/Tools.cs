using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.IO;

namespace Calculadora
{
    public class Tools
    {
        public bool paso1 = false;
        public string arch_intermed = "";
        public string tabsim = "";
        public string object_program = "";
        public string errors = "";
        public bool is_newFile = false;
        public string text = "";
        public string directory = Directory.GetCurrentDirectory();
        public string path = "";
        public bool is_constant;

        public static Tools tools = new Tools();

        public Tools()
        {
            path = directory + "TABSIM.txt";
        }
        /// <summary>
        /// Convierte un String a Entero hexadecimal
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public String StrToIntToHex(String source)
        {
            int num = Int32.Parse(source);
            String hex = num.ToString("X");
            return hex;
        }

        /// <summary>
        /// Quita la H o h en un numero y devuelve su valor Hexadecimal
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public int HexToInt(String source)
        {
            int r = 0;
            if (source.Contains("H") || source.Contains("h"))
            {
                source = source.Remove(source.Length - 1);
                r = Convert.ToInt32(source, 16);
            }
            else
            {
                if (source != "")
                    r = Convert.ToInt32(source);
            }
            return r;
        }
        public int HexToIntWithOutH(String source)
        {
            int r = 0;
            r = Convert.ToInt32(source, 16);
            return r;
        }

        public void Calculate_expression([NotNull] Gramatica_CalculadoraParser.InstruccionContext context, int step)
        {

        }

        public int value_operand(string operand)
        {
            int res = -1;
            operand = operand.Replace(" ", "");
            if (operand.All(char.IsDigit))
            {
                res = Int32.Parse(operand);
                if (res > 0 && res < 4096)
                    is_constant = true;
                // es un numero decimal
            }
            else
            {
                if (operand.Substring(operand.Length - 1, 1) == "H" || operand.Substring(operand.Length - 1, 1) == "H")
                {
                    string test = operand.Remove(operand.Length - 1);
                    if (System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z"))
                    {
                        res = HexToIntWithOutH(test);
                        if (res > 0 && res < 4096)
                            is_constant = true;
                    }
                    else
                    {
                        if (Read_tabsim(operand))
                        {
                            string[] lines_tab_sim = File.ReadAllLines(directory + "TABSIM.txt");
                            foreach (string line in lines_tab_sim)
                            {
                                if (line.Contains(operand))
                                {
                                    res = getDirNumConstant(line);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            // error
                        }
                    }
                }
                else
                {
                    if (Read_tabsim(operand))
                    {
                        string[] lines_tab_sim = File.ReadAllLines(directory + "TABSIM.txt");
                        foreach (string line in lines_tab_sim)
                        {
                            if (line.Contains(operand))
                            {
                                res = getDirNumConstant(line);
                                break;
                            }
                        }
                    }
                    else
                    {
                        // error
                    }
                }

            }

            return res;
        }

        int getDirNumConstant(string line)
        {
            string res = "";
            int indextabsim = 0;
            while (indextabsim < line.Length)
            {
                if (line[indextabsim] == '\t')
                {
                    indextabsim++;
                    while (indextabsim < line.Length)
                        if (line[indextabsim] != '\t')
                            res += line[indextabsim++].ToString();
                        else
                            break;
                    break;
                }
                indextabsim++;
            }
            return Convert.ToInt32(res, 16);
        }

        public bool Read_tabsim(string symb)
        {
            bool is_contained = false;
            if (File.Exists(path))
            {
                text = File.ReadAllText(directory + "TABSIM.txt");
                if (text.Contains(symb))
                {
                    is_contained = true;
                }
            }
            return is_contained;
        }


        public void WriteFileProgObj(String reg)
        {
            string directory = Directory.GetCurrentDirectory();
            using (StreamWriter file = new StreamWriter(directory + "ArchivoObjeto.obj", true))
            {
                file.WriteLine(reg);
            }
        }

        public string adjustStringToNBytes(string source, int num_bytes)
        {
            string res = "";
            int diff = num_bytes - source.Length;
            if (diff < 0)
                res = source.Remove(0, Math.Abs(diff));
            else
                res = source.PadLeft(num_bytes, '0');
            return res;
        }
    }
}
