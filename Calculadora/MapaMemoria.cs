using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class MapaMemoria : Form
    {
        int tam;
        string tamHex;
        string dirCargaHex;
        bool stop = false;
        string programaObj;

        public MapaMemoria()
        {
            InitializeComponent();
        }

        public void cargar(string progObj, int tamArch)
        {
            string[] registros = progObj.Split('\n');
            string dirCarga = registros[0].Substring(7, 6);

            programaObj = progObj;
            dirCargaHex = dirCarga;
            tam = tamArch;
            tamHex = tamArch.ToString("X");

            initDirecciones(dirCarga);

            for (int i = 1; i < registros.Length - 1; i++)
            {
                dirCarga = registros[i].Substring(1, 6);
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    string dirT = dataGridView1.Rows[j].Cells[0].Value.ToString().PadLeft(6, '0').Substring(0, 5);
                    if (dirT == dirCarga.Substring(0, 5))
                    {
                        int ultimo = Convert.ToInt32(dirCarga.Last().ToString(), 16);
                        for (int k = 9; k < registros[i].Length - 1; k += 2)
                        {
                            if (ultimo < 16)
                            {
                                dataGridView1.Rows[j].Cells[ultimo + 1].Value = registros[i].Substring(k, 2);
                                ultimo++;
                            }
                            else
                            {
                                ultimo = 0;
                                j++;
                                dataGridView1.Rows[j].Cells[ultimo + 1].Value = registros[i].Substring(k, 2);
                                ultimo++;
                            }
                        }

                        break;
                    }
                }

            }

            initRegistros();
            initgeneral();
        }

        public void initDirecciones(string dirCarga)
        {
            dirCarga = dirCarga.Substring(0, 5) + "0";
            int dir = Convert.ToInt32(dirCarga, 16);
            int ultimaDir = tam + dir + 10;
            for (int i = dir; i < ultimaDir; i += 16)
            {
                dataGridView1.Rows.Add(dirCarga.PadLeft(6, '0'), "FF ", "FF ", "FF ", "FF ", "FF ", "FF ", "FF ", "FF ", "FF ", "FF ", "FF ", "FF ", "FF ", "FF ", "FF ", "FF ");
                dirCarga = (Convert.ToInt32(dirCarga, 16) + 16).ToString("X");
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            System.IO.StreamReader file = null;
            string filePath = "";
            string linea = "";
            string progObj = "";
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Programa Objeto (*.obj)|*.obj";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                    }
                }
                file = new System.IO.StreamReader(filePath);
                while ((linea = file.ReadLine()) != null)
                {
                    progObj += linea + '\n';
                }
                file.Close();

                cargar(progObj, Convert.ToInt32(progObj.Substring(13, 6).ToString(), 16));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Archivo inexistente");
            }
        }

        private void initRegistros()
        {
            dataGridView2.Rows.Add("CP", dirCargaHex);
            dataGridView2.Rows.Add("A", "FFFFFF");
            dataGridView2.Rows.Add("X", "FFFFFF");
            dataGridView2.Rows.Add("L", "FFFFFF");
            dataGridView2.Rows.Add("SW", "FFFFFF");
        }

        private void initgeneral()
        {
            txtDirCarga.Text = dirCargaHex.PadLeft(6, '0');
            txtLong.Text = tamHex.ToString().PadLeft(6, '0');
        }

        private void ejecutarLinea()
        {
            for (int i = 0; i < Int32.Parse(numLineas.Value.ToString()); i++)
            {
                if (stop)
                {
                    break;
                }
                else
                {
                    //Se conoce el valor del contador
                    string CPHex = dataGridView2.Rows[0].Cells[1].Value.ToString();
                    int CP = Convert.ToInt32(CPHex, 16);
                    //3 primeros digitos del CP
                    string dirCP1 = CPHex.Substring(0, 5);
                    //Ultimo digito del CP
                    string dirCP2 = CPHex.Substring(5, 1);
                    int indexCell = Convert.ToInt32(dirCP2, 16) + 1;

                    //Se leen 3 bytes
                    string instruccion = get3Bytes(dirCP1, indexCell);

                    //Se actualiza el valor del CP
                    string CPHexAux = CPHex;
                    CP += 3;
                    CPHex = CP.ToString("X").PadLeft(6, '0');
                    dataGridView2.Rows[0].Cells[1].Value = CPHex;

                    //Se interpreta la instruccion
                    string codOp = instruccion.Substring(0, 2);
                    string nemonico = getNemonico(codOp);
                    string efecto = getEfecto(codOp);
                    string operando = instruccion.Substring(2, 4);
                    string modDir = getModDir(operando.Substring(0, 1));

                    if (nemonico != "")
                        dataGridView3.Rows.Add(CPHexAux, nemonico, codOp, modDir, operando, efecto);

                    //Se aplica el efecto
                    operando = modDir == "INDEXADO" ? restaHEX(sumaHEX(operando, dataGridView2.Rows[2].Cells[1].Value.ToString()), "8000") : operando;
                    aplicarEfecto(codOp, operando);
                }
            }
            if (stop)
            {
                MessageBox.Show("TERMINA EJECUCION");
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            //ejecutarLinea();
        }

        private string sumaHEX(string HEX1, string HEX2)
        {
            return (Convert.ToInt32(HEX1, 16) + Convert.ToInt32(HEX2, 16)).ToString("X");
        }

        private string restaHEX(string HEX1, string HEX2)
        {
            return (Convert.ToInt32(HEX1, 16) - Convert.ToInt32(HEX2, 16)).ToString("X");
        }

        private string compHEX(string HEX1, string HEX2)
        {
            string res = "";
            if (Convert.ToInt32(HEX1, 16) > Convert.ToInt32(HEX2, 16))
                res = ">";
            else if (Convert.ToInt32(HEX1, 16) < Convert.ToInt32(HEX2, 16))
                res = "<";
            else
                res = "=";

            return res;
        }

        private string get3Bytes(string dirCP1, int indexCell)
        {
            string instruccion = "";
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string currentDir = dataGridView1.Rows[i].Cells[0].Value.ToString();

                    if (currentDir.Substring(0, 5) == dirCP1)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            instruccion += dataGridView1.Rows[i].Cells[indexCell].Value.ToString();
                            indexCell++;
                            if (indexCell > 16)
                            {
                                i++;
                                indexCell = 1;
                            }
                        }
                        break;
                    }
                }

                if (instruccion[2] == ' ')
                {
                    instruccion = "000000";
                }
                return instruccion;
            }
            catch (NullReferenceException xe)
            {
                stop = true;
                MessageBox.Show("CP fuera de rango de memoria");
                return "FFFFFF";
            }
        }

        private void set3Bytes(string dir, string value)
        {
            string dirCP1 = dir.PadLeft(6, '0').Substring(0, 5);
            int indexCell = Convert.ToInt32((dir.PadLeft(6, '0').Substring(5, 1)), 16) + 1;
            if (!stop && (Convert.ToInt32(dir, 16) < Convert.ToInt32(dirCargaHex, 16) || Convert.ToInt32(dir, 16) > Convert.ToInt32(dirCargaHex, 16) + tam))
            {
                stop = true;
                MessageBox.Show("CP fuera de rango de memoria");
            }
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                string currentDir = dataGridView1.Rows[i].Cells[0].Value.ToString();

                if (currentDir.Substring(0, 5) == dirCP1)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        dataGridView1.Rows[i].Cells[indexCell].Value = value.Substring(j * 2, 2);
                        indexCell++;
                        if (indexCell > 16)
                        {
                            i++;
                            indexCell = 1;
                        }
                    }
                    break;
                }
            }
        }

        private void set1Bytes(string dir, string value)
        {
            string dirCP1 = dir.PadLeft(6, '0').Substring(0, 5);
            int indexCell = Convert.ToInt32((dir.PadLeft(6, '0').Substring(5, 1)), 16) + 1;

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                string currentDir = dataGridView1.Rows[i].Cells[0].Value.ToString();

                if (currentDir.Substring(0, 5) == dirCP1)
                {
                    dataGridView1.Rows[i].Cells[indexCell].Value = value;
                    break;
                }
            }
        }

        private string getNemonico(string codOp)
        {
            string instruccion = "";

            switch (codOp)
            {
                case "18":
                    instruccion = "ADD"; break;
                case "40":
                    instruccion = "AND"; break;
                case "28":
                    instruccion = "COMP"; break;
                case "24":
                    instruccion = "DIV"; break;
                case "3C":
                    instruccion = "J"; break;
                case "30":
                    instruccion = "JEQ"; break;
                case "34":
                    instruccion = "JGT"; break;
                case "38":
                    instruccion = "JLT"; break;
                case "48":
                    instruccion = "JSUB"; break;
                case "00":
                    instruccion = "LDA"; break;
                case "50":
                    instruccion = "LDCH"; break;
                case "08":
                    instruccion = "LDL"; break;
                case "04":
                    instruccion = "LDX"; break;
                case "20":
                    instruccion = "MUL"; break;
                case "44":
                    instruccion = "OR"; break;
                case "D8":
                    instruccion = "RD"; break;
                case "4C":
                    instruccion = "RSUB"; break;
                case "0C":
                    instruccion = "STA"; break;
                case "54":
                    instruccion = "STCH"; break;
                case "14":
                    instruccion = "STL"; break;
                case "E8":
                    instruccion = "STSW"; break;
                case "10":
                    instruccion = "STX"; break;
                case "1C":
                    instruccion = "SUB"; break;
                case "E0":
                    instruccion = "TD"; break;
                case "2C":
                    instruccion = "TIX"; break;
                case "DC":
                    instruccion = "WD"; break;
            }

            return instruccion;
        }

        private string getEfecto(string codOp)
        {
            string efecto = "";

            switch (codOp)
            {
                case "18":
                    efecto = "A<-(A)+(m..m+2)"; break;
                case "40":
                    efecto = "A<-(A)&(m..m+2)"; break;
                case "28":
                    efecto = "A:(m..m+2)"; break;
                case "24":
                    efecto = "A<-(A)/(m..m+2)"; break;
                case "3C":
                    efecto = "CP<-m"; break;
                case "30":
                    efecto = "CP<-m si CC esta en ="; break;
                case "34":
                    efecto = "CP<-m si CC esta en >"; break;
                case "38":
                    efecto = "CP<-m si CC esta en <"; break;
                case "48":
                    efecto = "L<-(CP);  CP<-m"; break;
                case "00":
                    efecto = "A<-(m..m+2)"; break;
                case "50":
                    efecto = "A[el byte de mas a la derecha]<-(m)"; break;
                case "08":
                    efecto = "L<-(m..m+2)"; break;
                case "04":
                    efecto = "X<-(m..m+2)"; break;
                case "20":
                    efecto = "A<-(A)*(m..m+2)"; break;
                case "44":
                    efecto = "A<-(A)|(m..m+2)"; break;
                case "D8":
                    efecto = "A[el byte de mas a la derecha]<-datos del dispositivo especificado por (m)"; break;
                case "4C":
                    efecto = "CP<-(L)"; break;
                case "0C":
                    efecto = "m..m+2<-(A)"; break;
                case "54":
                    efecto = "m<-A[el byte de mas a la derecha]"; break;
                case "14":
                    efecto = "m..m+2<-(L)"; break;
                case "E8":
                    efecto = "m..m+2<-(SW)"; break;
                case "10":
                    efecto = "m..m+2<-(X)"; break;
                case "1C":
                    efecto = "A<-(A)-(m..m+2)"; break;
                case "E0":
                    efecto = "Prueba el dispositivo especificado por (m). Modifica el codigo de condicion para indicar el resultado de la prueba. < listo para enviar o recibir, = ocupado, > no esta operativo"; break;
                case "2C":
                    efecto = "X<-(X)+1; (X):(m..m+2)"; break;
                case "DC":
                    efecto = "Dispositivo especificado por (m)<-(A)[el byte de mas a la derecha]"; break;
            }

            return efecto;
        }

        private string getModDir(string operando)
        {
            return (Convert.ToInt32(operando, 16) - 8) >= 0 ? "INDEXADO" : "DIRECTO";
        }

        private void aplicarEfecto(string codOp, string operando)
        {
            string efecto = "";
            string currentCP = dataGridView2.Rows[0].Cells[1].Value.ToString();
            string currentA = dataGridView2.Rows[1].Cells[1].Value.ToString();
            string currentX = dataGridView2.Rows[2].Cells[1].Value.ToString();
            string currentL = dataGridView2.Rows[3].Cells[1].Value.ToString();
            string currentSW = dataGridView2.Rows[4].Cells[1].Value.ToString();
            string data;

            switch (codOp)
            {
                case "18":
                    data = (Convert.ToInt32(currentA, 16) + Convert.ToInt32(get3Bytes(operando.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(operando.PadLeft(6, '0').Substring(5, 1), 16) + 1), 16)).ToString("X").PadLeft(6, '0');
                    dataGridView2.Rows[1].Cells[1].Value = data;
                    break;
                case "40":
                    data = (Convert.ToInt32(dataGridView2.Rows[1].Cells[1].Value.ToString(), 16) & Convert.ToInt32(get3Bytes(operando.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(operando.PadLeft(6, '0').Substring(5, 1), 16) + 1), 16)).ToString();
                    dataGridView2.Rows[1].Cells[1].Value = data;
                    efecto = "A<-(A)&(m..m+2)"; break;
                case "28":
                    dataGridView2.Rows[4].Cells[1].Value = compHEX(dataGridView2.Rows[1].Cells[1].Value.ToString(), get3Bytes(operando.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(operando.PadLeft(6, '0').Substring(5, 1), 16) + 1));
                    efecto = "A:(m..m+2)"; break;
                case "24":
                    dataGridView2.Rows[1].Cells[1].Value = (Convert.ToInt32(get3Bytes(dataGridView2.Rows[1].Cells[1].Value.ToString().PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(dataGridView2.Rows[1].Cells[1].Value.ToString().PadLeft(6, '0').Substring(5, 1), 16) + 1), 16) / Convert.ToInt32(get3Bytes(operando.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(operando.PadLeft(6, '0').Substring(5, 1), 16) + 1), 16)).ToString("X");
                    efecto = "A<-(A)/(m..m+2)"; break;
                case "3C":
                    dataGridView2.Rows[0].Cells[1].Value = operando.PadLeft(6, '0');
                    efecto = "CP<-m"; break;
                case "30":
                    dataGridView2.Rows[0].Cells[1].Value = currentSW == "=" ? operando.PadLeft(6, '0') : currentCP.PadLeft(6, '0');
                    efecto = "CP<-m si CC esta en ="; break;
                case "34":
                    dataGridView2.Rows[0].Cells[1].Value = currentSW == ">" ? operando.PadLeft(6, '0') : currentCP.PadLeft(6, '0');
                    efecto = "CP<-m si CC esta en >"; break;
                case "38":
                    dataGridView2.Rows[0].Cells[1].Value = currentSW == "<" ? operando.PadLeft(6, '0') : currentCP.PadLeft(6, '0');
                    break;
                case "48":
                    dataGridView2.Rows[3].Cells[1].Value = get3Bytes(dataGridView2.Rows[0].Cells[1].Value.ToString().PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(dataGridView2.Rows[0].Cells[1].Value.ToString().PadLeft(6, '0').Substring(5, 1), 16) + 1);
                    dataGridView2.Rows[0].Cells[1].Value = operando.PadLeft(6, '0');
                    efecto = "L<-(CP);  CP<-m"; break;
                case "00":
                    data = get3Bytes(operando.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(operando.PadLeft(6, '0').Substring(5, 1), 16) + 1);
                    dataGridView2.Rows[1].Cells[1].Value = data;
                    break;
                case "50":
                    if (currentA == "FFFFFF")
                        currentA = "000000";
                    dataGridView2.Rows[1].Cells[1].Value = currentA.Substring(0, 4) + get3Bytes(operando.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(operando.PadLeft(6, '0').Substring(5, 1), 16) + 1).Substring(0, 2);
                    efecto = "A[el byte de mas a la derecha]<-(m)"; break;
                case "08":
                    dataGridView2.Rows[3].Cells[1].Value = get3Bytes(operando.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(operando.PadLeft(6, '0').Substring(5, 1), 16) + 1);
                    efecto = "L<-(m..m+2)"; break;
                case "04":
                    data = get3Bytes(operando.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(operando.PadLeft(6, '0').Substring(5, 1), 16) + 1);
                    dataGridView2.Rows[2].Cells[1].Value = data;
                    break;
                case "20":
                    dataGridView2.Rows[1].Cells[1].Value = (Convert.ToInt32(get3Bytes(dataGridView2.Rows[1].Cells[1].Value.ToString().PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(dataGridView2.Rows[1].Cells[1].Value.ToString().PadLeft(6, '0').Substring(5, 1), 16) + 1), 16) * Convert.ToInt32(get3Bytes(operando.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(operando.PadLeft(6, '0').Substring(5, 1), 16) + 1), 16)).ToString("X");
                    efecto = "A<-(A)*(m..m+2)"; break;
                case "44":
                    dataGridView2.Rows[1].Cells[1].Value = (Convert.ToInt32(get3Bytes(dataGridView2.Rows[1].Cells[1].Value.ToString().PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(dataGridView2.Rows[1].Cells[1].Value.ToString().PadLeft(6, '0').Substring(5, 1), 16) + 1), 16) | Convert.ToInt32(get3Bytes(operando.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(operando.PadLeft(6, '0').Substring(5, 1), 16) + 1), 16)).ToString("X");
                    efecto = "A<-(A)|(m..m+2)"; break;
                case "D8":
                    efecto = "A[el byte de mas a la derecha]<-datos del dispositivo especificado por (m)"; break;
                case "4C":
                    dataGridView2.Rows[0].Cells[1].Value = get3Bytes(currentL.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(currentL.PadLeft(6, '0').Substring(5, 1), 16) + 1);
                    break;
                case "0C":
                    set3Bytes(operando, currentA);
                    break;
                case "54":
                    efecto = "m<-A[el byte de mas a la derecha]";
                    set1Bytes(operando, currentA.Substring(4, 2));
                    break;
                case "14":
                    set3Bytes(operando, currentL);
                    efecto = "m..m+2<-(L)"; break;
                case "E8":
                    set3Bytes(operando, currentSW);
                    efecto = "m..m+2<-(SW)"; break;
                case "10":
                    set3Bytes(operando, currentX);
                    efecto = "m..m+2<-(X)"; break;
                case "1C":
                    dataGridView2.Rows[1].Cells[1].Value = (Convert.ToInt32(get3Bytes(dataGridView2.Rows[1].Cells[1].Value.ToString().PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(dataGridView2.Rows[1].Cells[1].Value.ToString().PadLeft(6, '0').Substring(5, 1), 16) + 1), 16) - Convert.ToInt32(get3Bytes(operando.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(operando.PadLeft(6, '0').Substring(5, 1), 16) + 1), 16)).ToString("X");
                    efecto = "A<-(A)-(m..m+2)"; break;
                case "E0":
                    efecto = "Prueba el dispositivo especificado por (m). Modifica el codigo de condicion para indicar el resultado de la prueba. < listo para enviar o recibir, = ocupado, > no esta operativo"; break;
                case "2C":
                    dataGridView2.Rows[2].Cells[1].Value = sumaHEX(dataGridView2.Rows[2].Cells[1].Value.ToString(), "1").PadLeft(6, '0');
                    currentX = dataGridView2.Rows[2].Cells[1].Value.ToString();
                    dataGridView2.Rows[4].Cells[1].Value = compHEX(currentX, get3Bytes(operando.PadLeft(6, '0').Substring(0, 5), Convert.ToInt32(operando.PadLeft(6, '0').Substring(5, 1), 16) + 1));
                    break;
                case "DC":
                    efecto = "Dispositivo especificado por (m)<-(A)[el byte de mas a la derecha]"; break;
            }
            if (!stop && (Convert.ToInt32(dataGridView2.Rows[0].Cells[1].Value.ToString(), 16) < Convert.ToInt32(dirCargaHex, 16) || Convert.ToInt32(dataGridView2.Rows[0].Cells[1].Value.ToString(), 16) > Convert.ToInt32(dirCargaHex, 16) + tam))
            {
                stop = true;
                MessageBox.Show("CP fuera de rango de memoria");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEjecutarTodo_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 1000; i++)
            //{
            //    if (stop)
            //    {
            //        MessageBox.Show("TERMINA EJECUCION");
            //        break;
            //    }
            //    else
            //    {
            //        //Se conoce el valor del contador
            //        string CPHex = dataGridView2.Rows[0].Cells[1].Value.ToString();
            //        int CP = Convert.ToInt32(CPHex, 16);
            //        //3 primeros digitos del CP
            //        string dirCP1 = CPHex.Substring(0, 5);
            //        //Ultimo digito del CP
            //        string dirCP2 = CPHex.Substring(5, 1);
            //        int indexCell = Convert.ToInt32(dirCP2, 16) + 1;

            //        //Se leen 3 bytes
            //        string instruccion = get3Bytes(dirCP1, indexCell);

            //        //Se actualiza el valor del CP
            //        string CPHexAux = CPHex;
            //        CP += 3;
            //        CPHex = CP.ToString("X").PadLeft(6, '0');
            //        dataGridView2.Rows[0].Cells[1].Value = CPHex;

            //        //Se interpreta la instruccion
            //        string codOp = instruccion.Substring(0, 2);
            //        string nemonico = getNemonico(codOp);
            //        string efecto = getEfecto(codOp);
            //        string operando = instruccion.Substring(2, 4);
            //        string modDir = getModDir(operando.Substring(0, 1));

            //        if (nemonico != "")
            //            dataGridView3.Rows.Add(CPHexAux, nemonico, codOp, modDir, operando, efecto);

            //        //Se aplica el efecto
            //        operando = modDir == "INDEXADO" ? restaHEX(sumaHEX(operando, dataGridView2.Rows[2].Cells[1].Value.ToString()), "8000") : operando;
            //        aplicarEfecto(codOp, operando);
            //    }
            //}
        }

        private void MapaMemoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F9")
            {
                ejecutarLinea();
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView3.FirstDisplayedScrollingRowIndex = dataGridView3.RowCount - 1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //dataGridView3.Rows.Clear();
            //dataGridView1.Rows.Clear();
            //dataGridView2.Rows.Clear();
            //cargar(programaObj, tam);
            //stop = false;
        }
    }
}
