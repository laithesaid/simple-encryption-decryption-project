using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;

namespace EncryptionSolo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string hash = "ENCryPtIon SolO";

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(textBox1.Text); //converting text into a byte array
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) //creating an instance of the md5crypto class
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash)); //this returns the has as an array of 16 bytes
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })    //set the secret key for the tripleDES algorithm
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();    //transform the specified region of bytes array to resultArray

                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);    //Release resources held by TripleDes Encryptor

                    textBox2.Text = Convert.ToBase64String(results, 0, results.Length);  //prints in second textbox

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string password;
            password = "1";

            if (checkBox2.Checked == false)
            {

                //else if (password == textBox4.Text)
                //  {
                byte[] data = Convert.FromBase64String(textBox2.Text);
                //if hashing was used get the hash code with regards to your key
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                    { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })//set the secret key for the tripleDES algorithm
                    {
                        ICryptoTransform transform = tripDes.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);    //Release resources held by TripleDes Encryptor  
                        string decryptresult = UTF8Encoding.UTF8.GetString(results);
                        //string path = @"C:\Users\laith\Desktop\University First Semester 2020\System Analysis\decryptresult.txt";

                        if (checkBox1.Checked)
                        {
                            try
                            {

                                TextWriter tw = new StreamWriter(@"C:\Users\laith\Desktop\University First Semester 2020\System Analysis\decryptresult.txt", true);
                                tw.WriteLine(decryptresult);
                                tw.Close();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(e);
                                throw;
                            }

                            // File.WriteAllText( path,decryptresult);
                            // @"C: \Users\laith\Desktop\University First Semester 2020\System Analysis
                        }


                        else
                        {
                            textBox3.Text = UTF8Encoding.UTF8.GetString(results); //prints decrypted data in third textbox

                        }


                    }
                }
            }
            else if (checkBox2.Checked && (password == null || textBox4.Text != password))
            {
                MessageBox.Show("WRONG PASSWORD PLEASE RE ENTER ASSIGNED PASSWORD BY THE COMPANY",
                                "ERROR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                textBox4.Text = "";
            }


            else if (checkBox2.Checked && password == textBox4.Text)
            {
                byte[] data = Convert.FromBase64String(textBox2.Text);
                //if hashing was used get the hash code with regards to your key
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                    { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })//set the secret key for the tripleDES algorithm
                    {
                        ICryptoTransform transform = tripDes.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);    //Release resources held by TripleDes Encryptor  
                        string decryptresult = UTF8Encoding.UTF8.GetString(results);
                        //string path = @"C:\Users\laith\Desktop\University First Semester 2020\System Analysis\decryptresult.txt";

                        if (checkBox1.Checked)
                        {
                            try
                            {

                                TextWriter tw = new StreamWriter(@"C:\Users\laith\Desktop\University First Semester 2020\System Analysis\decryptresult.txt", true);
                                tw.WriteLine(decryptresult);
                                tw.Close();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(e);
                                throw;
                            }

                            // File.WriteAllText( path,decryptresult);
                            // @"C: \Users\laith\Desktop\University First Semester 2020\System Analysis
                        }


                        else
                        {
                            textBox3.Text = UTF8Encoding.UTF8.GetString(results); //prints decrypted data in third textbox

                        }


                    }
                }
            }
            }

        


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}



