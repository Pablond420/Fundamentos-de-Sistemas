using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace Calculadora
{
    public class DescriptiveErrorListener : IAntlrErrorListener<int>
    {
        public static DescriptiveErrorListener INSTANCE = new DescriptiveErrorListener();

        public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] int offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            string directory = Directory.GetCurrentDirectory();
            Console.WriteLine("Error del Lexer " + msg + " en la linea: " + line + " en la posición " + charPositionInLine);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(directory + "Errores.err", true))
            {
                file.WriteLine("Error del Lexer " + msg + " en la linea: " + line + " en la posición " + charPositionInLine);
            }

        }
    }

    public class DescriptiveErrorListenerTk : IAntlrErrorListener<IToken>
    {
        public static DescriptiveErrorListenerTk INSTANCE = new DescriptiveErrorListenerTk();

        public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] IToken offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            string directory = Directory.GetCurrentDirectory();
            //String linea = "";
            //if (msg.Contains("no viable alternative at input"))
            //{
            //    linea = "Error Instrucción no existe en la linea: " + line + " en la posición " + charPositionInLine;
            //    Console.WriteLine(linea);
            //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(directory + "Errores.err", true))
            //    {
            //        file.WriteLine(linea);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Error del Parser " + msg + " en la linea: " + line + " en la posición " + charPositionInLine);
            //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(directory + "Errores.err", true))
            //    {
            //        file.WriteLine("Error del Parser " + msg + " en la linea: " + line + " en la posición " + charPositionInLine);
            //    }
            //}
            Console.WriteLine("Error del Parser " + msg + " en la linea: " + line + " en la posición " + charPositionInLine);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(directory + "Errores.err", true))
            {
                file.WriteLine("Error del Parser " + msg + " en la linea: " + line + " en la posición " + charPositionInLine);
            }

        }
    }
}
