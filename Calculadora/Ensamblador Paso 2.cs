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
        bool is_error = false;
        bool n, i, x, b, p, e = false;
        string[] text;
        String label = "";
        String error = "";
        String ins = "";
        String opIns = "";

        public const int FIX = 0xC4, FLOAT = 0xC0, HIO = 0xF4, NORM = 0xC8, SIO = 0xF0, TIO = 0xF8, ADDR = 0x90, CLEAR = 0xB4,
            COMPR = 0xA0, DIVR = 0x9C, MULR = 0x98, RMO = 0xAC, SHIFTL = 0xA4, SHIFTR = 0xA8, SUBR = 0x94, SVC = 0xB0, TIXR = 0xB8,
            ADD = 0x18, ADDF = 0x58, AND = 0x40, COMP = 0x28, COMPF = 0x88, DIV = 0x24, DIVF = 0x64, J = 0x3C, JEQ = 0x30,
            JGT = 0x34, JLT = 0x38, JSUB = 0x48, LDA = 0x00, LDB = 0x68, LDCH = 0x50, LDF = 0x70, LDL = 0x08, LDS = 0x6C, LDT = 0x74,
            LDX = 0x04, LPS = 0xD0, MUL = 0x20, MULF = 0x60, OR = 0x44, RD = 0xD8, SSK = 0xEC, STA = 0x0C, STB = 0x78, STCH = 0x54,
            STF = 0x80, STI = 0xD4, STL = 0x14, STS = 0x7C, STSW = 0xE8, STT = 0x84, STX = 0x10, SUB = 0x1C, SUBF = 0x5C, TD = 0xE0,
            TIX = 0x2C, WD = 0xDC; 

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
                else if(ins == "WORD" || ins == "WORD ")
                {
                    int codObj = t.HexToInt(opIns);
                    t.WriteFileObj(linea, t.StrToIntToHex(cp.ToString()), label, ins, opIns, codObj.ToString("D3"));
                }
                else if (ins == "BYTE" || ins == "BYTE ")
                {
                    string cod_Obj = "";
                    if (opIns.Contains("X"))
                    {
                        string val = opIns.Replace("X", String.Empty);
                        string codObje = val.Remove(0, 1);
                        string codObje2 = val.Remove(val.Length - 1, 1);
                        t.WriteFileObj(linea, t.StrToIntToHex(cp.ToString()), label, ins, opIns, codObje2);
                    }
                    else if (opIns.Contains("C"))
                    {
                        string val = opIns.Replace("C", String.Empty);
                        string codObje = val.Remove(0,1);
                        string codObje2 = val.Remove(val.Length-1, 1);
                        
                        char[] cad = codObje2.ToCharArray();                        
                        foreach(char ch in cad)
                        {
                            int ascii_int = (int)ch;
                            cod_Obj += t.HexToInt(ascii_int.ToString());
                        }
                        t.WriteFileObj(linea, t.StrToIntToHex(cp.ToString()), label, ins, opIns, cod_Obj);
                    }
                    string codObj = t.StrToIntToHex(cod_Obj);
                    t.WriteFileObj(linea, t.StrToIntToHex(cp.ToString()), label, ins, opIns, codObj);
                }
                else
                {
                    if (is_error)
                    {
                        
                    }
                }
                iterator = 0;
                index++;
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

        void set_flag()
        {
            int cp_n = 0;
            if (index < text.Length - 1)
                cp_n = getNextCP(text[index + 1]);
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
                if (opIns.Contains('X'))
                    x = true;
            }
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
