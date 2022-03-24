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
            if(diff < 0)
                res = source.Remove(0, Math.Abs(diff));
            else
                res = source.PadLeft(num_bytes, '0');
            return res;
        }
    }
}
