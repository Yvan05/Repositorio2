using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Mensajes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void EnviaEmail(string pEmailDestino, string pCopia, string pSubjet, string pMensaje, List<string> ArchivoPedido_ = null)
        {
            try
            {
                MailMessage Email = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                Email.SubjectEncoding = Encoding.UTF8;
                Email.BodyEncoding = Encoding.UTF8;
                Email.From = new MailAddress("ylinares@uabc.edu.mx", "Administrador del sistema");
                Email.Subject = pSubjet;
                Email.Body = pMensaje + "SU SOLICITUD DE BAJA HA SIDO ACEPTADA PARA VERIFICAR INGRESE ALA SECCION DE ESTADO Y REVISE EL ESTADO DE SU SOLICITUD,GRACIAS.  : " + GenerarCodigo();

                MailAddress copy = new MailAddress(pCopia);
                Email.CC.Add(copy);

                MailAddress Bcopy = new MailAddress(pCopia);
                Email.Bcc.Add(Bcopy);

                if (ArchivoPedido_ != null)
                {
                    foreach (string archivo in ArchivoPedido_)
                    {

                        if (System.IO.File.Exists(@archivo))
                            Email.Attachments.Add(new Attachment(@archivo));
                    }
                }

                Email.To.Add(pEmailDestino);
                SmtpServer.Port = 587; //SMTP de GMAIL
                SmtpServer.Credentials = new NetworkCredential("ylinares@uabc.edu.mx", "1995100317x");      //Hay que crear las credenciales del correo emisor
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(Email);

                lblMsg.Text = "MENSAJE ENVIADO";
            }
            catch (SmtpException ex)
            {
                throw new Exception(lblMsg.Text + ex);
            }
        }

        protected void btnMensaje_Click(object sender, EventArgs e)
        {
            // Se crea la lista de archivos a enviar

            List<string> LstArchivos = new List<string>();

            LstArchivos.Add("d:/NET_Adapter.pptx");
            LstArchivos.Add("d:/Ejemplo 2.docx");


            EnviaEmail(tbdir.Text, tbdir2.Text, tbAsunto.Text, tbMensaje.Text, LstArchivos);
            lblMsg.Visible = true;
            lblMsg.Text = "EL MENSAJE A SIDO ENVIADO";

        }
        public string GenerarCodigo()
        {
            string Codigo = string.Empty;
            int i;

            Random rnd = new Random();
            for (i = 0; i < 5; i++)
                Codigo += Convert.ToChar(rnd.Next(65, 90)).ToString();

            return Codigo;
        }
    }
}