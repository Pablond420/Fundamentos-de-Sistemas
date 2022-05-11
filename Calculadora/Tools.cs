using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.IO;
using MathParserTK;

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
        public bool is_symbol = false;
        public bool expresion_type = false;
        public double value_expr = 0;
        public int ret = -1;
        public MathParser parser = new MathParser();    
        public string namep = "";

        public string text = "";
        public string directory = Directory.GetCurrentDirectory();
        public string path = "";
        public bool is_constant;
        public string type = "";
        
        List<string> expression = new List<string>();
        List<string> types = new List<string>();

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

        public int Calculate_expression(string context, int step)
        {
            string txtaux = "";
            List<string> expresion = new List<string>();
            context = context.Replace(" ", "");
            value_expr = 0;
            expresion.Clear();
            expression.Clear();
            types.Clear();
            ret = -1;
            value_expr = 0;
            for (int i = 0; i < context.Length; i++)
            {
                
                if (context.Substring(i, 1) != "+" && context.Substring(i, 1) != "*" && context.Substring(i, 1) != "/"
                    && context.Substring(i, 1) != "-" && context.Substring(i, 1) != "(" && context.Substring(i, 1) != ")")
                {
                    txtaux += context.Substring(i, 1);
                }
                else
                {
                    if (txtaux == "")
                        expresion.Add(context.Substring(i, 1));
                    else
                    {
                        expresion.Add(txtaux);
                        expresion.Add(context.Substring(i, 1));
                        txtaux = "";
                    }
                    
                }
                if (i == context.Length - 1)
                {
                    if(txtaux != "")
                        expresion.Add(txtaux);
                }
            }
           if (valid_expresion(expresion))
            {
                if(types.Count == 1)
                {
                    if(types.ElementAt(0) == "A")
                    {
                        ret = 0; // el simbolo que registra equ es absoluto
                    }
                }
                else
                {
                    string calc_expr = "";
                    for(int i=0; i<expression.Count();i++)
                        calc_expr += expression.ElementAt(i);
                    value_expr = parser.Parse(calc_expr, false);
                }
            }else
            {
                ret = -1;
            }

            return ret;
        }
        public bool valid_expresion(List<string> s)
        {
            bool is_valid = false;
            bool is_negative = false;
            bool flag_error = false;
            int value_op = 0;
            string expre = "";
            for (int i = 0; i<s.Count();i++)
            {
                is_symbol = false;
                type = "";
                value_op = 0;
                
                if(s.ElementAt(i) != "+" && s.ElementAt(i) != "-" && s.ElementAt(i) != "*" &&
                    s.ElementAt(i) != "/" && s.ElementAt(i) != "(" && s.ElementAt(i) != ")")
                {
                    value_op = value_operand(s.ElementAt(i));
                    if(is_symbol)
                    {
                        if(value_op != -1)
                        {
                            expression.Add(value_op.ToString());
                            types.Add(type);
                        }
                        else
                        {
                            flag_error = true;
                            break;
                        }
                    }else
                    {
                        if (value_op != -1)
                            expression.Add(value_op.ToString());
                        else
                        {
                            flag_error = true;
                            break;
                        }
                        if (is_constant)
                            types.Add("A");
                        else
                            types.Add("R");
                    }
                }
                else
                {
                    expression.Add(s.ElementAt(i));
                    types.Add(s.ElementAt(i));
                }
            }
            if (!flag_error)
            {
                if (types.Count == s.Count)
                {
                    bool final = false;
                    int index_aux = -1;
                    bool opadd = false;

                    do
                    {
                        index_aux = -1;
                        is_negative = false;
                        opadd = false;
                        for (int i = 0; i < types.Count; i++)
                        {
                            if (i == types.Count - 1)
                                final = true;
                            if (types.ElementAt(i) == "+")
                            {
                                opadd = true;
                                is_negative = false;
                                continue;
                            }
                            if (types.ElementAt(i) == "-")
                            {
                                opadd = true;
                                is_negative = true;
                                continue;
                            }
                            if (types.ElementAt(i) == "(")
                            {
                                
                                if(opadd || i==0)
                                {
                                    index_aux = i;
                                    break;
                                }
                                
                            }
                            else if (types.ElementAt(i) == "R" || types.ElementAt(i) == "A")
                            {
                                opadd = false;
                                is_negative = false;
                            }
                        }

                        if (index_aux != -1)
                            delete_parent(index_aux, is_negative);

                    } while (final != true);
                    
                    for (int i = 0; i < types.Count; i++)
                        expre += types.ElementAt(i);
                    if (expre.Contains("*R") || expre.Contains("R*") || expre.Contains("/R") || expre.Contains("R/"))
                            flag_error = true;
                }
            }
            if (!flag_error)
            {
                List<string> negativeR = new List<string>();
                List<string> positiveR = new List<string>();
                negativeR.Clear();
                positiveR.Clear();
                is_valid = true;
                expresion_type = false;
                if (!expre.Contains("R"))
                {
                    expresion_type = true; // Absoluto
                    if (expre.Count() > 1)
                    {
                        ret = 1;
                    }
                }
                
                if(!expresion_type)
                {
                    is_negative = false;
                    for(int i=0; i<types.Count();i++)
                    {
                        if(types.ElementAt(i) == "-")
                        {
                            is_negative = true;
                        }else if (types.ElementAt(i) == "R")
                        {
                            if (!is_negative)
                                positiveR.Add(types.ElementAt(i));
                            else
                                negativeR.Add(types.ElementAt(i));
                            is_negative = false;
                        }
                    }
                    if (positiveR.Count == negativeR.Count)
                    {
                        is_valid = true;
                        ret = 1;
                        //es absoluto
                    }
                    else if(positiveR.Count == negativeR.Count + 1)
                    {
                        is_valid = true;
                        ret = 2;
                        // es relativo
                    }
                    else
                    {
                        is_valid = false;
                    }

                }


            }

            return is_valid;
        }
        public void delete_parent(int it, bool sign)
        {
            int left_parent = it;
            int count_aux = 0;
            bool flag1 = false;
            bool signn = false;
            List<string> aux = new List<string>();
            for(int i=0 ; i < types.Count; i++)
            {
                if (sign && it>0)
                    if(i == it - 1)
                        continue;
                if (i == it)
                {
                    flag1 = true;
                    continue;
                }
                if(!flag1)
                    aux.Add(types.ElementAt(i));
                else
                {
                    if (types.ElementAt(i) == "(")
                    {
                        count_aux++;
                        aux.Add(types.ElementAt(i));
                        continue;
                    }
                    if (types.ElementAt(i) == ")")
                    {
                        if (count_aux == 0)
                        {
                            flag1 = false;
                            continue;
                        }
                        else
                        {
                            count_aux--;
                        }
                    }
                    if (sign)
                    {
                        if (types.ElementAt(i) == "+")
                        {
                            aux.Add("-");
                            signn = true;
                        }
                        else if (types.ElementAt(i) == "A" || types.ElementAt(i) == "R")
                        {
                            if (!signn)
                                aux.Add("-");
                            aux.Add(types.ElementAt(i));
                            signn = false;
                        }
                        else if(types.ElementAt(i) == "-")
                        {
                            aux.Add("+");
                            signn = true;
                        }
                        else
                        {
                            aux.Add(types.ElementAt(i));
                        }
                    }
                    else
                    {
                        aux.Add(types.ElementAt(i));
                    }
                    
                }
            }

            types.Clear();
            for(int i = 0; i < aux.Count; i++)
                types.Add(aux.ElementAt(i));
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
                                    is_symbol = true;
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
                                is_symbol = true;
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
                        {
                            indextabsim++;
                            type = line[indextabsim].ToString();
                            break;

                        }
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

        //public bool WriteFileTabSim(String symb, String dir, String tipo)
        //{
        //    // String line = "Simbolo" + "    Direccion";
        //    String line = symb + "\t" + dir + "\t" + tipo;
        //    bool repeatedSymbol = false;
        //    if (File.Exists(path))
        //    {
        //        String text = File.ReadAllText(directory + "TABSIM.txt");
        //        if (!text.Contains(symb))
        //        {
        //            using (StreamWriter file = new StreamWriter(directory + "TABSIM.txt", true))
        //            {
        //                file.WriteLine(line);
        //            }
        //        }
        //        else
        //        {
        //            repeatedSymbol = true;
        //        }
        //    }
        //    return repeatedSymbol;
        //}
    }
}
