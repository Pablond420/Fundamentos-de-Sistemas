using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Antlr4;
using Antlr4.Runtime;

namespace Calculadora
{
    public partial class Interfaz_Grafica : Form
    {
        string texto = "";
        string line = "";
        string name_program = "";
        string directory = Directory.GetCurrentDirectory();
        string entrada = "";
        public string size_program = "";
        bool clearAll = true;
        public string namep = "";

        Tools t = new Tools();
        

        public Interfaz_Grafica()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t.is_newFile = true;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XE Files|*.xe";
            saveFileDialog1.Title = "Crear nuevo archivo";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                fs.Close();
                name_program = Path.GetFileName(saveFileDialog1.FileName);
                Ensamblador_Paso_1.setName(name_program);
                Ensamblador_Paso_2.setName(name_program);
                
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataErrores.Text = "";
            dataTabSim.Text = "";
            dataArchInt.Text = "";
            dataObjProg.Text = "";
            dataSourceProgram.Text = "";
            t.tabsim = "";
            t.errors = "";
            t.arch_intermed = "";
            t.object_program = "";

            this.openFileDialog1 = new OpenFileDialog();
            this.openFileDialog1.ShowDialog();
            name_program = openFileDialog1.SafeFileName;

            Ensamblador_Paso_1.setName(name_program);
            Ensamblador_Paso_2.setName(name_program);
            line = openFileDialog1.FileName;
            
            if(line != "")
            {
                string[] dataFuente = File.ReadAllLines(line);
                foreach (string str in dataFuente)
                {
                    texto += str + "\r\n";
                }
                dataSourceProgram.Text = texto;

                entrada = File.ReadAllText(line);
                entrada = entrada.Replace("\r", string.Empty);
            }
        }

        private void LexyaccToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lexyacc();

            string[] _errors = File.ReadAllLines(directory + "Errores.err");
            foreach (string str in _errors)
                t.errors += str + "\r\n";

