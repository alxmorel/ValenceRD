using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValenceRD
{
    public partial class InfosOubliees : Form
    {
        public InfosOubliees()
        {
            InitializeComponent();
        }

        private void inputAdresse_Enter(object sender, EventArgs e)
        {
            if (inputAdresse.Text =="Adresse e-mail")
            {
                inputAdresse.Text = "";
                inputAdresse.ForeColor = Color.Black;
            }
        }

        private void inputAdresse_Leave(object sender, EventArgs e)
        {
            if (inputAdresse.Text == "")
            {
                inputAdresse.Text = "Adresse e-mail";
                inputAdresse.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Connexion formCo = new Form_Connexion();
            formCo.StartPosition = this.StartPosition;
            formCo.Show();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputAdresse.Text))
            {
                MessageBox.Show("Veuillez saisir une adresse e-mail liée à votre compte", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (IsValidEmail(inputAdresse.Text))
                {
                    Console.WriteLine("Envoie mail de récupération du mot de passe");
                    //Connexion a la base et verif que le mail est lié à un compte puis récup données et envoie de l'e-mail
                    EnvoieMailRecupMotDePasse(inputAdresse.Text);
                }
                else
                {
                    MessageBox.Show("Veuillez entrer une adresse e-mail valide", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        public static void EnvoieMailRecupMotDePasse(String mail)
        {
            String server = "smtp.gmail.com";
            int port = 587;
            string from = "rd.valence@gmail.com";
            string mdp = "rdValence";
            string subject = "Récupération de vos informations personnelles de connexion";
            string body = @"Voici un récapitulatif de vos informations personnelles liées à votre e-mail : ";
            MailMessage msg = new MailMessage(from, mail, subject, body);
            SmtpClient client = new SmtpClient(server, port);
            // Credentials are necessary if the server requires the client
            // to authenticate before it will send e-mail on the client's behalf.
            
            client.Credentials = new NetworkCredential(from, mdp);
            client.Port = port;
            client.Host = server;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            msg.Priority = MailPriority.Normal;
            msg.BodyEncoding = Encoding.UTF8;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
           
            client.Send(msg);
            MessageBox.Show("Un e-mail de récupération de votre mot de passe vous a été envoyé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void press_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnRechercher_Click(sender, e);
            }
        }
    }
}
