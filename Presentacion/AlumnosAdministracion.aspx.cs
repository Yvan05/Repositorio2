using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Presentacion
{
    public partial class AlumnosAdministracion : System.Web.UI.Page
    {
        //variables
        string strConexion;
        DataTable tblAlumn;
        


        protected void Page_Load(object sender, EventArgs e)
        {

            //carga los datos en el  en el gridview
            cargarDatosAlumno();
            DatodelAlumno.DataSource = tblAlumn;
            DatodelAlumno.DataBind();




        }
        //metodo para cargar los datos
        public void cargarDatosAlumno()
        {

          

            //cadena de conexion
            strConexion = @"Data Source=DESKTOP-8OI8PMB\MSSQLSERVER01;Initial Catalog=SistemaDeBajas;Integrated Security=True";
            tblAlumn = new DataTable("Alumnos");
            SqlConnection Conne = new SqlConnection(strConexion);
           // SqlCommand cmdSelecction = new SqlCommand("Select matricula,nombre,apPaterno,apMaterno,sexo,edad,direccion,carrera,semestre,estado,correo from RegistroAlum", Conne);
            SqlCommand cmdSelecction = new SqlCommand("Select matricula,nombre,apPaterno,apMaterno,sexo,edad,direccion,carrera,correo,semestre,celular,estado from RegistroAlum", Conne);

            Conne.Open();
            SqlDataReader sdrAlum = cmdSelecction.ExecuteReader();
            tblAlumn.Load(sdrAlum);
            sdrAlum.Close();
            Conne.Close();
            //creamos la tabla
            

        }

      //genera pdf de todos los registros
        private void GenerarPdf(DataTable tblReporte,string NombreReporte)
        {
            //Dimensiones del documento
            Document documento = new Document(PageSize.LETTER, 50, 100, 20, 100);
            //creamos el  documento
            //ruta donde se encuentra nuestra apliccaion
            try
            {
                PdfWriter WriterPdf = PdfWriter.GetInstance(documento, new FileStream(@"C: \Users\user\Desktop\BajaUABC5\SisBajaUabc\PDF_Generados\TodosLosRegistros\" + NombreReporte, FileMode.Create));
            //abrimos el documento
            documento.Open();
                // Titulo del archivo
                // Font font248 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, Font.BOLD, BaseColor.BLUE);
                // Phrase Titulo = new Phrase("Reporte De Alumnos", font248);


                PdfPTable TblHeader = new PdfPTable(1); // 1 columna
                TblHeader.WidthPercentage = 100;

                Paragraph Parrafo = new Paragraph(Chunk.NEWLINE + "UNIVERSIDAD AUTÓNOMA DE BAJA CALIFORNIA" + Chunk.NEWLINE, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 19, Font.BOLD, BaseColor.DARK_GRAY));
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
            //creacion de la tabla que se mostrara en el pdf
            PdfPTable table = new PdfPTable(12);
            Font LetraTituloTabla = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLDITALIC);
                //creamos las cabecerar de la tabla
                PdfPCell celdaIDMatricula = new PdfPCell(new Phrase("Matricula", LetraTituloTabla));
                PdfPCell celdaNombre = new PdfPCell(new Phrase("Nombre", LetraTituloTabla));
              // PdfPCell celdaSNombre = new PdfPCell(new Phrase("S.Nombre", LetraTituloTabla));
              PdfPCell celdaAppPaterno = new PdfPCell(new Phrase("ApPaterno", LetraTituloTabla));
              PdfPCell celdaApMaterno = new PdfPCell(new Phrase("ApMaterno", LetraTituloTabla));
              PdfPCell celdaSexo = new PdfPCell(new Phrase("Sexo", LetraTituloTabla));
              PdfPCell celdaEdad = new PdfPCell(new Phrase("Edad", LetraTituloTabla));
              PdfPCell celdaDireccion = new PdfPCell(new Phrase("Dirc", LetraTituloTabla));
                PdfPCell celdaCarrera = new PdfPCell(new Phrase("Carrera", LetraTituloTabla));
                PdfPCell celdaCorreo = new PdfPCell(new Phrase("Correo", LetraTituloTabla));
               PdfPCell celdaSemestre = new PdfPCell(new Phrase("Semestre", LetraTituloTabla));
                PdfPCell celdaCelular = new PdfPCell(new Phrase("Cel", LetraTituloTabla));
                //PdfPCell celdaTelefono = new PdfPCell(new Phrase("Tel", LetraTituloTabla));
                PdfPCell celdaEstado = new PdfPCell(new Phrase("Estado", LetraTituloTabla));
                celdaIDMatricula.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaNombre.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaAppPaterno.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaApMaterno.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaSexo.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaEdad.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaDireccion.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaCarrera.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaCorreo.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaSemestre.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaCelular.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaEstado.BackgroundColor = BaseColor.LIGHT_GRAY;


                //Agregamos las cabeceras ala tabla


                table.AddCell(celdaIDMatricula);
                table.AddCell(celdaNombre);
              //  table.AddCell(celdaSNombre);
                table.AddCell(celdaAppPaterno);
               table.AddCell(celdaApMaterno);
               table.AddCell(celdaSexo);
                table.AddCell(celdaEdad);
                /*

                // table.AddCell(celdaTelefono);*/
                table.AddCell(celdaDireccion);
                table.AddCell(celdaCarrera);
                table.AddCell(celdaCorreo);
                table.AddCell(celdaSemestre);
              table.AddCell(celdaCelular);
                table.AddCell(celdaEstado);










                //recorremos todas las filas del datatable
                foreach (DataRow fila in tblReporte.Rows)
            {
                table.AddCell(fila[0].ToString());
                table.AddCell(fila[1].ToString());
                table.AddCell(fila[2].ToString());
                table.AddCell(fila[3].ToString());
                table.AddCell(fila[4].ToString());
                table.AddCell(fila[5].ToString());
               table.AddCell(fila[6].ToString());
                table.AddCell(fila[7].ToString());
              table.AddCell(fila[8].ToString());
               table.AddCell(fila[9].ToString());
               table.AddCell(fila[10].ToString());
                table.AddCell(fila[11].ToString());
               /* table.AddCell(fila[12].ToString());*/
                    // table.AddCell(fila[10].ToString());
                    //table.AddCell(fila[11].ToString());
                }
            table.TotalWidth = 500;
            table.WriteSelectedRows(0, -1, 50, 680, WriterPdf.DirectContent);
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


            
            documento.Add(paragraph);

            documento.Add(jpg);
           
            documento.Close();
            
        }
        //gridview
        protected void DatodelAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selecciona de la primera fila
            GridViewRow filaSeleccionada = DatodelAlumno.SelectedRow;
            //obtenemos el id de empleado
            string Matricula = filaSeleccionada.Cells[0].Text;
            //con el metodo slect del datatable podemos hacer consultas ala tabla
            DataRow filaReporte = tblAlumn.Select("Matricula=" + Matricula)[0];
            string nombreReporte = "Solicitud" + Matricula + ".pdf";
            GenerarPdf( filaReporte, nombreReporte);
            //abre el pdf de la url
            Process.Start(@"C:\Users\user\Desktop\BajaUABC5\SisBajaUabc\PDF_Generados\Solicitudes\"+nombreReporte);
            // Response.Redirect("~/ReportesPDF/" + nombreReporte);
        }
        //metodo para generar pdf individual
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
                PdfWriter WriterPdf = PdfWriter.GetInstance(documento, new FileStream(@"C:\Users\user\Desktop\BajaUABC5\SisBajaUabc\PDF_Generados\Solicitudes\" + nombreReporte, FileMode.Create));
                //abrimos el documento
                documento.Open();
                // Titulo del archivo
                // Font font248 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, Font.BOLD, BaseColor.BLUE);
                // Phrase Titulo = new Phrase("Reporte De Alumnos", font248);


                PdfPTable TblHeader = new PdfPTable(1); // 1 columna
                TblHeader.WidthPercentage = 100;

                Paragraph Parrafo = new Paragraph(Chunk.NEWLINE + "UNIVERSIDAD AUTÓNOMA DE BAJA CALIFORNIA" + Chunk.NEWLINE, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 19, Font.BOLD, BaseColor.DARK_GRAY));
                Paragraph saltoDeLinea7 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                documento.Add(saltoDeLinea7);
                Paragraph Parrafo2 = new Paragraph("FACULTAD DE INGENIERÍA ARQUITECTURA Y DISEÑO" + Chunk.NEWLINE, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 19, Font.BOLD, BaseColor.DARK_GRAY));

                PdfPCell CellHeader = new PdfPCell(Parrafo);
                PdfPCell CellHeader2 = new PdfPCell(Parrafo2);
                Paragraph saltoDeLinea6 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                documento.Add(saltoDeLinea6);
                Paragraph text = new Paragraph("REPORTE DE ALUMNOS SOLICITUD " + Chunk.NEWLINE, FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 18, Font.BOLD, BaseColor.BLACK));
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
                PdfPTable table1 = new PdfPTable(3);
                PdfPTable table2 = new PdfPTable(3);
                PdfPTable table3 = new PdfPTable(3);
                PdfPTable table4 = new PdfPTable(3);
                Font LetraTituloTabla = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13, Font.COURIER, BaseColor.BLACK);
                //creamos las cabecerar de la tabla
                PdfPCell celdaIDMatricula = new PdfPCell(new Phrase("Matricula",LetraTituloTabla));
          
                PdfPCell celdaNombre = new PdfPCell(new Phrase("Nombre", LetraTituloTabla));
               // PdfPCell celdaSNombre = new PdfPCell(new Phrase("S.Nombre", LetraTituloTabla));
                PdfPCell celdaAppPaterno = new PdfPCell(new Phrase("ApPaterno", LetraTituloTabla));
               PdfPCell celdaApMaterno = new PdfPCell(new Phrase("ApMaterno", LetraTituloTabla));
               PdfPCell celdaSexo = new PdfPCell(new Phrase("Sexo", LetraTituloTabla));
               PdfPCell celdaEdad = new PdfPCell(new Phrase("Edad", LetraTituloTabla));
               PdfPCell celdaDireccion = new PdfPCell(new Phrase("Dirc", LetraTituloTabla));
                PdfPCell celdaCarrera = new PdfPCell(new Phrase("Carrera", LetraTituloTabla));
                PdfPCell celdaCorreo = new PdfPCell(new Phrase("Correo", LetraTituloTabla));
                PdfPCell celdaSemestre = new PdfPCell(new Phrase("Semestre", LetraTituloTabla));
               PdfPCell celdaCelular = new PdfPCell(new Phrase("Cel", LetraTituloTabla));
                //PdfPCell celdaTelefono = new PdfPCell(new Phrase("Tel", LetraTituloTabla));
                PdfPCell celdaEstado = new PdfPCell(new Phrase("Estado", LetraTituloTabla));
                celdaIDMatricula.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaNombre.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaAppPaterno.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaApMaterno.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaSexo.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaEdad.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaDireccion.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaCarrera.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaCorreo.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaSemestre.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaCelular.BackgroundColor = BaseColor.LIGHT_GRAY;
                celdaEstado.BackgroundColor = BaseColor.LIGHT_GRAY;
               


                //Agregamos las cabeceras ala tabla
                table1.AddCell(celdaIDMatricula);
                
                table1.AddCell(celdaNombre);
               /* table.AddCell(celdaSNombre);*/
                table1.AddCell(celdaAppPaterno);
              table2.AddCell(celdaApMaterno);
              table2.AddCell(celdaSexo);
               table2.AddCell(celdaEdad);
                // table.AddCell(celdaTelefono);
                table3.AddCell(celdaDireccion);
                table3.AddCell(celdaCarrera);
                table3.AddCell(celdaCorreo);
               table4.AddCell(celdaSemestre);
               table4.AddCell(celdaCelular);
                table4.AddCell(celdaEstado);

                //recorremos todas las filas del datatable
               // foreach (DataRow fila in filaReporte.Rows)
               // {
                    table1.AddCell(FilaDatos[0].ToString());
            
                table1.AddCell(FilaDatos[1].ToString());
                    table1.AddCell(FilaDatos[2].ToString());
                    table2.AddCell(FilaDatos[3].ToString());
                    table2.AddCell(FilaDatos[4].ToString());
                    table2.AddCell(FilaDatos[5].ToString());
                   table3.AddCell(FilaDatos[6].ToString());
                  table3.AddCell(FilaDatos[7].ToString());
                  table3.AddCell(FilaDatos[8].ToString());
                   table4.AddCell(FilaDatos[9].ToString());
                    table4.AddCell(FilaDatos[10].ToString());
                   table4.AddCell(FilaDatos[11].ToString());
                 /*   table.AddCell(FilaDatos[12].ToString());*/
                // table.AddCell(fila[10].ToString());
                //table.AddCell(fila[11].ToString());
                // }
                table1.TotalWidth = 600;
                table1.WriteSelectedRows(0, -1, 10, 670, WriterPdf.DirectContent);
                table2.TotalWidth = 600;
                table2.WriteSelectedRows(0, -1, 10, 610, WriterPdf.DirectContent);
                table3.TotalWidth = 600;
                table3.WriteSelectedRows(0, -1, 10, 550, WriterPdf.DirectContent);
                table4.TotalWidth = 600;
                table4.WriteSelectedRows(0, -1, 10, 490, WriterPdf.DirectContent);
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
            Paragraph pie = new Paragraph("______________________ " + Chunk.NEWLINE + "Firma", FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 18, Font.BOLD, BaseColor.BLACK));
            pie.Alignment = Element.ALIGN_CENTER;


            documento.Add(paragraph);

            documento.Add(jpg);
            documento.Add(pie);
            documento.Close();
        }
        ///genera el pdf total
        protected void ibTodoPdf_Click(object sender, ImageClickEventArgs e)
        {
            
            string nombreReporte = "pdfTodo.pdf";
            GenerarPdf(tblAlumn, nombreReporte);
            lblMensaje.Visible = true;
            lblMensaje.Text = "REPORTE GENERADO CORRECTAMENTE";
            
            

        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            if(lblMensaje.Text== "REPORTE GENERADO CORRECTAMENTE")
            {
                Process.Start(@"C:\Users\user\Desktop\BajaUABC5\SisBajaUabc\PDF_Generados\TodosLosRegistros\pdfTodo.pdf");
            }
            else
            { 
           
                lblMensaje.Visible = true;
                lblMensaje.Text = "Aun no se genera el reporte";
            }
        }

        protected void DatodelAlumno_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DatodelAlumno.EditIndex = e.NewEditIndex;
            cargarDatosAlumno();

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            //oculta el panel o lo hace visible
            PanelGvEditar.Visible = true;
            PanelGvMostrar.Visible = false;
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            PanelGvEditar.Visible = false;
            PanelGvMostrar.Visible = true;
        }
    }

        

      
    
}