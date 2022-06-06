using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace filesApi.Models
{
    public class Files
    {
        public string id { get; set; }
        public string recibo_fileName { get; set; }
        public string cfdi_pdf_fileName { get; set; }
        public string cfdi_xml_fileName { get; set; }

        public static List<Files> getFiles() {
            List<Files> arrayFiles = new List<Files>();
            Files archivo = new Files();
            for (int i = 1; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    archivo = new Files { id = "12312312", recibo_fileName = "CARTA_PRESENTACION.pdf", cfdi_pdf_fileName = "CARTA_PRESENTACION.pdf", cfdi_xml_fileName = "CFDI-RESULTADO-00219-19-04-003-220315181941-0000007184-Y-00001.xml" };

                }
                else
                {
                    archivo = new Files { id = "12312314", recibo_fileName = "CARTA_PRESENTACION.pdf", cfdi_pdf_fileName = "CARTA_PRESENTACION.pdf", cfdi_xml_fileName = "CFDI-RESULTADO-00219-19-04-003-220315181941-0000007184-Y-00001.xml" };

                }
                arrayFiles.Add(archivo);
            }
            return arrayFiles;
        }
    }
}