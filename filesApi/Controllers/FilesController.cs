using filesApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace filesApi.Controllers
{
    [RoutePrefix("api/v1")]
    public class FilesController : ApiController
    {




        [HttpGet]
        [Route("cfdi-pdf/id")]
        public HttpResponseMessage DownloadFile_Cfdi_PDF(string id)
        {
            Files newObjectFiles = new Files();

            List<Files> arrayFiles = Files.getFiles();

            Files archivoEncontrado = arrayFiles.Find(a => a.id == id);

            string[] extensionFile = archivoEncontrado.cfdi_pdf_fileName.Split('.');

            var path = @"C:/Users/carlos.sanchez/Desktop/FilesPruebaKioscoWeb/" + archivoEncontrado.cfdi_pdf_fileName;
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");

            result.Content.Headers.ContentDisposition.FileName = archivoEncontrado.cfdi_pdf_fileName;
            result.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            return result;

        }


        [HttpGet]
        [Route("cfdi-xml/id")]
        public HttpResponseMessage DownloadFile_Cfdi_Xml(string id)
        {
            Files newObjectFiles = new Files();

            List<Files> arrayFiles = Files.getFiles();

            Files archivoEncontrado = arrayFiles.Find(a => a.id == id);

            string[] extensionFile = archivoEncontrado.cfdi_xml_fileName.Split('.');

            var path = @"C:/Users/carlos.sanchez/Desktop/FilesPruebaKioscoWeb/" + archivoEncontrado.cfdi_xml_fileName;
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");

            result.Content.Headers.ContentDisposition.FileName = archivoEncontrado.cfdi_xml_fileName;
            result.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
            return result;

        }


        [HttpGet]
        [Route("recibo/id")]
        public HttpResponseMessage DownloadFile_Recibo(string id)
        {
            Files newObjectFiles = new Files();

            List<Files> arrayFiles = Files.getFiles();

            Files archivoEncontrado = arrayFiles.Find(a =>  a.id == id);

            string[] extensionFile = archivoEncontrado.recibo_fileName.Split('.');

            var path = @"C:/Users/carlos.sanchez/Desktop/FilesPruebaKioscoWeb/" + archivoEncontrado.recibo_fileName;
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");

            result.Content.Headers.ContentDisposition.FileName = archivoEncontrado.recibo_fileName;
            result.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            return result;
 
        }

        [HttpGet]
        [Route("recibos")]
        public IHttpActionResult GetAllRecibos()
        {
            List<Nominas> nominas = new List<Nominas>();
            Nominas nom = new Nominas();
            for (int i = 0; i < 2; i++)
            {

                if (i % 2 == 0) {
                  nom = new Nominas { ejercicio_fiscal = "202"+i.ToString(), periodo = new Periodo { id = 12312312, descripcion = "1a.Q.Mayo" }, recibo = false, cfdi_pdf = false, cfdi_xml = true };

                }
                else {
                  nom = new Nominas { ejercicio_fiscal = "202"+i.ToString(), periodo = new Periodo { id = 12312314, descripcion = "1a.Q.Mayo" }, recibo = true, cfdi_pdf = true, cfdi_xml = false };
                }
                nominas.Add(nom);
            }

         
            return Ok(nominas);
        }

        [HttpGet]
        [Route("detalles")]
        public IHttpActionResult GetAllRecibosDetalles()
        {
            List<NominaDetalles> nominas = new List<NominaDetalles>();
            NominaDetalles nom = new NominaDetalles();
            for (int i = 0; i < 2; i++)
            {

                if (i % 2 == 0)
                {
                    nom = new NominaDetalles { concepto = "202" + i.ToString(), descripcion = "Descripcion del concepto de prueba 1", cuota = 12.22, diasHrs = "05.12", importe = 33.55 };

                }
                else
                {
                    nom = new NominaDetalles { concepto = "202" + i.ToString(), descripcion = "Descripcion del concepto de prueba 2", cuota = 45.22, diasHrs = "09.34", importe = 553.65 };
                }
                nominas.Add(nom);
            }


            return Ok(nominas);
        }



        [HttpGet]
        [Route("FilesAdminArch")]
        public IHttpActionResult GetFilesAdminArch()
        {
            List<AdminArch> listFiles = new List<AdminArch>();
            AdminArch arch = new AdminArch();

            for (int i = 0; i < 2; i++)
            {

                if (i % 2 == 0)
                {
                    arch = new AdminArch { uid = i, nombreArchivo = "Recibo_esta.pdf", size = 10033, status = new Status { upload = new Load { user = "carlos", tmp = "05-05-22"}, download = new Load { user = "Fernado", tmp = "05-05-23" } } };

                }
                else
                {
                    arch = new AdminArch { uid = i + 3, nombreArchivo = "Recibo_esta2.pdf", size = 100443, status = new Status { upload = new Load { user = "Erik", tmp = "04-04-22" }, download = null } };
                }
                listFiles.Add(arch);
            }

            return Ok(listFiles);
        }


        [HttpPost]
        [Route("UploadFile")]
        public IHttpActionResult UploadFile([FromBody] string fileBase64)
        {
            List<string> listFiles = new List<string>();

            //listFiles.Add(fileBase64);
            //listFiles.Add("Carlos");
            return Ok(fileBase64);
        }



    }

}