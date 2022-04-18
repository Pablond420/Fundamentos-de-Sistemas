using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calculadora
{
    public class Ensamblador_Paso_2
    {
        public static Ensamblador_Paso_2 INSTANCE = new Ensamblador_Paso_2();
        Tools t = new Tools();
        int cp, index = 0;
        int iterator = 0;
        int linea = 0;
        int cp_next = 0;
        int num_constant = 0;
        int ta_calculate = -10000;
        int dir_num_constant = 0;
        int base_value = -2;
        bool is_error = false;
        bool is_error_step2 = false;
        bool n, i, x, b, p, e = false;
        bool is_constant = false;
        bool is_dir_mem = false;
        bool is_out_range = false;
        bool diferent_previous_cp = false;
        string[] text;
        string codop = "";// object code values in binary
        string ins_alone = "";
        string reg_alone = "";
        string flags = "";
        string object_code = "";
        string opIns_aux = "";
        String label = "";
        String error = "Error : ";
        String ins = "";
        String opIns, opIns2= "";

        public const string ADD = "000110", ADDF = "010110", AND = "100100", COMP = "001010", COMPF = "100010", DIV = "001001", DIVF = "011001"
            , J = "001111", JEQ = "001100", JGT = "001101", JLT = "001110", JSUB = "010010", LDA = "000000", LDB = "011010", LDCH = "010100",
            LDF = "011100", LDL = "000010", LDS = "011011", LDT = "011101", LDX = "000001", LPS = "110100", MUL = "001000", MULF = "011000",
            OR = "010001", RD = "110110", SSK = "111011", STA = "000011", STB = "011110", STCH = "010101", STF = "100000",
            STI = "110101", STL = "000101", STS = "011111", STSW = "111010", STT = "100001", STX = "000100", SUB = "000111", SUBF = "010111",
            TD = "111000", TIX = "001011", WD = "110111";

        public const string FIX = "11000100", FLOAT = "11000000", HIO = "11110100", NORM = "11001000", SIO = "11110000", TIO = "11111000",
            ADDR = "10010000", CLEAR = "10110100", COMPR = "10100000", DIVR = "10011100", MULR = "10011000", RMO = "10101100", SHIFTL = "10100100",
            SHIFTR = "10101000", SUBR = "10010100", SVC = "10110000", TIXR = "10111000";

        public const string A = "0000", X = "0001", L = "0010", B = "0011", S = "0100", T = "0101", F = "0110", CP = "1000", SW = "1001";

        public void CodigoObjeto()
        {
            string directory = Directory.GetCurrentDirectory();
            text = File.ReadAllLines(directory + "ArchivoIntermedio.txt");            
            while(index < text.Length)
            {
                Console.WriteLine(text[index]);
                deformatLine(text[index]);
                if(ins == "START" || ins == "RESW" || ins == "RESB" || ins == "ORG" || ins == "END" || ins == "EQU" || ins == "START " || ins == "RESW " || ins == "RESB " || ins == "ORG " || ins == "END " || ins == "EQU ")
                {
                    t.WriteFileObj(linea, t.StrToIntToHex(cp.ToString()), label, ins, opIns, "----");
                }
                else if (ins == "WORD" || ins == "WORD ")
                {
                    string codObj = "";
                    if (opIns.Contains("H") || opIns.Contains("h"))
                    {
                        string saveOpIn = opIns;
                        saveOpIn = saveOpIn.Remove(saveOpIn.Length - 1);
                        codObj = saveOpIn.ToString();
                    }
                    else
                    {
                        if (opIns != "")
                        {
                            int num = Int32.Parse(opIns);
                            codObj = num.ToString("X");
                        }
                    }
                    t.WriteFileObj(linea, t.StrToIntToHex(cp.ToString()), label, ins, opIns, codObj.PadLeft(6, '0'));
                }
                else if (ins == "BYTE" || ins == "BYTE ")
                {
                    string cod_Obj = "";
                    if (opIns.Contains("X"))
                    {
                        string codObje = opIns.Remove(0, 2);
                        string codObje2 = codObje.Remove(codObje.Length - 1, 1);
                        if(codObje2.Length % 2 != 0)
                            codObje2 = codObje2.PadLeft(codObje2.Length + 1, '0');
                        t.WriteFileObj(linea, t.StrToIntToHex(cp.ToString()), label, ins, opIns, codObje2);
                    }
                    else if (opIns.Contains("C"))
                    {
                        string codObje = opIns.Remove(0, 2);
                        string codObje2 = codObje.Remove(codObje.Length - 1, 1);

                        char[] cad = codObje2.ToCharArray();
                        foreach (char ch in cad)
                        {
                            int ascii_int = (int)ch;
                            cod_Obj += t.StrToIntToHex(ascii_int.ToString());
                        }
                        t.WriteFileObj(linea, t.StrToIntToHex(cp.ToString()), label, ins, opIns, cod_Obj);
                    }
                }
                else if (ins == "BASE" || ins == "BASE ")
                {
                    opIns2 = opIns;
                    base_value = extract_number();
                    t.WriteFileObj(linea, t.StrToIntToHex(cp.ToString()), label, ins, opIns, "----");
                }
                else
                {                    
                    if (!is_error ) // y ademas puede ser error pero que sea por simbolo repetido deberia entrar
                    {
                        if (is_format3_or_format4())
                            set_flag();
                        else if (is_format1())
                            object_code_f1();
                        else if (is_format2())
                            object_code_f2();
                        Console.WriteLine(linea);
                        if (e)
                        {
                            if (object_code.Length < 8)
                                object_code = object_code.PadLeft(8, '0');
                            if(!is_error_step2)
                                object_code += "*";
                        }
                        else if(is_format3_or_format4())
                        {
                            if (object_code.Length < 6)
                                object_code = object_code.PadLeft(6, '0');
                        }
                        if (ins == "RSUB" || ins == "RSUB ")
                            object_code = "4F0000";
                        t.WriteFileObj(linea, t.StrToIntToHex(cp.ToString()), label, ins, opIns, object_code);
                    }
                }
                Console.WriteLine(object_code);
                iterator = 0;
                error = "Error : ";
                index++;
                is_constant = false;
                diferent_previous_cp = false;
                is_error = false;
                base_value = -2;
                is_dir_mem = false;
                is_out_range = false;
                opIns_aux = "";
                ins_alone = "";
                object_code = "";
                reg_alone = "";
                opIns2 = "";
                num_constant = 0;
                is_error_step2 = false;
                n = i = x = b = p = e = false;
            }
        }

        void deformatLine(string line)
        {
            linea = getLine(line);
            cp = getCP(line);
            label = getLabel(line);
            ins = getInst(line);
            opIns = getOpInst(line);
        }

        bool is_format3_or_format4()
        {
            bool res = false;
            ins_alone = ins.Replace("+", "");
            ins_alone = ins_alone.Replace(" ", "");
            string ins_text_f3_f4 = "ADD ADDF AND COMP COMPF DIV DIVF J JEQ JGT JLT JSUB LDA LDB LDCH LDF LDL LDS LDT LDX LPS MUL MULF OR RD SSK STA STB STCH STF STI STL STS STSW STT STX SUB SUBF TD TIX WD ";
         
            if (ins_text_f3_f4.Contains(ins_alone))
                res = true;
            
            return res;
        }

        bool is_format1()
        {
            bool res = false;
            ins_alone = ins.Replace(" ", "");
            string ins_text_f1 = "FIX   FLOAT   HIO   NORM   SIO   TIO ";
            if (ins_text_f1.Contains(ins_alone))
                res = true;
            return res;
        }

        bool is_format2()
        {
            bool res = false;
            ins_alone = ins.Replace(" ", "");
            string ins_text_f2 = "ADDR   CLEAR   COMPR   DIVR   MULR   RMO   SHIFTL SHIFTR   SUBR   SVC   TIXR  ";
            if (ins_text_f2.Contains(ins_alone))
                res = true;
            return res;
        }

        void object_code_f1()
        {
            codop = what_ins_is_f1();
            object_code = binary_to_hex(codop);
        }
        void object_code_f2()
        {
            codop = what_ins_is_f2();     
            if(!opIns.Contains(',')) // SVC, TIXR, CLEAR
            {
                reg_alone = opIns.Replace(" ", "");
                object_code = codop + what_register_is() + "0000";
                object_code = binary_to_hex(object_code);
            }else
            {
                reg_alone = opIns.Replace(" ", "");
                reg_alone = reg_alone.Substring(0, 1);
                object_code = codop + what_register_is();
                reg_alone = opIns.Substring(opIns.IndexOf(',') + 1);
                reg_alone = reg_alone.Replace(" ", "");
                reg_alone = reg_alone.Replace(",", "");
                object_code += what_register_is();
                object_code = binary_to_hex(object_code);
            }
        }

        string binary_to_hex(string bin)
        {
            Console.WriteLine(bin);
            string res = string.Format("{0:X}", Convert.ToInt64(bin, 2));
            return res;
        }

        void set_flag()
        {
            opIns2 = opIns;

            cp_next = 0;
            if (index < text.Length - 1)
                cp_next = getNextCP(text[index + 1]);

            if (opIns2.Contains('@') || opIns2.Contains('#'))
            {
                opIns2 = opIns2.Remove(0, 1);
                Console.WriteLine(opIns2);
            }
            set_num_constant();
            Console.WriteLine(is_constant ? "True" : "False");
            Console.WriteLine(is_dir_mem ? "True" : "False");
            Console.WriteLine(num_constant.ToString());

            if (opIns.Contains('@'))
            {
                n = true;
                i = false;
            }
            else if (opIns.Contains('#'))
            {
                n = false;
                i = true;
            }
            else
            {
                n = true;
                i = true;
                x = opIns.Contains(",X ") || opIns.Contains(", X ") || opIns.Contains(",X") || opIns.Contains(", X") ? true : false;
            }
            
            e = ins.Contains('+') ? true : false;
            calculate_ta(x);

            Console.WriteLine("n\ti\tx\tb\tp\te");
            flags = "";
            flags += n ? '1' : '0';
            flags += "\t";
            flags += i ? '1' : '0';
            flags += "\t";
            flags += x ? '1' : '0';
            flags += "\t";
            flags += b ? '1' : '0';
            flags += "\t";
            flags += p ? '1' : '0';
            flags += "\t";
            flags += e ? '1' : '0';
            flags += "\n";
            Console.WriteLine(flags);
            flags = flags.Replace("\t", "");
            flags = flags.Replace("\n", "");
            flags = flags.Replace(" ", "");
            string ta_f4 = "";
            if (e)
            {
                if(ta_calculate != -10000 && !is_error_step2)
                {
                    ta_f4 = Convert.ToString(ta_calculate, 2);
                    ta_f4 = number_5_bytes(ta_f4);
                    object_code = codop + flags + ta_f4;
                    object_code = binary_to_hex(object_code);
                }else
                {
                    if (is_error_step2)
                    {
                        object_code = codop + flags + object_code;
                        object_code = binary_to_hex(object_code);
                    }
                    //error de algo por que en el calculo de TA no salio nada
                }
            }
            else
            {
                if(ta_calculate != -10000 && !is_error_step2)
                {
                    ta_f4 = Convert.ToString(ta_calculate, 2);
                    ta_f4 = number_3_bytes(ta_f4);
                    object_code = codop + flags + ta_f4;
                    object_code = binary_to_hex(object_code);
                }else
                {
                    if (is_error_step2)
                    {
                        object_code = codop + flags + object_code;
                        object_code = binary_to_hex(object_code);
                    }
                    // un error por que no hay nada en ta_calculate
                }
                
            }
        }

        void set_num_constant()
        {
            int test;
            opIns_aux = opIns2;
            if (opIns2.Contains(",X "))
                opIns_aux = opIns2.Replace(",X ", "");
            else if (opIns2.Contains(", X "))
                opIns_aux = opIns2.Replace(",X ", "");
            else if (opIns2.Contains(",X"))
                opIns_aux = opIns2.Replace(",X", "");
            else if (opIns2.Contains(", X"))
                opIns_aux = opIns2.Replace(", X", "");
            opIns_aux = opIns_aux.Replace(" ", "");

            Console.WriteLine(opIns_aux);
            if (!opIns_aux.Contains(','))
            {
                if (!Int32.TryParse(opIns_aux, out test))
                {
                    if (opIns_aux.Substring(opIns_aux.Length - 1, 1) == "H" || opIns_aux.Substring(opIns_aux.Length - 1, 1) == "h")
                    {
                        num_constant = t.HexToInt(opIns_aux);
                        if (num_is_constant(num_constant) == 1)
                            is_constant = true;
                        else if (num_is_constant(num_constant) == 2)
                            is_dir_mem = true;
                    }
                    else // seria una m verificar si m existe en TABSIM
                        is_dir_mem = true;
                }
                else
                {
                    if (num_is_constant(-1) == 1)
                        is_constant = true;
                    else if (num_is_constant(-1) == 2)
                        is_dir_mem = true;
                    else if (num_is_constant(-1) == 0)
                        is_out_range = true;
                }
            }
        }

        int extract_number()
        {
            opIns_aux += opIns_aux == "" ? opIns2 : "";
            string directory = Directory.GetCurrentDirectory();
            string text_tab_sim = File.ReadAllText(directory + "TABSIM.txt");
            if (text_tab_sim.Contains(opIns_aux.ToString()))
            {
                string[] lines_tab_sim = File.ReadAllLines(directory + "TABSIM.txt");
                foreach (string line in lines_tab_sim)
                {
                    if (line.Contains(opIns_aux.ToString()))
                    {
                        dir_num_constant = getDirNumConstant(line);
                        break;
                    }
                }
            }
            else
                dir_num_constant = -1;
            return dir_num_constant;
        }
        string number_3_bytes(string binary)
        {
            string res = "";
            if (binary.Length > 12)   // desplazamiento = C2 o numero negativo FFFFFFC2   1111 1111 1111 1100 0010
            {
                int count_aux = binary.Length - 12;
                for (int i = count_aux; i < binary.Length; i++)
                    res += binary.Substring(i, 1);
            }
            else                         // 1100 0010
            {
                string plus = "";
                for (int i = binary.Length ; i < 12; i++)
                    plus += "0";
                res = plus + binary;  // 0000 1100 0010
            }

            return res;
        }
        string number_5_bytes(string binary)
        {
            string res = "";
            if (binary.Length > 20)
            {
                int count_aux = binary.Length - 20;
                for (int i = count_aux - 1; i < binary.Length; i++)
                    res += binary.Substring(i, 1);
            }
            else
            {
                string plus = "";
                for (int i = binary.Length; i < 20; i++)
                    plus += "0";
                res = plus + binary;
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
                        res += line[indextabsim++].ToString();
                }
                indextabsim++;
            }
            return Convert.ToInt32(res, 16);
        }

        void calculate_ta(bool x)
        {
            codop = what_ins_is();
            Console.WriteLine(codop);
            ta_calculate = -10000;
            int ta_calculate_aux = 0;
            if(is_out_range)
            {
                b = p = is_error_step2 = true;
                object_code = "111111111111";
                error += "Operando fuera de rango.";
            }
            else if (x)
            {
                if (e) // TA -> dir + (X)
                {
                    if (is_dir_mem)
                    {
                        if (num_constant == 0)
                        {
                            if(extract_number() != -1)
                            {
                                ta_calculate = extract_number() - 0;
                            }else
                            {
                                b = p = is_error_step2 = true;
                                object_code = "11111111111111111111";
                                error += "Simbolo no encontrado en TABSIM.";
                               // error : Simbolo no encontrado en TABSIM
                            }
                            //opIns_aux tiene el simbolo
                        }
                        else
                        {
                            ta_calculate = num_constant - 0;
                            //num_constant es la dir_mem mayor a 4095
                        }
                    }else
                    {
                        b = p = is_error_step2 = true;
                        object_code = "11111111111111111111";
                        error += "Modo de direccionamiento no existe.";
                        //es error : deberia de ser una m sin embargo tiene una c en m,X
                    }
                }else if (is_constant) //c,X    TA->desp + X
                    ta_calculate = num_constant - 0;
                else if (is_dir_mem) // m,X 
                {
                    if (num_constant == 0)
                    {
                        if(extract_number() != -1)
                        {
                            ta_calculate_aux = extract_number() - cp_next - 0;
                            // TA -> CP + desp + X
                            if (ta_calculate_aux > -2049 && ta_calculate_aux < 2048)
                            {
                                p = true;
                                b = false;
                                ta_calculate = ta_calculate_aux;
                            }
                            else //m,X TA -> B+desp+X
                            {
                                if(base_value != -2)
                                {
                                    if (base_value != -1)
                                    {
                                        ta_calculate_aux = extract_number() - base_value - 0;
                                        if (ta_calculate_aux >= 0 && ta_calculate_aux <= 4095)
                                        {
                                            b = true;
                                            p = false;
                                            ta_calculate = ta_calculate_aux;
                                        }else
                                        {
                                            b = p = is_error_step2 = true;
                                            object_code = "111111111111";
                                            error += "La instruccion no es relativa al contador (CP) o a la base (B).";
                                        }
                                    }
                                    else
                                    {
                                        b = p = is_error_step2 = true;
                                        object_code = "111111111111";
                                        error += "Simbolo de la base no encontrado en TABSIM.";
                                        // Error: Base no definida

                                    }
                                }
                                else
                                {
                                    b = p = is_error_step2 = true;
                                    object_code = "111111111111";
                                    error += "La instruccion no es relativa al contador (CP) o a la base (B).";
                                    // Error: Base no definida
                                }
                            }

                        }
                        else
                        {
                            // Simbolo no esta definido en TABSIM
                            b = p = is_error_step2 = true;
                            object_code = "111111111111";
                            error += "Simbolo no encontrado en TABSIM.";
                        }

                    }
                    else
                    {
                        ta_calculate = num_constant;
                        ta_calculate_aux = ta_calculate - cp_next - 0;
                        // TA -> CP + desp + X
                        if (ta_calculate_aux > -2049 && ta_calculate_aux < 2048)
                        {
                            p = true;
                            b = false;
                            ta_calculate = ta_calculate_aux;
                        }
                        else //m,X TA -> B+desp+X
                        {
                            if (base_value != -2)
                            {
                                if (base_value != -1)
                                {
                                    ta_calculate_aux = ta_calculate - base_value - 0;
                                    if (ta_calculate_aux >= 0 && ta_calculate_aux <= 4095)
                                    {
                                        b = true;
                                        p = false;
                                        ta_calculate = ta_calculate_aux;
                                    }
                                    else
                                    {
                                        b = p = is_error_step2 = true;
                                        object_code = "111111111111";
                                        error += "La instruccion no es relativa al contador (CP) o a la base (B).";
                                    }
                                }
                                else
                                {
                                    b = p = is_error_step2 = true;
                                    object_code = "111111111111";
                                    error += "Simbolo de la base no encontrado en TABSIM.";
                                    // Error: Base no definida

                                }
                            }
                            else
                            {
                                b = p = is_error_step2 = true;
                                object_code = "111111111111";
                                error += "La instruccion no es relativa al contador (CP) o a la base (B).";
                                // Error: Base no definida
                            }
                        }
                        ta_calculate = num_constant;
                        //num_constant es nla dir_mem mayor a 4095
                    }
                }
                else 
                {
                    b = p = is_error_step2 = true;
                    object_code = "11111111111111111111";
                    error += "Modo de direccionamiento no existe.";
                    //es error : deberia de ser una m sin embargo tiene una c en m,X
                }
            }
            else if(e)
            {
                if (is_constant) //
                {
                    //Error: No hay instruccion extendida con c
                    b = p = is_error_step2 = true;
                    object_code = "11111111111111111111";
                    error += "Modo de direccionamiento no existe.";
                }
                else if (is_dir_mem)
                {
                    if (num_constant == 0)
                    {
                        if(extract_number() != -1)//+op  m,@m,#cm TA->dir 
                        {
                            ta_calculate = extract_number();
                        }
                        else
                        {
                            // Error: simbolo no encontrado en tabsim
                            b = p = is_error_step2 = true;
                            object_code = "11111111111111111111";
                            error += "Simbolo no encontrado en TABSIM.";
                        }
                        //opIns_aux tiene el simbolo
                    }
                    else
                    {
                        ta_calculate = num_constant;
                        //num_constant es nla dir_mem mayor a 4095
                    }
                }
                else
                {
                    b = p = is_error_step2 = true;
                    object_code = "11111111111111111111";
                    error += "Modo de direccionamiento no existe.";
                    //es error : deberia de ser una m sin embargo tiene una c en m,X
                }
            }
            else
            {
                if (is_constant) //op  @c, #c, c TA -> desp
                {
                    ta_calculate = num_constant;
                    //num_constant es la constante
                }
                else if (is_dir_mem)
                {
                    if (num_constant == 0)
                    {
                        if (extract_number() != -1)
                        {
                            ta_calculate_aux = extract_number() - cp_next;
                            // TA -> CP + desp
                            if (ta_calculate_aux > -2049 && ta_calculate_aux < 2048)
                            {
                                p = true;
                                b = false;
                                ta_calculate = ta_calculate_aux;
                            }
                            else //m TA -> B+desp
                            {
                                if (base_value != -2)
                                {
                                    if (base_value != -1)
                                    {
                                        ta_calculate_aux = extract_number() - base_value;
                                        if (ta_calculate_aux >= 0 && ta_calculate_aux <= 4095)
                                        {
                                            b = true;
                                            p = false;
                                            ta_calculate = ta_calculate_aux;
                                        }else
                                        {
                                            b = p = is_error_step2 = true;
                                            object_code = "111111111111";
                                            error += "La instruccion no es relativa al contador (CP) o a la base (B).";
                                        }
                                    }
                                    else
                                    {
                                        b = p = is_error_step2 = true;
                                        object_code = "111111111111";
                                        error += "Simbolo de la base no encontrado en TABSIM.";
                                        //Error:El simbolo no fue encontrado en TABSIM
                                    }
                                }
                                else
                                {
                                    b = p = is_error_step2 = true;
                                    object_code = "111111111111";
                                    error += "La instruccion no es relativa al contador (CP) o a la base (B).";
                                    // Error: Base no definida
                                }
                            }
                        }else
                        {
                            b = p = is_error_step2 = true;
                            object_code = "111111111111";
                            error += "Simbolo no encontrado en TABSIM.";
                            //Error:El simbolo no fue encontrado en TABSIM
                        }
                    }
                    else
                    { 
                        ta_calculate_aux = num_constant - cp_next;
                        // TA -> CP + desp
                        if (ta_calculate_aux > -2049 && ta_calculate_aux < 2048)
                        {
                            p = true;
                            b = false;
                            ta_calculate = ta_calculate_aux;
                        }
                        else //m TA -> B+desp+X
                        {
                            if (base_value != -2)
                            {
                                if (base_value != -1)
                                {
                                    ta_calculate_aux = num_constant - base_value;
                                    if (ta_calculate_aux >= 0 && ta_calculate_aux <= 4095)
                                    {
                                        b = true;
                                        p = false;
                                        ta_calculate = ta_calculate_aux;
                                    }else
                                    {
                                        b = p = is_error_step2 = true;
                                        object_code = "111111111111";
                                        error += "La instruccion no es relativa al contador (CP) o a la base (B).";
                                    }
                                }
                                else
                                {
                                    b = p = is_error_step2 = true;
                                    object_code = "111111111111";
                                    error += "Simbolo de la base no encontrado en TABSIM.";
                                    //Error: o no hay base o el simbolo no fue encontrado en TABSIM
                                }
                            }
                            else
                            {
                                b = p = is_error_step2 = true;
                                object_code = "111111111111";
                                error += "La instruccion no es relativa al contador (CP) o a la base (B).";
                                // Error: Base no definida
                            }
                        }
                    }
                }
                else
                {
                    b = p = is_error_step2 = true;
                    object_code = "111111111111";
                    error += "Modo de direccionamiento no existe.";
                    //es error : deberia de ser una m sin embargo tiene una c en m,X
                }
            }
            Console.WriteLine(ta_calculate);
        }

        string what_register_is()
        {
            string res = "";
            switch (reg_alone)
            {
                case "A":
                    res = A;
                    break;
                case "X":
                    res = X;
                    break;
                case "L":
                    res = L;
                    break;
                case "B":
                    res = B;
                    break;
                case "S":
                    res = S;
                    break;
                case "T":
                    res = T;
                    break;
                case "F":
                    res = F;
                    break;
                case "CP":
                    res = CP;
                    break;
                case "PC":
                    res = CP;
                    break;
                case "SW":
                    res = SW;
                    break;

            }
            return res;
        }
        string what_ins_is_f1()
        {
            string res = "";
            switch (ins_alone)
            {
                case "FIX":
                    res = FIX;
                    break;
                case "FLOAT":
                    res = FLOAT;
                    break;
                case "HIO":
                    res = HIO;
                    break;
                case "NORM":
                    res = NORM;
                    break;
                case "SIO":
                    res = SIO;
                    break;
                case "TIO":
                    res = TIO;
                    break;
            }
            return res;
        }
        string what_ins_is_f2()
        {
            string res = "";
            switch (ins_alone)
            {
                case "ADDR":
                    res = ADDR;
                    break;
                case "CLEAR":
                    res = CLEAR;
                    break;
                case "COMPR":
                    res = COMPR;
                    break;
                case "DIVR":
                    res = DIVR;
                    break;
                case "MULR":
                    res = MULR;
                    break;
                case "RMO":
                    res = RMO;
                    break;
                case "SHIFTL":
                    res = SHIFTL;
                    break;
                case "SHIFTR":
                    res = SHIFTR;
                    break;
                case "SUBR":
                    res = SUBR;
                    break;
                case "SVC":
                    res = SVC;
                    break;
                case "TIXR":
                    res = TIXR;
                    break;

            }
            return res;
        }

        string what_ins_is()
        {
            string res = "";
            switch (ins_alone)
            {
                case "ADD":
                    res = ADD;
                    break;
                case "ADDF":
                    res = ADDF;
                    break;
                case "AND":
                    res = AND;
                    break;
                case "COMP":
                    res = COMP;
                    break;
                case "COMPF":
                    res = COMPF;
                    break;
                case "DIV":
                    res = DIV;
                    break;
                case "DIVF":
                    res = DIVF;
                    break;
                case "J":
                    res = J;
                    break;
                case "JEQ":
                    res = JEQ;
                    break;
                case "JGT":
                    res = JGT;
                    break;
                case "JLT":
                    res = JLT;
                    break;
                case "JSUB":
                    res = JSUB;
                    break;
                case "LDA":
                    res = LDA;
                    break;
                case "LDB":
                    res = LDB;
                    break;
                case "LDCH":
                    res = LDCH;
                    break;
                case "LDF":
                    res = LDF;
                    break;
                case "LDL":
                    res = LDL;
                    break;
                case "LDS":
                    res = LDS;
                    break;
                case "LDT":
                    res = LDT;
                    break;
                case "LDX":
                    res = LDX;
                    break;
                case "LPS":
                    res = LPS;
                    break;
                case "MUL":
                    res = MUL;
                    break;
                case "MULF":
                    res = MULF;
                    break;
                case "OR":
                    res = OR;
                    break;
                case "RD":
                    res = RD;
                    break;
                case "SSK":
                    res = SSK;
                    break;
                case "STA":
                    res = STA;
                    break;
                case "STB":
                    res = STB;
                    break;
                case "STCH":
                    res = STCH;
                    break;
                case "STF":
                    res = STF;
                    break;
                case "STI":
                    res = STI;
                    break;
                case "STL":
                    res = STL;
                    break;
                case "STS":
                    res = STS;
                    break;
                case "STSW":
                    res = STSW;
                    break;
                case "STT":
                    res = STT;
                    break;
                case "STX":
                    res = STX;
                    break;
                case "SUB":
                    res = SUB;
                    break;
                case "SUBF":
                    res = SUBF;
                    break;
                case "TD":
                    res = TD;
                    break;
                case "TIX":
                    res = TIX;
                    break;
                case "WD":
                    res = WD;
                    break;
            }

            return res;
        }


        int num_is_constant(int source)
        {
            int res = 0;
            if (source == -1)
                num_constant = Int32.Parse(opIns_aux);
            else
                num_constant = source;
            if (num_constant < 4096 && num_constant >= 0)
                res = 1;
            else
                if (num_constant > 4095)
                    res = 2;
            return res;
        }

        int getLine(string line)
        {
            string res = "";
            iterator = 0;
            while (line[iterator] != '\t')
                res += line[iterator++].ToString();
            iterator++;  
            return Int32.Parse(res);
        }

        int getCP(string line)
        {
            string res = "";
            while (line[iterator] != '\t')
                res += line[iterator++].ToString();
            iterator++;
            is_error = res.Contains("*") ? true : false;
            res = res.Contains("*") ? res.Remove(res.Length - 1) : res;
            int resHex = t.HexToIntWithOutH(res);
            diferent_previous_cp = cp != resHex ? true : false;
            return resHex;
        }

        string getLabel(string line)
        {
            string res = "";
            while (line[iterator] != '\t')
                res += line[iterator++].ToString();
            iterator++;
            return res;
        }

        string getInst(string line)
        {
            string res = "";
            while (line[iterator] != '\t')
                res += line[iterator++].ToString();
            iterator++;
            return res;
        }

        string getOpInst(string line)
        {
            string res = "";
            while (iterator < line.Length)
                res += line[iterator++].ToString();
            return res;
        }

        int getNextCP(string line)
        {
            string res = "";
            int j = 4;
            while (line[j] != '\t')
                res += line[j++].ToString();
            res = res.Contains("*") ? res.Remove(res.Length - 1) : res;
            return t.HexToIntWithOutH(res);
        }


    }
}
