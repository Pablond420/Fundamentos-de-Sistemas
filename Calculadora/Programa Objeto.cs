using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Programa_Objeto
    {
        string name = "";
        Reg_H header;
        List<Reg_T> text = new List<Reg_T>();
        List<Reg_M> modification = new List<Reg_M>();
        Reg_E end;
        int length = 59;

        Tools t = new Tools();
        public Programa_Objeto(string name, string init)
        {
            this.name = name.Substring(0, 6);
            this.header = new Reg_H(this.name, init);
        }

        public void addTextRegister(Reg_T reg)
        {
            text.Add(reg);
        }

        public void addCodObj(string init_dir, string codObj, bool is_modification, string size_modification)
        {
            if (!is_modification)
            {
                if (this.text.Count == 0)
                    text.Add(new Reg_T(init_dir));
                codObj = codObj.Contains("*") ? codObj.Remove(codObj.Length - 1) : codObj;
                Reg_T last = this.text.Last();
                if (last.isOpen())
                {
                    int free_space = length - last.cod_obj.Length;
                    bool can_insert = free_space >= codObj.Length ? true : false;
                    if (can_insert)
                        last.addCodObj(codObj);
                    else
                    {
                        last.setSize();
                        Reg_T new_reg = new Reg_T(init_dir);
                        new_reg.addCodObj(codObj);
                        text.Add(new_reg);
                    }
                }
                else
                {
                    last.setSize();
                    Reg_T new_reg = new Reg_T(init_dir);
                    new_reg.addCodObj(codObj);
                    text.Add(new_reg);
                }
            }
            else
            {
                string cod = codObj.Remove(codObj.Length - 1);
                modification.Add(new Reg_M(size_modification, "+"));
                Reg_M last = this.modification.Last();
                last.setExternalSymb(name);
                last.setSize(size_modification);
            }
        }

        public void addModificationRegister(Reg_M reg)
        {
            modification.Add(reg);
        }

        public void setEndRegister(string end_dir, string size)
        {
            
            this.end = new Reg_E(end_dir);
            this.header.setSize(size);
        }

        public int countTextReg()
        {
            return this.text.Count();
        }

        public void setLastToClosed()
        {
            this.text.Last().setClosed();
        }

        public void WriteFileObjProg()
        {
            string directory = Directory.GetCurrentDirectory();
            String program_concat = header.headerConcat() + '\n';

            foreach (Reg_T reg_text in text)
                program_concat += reg_text.textConcat() + '\n';
            foreach (Reg_M reg_mod in modification)
                program_concat += reg_mod.modificationConcat() + '\n';

            program_concat += end.endConcat();

            using (StreamWriter file = new StreamWriter(directory + "ProgramaObjeto.txt", true))
            {
                file.WriteLine(program_concat);
            }
        }

    }

    public class Reg_H
    {
        string type = "H";
        string name = "";
        string init = "";
        string size = "";

        Tools t = new Tools();

        public Reg_H(string name, string init)
        {
            this.name = setName(name);
            this.init = t.adjustStringToNBytes(init, 6);
        }

        string setName(string name)
        {
            return name.Substring(0, 6);
        }

        public void setSize(string size)
        {
            this.size = t.adjustStringToNBytes(size, 6);
        }

        public string headerConcat()
        {
            return type + name + init + size;
        }
    }

    public class Reg_T
    {
        string type = "T";
        string init_dir = "";
        string size = "";
        public string cod_obj = "";
        public int size_int = 0;
        bool closed = false;
        

        Tools t = new Tools();

        public Reg_T(string init_dir)
        {
            this.init_dir = t.adjustStringToNBytes(init_dir, 6);
        }

        public void setSize()
        {
            this.size = t.StrToIntToHex((cod_obj.Length / 2).ToString()).PadLeft(2, '0');
        }

        public void addCodObj(string cod_obj)
        {
            this.cod_obj += cod_obj;
        }

        public void setClosed()
        {
            this.closed = true;
        }

        public bool isOpen()
        {
            return closed == true ? false : true;
        }

        public string textConcat()
        {
            return type + init_dir + size + cod_obj;
        }
    }

    public class Reg_M
    {
        string type = "M";
        string init_dir = "";
        string size = "";
        string flag = "";
        string external_symb = "";

        Tools t = new Tools();

        public Reg_M(string init_dir, string flag)
        {
            this.init_dir = t.adjustStringToNBytes(init_dir, 6); ;
            this.flag = flag;
        }

        public void setSize(string size)
        {
            this.size = t.StrToIntToHex(size.Length.ToString()).PadLeft(2, '0');
        }

        public void setExternalSymb(string name)
        {
            this.external_symb = t.adjustStringToNBytes(name, 6);
        }

        public string modificationConcat()
        {
            return type + init_dir + size + flag + external_symb;
        }
    }

    public class Reg_E
    {
        string type = "E";
        string first_exec_dir = "";

        Tools t = new Tools();

        public Reg_E( string first_exec_dir)
        {
            this.first_exec_dir = t.adjustStringToNBytes(first_exec_dir, 6); ;
        }

        public string endConcat()
        {
            return type + first_exec_dir;
        }
    }
}
