using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactApp
{
    public partial class search : Form
    {
        IContanctsRepository repository;
        mainWindow Main;

        public search(mainWindow main)
        {
            Main = main;
            InitializeComponent();
            repository = new ContanctsRepository();
        }

        private void Form2_Load(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string q = $@"SELECT distinct Companies.[id],[CategoryID], CONVERT(varchar,LastUpdate,101) as LastUpdate,[UniqueID],[LegalName],[DBAName],[USDOTNumber],[ApcantID],[CANumber]
                FROM Companies 
                LEFT JOIN Contacts ON Companies.ID = Contacts.CompanyID 
				LEFT JOIN DocketNumbers DN ON Companies.ID = DN.CompanyID
                WHERE Companies.Deleted='False'";

            //UNIQUEID
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                q += $" and UniqueID like '%{textBox1.Text.Trim()}%'";
            }
            //LEGALNAME
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                q += $" and LegalName like '%{textBox2.Text.Trim()}%'";
            }
            //DBANAME
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                q += $" and DBAName like '%{textBox3.Text.Trim()}%'";
            }
            //PHONE
            if (!string.IsNullOrEmpty(maskedTextBox1.Text.Replace("-", "").Replace("(","").Replace(")", "").Trim()))
            {
                q += $@" and NPN_Value in (select NPN_Value from Contacts where NPN_Value like '%{maskedTextBox1.Text.Replace("-", "").Replace("(", "").Replace(")", "").Trim()}%' and Type = 4)";

            }
            //FAX
            if (!string.IsNullOrEmpty(maskedTextBox2.Text.Replace("-", "").Replace("(", "").Replace(")", "").Trim()))
            {
                q += $@" and NPN_Value in (select NPN_Value from Contacts where NPN_Value like '%{maskedTextBox2.Text.Replace("-", "").Replace("(", "").Replace(")", "").Trim()}%' and Type = 5)";

            }
            //WEBSITE
            if (!string.IsNullOrEmpty(textBox14.Text))
            {
                q += $" and Value like '%{textBox14.Text.Trim()}%'";
            }
            //EMAIL
            if (!string.IsNullOrEmpty(textBox8.Text))
            {
                q += $" and Value like '%{textBox8.Text.Trim()}%'";
            }
            //COUNTRY
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                q += $" and Country like '%{textBox4.Text.Trim()}%'";
            }
            //STATE
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                q += $" and state like '%{textBox5.Text.Trim()}%'";
            }
            //CITY
            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                q += $" and city like '%{textBox6.Text.Trim()}%'";
            }
            //ZIPCODE
            if (!string.IsNullOrEmpty(textBox7.Text))
            {
                q += $" and Zip LIKE '%{textBox7.Text.Trim()}%' ";
            }
            //ADDRESS
            if (!string.IsNullOrEmpty(textBox16.Text))
            {
                q += $" and ADDRESS LIKE '%{textBox16.Text.Trim()}%' ";
            }

            DataTable dataTable =  repository.SelectAllRunner(q);
            Main.param = dataTable;
            this.DialogResult = DialogResult.OK;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
