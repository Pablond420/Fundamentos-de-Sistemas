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
    public class Ensamblador_Paso_1 : Gramatica_CalculadoraBaseListener
    {
        public static Ensamblador_Paso_1 INSTANCE = new Ensamblador_Paso_1();
        Tools tool = new Tools();
        int CP = 0;
        int linea = 1;
        bool repeatedSymbol = false;
        bool inst1 = false;
        bool inst2 = false;
        bool inst3 = false;
        bool is_byte = false;
        String tipo = "R";
        string byte_error = "";
        static string name_programa = "";
        static string size_program = "";
        String label = "";
        String error = "";
        String ins = "";
        String opIns = "";

        public static void setName(string name)
        {
            name_programa = name;
        }

        public static string getSize()
        {

            return size_program;
        }

        public void clearAll()
        {
            CP = 0;
            linea = 1;
            repeatedSymbol = false;
            inst1 = false;
            inst2 = false;
            inst3 = false;
            is_byte = false;
            byte_error = "";
            name_programa = "";
            label = "";
            error = "";
            ins = "";
            opIns = "";
            tool = new Tools();
        }

        /// <summary>
        /// INICIO
        /// </summary>
        /// <param name="context"></param>
        public override void ExitInicio([NotNull] Gramatica_CalculadoraParser.InicioContext context)
        {
            var dirInicial = "";
            if (context.NUM() != null)
            {
               dirInicial = context.NUM().GetText();
               CP += tool.HexToInt(dirInicial);
               WriteFile(tool.StrToIntToHex(CP.ToString()), context.etiqueta().GetText(), context.START().GetText(), dirInicial);
            }
            base.ExitInicio(context);
        }

        /// <summary>
        /// Nodos que contienen errores
        /// </summary>
        /// <param name="node"></param>
        public override void VisitErrorNode([NotNull] IErrorNode node)
        {
            error += node.GetText()+"\t";
            byte_error = node.Parent.GetText();
            if (byte_error.Contains("BYTE"))
                is_byte = true;
            
            base.VisitErrorNode(node);
        }

        /// <summary>
        /// Proposicion
        /// </summary>
        /// <param name="context"></param>
        public override void ExitProposicion([NotNull] Gramatica_CalculadoraParser.ProposicionContext context)
        {
            repeatedSymbol = false;
            if(error != "")
            {
                if (inst1)
                {
                    String line = linea.ToString("D3") + "\t" + tool.StrToIntToHex(CP.ToString()).PadLeft(5, '0') + "*" + "\t" + label + "\t" + ins + "\t" + error;
                    string directory = Directory.GetCurrentDirectory();
                    line = "'" + name_programa + "'" + "Error | linea " + linea + ": " + "Error de sintaxis";
                    using (StreamWriter file = new StreamWriter(directory + "Errores.err", true))
                    {
                        file.WriteLine(line);
                    }
                    using (StreamWriter file = new StreamWriter(directory + "ArchivoIntermedio.txt", true))
                    {
                        file.WriteLine(line);
                    }
                    linea++;
                }
                else if(inst2)
                {
                    String line = linea.ToString("D3") + "\t" + tool.StrToIntToHex(CP.ToString()) + "*" + "\t" + error;
                    string directory = Directory.GetCurrentDirectory();
                    line = "'" + name_programa + "'" + "Error | linea " + linea + ": " + "Error de sintaxis";
                    using (StreamWriter file = new StreamWriter(directory + "Errores.err", true))
                    {
                        file.WriteLine(line);
                    }
                    using (StreamWriter file = new StreamWriter(directory + "ArchivoIntermedio.txt", true))
                    {
                        file.WriteLine(line);
                    }
                    linea++;
                }
                else if (inst3)
                {
                    String line = linea.ToString("D3") + "\t" + tool.StrToIntToHex(CP.ToString()) + "*" + "\t" + error;
                    string directory = Directory.GetCurrentDirectory();
                    line = "'" + name_programa + "'" + "Error | linea " + linea + ": " + "Error de sintaxis";
                    using (StreamWriter file = new StreamWriter(directory + "Errores.err", true))
                    {
                        file.WriteLine(line);
                    }
                    using (StreamWriter file = new StreamWriter(directory + "ArchivoIntermedio.txt", true))
                    {
                        file.WriteLine(line);
                    }
                    linea++;
                }
                else
                {
                    if(is_byte)
                    {
                        byte_error = linea.ToString("D3") + "\t" + tool.StrToIntToHex(CP.ToString()) + "*\t" + byte_error;
                        byte_error = tool.StrToIntToHex(CP.ToString()) + "*\t" + byte_error;
                        byte_error = byte_error.Replace("\n", "");
                        string directory = Directory.GetCurrentDirectory();
                        String line = "'" + name_programa + "'" + "Error | linea " + linea + ": " + "Error de sintaxis";
                        using (StreamWriter file = new StreamWriter(directory + "Errores.err", true))
                        {
                            file.WriteLine(line);
                        }
                        using (StreamWriter file = new StreamWriter(directory + "ArchivoIntermedio.txt", true))
                        {
                            file.WriteLine(byte_error);
                        }
                        is_byte = false;
                        linea++;
                    }
                    else
                    {
                        if(context.instruccion() == null && context.directiva() == null)
                        {
                            //while(context.start.InputStream.[context.start] != '\n')
                        }
                        else
                        {
                            error = linea.ToString("D3") + "\t" + tool.StrToIntToHex(CP.ToString()) + "*\t" + error;
                            string directory = Directory.GetCurrentDirectory();
                            String line = "'" + name_programa + "'" + "Error | linea " + linea + ": " + "Error de sintaxis";
                            using (StreamWriter file = new StreamWriter(directory + "Errores.err", true))
                            {
                                file.WriteLine(line);
                            }
                            using (StreamWriter file = new StreamWriter(directory + "ArchivoIntermedio.txt", true))
                            {
                                file.WriteLine(error);
                            }
                            linea++;
                        }
                        
                    }
                    
                }
            }
            if(inst1 && error == "")
            {
                if (label != "")
                    WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()),tipo);
                if (repeatedSymbol)
                    WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                else
                    WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                CP += 1;
            }else if (inst2 && error == "")
            {
                if (label != "")
                    WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()), tipo);
                if (repeatedSymbol)
                    WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                else
                    WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                CP += 2;
            }
            //else
            //{
            //    WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
            //}
            error = "";
            ins = "";
            opIns = "";
            inst1 = false;
            inst2 = false;
            inst3 = false;
            is_byte = false;
            base.ExitProposicion(context);

        }

        /// <summary>
        /// Instruccion
        /// </summary>
        /// <param name="context"></param>
        public override void ExitInstruccion([NotNull] Gramatica_CalculadoraParser.InstruccionContext context)
        {
            label = context.etiqueta().GetText();
            var formato = context.opinstruccion().formato();

            if (formato.f1() != null)
            {
                inst1 = true;
                ins = formato.f1().COD_OP_F1().GetText();
               
            }
            else if (formato.f2() != null)
            {
                if(formato.f2().GetText() != "")
                {
                    inst2 = true;
                    ins = formato.f2().COD_OP_F2().GetText();
                    opIns = formato.f2().REG()[0].GetText();
                    if (formato.f2().COMA() != null)
                    {
                        if (formato.f2().NUM() != null)
                        {
                            opIns += "," + formato.f2().NUM().GetText();
                        }
                        else
                        {
                            opIns += "," + formato.f2().REG()[1].GetText();
                        }
                    }
                }
            }
            else if (formato.f3() != null)
            {
                formato3(context);
            }
            else
            {
                formato4(context);
            }
            
            base.ExitInstruccion(context);
        }

        /// <summary>
        /// Directiva
        /// </summary>
        /// <param name="context"></param>
        public override void ExitDirectiva([NotNull] Gramatica_CalculadoraParser.DirectivaContext context)
        {
            label = context.etiqueta().GetText();
            if (context.tipodirectiva() != null)
            {
                ins = context.tipodirectiva().GetText();
                if (context.tipodirectiva().GetText() == "WORD ")
                {
                    opIns = context.opdirectiva().expresion().GetText();
                    if (label != "")
                        WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()), tipo);
                    if (repeatedSymbol)
                        WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                    else
                        WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                    CP += 3;
                }
                else if (context.tipodirectiva().GetText() == "RESB ")
                {
                    opIns = context.opdirectiva().expresion().GetText();
                    if (label != "")
                        WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()), tipo);
                    if (repeatedSymbol)
                        WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                    else
                        WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                    CP += tool.HexToInt(context.opdirectiva().expresion().GetText());
                }
                else if (context.tipodirectiva().GetText() == "BYTE ")
                {
                    if (context.opdirectiva().CONSTHEX() != null)
                    {
                        opIns = context.opdirectiva().CONSTHEX().GetText();
                        char[] hex = context.opdirectiva().CONSTHEX().GetText().ToCharArray();
                        float nibble = ((float)hex.Length - 3) / 2;
                        int plus = (int)Math.Ceiling(nibble);
                        if (label != "")
                            WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()), tipo);
                        if (repeatedSymbol)
                            WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                        else
                            WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                        CP += plus;
                    }
                    else if (context.opdirectiva().CONSTCAD() != null)
                    {
                        opIns = context.opdirectiva().CONSTCAD().GetText();
                        char[] hex = context.opdirectiva().CONSTCAD().GetText().ToCharArray();
                        int plus = hex.Length - 3;
                        if (label != "")
                            WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()), tipo);
                        if (repeatedSymbol)
                            WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                        else
                            WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                        CP += plus;
                    }

                }
                else if (context.tipodirectiva().GetText() == "RESW ")
                {
                    opIns = context.opdirectiva().expresion().GetText();
                    if (label != "")
                        WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()), tipo);
                    if (repeatedSymbol)
                        WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                    else
                        WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                    CP += (tool.HexToInt(context.opdirectiva().expresion().NUM().GetText()) * 3);
                }
                else if (context.tipodirectiva().GetText() == "BASE ")
                {
                    opIns = context.opdirectiva().expresion().GetText();
                    if (label != "")
                        WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()), tipo);
                    if (repeatedSymbol)
                        WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                    else
                        WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                }
                else if(context.tipodirectiva().GetText() == "ORG ")
                {
                    opIns = context.opdirectiva().expresion().GetText();
                    if (label != "")
                        WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()), tipo);
                    if (repeatedSymbol)
                        WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                    else
                        WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                    string aux = tool.HexToInt(opIns).ToString();
                    CP = Int32.Parse(aux);
                }
                var opDir = context.opdirectiva();
            }else
            {
                if(context.direqu() != null)
                {
                    ins = "EQU ";
                    if (context.direqu().expresion() != null)
                        opIns = context.direqu().expresion().GetText();
                    else
                        opIns = "*";
                    if (label != "" && opIns == "*")
                    {
                        WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()), tipo);
                        if (repeatedSymbol)
                            WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                        else
                            WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                    }
                    else if (label != "")
                    {
                        double res_exp = 0;
                        String str = "";
                        switch (tool.Calculate_expression(opIns, 1))
                        {
                            case -1: // expresion no es valida
                                tipo = "A";
                                WriteFileTabSim(label, "FFFF", tipo);
                                WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                                tipo = "R";
                                //error
                                break;
                            case 0: // es valida absoluta sin expresion
                                tipo = "A";
                                str = tool.StrToIntToHex(tool.HexToInt(opIns).ToString());
                                WriteFileTabSim(label, str, tipo);
                                if (repeatedSymbol)
                                    WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                                else
                                    WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                                tipo = "R";
                                break;
                            case 1: // es valida absoluta
                                res_exp = tool.value_expr;
                                tipo = "A";
                                str = tool.StrToIntToHex(tool.HexToInt(res_exp.ToString()).ToString());
                                WriteFileTabSim(label, str, tipo);
                                if (repeatedSymbol)
                                    WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                                else
                                    WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                                tipo = "R";

                                break;
                            case 2: // es valida relativa
                                res_exp = tool.value_expr;
                                str = tool.StrToIntToHex(tool.HexToInt(res_exp.ToString()).ToString());
                                WriteFileTabSim(label, str, tipo);
                                if (repeatedSymbol)
                                    WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                                else
                                    WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                                break;
                        }
                    }
                }
                    

            }
            base.ExitDirectiva(context);
        }

        /// <summary>
        /// Fin
        /// </summary>
        /// <param name="context"></param>
        public override void ExitFin([NotNull] Gramatica_CalculadoraParser.FinContext context)
        {
            label = "";
            ins = "END";
            opIns = context.entrada().GetText();
            WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
            size_program = tool.StrToIntToHex(CP.ToString());
            String line =  "*Tamaño del programa: " + size_program + "H";
            string directory = Directory.GetCurrentDirectory();
            using (StreamWriter file = new StreamWriter(directory + "TABSIM.txt", true))
            {
                file.WriteLine(line);
            }
            tool.paso1 = true;
            base.ExitFin(context);
        }

        /// <summary>
        /// Etiqueta
        /// </summary>
        /// <param name="context"></param>
        public override void ExitEtiqueta([NotNull] Gramatica_CalculadoraParser.EtiquetaContext context)
        {
            //Guardar las etiquetas
            var etiq = context.GetText();
            base.ExitEtiqueta(context);
        }

        /// <summary>
        /// OpDirectiva
        /// </summary>
        /// <param name="context"></param>
        public override void ExitOpdirectiva([NotNull] Gramatica_CalculadoraParser.OpdirectivaContext context)
        {
            var opDir = context.GetText();
            base.ExitOpdirectiva(context);
        }

        /// <summary>
        /// Escribe el archivo intermedio
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="label"></param>
        /// <param name="instruc"></param>
        /// <param name="op"></param>
        public void WriteFile(String cp, String label, String instruc, String op)
        {
            String line = linea.ToString("D3") + "\t" + (cp.Contains("*") ? cp.PadLeft(5, '0') :  cp.PadLeft(4, '0')) + "\t" + label + "\t" + instruc + "\t" + op;
            string directory = Directory.GetCurrentDirectory();
            using (StreamWriter file = new StreamWriter(directory + "ArchivoIntermedio.txt", true))
            {
                file.WriteLine(line);
            }
            
            if (repeatedSymbol && cp.Contains("*"))
            {
                line = "'" + name_programa + "'" + "Error | linea " + linea + ": " + "Símbolo duplicado";
                using (StreamWriter file = new StreamWriter(directory + "Errores.err", true))
                {
                    file.WriteLine(line);
                }
            }
            linea++;
        }

        /// <summary>
        /// Escribe el archivo de la tabla de simbolos
        /// </summary>
        /// <param name="symb"></param>
        /// <param name="dir"></param>
        public void WriteFileTabSim(String symb, String dir, String tipo)
        {
            // String line = "Simbolo" + "    Direccion";
            String line = symb + "\t" + dir + "\t" + tipo;
            string directory = Directory.GetCurrentDirectory();
            string path = directory + "TABSIM.txt";
            if (File.Exists(path))
            {
                String text = File.ReadAllText(directory + "TABSIM.txt");
                if (!text.Contains(symb))
                {
                    using (StreamWriter file = new StreamWriter(directory + "TABSIM.txt", true))
                    {
                        file.WriteLine(line);
                    }
                }
                else
                {
                    repeatedSymbol = true;
                }
            }
        }

        /// <summary>
        /// Manejador de instrucciones de formato 3
        /// </summary>
        /// <param name="context"></param>
        public void formato3([NotNull] Gramatica_CalculadoraParser.InstruccionContext context)
        {
            var formato = context.opinstruccion().formato();
            if (formato.f3().simple3() != null)
            {
                ins = formato.f3().simple3().COD_OP_F3().GetText();
                if(formato.f3().simple3().expresion() != null)
                {
                    opIns += formato.f3().simple3().expresion().GetText();
                }
                else if (formato.f3().simple3().MEM_DIR() != null)
                {
                    if (formato.f3().simple3().REG() != null)
                    {
                        opIns += formato.f3().simple3().MEM_DIR().GetText() + "," + formato.f3().simple3().REG().GetText();
                    }
                    else
                    {
                        opIns += formato.f3().simple3().MEM_DIR().GetText();
                    }
                }
                else
                {
                    if (formato.f3().simple3().REG() != null)
                    {
                        opIns += formato.f3().simple3().NUM().GetText() + "," + formato.f3().simple3().REG().GetText();
                    }
                    else
                    {
                        opIns += formato.f3().simple3().NUM().GetText();
                    }
                }

            }
            else if (formato.f3().indirecto3() != null)
            {
                ins = formato.f3().indirecto3().COD_OP_F3().GetText();
                if (formato.f3().indirecto3().expresion() != null)
                {
                    opIns += "@" + formato.f3().indirecto3().expresion().GetText();
                }
            }
            else if (formato.f3().inmediato3() != null)
            {
                
                ins = formato.f3().inmediato3().COD_OP_F3().GetText();
                if (formato.f3().inmediato3().expresion() != null)
                {
                    opIns += "#" + formato.f3().inmediato3().expresion().GetText();
                }
            }else
            {
                ins = formato.f3().RSUB().GetText();
                opIns = "";
            }
            if (label != "")
                WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()),tipo);
            if (repeatedSymbol)
                WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
            else
                WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
            CP += 3;
        }

        /// <summary>
        /// Manejador de instrucciones de formato 4
        /// </summary>
        /// <param name="context"></param>
        public void formato4([NotNull] Gramatica_CalculadoraParser.InstruccionContext context)
        {
            var formato = context.opinstruccion().formato();
            if (formato.f4().f3().simple3() != null)
            {
                ins = "+" + formato.f4().f3().simple3().COD_OP_F3().GetText();
                if (formato.f4().f3().simple3().expresion() != null)
                {
                    opIns += formato.f4().f3().simple3().expresion().GetText();
                }
                else if (formato.f4().f3().simple3().MEM_DIR() != null)
                {
                    if (formato.f4().f3().simple3().REG() != null)
                    {
                        opIns += formato.f4().f3().simple3().MEM_DIR() +"," + formato.f4().f3().simple3().REG().GetText();
                    }
                    else
                    {
                        opIns += formato.f4().f3().simple3().MEM_DIR().GetText();
                    }
                }
                else
                {
                    if (formato.f4().f3().simple3().REG() != null)
                    {
                        opIns += formato.f4().f3().simple3().NUM().GetText() + "," + formato.f4().f3().simple3().REG().GetText();
                    }
                    else
                    {
                        opIns += formato.f4().f3().simple3().NUM().GetText();
                    }
                }

            }
            else if (formato.f4().f3().indirecto3() != null)
            {
                ins = "+" + formato.f4().f3().indirecto3().COD_OP_F3().GetText();
                opIns += formato.f4().f3().indirecto3().expresion().GetText();
                //if (formato.f4().f3().indirecto3().expresion().MEM_DIR() != null)
                //{
                //    opIns += "@" + formato.f4().f3().indirecto3().expresion().MEM_DIR().GetText();
                //}
                //else
                //{
                //    opIns += "@" + formato.f4().f3().indirecto3().expresion().NUM().GetText();
                //}
            }
            else
            {
                ins = "+" + formato.f4().f3().inmediato3().COD_OP_F3().GetText();
                opIns += formato.f4().f3().inmediato3().expresion().GetText();
                //if (formato.f4().f3().inmediato3().expresion().MEM_DIR() != null)
                //{
                //    opIns += "#" + formato.f4().f3().inmediato3().expresion().MEM_DIR().GetText();
                //}
                //else
                //{
                //    opIns += "#" + formato.f4().f3().inmediato3().expresion().NUM().GetText();
                //}
            }
            if (label != "")
                WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()), tipo);
            if (repeatedSymbol)
                WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
            else
                WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
            CP += 4;
        }
    }
}
