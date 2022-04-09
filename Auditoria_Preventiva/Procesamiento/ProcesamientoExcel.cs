using Auditoria_Preventiva.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria_Preventiva.Procesamiento
{
    public class ProcesamientoExcel
    {
        private string _excelFileName { get; set; }

        public ProcesamientoExcel(string ExcelFileName)
        {
            this._excelFileName = ExcelFileName;
        }

        public void CreateExcelFile_deprecated()
        {
            using (FileStream fs = new FileStream(this._excelFileName, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Hoja1");

                bool esBlanca = true;
                for (int i = 0; i < 8; i++)
                {
                    IRow row = excelSheet.CreateRow(i);

                    for (int j = 0; j < 8; j++)
                    {
                        if (esBlanca)
                        {
                            ICellStyle style1 = workbook.CreateCellStyle();
                            style1.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
                            style1.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
                            row.CreateCell(j).SetCellValue("Blanca");
                            row.Cells[j].CellStyle = style1;
                            if (j < 7)
                            {
                                esBlanca = false;
                            }
                        }
                        else
                        {
                            ICellStyle style1 = workbook.CreateCellStyle();
                            style1.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
                            style1.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;
                            row.CreateCell(j).SetCellValue("Negra");
                            row.Cells[j].CellStyle = style1;
                            if (j < 7)
                            {
                                esBlanca = true;
                            }
                        }
                    }
                }
                workbook.Write(fs);
            }
        }

        public void CreateExcelFile(List<List<object>> dataFile)
        {
            using (FileStream fs = new FileStream(this._excelFileName, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();

                for (int i = 0; i < 2; i++)
                {
                    if (dataFile[i][0].GetType() == typeof(_501))
                    {
                        foreach (_501 file in dataFile[i])
                        {
                            ISheet excelSheet = workbook.CreateSheet(file.Patente + file.Pedimento + file.SeccionAduanera);
                            IRow row = excelSheet.CreateRow(i);
                            row.CreateCell(0).SetCellValue(file.TipoOperacion);
                            row.CreateCell(1).SetCellValue(file.ClaveDocumento);
                            row.CreateCell(2).SetCellValue(file.SeccionAduaneraEntrada);
                            row.CreateCell(3).SetCellValue(file.CurpContribuyente);
                            row.CreateCell(4).SetCellValue(file.Rfc);
                            row.CreateCell(5).SetCellValue(file.CurpAgenteA);
                            row.CreateCell(6).SetCellValue(file.TipoCambio);
                            row.CreateCell(7).SetCellValue(file.TotalFletes);
                            row.CreateCell(8).SetCellValue(file.TotalSeguros);
                            row.CreateCell(9).SetCellValue(file.TotalEmbalajes);
                            row.CreateCell(10).SetCellValue(file.TotalIncrementables);
                            row.CreateCell(11).SetCellValue(file.TotalDeducibles);
                            row.CreateCell(12).SetCellValue(file.PesoBrutoMercancia);
                            row.CreateCell(13).SetCellValue(file.MedioTransporteEntrada_Salida);
                            row.CreateCell(14).SetCellValue(file.DestinoMercancia);
                            row.CreateCell(15).SetCellValue(file.NombreContribuyente);
                            row.CreateCell(16).SetCellValue(file.CalleContribuyente);
                            row.CreateCell(17).SetCellValue(file.NumInteriorContribuyente);
                            row.CreateCell(18).SetCellValue(file.NumExteriorContribuyente);
                            row.CreateCell(19).SetCellValue(file.CPContribuyente);
                            row.CreateCell(20).SetCellValue(file.MunicipioContribuyente);
                            row.CreateCell(21).SetCellValue(file.EntidadFedContribuyente);
                            row.CreateCell(22).SetCellValue(file.PaisContribuyente);
                            row.CreateCell(23).SetCellValue(file.TipoPedimento);
                            row.CreateCell(24).SetCellValue(file.FechaRecepcionPedimento);
                            row.CreateCell(25).SetCellValue(file.FechaPagoReal);
                        }
                    }
                    {
                        if (dataFile[i][0].GetType() == typeof(_502))
                        {
                            foreach (_502 file in dataFile[i])
                            {
                                ISheet excelsheet = workbook.CreateSheet(file.Patente + file.Pedimento + file.SeccionAduanera);
                                IRow row = excelsheet.CreateRow(i);
                                row.CreateCell(0).SetCellValue(file.RfcTransportista);
                                row.CreateCell(1).SetCellValue(file.CurpTransportista);
                                row.CreateCell(2).SetCellValue(file.NombreTransportista);
                                row.CreateCell(3).SetCellValue(file.PaisTransporte);
                                row.CreateCell(4).SetCellValue(file.IdentificadorTransporte);
                                row.CreateCell(5).SetCellValue(file.FechaPagoReal);
                            }
                        }
                   
                    }
                }

                workbook.Write(fs);
            }
        }
    }
}