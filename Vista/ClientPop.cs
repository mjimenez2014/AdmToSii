using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Limilabs.Client.IMAP;
using Limilabs.Client.POP3;
using Limilabs.Client.SMTP;
using Limilabs.Mail;
using Limilabs.Mail.MIME;
using Limilabs.Mail.Fluent;
using Limilabs.Mail.Headers;


namespace Vista
{
    public partial class ClientPop : Form
    {
        public ClientPop()
        {
            InitializeComponent();
        }

        private void ClientPop_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Pop3 pop3 = new Pop3())
            {
                pop3.Connect("mail.invoicedigital.cl");       // or ConnectSSL for SSL
                pop3.UseBestLogin("test@invoicedigital.cl", "sopabru2011");

                foreach (string uid in pop3.GetAll())
                {
                    IMail email = new MailBuilder()
                        .CreateFromEml(pop3.GetMessageByUID(uid));
                    Console.WriteLine("===================================================");
                    Console.WriteLine(email.Subject);
                    Console.WriteLine(email.Text);
                    foreach (MimeData mime in email.Attachments)
                    {

                        mime.Save(@"C:\AdmToSii\file\libroCompra\proveedores\" + mime.SafeFileName);


                    }
                    Console.WriteLine("===================================================");
                }
                pop3.Close();
            }

        }
    }
}
