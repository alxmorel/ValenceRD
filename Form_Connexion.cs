using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Security.Permissions;


namespace ValenceRD
{
    public partial class Form_Connexion : Form
    {
        public Form_Connexion()
        {
            InitializeComponent();
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            lblInfosOubliees.Font = new Font(lblInfosOubliees.Font.Name, lblInfosOubliees.Font.SizeInPoints, FontStyle.Underline);
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            lblInfosOubliees.Font = new Font(lblInfosOubliees.Font.Name, lblInfosOubliees.Font.SizeInPoints, FontStyle.Regular);
        }


        string hash = "f0xle@rn";

        private string Encrypt(string value)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(value);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        private string Decrypt(string value)
        {
            byte[] data = Convert.FromBase64String(value);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }



        // IP : 185.116.106.73
        // Port : 389

        // Username : admin_ldap (CN=admin_ldap,OU=VALENCE,OU=DOMAINE,DC=buena-vista-medical,DC=ovh)
        // Pass : e-EpT&*H5dXG

        // User valence : user_valence
        // Mdp user Valence : 01_Admin

        // admin@buena-vista-medical-ovh

        /// <summary>
        /// Cette fonction permetra de se connecter au LDAP de fçon anonyme, de récupérer les informations d'un utilisateur clairement défini
        /// </summary>
        /// <param name="strusername">Le nom de l'utilisateur recherché</param>
        /// <returns>Les informations de l'utilisateurs</returns>
        public bool UserAccessActiveDirectory(string user, string pass)
        {
            try
            {
                // Create the new LDAP connection
                LdapDirectoryIdentifier ldi = new LdapDirectoryIdentifier("185.116.106.73", 389);
                System.DirectoryServices.Protocols.LdapConnection ldapConnection =
                    new System.DirectoryServices.Protocols.LdapConnection(ldi);
                Console.WriteLine("LdapConnection is created successfully.");
                ldapConnection.AuthType = AuthType.Basic;
                ldapConnection.SessionOptions.ProtocolVersion = 3;
                NetworkCredential nc = new NetworkCredential("CN=" + user + ",OU=VALENCE,OU=DOMAINE,DC=buena-vista-medical,DC=ovh", pass); //password
                ldapConnection.Bind(nc);
                Console.WriteLine("LdapConnection authentication success");
                ldapConnection.Dispose();
                return true;
            }
            catch (LdapException e)
            {
                Console.WriteLine("\r\nUnable to login:\r\n\t" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" + e.GetType() + ":" + e.Message);
                return false;
            }
        }






        private void button2_Click(object sender, EventArgs e)
        {
            if (! string.IsNullOrEmpty(inputUser.Text) || !string.IsNullOrEmpty(inputMdp.Text))
            {
                /////////////CONNEXION SANS MDP CHECK - A METTRE EN COMMENTAIRE SI CONNEXION AVEC MDP CHECK EST ACTIVEE///////////
                this.Hide();
                MainPageRDValence main = new MainPageRDValence();
                main.StartPosition = FormStartPosition.CenterParent;
                main.Show();
                ////////////////////////////////FIN CONNEXION SANS MDP CHECK//////////////////////////////
                //ATTENTION LE SERVEUR ACTIVE DIRECTORY DOIT ÊTRE OUVERT !
                /*
                if (UserAccessActiveDirectory(inputUser.Text, inputMdp.Text))
                {
                    this.Hide();
                    MainPageRDValence main = new MainPageRDValence();
                    main.StartPosition = FormStartPosition.CenterParent;
                    main.Show();
                }
                */

                //CONNEXION AVEC MDP CHECK
                /////////////A METTRE EN COMMENTAIRE LA CONNECTION LOCALHOST///////////
                // String mdpEncrypt = Encrypt(inputMdp.Text);

                // DBConnection dbCon = DBConnection.Instance();
                // dbCon.DatabaseName = "r_d_valence";

                // if (dbCon.IsConnect())
                // {
                //     Console.WriteLine("DB CONNECTION FAITE !");

                //     string queryUserMdp = "select count(*) from login where user =\"" + inputUser.Text + "\" and password =\"" + mdpEncrypt + "\" ";
                //     MySqlCommand cmdIdVersion = new MySqlCommand(queryUserMdp, dbCon.Connection);
                //     MySqlDataReader readerUserMdp = cmdIdVersion.ExecuteReader();

                //     if (readerUserMdp.HasRows)
                //     {
                //         readerUserMdp.Read();

                //         if (readerUserMdp.GetInt32(0)==1)
                //         {
                //             Console.WriteLine("Couple user / mot de passe trouvé");

                //             this.Hide();
                //             MainPageRDValence main = new MainPageRDValence();
                //             main.StartPosition = FormStartPosition.CenterParent;
                //             main.Show();
                //         }
                //         else
                //         {
                //             Console.WriteLine("Couple user / mot de passe non trouvé");
                //             MessageBox.Show("Please enter a valid username and password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //         }
                //     }
                //     else
                //     {
                //         Console.WriteLine("La requète n'a pas renvoyé de ligne");
                //     }
                //     readerUserMdp.Close();
                // }
                // dbCon.Close();
                /////////////FIN A METTRE EN COMMENTAIRE LA CONNECTION LOCALHOST///////////
            }
            else
            {
                MessageBox.Show("Please enter a username and a password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void lblInfosOubliees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            InfosOubliees formInfoOublie = new InfosOubliees();
            formInfoOublie.StartPosition = FormStartPosition.CenterParent;
            formInfoOublie.Show();
        }



        private void press_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                button2_Click(sender, e);
            }
        }


    }
}
