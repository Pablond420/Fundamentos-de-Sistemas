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
        string byte_error = "";
        String label = "";
        String error = "";
        String ins = "";
        String opIns = "";

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
                        byte_error = linea.ToString("D3") + "\t" + tool.StrToIntToHex(CP.ToString()) + "*\t" + byte_error; byte_error = tool.StrToIntToHex(CP.ToString()) + "*\t" + byte_error;
                        byte_error = byte_error.Replace("\n", "");
                        string directory = Directory.GetCurrentDirectory();
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
                    WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()));
                if (repeatedSymbol)
                    WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                else
                    WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                CP += 1;
            }else if (inst2 && error == "")
            {
                if (label != "")
                    WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()));
                if (repeatedSymbol)
                    WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                else
                    WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                CP += 2;
            }
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
            ins = context.tipodirectiva().GetText();
            if(context.tipodirectiva().GetText() == "WORD ")
            {
                opIns = context.opdirectiva().NUM().GetText();
                if (label != "")
                    WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()));
                if (repeatedSymbol)
                    WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                else
                    WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                CP += 3;
            }else if (context.tipodirectiva().GetText() == "RESB ")
            {
                opIns = context.opdirectiva().NUM().GetText();
                if (label != "")
                    WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()));
                if (repeatedSymbol)
                    WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                else
                    WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                CP += tool.HexToInt(context.opdirectiva().NUM().GetText());
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
                        WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()));
                    if (repeatedSymbol)
                        WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                    else
                        WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                    CP += plus;
                }
                else if(context.opdirectiva().CONSTCAD() != null)
                {
                    opIns = context.opdirectiva().CONSTCAD().GetText();
                    char[] hex = context.opdirectiva().CONSTCAD().GetText().ToCharArray();
                    int plus = hex.Length - 3;
                    if (label != "")
                        WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()));
                    if (repeatedSymbol)
                        WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                    else
                        WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                    CP += plus;
                }
                
            }
            else if (context.tipodirectiva().GetText() == "RESW ")
            {
                opIns = context.opdirectiva().NUM().GetText();
                if (label != "")
                    WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()));
                if (repeatedSymbol)
                    WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                else
                    WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
                CP += (tool.HexToInt(context.opdirectiva().NUM().GetText()) * 3);
            }
            else if (context.tipodirectiva().GetText() == "BASE ")
            {
                opIns = context.opdirectiva().MEM_DIR().GetText();
                if (label != "")
                    WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()));
                if (repeatedSymbol)
                    WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
                else
                    WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
            }

        var opDir = context.opdirectiva();
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
            String line =  "*Tamaño del programa: " + tool.StrToIntToHex(CP.ToString()) + "H";
            string directory = Directory.GetCurrentDirectory();
            using (StreamWriter file = new StreamWriter(directory + "TABSIM.txt", true))
            {
                file.WriteLine(line);
            }
            Ensamblador_Paso_2.INSTANCE.CodigoObjeto();
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
            linea++;
        }

        /// <summary>
        /// Escribe el archivo de la tabla de simbolos
        /// </summary>
        /// <param name="symb"></param>
        /// <param name="dir"></param>
        public void WriteFileTabSim(String symb, String dir)
        {
            // String line = "Simbolo" + "    Direccion";
            String line = symb + "\t" + dir;
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
                if (formato.f3().simple3().MEM_DIR() != null)
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
                if (formato.f3().indirecto3().MEM_DIR() != null)
                {
                    opIns += "@" + formato.f3().indirecto3().MEM_DIR().GetText();
                }
                else
                {
                    opIns += "@" + formato.f3().indirecto3().NUM().GetText();
                }
            }
            else if (formato.f3().inmediato3() != null)
            {
                
                ins = formato.f3().inmediato3().COD_OP_F3().GetText();
                if (formato.f3().inmediato3().MEM_DIR() != null)
                {
                    opIns += "#" + formato.f3().inmediato3().MEM_DIR().GetText();
                }
                else
                {
                    opIns += "#" + formato.f3().inmediato3().NUM().GetText();
                }
            }else
            {
                ins = formato.f3().RSUB().GetText();
                opIns = "";
            }
            if (label != "")
                WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()));
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
                if (formato.f4().f3().simple3().MEM_DIR() != null)
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
                if (formato.f4().f3().indirecto3().MEM_DIR() != null)
                {
                    opIns += "@" + formato.f4().f3().indirecto3().MEM_DIR().GetText();
                }
                else
                {
                    opIns += "@" + formato.f4().f3().indirecto3().NUM().GetText();
                }
            }
            else
            {
                ins = "+" + formato.f4().f3().inmediato3().COD_OP_F3().GetText();
                if (formato.f4().f3().inmediato3().MEM_DIR() != null)
                {
                    opIns += "#" + formato.f4().f3().inmediato3().MEM_DIR().GetText();
                }
                else
                {
                    opIns += "#" + formato.f4().f3().inmediato3().NUM().GetText();
                }
            }
            if (label != "")
                WriteFileTabSim(label, tool.StrToIntToHex(CP.ToString()));
            if (repeatedSymbol)
                WriteFile(tool.StrToIntToHex(CP.ToString()) + "*", label, ins, opIns);
            else
                WriteFile(tool.StrToIntToHex(CP.ToString()), label, ins, opIns);
            CP += 4;
        }
    }
}
