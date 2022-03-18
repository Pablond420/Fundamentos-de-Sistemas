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
        int num_constant = 0;
        int dir_num_constant = 0;
        int base_value = 0;
        bool is_error = false;
        bool n, i, x, b, p, e = false;
        bool is_constant = false;
        bool is_dir_mem = false;
        string[] text;
        string codop = "";// object code values in binary
        string flags_bits = "";// object code values in binary
        string ta_dir = "";// object code values in binary
        string ins_alone = "";
        string opIns_aux = "";
        String label = "";
        String error = "";
        String ins = "";
        String opIns, opIns2= "";

        public const string ADD = "000110", ADDF = "010110", AND = "100100", COMP = "001010", COMPF = "100010", DIV = "001001", DIVF = "011001"
            , J = "001111", JEQ = "001100", JGT = "001101", JLT = "001110", JSUB = "010010", LDA = "000000", LDB = "011010", LDCH = "010100",
            LDF = "011100", LDL = "000010", LDS = "011011", LDT = "011101", LDX = "000001", LPS = "110100", MUL = "001000", MULF = "011000",
            OR = "010001", RD = "110110", RSUB = "010011", SSK = "111011", STA = "000011", STB = "011110", STCH = "010101", STF = "100000",
            STI = "110101", STL = "000101", STS = "011111", STSW = "111010", STT = "100001", STX = "000100", SUB = "000111", SUBF = "010111",
            TD = "111000", TIX = "001011", WD = "110111";

        public const int FIX = 0xC4, FLOAT = 0xC0, HIO = 0xF4, NORM = 0xC8, SIO = 0xF0, TIO = 0xF8, ADDR = 0x90, CLEAR = 0xB4,
            COMPR = 0xA0, DIVR = 0x9C, MULR = 0x98, RMO = 0xAC, SHIFTL = 0xA4, SHIFTR = 0xA8, SUBR = 0x94, SVC = 0xB0, TIXR = 0xB8;

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
                else
                {
                    if (is_format3_or_format4())
                        set_flag();

                    if (is_error)
                    {

                    }
                    else
                    {
                        
                    }
                }
                iterator = 0;
                index++;
                is_constant = false;
                is_dir_mem = false;
                is_error = false;
                opIns_aux = "";
                opIns2 = "";
                num_constant = 0;
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
            string ins_text_f3_f4 = "ADD ADDF AND COMP COMPF DIV DIVF J JEQ JGT JLT JSUB LDA LDB LDCH LDF LDL LDS LDT LDX LPS MUL MULF OR RD SSK STA STB STCH STF STI STL STS STSW STT STX SUB SUBF TD TIX WD ";
         
            if (ins_text_f3_f4.Contains(ins_alone))
                res = true;
            
            return res;
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
                }
            }
        }

        int extract_number()
        {
            string directory = Directory.GetCurrentDirectory();
            string text_tab_sim = File.ReadAllText(directory + "TABSIM.txt");
            if (text_tab_sim.Contains(opIns2.ToString()))
            {
                string[] lines_tab_sim = File.ReadAllLines(directory + "TABSIM.txt");
                foreach (string line in lines_tab_sim)
                {
                    if (line.Contains(opIns2.ToString()))
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

        void set_flag()
        {
            opIns2 = opIns;

            int cp_next = 0;
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
            if (e) // FORMATO 4
            {
                b = false;
                p = false;
                if (opIns.Contains('@') || opIns.Contains('#')) //  ta -> dir
                {
                    // verificar que m exista y hacer la logica del codigo objeto 
                }
                else
                {
                    if (opIns.Contains(",X ") || opIns.Contains(", X ") || opIns.Contains(",X") || opIns.Contains(", X")) // TA -> dir + (X)
                    {
                        x = true;

                        // logica para obtener el codigo objeto de los que tengan formato 4 y TA que indica el comentario aun lado del if
                    }
                    else // f4 TA -> dir 
                    {
                        // verificar que m exista y hacer la logica del codigo objeto
                    }
                }
            }
            else
            {
                calculate_ta(x);
            }
            Console.WriteLine("n\ti\tx\tb\tp\te");
            string flags = "";
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
        }

        void calculate_ta(bool x)
        {
            codop = what_ins_is();
            Console.WriteLine(codop);
            if (x)
            {
                if (is_constant)
                {
                    //num_constant es la constante o la dir_mem mayor a 4095
                }
                else if (is_dir_mem)
                {
                    if (num_constant == 0)
                    {
                        //opIns_aux tiene el simbolo
                    }
                    else
                    {
                        //num_constant es nla dir_mem mayor a 4095
                    }
                }
            }
            else
            {
                if (is_constant)
                {
                    //num_constant es la constante o la dir_mem mayor a 4095
                }
                else if (is_dir_mem)
                {
                    if (num_constant == 0)
                    {
                        //opIns_aux tiene el simbolo
                    }
                    else
                    {
                        //num_constant es nla dir_mem mayor a 4095
                    }
                }
            }
            
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
                case "RSUB":
                    res = RSUB;
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
            res = res.Contains("*") ? res.Remove(res.Length - 1) : res;
            is_error = res.Contains("*") ? true : false;
            return t.HexToIntWithOutH(res);
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
            is_error = res.Contains("*") ? true : false;
            return t.HexToIntWithOutH(res);
        }


    }
}
