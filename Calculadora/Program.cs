using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4;
using Antlr4.Runtime;

namespace Calculadora
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Interfaz_Grafica app = new Interfaz_Grafica();
            app.ShowDialog();
            //string line = "";
            //Convert.ToDecimal(8);

            ////VARIABLE PARA ALMACENAR LA CADENA DE ENTRADA
            //while (true)
            //{
            //    Console.WriteLine("Introduzca nombre del archivo: ");
            //    line = Console.ReadLine();
            //    Ensamblador_Paso_2.setName(line);
            //    Ensamblador_Paso_1.setName(line);
            //    string entrada = File.ReadAllText(line + ".xe");
            //    entrada = entrada.Replace("\r", string.Empty);
            //    Console.WriteLine(entrada);
            //    //line = Console.ReadLine();
            //    //SE ALMACENA LA CADENA DE ENTRADA
            //    if (entrada.Contains("EXIT") || entrada.Contains("exit"))
            //        //SI DETECTA EXIT SALE DEL PROGRAMA
            //        break;
            //    Gramatica_CalculadoraLexer lex = new Gramatica_CalculadoraLexer(new AntlrInputStream(entrada + Environment.NewLine));
            //    //CREAMOS UN LEXER CON LA CADENA QUE ESCRIBIO EL USUARIO
            //    lex.RemoveErrorListeners();
            //    lex.AddErrorListener(DescriptiveErrorListener.INSTANCE);

            //    CommonTokenStream tokens = new CommonTokenStream(lex);
            //    //CREAMOS LOS TOKENS SEGUN EL LEXER CREADO
            //    Gramatica_CalculadoraParser parser = new Gramatica_CalculadoraParser(tokens);

            //    //Agregar el Listener del Parser para control del contador de programa, archivo intermedio y TABSIM
            //    parser.AddParseListener(Ensamblador_Paso_1.INSTANCE);

            //    parser.RemoveErrorListeners();
            //    parser.AddErrorListener(DescriptiveErrorListenerTk.INSTANCE);

            //    //CREAMOS EL PARSER CON LOS TOKENS CREADOS
            //    try
            //    {
            //        parser.programa();
            //        //SE VERIFICA QUE EL ANALIZADOR EMPIECE CON LA EXPRESION
            //    }
            //    catch (RecognitionException e)
            //    {
            //        Console.Error.WriteLine(e);
            //        Console.Error.WriteLine(e.StackTrace);
            //    }
            //}
        }
    }


}
