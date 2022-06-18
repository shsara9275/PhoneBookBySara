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
            if (!string.IsNullOrEmpty(maskedTextBox1.Text.Trim().Replace('-', ' ').Replace('(',' ').Replace(')', ' ').Trim()))
            {
                q += $@" and npn_value in (select npn_value from Contacts inner join Companies on Companies.id = Contacts.CompanyID 

                                    where NPN_Value LIKE '%{maskedTextBox1.Text.Trim().Replace('-', ' ').Replace('(', ' ').Replace(')', ' ')}%' and type = 4 )";

            }
            //FAX
            if (!string.IsNullOrEmpty(maskedTextBox2.Text.Trim().Replace('-', ' ').Replace('(', ' ').Replace(')', ' ').Trim()))
            {
                q += $@" and npn_value in (select npn_value from Contacts inner join Companies on Companies.id = Contacts.CompanyID 

                                    where NPN_Value LIKE '%{maskedTextBox2.Text.Trim().Replace('-', ' ').Replace('(', ' ').Replace(')', ' ')}%' and type = 4 )";

            }
            //WEBSITE
            if (!string.IsNullOrEmpty(textBox14.Text))
            {
                
            }
            //EMAIL
            if (!string.IsNullOrEmpty(textBox8.Text))
            {

            }
            //COUNTRY
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                q += $" and Country in ({textBox4})";
            }
            //STATE
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                q += $" and state in ({textBox5})";
            }
            //CITY
            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                q += $" and city in ({textBox6})";
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

            //var _maskedTextBox1 = maskedTextBox1.Text.Trim().Length < 11 ? string.Empty : maskedTextBox1.Text;
            //var _maskedTextBox2 = maskedTextBox2.Text.Trim().Length < 11 ? string.Empty : maskedTextBox2.Text;
            //var _textBox14 = textBox14.Text.Trim().Length < 11 ? string.Empty : textBox14.Text;
            //var _textBox8 = textBox8.Text.Trim().Length < 11 ? string.Empty : textBox8.Text;

            //string q = $"SELECT distinct Companies.[id]," +
            //    $"[CategoryID]," +
            //    $"CONVERT(varchar,LastUpdate,101) as LastUpdate," +
            //    $"[UniqueID]," +
            //    $"[LegalName]," +
            //    $"[DBAName]," +
            //    $"[USDOTNumber]," +
            //    $"[ApcantID]," +
            //    $"[CANumber] " +
            //    $"FROM Companies " +
            //    $"INNER JOIN Contacts ON Companies.ID = Contacts.CompanyID " +
            //    $"WHERE Contacts.Deleted='False' " +
            //    $"AND Companies.Deleted='False' " +
            //    $"AND UniqueID LIKE '%{textBox1.Text}%' " +
            //    $"AND  LegalName LIKE '%{textBox2.Text}%' " +
            //    $"AND  DBAName LIKE '%{textBox3.Text}%'  " +
            //    $"AND  (Value LIKE '%{_maskedTextBox1}%'  AND  Value LIKE '%{_maskedTextBox2}%' AND  Value LIKE '%{_textBox14}%' AND  Value LIKE '%{_textBox8}%' )" +
            //    $"AND  Address LIKE '%{textBox16.Text}%' " +
            //    $"AND  Country LIKE '%{textBox4.Text}%' " +
            //    $"AND  City LIKE '%{textBox6.Text}%' " +
            //    $"AND  Zip LIKE '%{textBox7.Text}%'";

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
