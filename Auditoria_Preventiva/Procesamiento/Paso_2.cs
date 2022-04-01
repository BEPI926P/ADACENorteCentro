using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria_Preventiva.Procesamiento
{
    public class Paso_2
    {
        // Lista de columnas
        private string[] _file { get; set; }

        public Paso_2()
        {
        }

        private void ReadFileData(string fileName)
        {
            // Leer archivo de texto
            this._file = System.IO.File.ReadAllLines(fileName);
        }

        public string[] ReadDataInFile(string filename)
        {
            ReadFileData(filename);
            return _file;
        }

        public void PrintFileData(string filename)
        {
            ReadFileData(filename);
            foreach (string row in this._file)
            {
                Console.WriteLine(row);
            }
        }

        public List<string> ReadFile(string fileName)
        {
            ReadFileData(fileName);

            List<string> fileToSave = new List<string>();

            int contador = 0;

            foreach (string line in this._file)
            {
                string tempLine = line;

                if (contador == 0)
                {
                    string[] columnsName = tempLine.Split("|");
                    tempLine = string.Empty;

                    for (int i = 0; i < columnsName.Length; i++)
                    {
                        if (i < 3)
                        {
                            if (string.IsNullOrEmpty(tempLine))
                            {
                                tempLine = "NumeroPedimento";
                            }
                        }
                        else
                        {
                            tempLine = tempLine + "," + columnsName[i];
                        }
                    }
                }
                else if (contador > 0)
                {
                    tempLine = line.Replace(",", ";");
                    tempLine = tempLine.Replace("|", ",");
                    string[] columnsData = tempLine.Split(",");
                    tempLine = string.Empty;

                    for (int i = 0; i < columnsData.Length; i++)
                    {
                        if (i < 3)
                        {
                            tempLine = tempLine + columnsData[i];
                        }
                        else
                        {
                            tempLine = tempLine + "," + columnsData[i];
                        }
                    }
                }

                fileToSave.Add(tempLine);
                contador = contador + 1;
            }

            return fileToSave;
        }

        public string[] ReadColumns(string fileName)
        {
            ReadFileData(fileName);

            string[] columnsLine = this._file[0].Split("|");
            return columnsLine;
        }

        public void PrintColumnsNames(List<string> columnsLine)
        {
            int contador = 1;
            foreach (string column in columnsLine)
            {
                Console.WriteLine(contador + " - " + column);
                contador = contador + 1;
            }
        }

        public string[] ReadColumnsInDatabase()
        {
            try
            {
                string filePath = Directory.GetCurrentDirectory() + "\\Database\\ColumnsDatabase.txt";
                if (File.Exists(filePath))
                {
                    ReadFileData(filePath);
                }
                else
                {
                    if (Directory.Exists(Directory.GetCurrentDirectory() + "\\Database\\"))
                    {
                        File.Create(filePath).Close();
                        ReadFileData(filePath);
                        Console.WriteLine("El archivo no existe y se ha creado");
                    }
                    else
                    {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Database\\");
                        File.Create(filePath).Close();
                        ReadFileData(filePath);
                        Console.WriteLine("El archivo no existe y se ha creado");
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Ocurrio un Error"); }

            return this._file;
        }

        public bool SaveColumnsInFile(List<string> columns)
        {
            bool result = false;
            try
            {
                string filePath = Directory.GetCurrentDirectory() + "\\Database\\ColumnsDatabase.txt";
                File.WriteAllLines(filePath, columns);
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result = false;
            }

            return result;
        }
    }
}