            dataErrores.Text = t.errors;
        }

        private void paso1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataErrores.Text = "";
            dataTabSim.Text = "";
            dataArchInt.Text = "";
            dataObjProg.Text = "";
            t.tabsim = "";
            t.errors = "";
            t.arch_intermed = "";
            t.object_program = "";
            string[] _tabsim = File.ReadAllLines(directory + "TABSIM.txt");
            foreach (string str in _tabsim)
                t.tabsim += str + "\r\n";

            string[] _errors = File.ReadAllLines(directory + "Errores.err");
            foreach (string str in _errors)
                t.errors += str + "\r\n";

            string[] _archInterm = File.ReadAllLines(directory + "ArchivoIntermedio.txt");
            foreach (string str in _archInterm)
                t.arch_intermed += str + "\r\n";

            dataErrores.Text = t.errors;
            dataTabSim.Text = t.tabsim;
            dataArchInt.Text = t.arch_intermed;
            paso2ToolStripMenuItem.Enabled = true;
        }

        void paso1()
        {
            dataErrores.Text = "";
            dataTabSim.Text = "";
            dataArchInt.Text = "";
            dataObjProg.Text = "";
            t.tabsim = "";
            t.errors = "";
            t.arch_intermed = "";
            t.object_program = "";
            string[] _tabsim = File.ReadAllLines(directory + "TABSIM.txt");
            foreach (string str in _tabsim)
                t.tabsim += str + "\r\n";

            string[] _errors = File.ReadAllLines(directory + "Errores.err");
            foreach (string str in _errors)
                t.errors += str + "\r\n";

            string[] _archInterm = File.ReadAllLines(directory + "ArchivoIntermedio.txt");
            foreach (string str in _archInterm)
                t.arch_intermed += str + "\r\n";

            dataErrores.Text = t.errors;
            dataTabSim.Text = t.tabsim;
            dataArchInt.Text = t.arch_intermed;
            paso2ToolStripMenuItem.Enabled = true;
        }

        void paso2()
        {
            dataErrores.Text = "";
            dataTabSim.Text = "";
            dataArchInt.Text = "";
            dataObjProg.Text = "";
            t.tabsim = "";
            t.errors = "";
            t.arch_intermed = "";
            t.object_program = "";
            if (dataSourceProgram.Text != "")
            {
                Ensamblador_Paso_2.INSTANCE.CodigoObjeto();
                // Ensamblador_Paso_2.INSTANCE.namep = Ensamblador_Paso_1.INSTANCE.namep;

                string[] _tabsim = File.ReadAllLines(directory + "TABSIM.txt");
                foreach (string str in _tabsim)
                    t.tabsim += str + "\r\n";

                string[] _errors = File.ReadAllLines(directory + "Errores.err");
                foreach (string str in _errors)
                    t.errors += str + "\r\n";

                string[] _archInterm = File.ReadAllLines(directory + "ArchivoIntermedioCodObj.txt");
                foreach (string str in _archInterm)
                    t.arch_intermed += str + "\r\n";

                string[] _progObj = File.ReadAllLines(directory + "ProgramaObjeto.txt");
                foreach (string str in _progObj)
                    t.object_program += str + "\r\n";

                dataErrores.Text = t.errors;
                dataTabSim.Text = t.tabsim;
                dataArchInt.Text = t.arch_intermed;
                dataObjProg.Text = t.object_program;
            }
        }

        private void paso2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataErrores.Text = "";
            dataTabSim.Text = "";
            dataArchInt.Text = "";
            dataObjProg.Text = "";
            t.tabsim = "";
            t.errors = "";
            t.arch_intermed = "";
            t.object_program = "";
            if (dataSourceProgram.Text != "")
            {
                Ensamblador_Paso_2.INSTANCE.CodigoObjeto();

                string[] _tabsim = File.ReadAllLines(directory + "TABSIM.txt");
                foreach (string str in _tabsim)
                    t.tabsim += str + "\r\n";

                string[] _errors = File.ReadAllLines(directory + "Errores.err");
                foreach (string str in _errors)
                    t.errors += str + "\r\n";

                string[] _archInterm = File.ReadAllLines(directory + "ArchivoIntermedioCodObj.txt");
                foreach (string str in _archInterm)
                    t.arch_intermed += str + "\r\n";

                string[] _progObj = File.ReadAllLines(directory + "ProgramaObjeto.txt");
                foreach (string str in _progObj)
                    t.object_program += str + "\r\n";

                dataErrores.Text = t.errors;
                dataTabSim.Text = t.tabsim;
                dataArchInt.Text = t.arch_intermed;
                dataObjProg.Text = t.object_program;
            }
            
        }

        void resetTextBoxAndFiles()
        {
            File.WriteAllText(directory + "Errores.err", string.Empty);
            File.WriteAllText(directory + "TABSIM.txt", string.Empty);
            File.WriteAllText(directory + "ArchivoIntermedioCodObj.txt", string.Empty);
            File.WriteAllText(directory + "ArchivoIntermedio.txt", string.Empty);
            File.WriteAllText(directory + "ProgramaObjeto.txt", string.Empty);

            t.arch_intermed = "";
            t.errors = "";
            t.object_program = "";
            t.tabsim = "";

            Ensamblador_Paso_1.INSTANCE.clearAll();
            Ensamblador_Paso_2.INSTANCE.clearAll();

            dataErrores.Text = "";
            dataTabSim.Text = "";
            dataArchInt.Text = "";
            dataObjProg.Text = "";
            size_program = "";
        }

        void lexyacc()
        {
            Gramatica_CalculadoraLexer lex = new Gramatica_CalculadoraLexer(new AntlrInputStream(entrada + Environment.NewLine));
            //CREAMOS UN LEXER CON LA CADENA QUE ESCRIBIO EL USUARIO
            lex.RemoveErrorListeners();
            lex.AddErrorListener(DescriptiveErrorListener.INSTANCE);

            CommonTokenStream tokens = new CommonTokenStream(lex);
            //CREAMOS LOS TOKENS SEGUN EL LEXER CREADO
            Gramatica_CalculadoraParser parser = new Gramatica_CalculadoraParser(tokens);
            //Agregar el Listener del Parser para control del contador de programa, archivo intermedio y TABSIM
            parser.AddParseListener(Ensamblador_Paso_1.INSTANCE);
            size_program = Ensamblador_Paso_1.getSize();
            parser.RemoveErrorListeners();
            parser.AddErrorListener(DescriptiveErrorListenerTk.INSTANCE);

            //CREAMOS EL PARSER CON LOS TOKENS CREADOS
            try
            {
                parser.programa();
                //SE VERIFICA QUE EL ANALIZADOR EMPIECE CON LA EXPRESION
            }
            catch (RecognitionException ex)
            {
                Console.Error.WriteLine(ex);
                Console.Error.WriteLine(ex.StackTrace);
            }
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            name_program = "";
            resetTextBoxAndFiles();
            dataErrores.Text = "";
            dataTabSim.Text = "";
            dataArchInt.Text = "";
            dataObjProg.Text = "";
            dataSourceProgram.Text = "";
        }

        private void Interfaz_Grafica_Load(object sender, EventArgs e)
        {
            resetTextBoxAndFiles();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (t.is_newFile)
            {
                string source = dataSourceProgram.Text;
                string new_source = getTextFromDataSourcePrg(dataSourceProgram.Text);
                File.WriteAllText(directory + name_program, new_source);
            }
        }

        private void dataSourceProgram_TextChanged(object sender, EventArgs e)
        {
            if (name_program != "")
            {
                File.WriteAllText(directory + "\\" + name_program, getTextFromDataSourcePrg(dataSourceProgram.Text));
                entrada = File.ReadAllText(directory + "\\"+ name_program);
                entrada = entrada.Replace("\r", string.Empty);
            }
        }

        string getTextFromDataSourcePrg(string source)
        {
            char old_char = '*';
            string new_source = "";
            bool text_found = false;
            foreach (char c in source)
            {
                if (c != '\n' && old_char == '\n' && !text_found)
                    text_found = true;
                if (text_found)
                    new_source += c;
                old_char = c;
            }
            return new_source;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(directory + name_program, getTextFromDataSourcePrg(dataSourceProgram.Text));
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ensamblarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lexyacc();
            paso1(); ;
            paso2();
        }

        private void cargadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapaMemoria mapa = new MapaMemoria();
            if (dataObjProg.Text != "")
                mapa.cargar(dataObjProg.Text, searchSizeTabsim(), "000000");
            mapa.Show();
        }


        int searchSizeTabsim()
        {
            string res = "";
            string directory = Directory.GetCurrentDirectory();
            string text_tab_sim = File.ReadAllText(directory + "TABSIM.txt");
            string[] lines_tab_sim = File.ReadAllLines(directory + "TABSIM.txt");
            foreach (string line in lines_tab_sim)
            {
                if (line.Contains("Tamaño del programa"))
                {
                    bool flag = false;
                    for(int i = 0; i<line.Length; i++)
                    {
                        if (line.Substring(i, 1) == ":")
                        {
                            flag = true;
                            continue;
                        }
                        if (flag)
                            res += line.Substring(i, 1);

                    }
                    break;
                }
            }
            res = res.Replace(" ", "");
            int numres = t.HexToInt(res);
            return numres;
            
        }
    }
}
