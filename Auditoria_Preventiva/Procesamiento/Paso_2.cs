using Auditoria_Preventiva.Models;
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

        public List<object> LoadDataInClasses(string filename)
        {
            ReadFileData(filename);
            string[] path = filename.Split("\\");
            int fileNumber = Convert.ToInt32(path[path.Length - 1].Split("_")[1].Split(".")[0]);

            List<object> linesInClasses = new List<object>();

            switch (fileNumber)
            {
                case 501:
                    foreach (string line in this._file)
                    {
                        string[] columns = line.Split("|");
                        if (Array.IndexOf(this._file, line) != 0)
                        {
                            _501 lineInClass = new _501()
                            {
                                FileName = path[path.Length - 1],
                                Patente = columns[0],
                                Pedimento = columns[1],
                                SeccionAduanera = columns[2],
                                TipoOperacion = columns[3],
                                ClaveDocumento = columns[4],
                                SeccionAduaneraEntrada = columns[5],
                                CurpContribuyente = columns[6],
                                Rfc = columns[7],
                                CurpAgenteA = columns[8],
                                TipoCambio = columns[9],
                                TotalFletes = columns[10],
                                TotalSeguros = columns[11],
                                TotalEmbalajes = columns[12],
                                TotalIncrementables = columns[13],
                                TotalDeducibles = columns[14],
                                PesoBrutoMercancia = columns[15],
                                MedioTransporteSalida = columns[16],
                                MedioTransporteArribo = columns[17],
                                MedioTransporteEntrada_Salida = columns[18],
                                DestinoMercancia = columns[19],
                                NombreContribuyente = columns[20],
                                CalleContribuyente = columns[21],
                                NumInteriorContribuyente = columns[22],
                                NumExteriorContribuyente = columns[23],
                                CPContribuyente = columns[24],
                                MunicipioContribuyente = columns[25],
                                EntidadFedContribuyente = columns[26],
                                PaisContribuyente = columns[27],
                                TipoPedimento = columns[28],
                                FechaRecepcionPedimento = columns[29],
                                FechaPagoReal = columns[30]
                            };

                            linesInClasses.Add(lineInClass);
                        }
                    }
                    break;
                case 502:
                    foreach (string line in this._file)
                    {
                        string[] columns = line.Split("|");
                        if (Array.IndexOf(this._file, line) != 0)
                        {
                            _502 lineInClass = new _502()
                            {
                                Patente = columns[0],
                                Pedimento = columns[1],
                                SeccionAduanera = columns[2],
                                RfcTransportista = columns[3],
                                CurpTransportista = columns[4],
                                NombreTransportista = columns[5],
                                PaisTransporte = columns[6],
                                IdentificadorTransporte = columns[7],
                                FechaPagoReal = columns[8]
                            };

                            linesInClasses.Add(lineInClass);
                        }
                    }
                    break;
                /*case 503:
                    break;
                case 504:
                    break;
                case 505:
                    break;
                case 506:
                    break;
                case 507:
                    break;
                case 508:
                    break;
                case 509:
                    break;
                case 510:
                    break;
                case 511:
                    break;*/
                default:
                    break;
            }

            return linesInClasses;
        }

        public void PrintFileData(string filename)
        {
            ReadFileData(filename);
            ProcessFileIntoColumns(filename);
            foreach (string row in this._file)
            {
                Console.WriteLine(row);
            }
        }

        private void ProcessFileIntoColumns(string filename)
        {
            List<string> fileProcesed = new List<string>();

            foreach (string row in this._file)
            {
                string tempLine = row.Replace(",", ";");
                tempLine = tempLine.Replace("|", ",");

                fileProcesed.Add(tempLine);
            }

            this._file = fileProcesed.ToArray();
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
