using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calculadora
{
    public class Tools
    {
        public static Tools tools = new Tools();
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

        public void WriteFileObj(int linea, String cp, String label, String instruc, String op, String codObj)
        {

            String line = linea.ToString() + "\t" + (cp.Contains("*") ? cp.PadLeft(5, '0') : cp.PadLeft(4, '0')) + "\t" + label + "\t" + instruc + "\t" + op + "\t" + codObj;
            string directory = Directory.GetCurrentDirectory();
            using (StreamWriter file = new StreamWriter(directory + "ArchivoIntermedioCodObj.txt", true))
            {
                file.WriteLine(line);
            }
            linea++;
        }
    }
}
