using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Expediente : System.Web.UI.Page
    {
        string strConexionC;
        DataTable tblCuesti;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDatosAlumnoCues();

            DatodelAlumnoCuestionario.DataSource = tblCuesti;
            DatodelAlumnoCuestionario.DataBind();

        }
        public void cargarDatosAlumnoCues()
        {
            //cadena de conexion
            strConexionC = @"Data Source=DESKTOP-8OI8PMB\MSSQLSERVER01;Initial Catalog=SistemaDeBajas;Integrated Security=True";
            tblCuesti = new DataTable("Cuestionario");
            SqlConnection Conne = new SqlConnection(strConexionC);
            // SqlCommand cmdSelecction = new SqlCommand("Select matricula,nombre,apPaterno,apMaterno,sexo,edad,direccion,carrera,semestre,estado,correo from RegistroAlum", Conne);
            SqlCommand cmdSelecction = new SqlCommand("Select nombres, idMatricula,fecha,años,estado,sexo,situacion,economicamente,baja,estudiando,apoyo,familia,hijos,numhijos,padres from Cuestionario", Conne);

            Conne.Open();
            SqlDataReader sdrCuest = cmdSelecction.ExecuteReader();
            tblCuesti.Load(sdrCuest);
            sdrCuest.Close();
            Conne.Close();
            //creamos la tabla


        }

       

        protected void DatodelAlumnoCuestionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaSeleccionada = DatodelAlumnoCuestionario.SelectedRow;
            //obtenemos el id de empleado
            string Matricula = filaSeleccionada.Cells[0].Text;
            //con el metodo slect del datatable podemos hacer consultas ala tabla
            DataRow filaReporte = tblCuesti.Select("IdMatricula=" + Matricula)[0];
            string nombreReporte = "Cuestionario" + Matricula + ".pdf";
            GenerarPdf(filaReporte, nombreReporte);
            Process.Start(@"C:\Users\user\Desktop\BajaUABC5\SisBajaUabc\PDF_Generados\Cuestionarios\" + nombreReporte);
            // Response.Redirect("~/ReportesPDF/" + nombreReporte);

        }
        private void GenerarPdf(DataRow FilaDatos, string nombreReporte)
        {
            //Dimensiones del documento
            Document documento = new Document(PageSize.LETTER, 50, 100, 20, 100);
            string DirecRaiz = Directory.GetCurrentDirectory();
            string[] DireIos = Directory.GetDirectories(DirecRaiz);
            DirecRaiz = DireIos[0];
            DireIos = Directory.GetDirectories(DirecRaiz);
            //creamos el  documento
            //ruta donde se encuentra nuestra apliccaion
            try
            {
                PdfWriter WriterPdf = PdfWriter.GetInstance(documento, new FileStream(@"C: \Users\user\Desktop\BajaUABC5\SisBajaUabc\PDF_Generados\Cuestionarios\" + nombreReporte, FileMode.Create));
                //abrimos el documento
                documento.Open();
                // Titulo del archivo
                // Font font248 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, Font.BOLD, BaseColor.BLUE);
                // Phrase Titulo = new Phrase("Reporte De Alumnos", font248);


                PdfPTable TblHeader = new PdfPTable(1); // 1 columna
                TblHeader.WidthPercentage = 100;
                
                Paragraph Parrafo = new Paragraph(Chunk.NEWLINE+"UNIVERSIDAD AUTÓNOMA DE BAJA CALIFORNIA" + Chunk.NEWLINE, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 19, Font.BOLD, BaseColor.DARK_GRAY));
                Paragraph saltoDeLinea7 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                documento.Add(saltoDeLinea7);
                Paragraph Parrafo2 = new Paragraph("FACULTAD DE INGENIERÍA ARQUITECTURA Y DISEÑO" + Chunk.NEWLINE, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 19, Font.BOLD, BaseColor.DARK_GRAY));
               
                PdfPCell CellHeader = new PdfPCell(Parrafo);
                PdfPCell CellHeader2 = new PdfPCell(Parrafo2);
                Paragraph saltoDeLinea6 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                documento.Add(saltoDeLinea6);
                Paragraph text = new Paragraph("REPORTE DE ALUMNOS CUESTIONARIO " + Chunk.NEWLINE, FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 18, Font.BOLD, BaseColor.BLACK));
                PdfPCell celltext = new PdfPCell(text);
                CellHeader.Border = 0;
                CellHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                CellHeader2.Border = 0;
                CellHeader2.HorizontalAlignment = Element.ALIGN_CENTER;
                celltext.Border = 0;
                celltext.HorizontalAlignment = Element.ALIGN_CENTER;
                TblHeader.AddCell(CellHeader);
                TblHeader.AddCell(CellHeader2);
                TblHeader.AddCell(celltext);
               

                TblHeader.TotalWidth = documento.PageSize.Width - documento.LeftMargin - documento.RightMargin; //this centers [table]      
                TblHeader.WriteSelectedRows(0, -1, documento.LeftMargin, documento.PageSize.Height + 8, WriterPdf.DirectContent);
                ///




                PdfContentByte db = WriterPdf.DirectContent;
                ColumnText ct = new ColumnText(db);
                //  ct.SetSimpleColumn(Titulo, documento.Left, 0, documento.LeftMargin, documento.Top, 24, Element.ALIGN_JUSTIFIED);
                // ct.Go();
                Paragraph saltoDeLinea5 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                documento.Add(saltoDeLinea5);
                //creacion de la tabla que se mostrara en el pdf
                PdfPTable table = new PdfPTable(3);
                PdfPTable table2 = new PdfPTable(3);
                PdfPTable table3 = new PdfPTable(3);
                PdfPTable table4 = new PdfPTable(3);
                PdfPTable table5 = new PdfPTable(3);
              
            
                Font LetraTituloTabla = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13, Font.COURIER, BaseColor.BLACK);
                CellHeader.BackgroundColor = BaseColor.DARK_GRAY;
                //creamos las cabecerar de la tabla
                PdfPCell celdaNombres = new PdfPCell(new Phrase("Nombres", LetraTituloTabla));
               
                PdfPCell celdaIDMatricula = new PdfPCell(new Phrase("Matricula", LetraTituloTabla));
                
                // PdfPCell celdaSNombre = new PdfPCell(new Phrase("S.Nombre", LetraTituloTabla));
                PdfPCell celdaFecha = new PdfPCell(new Phrase("Fecha Nacimiento", LetraTituloTabla));
                PdfPCell celdaEdad = new PdfPCell(new Phrase("Edad", LetraTituloTabla));
                PdfPCell celdaEstadoCivi = new PdfPCell(new Phrase("Estado Civil", LetraTituloTabla));
                PdfPCell celdaSexo = new PdfPCell(new Phrase("Sexo", LetraTituloTabla));
                
                PdfPCell celdaLaboral = new PdfPCell(new Phrase("Situcion Laboral", LetraTituloTabla));
                PdfPCell celdaDepende= new PdfPCell(new Phrase("Depende de alguien", LetraTituloTabla));
                PdfPCell celdaMotivo = new PdfPCell(new Phrase("Motivo de baja", LetraTituloTabla));
                PdfPCell celdaSEstidiando = new PdfPCell(new Phrase("Seguira estidiando", LetraTituloTabla));
                PdfPCell celdaBeca = new PdfPCell(new Phrase("Cuenta con beca", LetraTituloTabla));
                PdfPCell celdaEstadoEco= new PdfPCell(new Phrase("Estado economico", LetraTituloTabla));
                //PdfPCell celdaTelefono = new PdfPCell(new Phrase("Tel", LetraTituloTabla));
                PdfPCell celdaHijos = new PdfPCell(new Phrase("Tiene hijos", LetraTituloTabla));
                PdfPCell celdaNumHijos = new PdfPCell(new Phrase("Numero de hijos", LetraTituloTabla));
                PdfPCell celdaPadres = new PdfPCell(new Phrase("Vive con sus padres", LetraTituloTabla));
                celdaNombres.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaIDMatricula.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaFecha.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaEdad.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaEstadoCivi.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaSexo.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaLaboral.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaDepende.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaMotivo.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaSEstidiando.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaBeca.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaEstadoEco.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaHijos.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaNumHijos.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaPadres.BackgroundColor = BaseColor.LIGHT_GRAY;

                // table.DefaultCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                // table2.DefaultCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                //// table3.DefaultCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                // table4.DefaultCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                // table5.DefaultCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                //Agregamos las cabeceras ala tabla
                table.AddCell(celdaNombres);
                table.AddCell(celdaIDMatricula);

                
                /* table.AddCell(celdaSNombre);*/
                table.AddCell(celdaFecha);
                table2.AddCell(celdaEdad);
                table2.AddCell(celdaEstadoCivi);
                table2.AddCell(celdaSexo);
                table3.AddCell(celdaLaboral);
                table3.AddCell(celdaDepende);
                table3.AddCell(celdaMotivo);
                table4.AddCell(celdaSEstidiando);
                table4.AddCell(celdaBeca);
                table4.AddCell(celdaEstadoEco);
                table5.AddCell(celdaHijos);
                table5.AddCell(celdaNumHijos);
                table5.AddCell(celdaPadres);

                //recorremos todas las filas del datatable
                // foreach (DataRow fila in filaReporte.Rows)
                // {
                table.AddCell(FilaDatos[0].ToString());

                table.AddCell(FilaDatos[1].ToString());
                table.AddCell(FilaDatos[2].ToString());
                table2.AddCell(FilaDatos[3].ToString());
                table2.AddCell(FilaDatos[4].ToString());
                table2.AddCell(FilaDatos[5].ToString());
                table3.AddCell(FilaDatos[6].ToString());
                table3.AddCell(FilaDatos[7].ToString());
                table3.AddCell(FilaDatos[8].ToString());
                table4.AddCell(FilaDatos[9].ToString());
                table4.AddCell(FilaDatos[10].ToString());
                table4.AddCell(FilaDatos[11].ToString());
                table5.AddCell(FilaDatos[12].ToString());
                table5.AddCell(FilaDatos[13].ToString());
                table5.AddCell(FilaDatos[14].ToString());
                /*   table.AddCell(FilaDatos[12].ToString());*/
                // table.AddCell(fila[10].ToString());
                //table.AddCell(fila[11].ToString());
                // }
                table.TotalWidth = 600;
                table.WriteSelectedRows(0, -1, 10, 670, WriterPdf.DirectContent);
                table2.TotalWidth = 600;
                table2.WriteSelectedRows(0, -1, 10, 610, WriterPdf.DirectContent);
                table3.TotalWidth = 600;
                table3.WriteSelectedRows(0, -1, 10, 550, WriterPdf.DirectContent);
                table4.TotalWidth = 600;
                table4.WriteSelectedRows(0, -1, 10, 490, WriterPdf.DirectContent);
                table5.TotalWidth = 600;
                table5.WriteSelectedRows(0, -1, 10, 430, WriterPdf.DirectContent);
                //cerramos el documento
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }
            Paragraph saltoDeLinea = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
            documento.Add(saltoDeLinea);
            Paragraph saltoDeLinea1 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
            documento.Add(saltoDeLinea1);
            Paragraph saltoDeLinea2 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
            documento.Add(saltoDeLinea2);
            Paragraph paragraph = new Paragraph(" ");
            Paragraph saltoDeLinea3 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
            documento.Add(saltoDeLinea3);
            Paragraph saltoDeLinea4 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
            documento.Add(saltoDeLinea4);
            Paragraph saltoDeLinea9 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
            documento.Add(saltoDeLinea9);
            Paragraph saltoDeLinea10 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
            documento.Add(saltoDeLinea10);
            Paragraph saltoDeLinea11 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
            documento.Add(saltoDeLinea11);

            string imageURL = Server.MapPath(".") + "/logo.jpg";

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

            //Resize image depend upon your need

            jpg.ScaleToFit(280, 240);

            //Give space before image

            jpg.SpacingBefore = 100f;

            //Give some space after the image

            jpg.SpacingAfter = 100f;

            jpg.Alignment = Element.ALIGN_CENTER;
            //jpg.Alignment=Element.ALIGN_CENTER;

        
            Paragraph pie = new Paragraph("______________________ " + Chunk.NEWLINE+ "Firma", FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 18, Font.BOLD, BaseColor.BLACK));
            pie.Alignment = Element.ALIGN_CENTER;
           
            documento.Add(paragraph);

            documento.Add(jpg);
            documento.Add(pie);
            documento.Close();
        }
    }
}