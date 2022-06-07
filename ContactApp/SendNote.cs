﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactApp.Components;
using System.Linq;

namespace ContactApp
{
    public partial class SendNote : Form
    {
        List<CCBoxItem> citySelected;
        List<CCBoxItem> countrySelected;
        List<CCBoxItem> stateSelected;
        List<CCBoxItem> phoneBookSelected;
        List<CCBoxItem> categorySelected;
        string _citySelected;
        string _stateSelected;
        string _countrySelected;
        string _lastUpdateFromTextBox;
        string _lastUpdateToTextBox;
        string _legalNameTextBox;
        string _dbaNameTextBox;
        string _fromUsDotNumberTextBox;
        string _toUsDotNumberTextBox;
        string _mcNumberTextBox;
        string _fromCanNumberTextBox;
        string _toCanNumberTextBox;
        string _fromApcantIDTextBox;
        string _toApcantIDTextBox;
        string _fromPhoneTextBox;
        string _toPhoneTextBox;
        string _fromFaxTextBox;
        string _toFaxTextBox;
        string _fromZipCodeTextBox;
        string _toZipCodeTextBox;
        string _categorySelected;

        public SendNote()
        {
            InitializeComponent();
            repository = new ContanctsRepository();
        }

        IContanctsRepository repository;
        private void SendNote_Load(object sender, EventArgs e)
        {
            FillFilteredDataGrid(null, null);
            CityComboBoxFillDataSource(null);
            StateComboBoxFillDataSource(null);
            CountryComboBoxFillDataSource(null);
            PhoneBookComboBoxFillDataSource(null);
            citySelected = new List<CCBoxItem>();
            countrySelected = new List<CCBoxItem>();
            stateSelected = new List<CCBoxItem>();
            phoneBookSelected = new List<CCBoxItem>();
            categorySelected = new List<CCBoxItem>();
        }

        private void PhoneBookComboBoxFillDataSource(string q)
        {
            DataTable dt;
            if (q == null)
            {
                string query = "SELECT [ID],[Title] FROM [dbo].[PhoneBooks] WHERE Deleted='False' union all select NEWID() ,N'All' ORDER BY [Title]";
                dt = repository.SelectAllRunner(query);
            }
            else
            {
                string query = q;
                dt = repository.SelectAllRunner(query);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CCBoxItem item = new CCBoxItem(dt.Rows[i]["Title"].ToString(), dt.Rows[i]["ID"].ToString());
                phoneBookCheckedComboBox.Items.Add(item);

            }

        }

        private void CategoryComboBoxFillDataSource(string q, string phoneBookID)
        {
            DataTable dt;
            if (q == null)
            {
                string query = "";
                if (phoneBookID == null)
                {
                    query = $"SELECT [ID],[Title],[ParentID],[PhoneBookID] FROM [dbo].[Categories] WHERE Deleted='False' AND PhoneBookID=PhoneBookID AND Title != 'None'AND ParentID = '7cf2f60e-6903-4cb4-b642-0b060aacf2d9' ORDER BY [Title]";

                }
                else
                {
                    query = $"SELECT [ID],[Title],[ParentID],[PhoneBookID] FROM [dbo].[Categories] WHERE Deleted='False' AND PhoneBookID='{phoneBookID}'AND Title != 'None'AND ParentID = '7cf2f60e-6903-4cb4-b642-0b060aacf2d9' ORDER BY [Title]";
                }
                dt = repository.SelectAllRunner(query);
            }
            else
            {
                string query = q;
                dt = repository.SelectAllRunner(query);
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CCBoxItem item = new CCBoxItem(dt.Rows[i]["Title"].ToString(), dt.Rows[i]["ID"].ToString());

                bool isExist = categoryCheckedComboBox.Items
                                .Cast<CCBoxItem>()
                                .ToList()
                                .Any(a => a.ID.ToString() == item.ID.ToString());

                if (!isExist)
                {
                    var items1 = categoryCheckedComboBox.CheckedItems;
                    categoryCheckedComboBox.Items.Add(item);

                }

            }

        }

        private void CityComboBoxFillDataSource(string q)
        {
            DataTable dt;
            if (q == null)
            {
                string query = "Select distinct City from [dbo].[Contacts]where city is not null and TRIM(City) != ''";
                dt = repository.SelectAllRunner(query);
            }
            else
            {
                string query = q;
                dt = repository.SelectAllRunner(query);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CCBoxItem item = new CCBoxItem(dt.Rows[i]["City"].ToString(), i);
                cityCheckedComboBox.Items.Add(item);

            }

            //cityCheckedComboBox.ValueMember = "id";
            //cityCheckedComboBox.DisplayMember = "City";
            //cityCheckedComboBox.DataSource = dt;
            //cityCheckedComboBox.Columns[0].Visible = false;
            //cityCheckedComboBox.Columns[1].Visible = false;
            //cityCheckedComboBox.ClearSelection();

        }

        private void StateComboBoxFillDataSource(string q)
        {
            DataTable dt;
            if (q == null)
            {
                string query = "select distinct State from [dbo].[Contacts] where State is not null and TRIM(State) != '' ";
                dt = repository.SelectAllRunner(query);
            }
            else
            {
                string query = q;
                dt = repository.SelectAllRunner(query);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CCBoxItem item = new CCBoxItem(dt.Rows[i]["State"].ToString(), i);
                stateCheckedComboBox.Items.Add(item);

            }

        }
        private void CountryComboBoxFillDataSource(string q)
        {
            DataTable dt;
            if (q == null)
            {
                string query = "select distinct Country from [dbo].[Contacts] where Country is not null and TRIM(Country) != '' ";
                dt = repository.SelectAllRunner(query);
            }
            else
            {
                string query = q;
                dt = repository.SelectAllRunner(query);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CCBoxItem item = new CCBoxItem(dt.Rows[i]["Country"].ToString(), i);
                countryCheckedComboBox.Items.Add(item);

            }

        }

        private void FillFilteredDataGrid(string selectedNodeArray, string q)
        {
            DataTable dt;
            if (q == null)
            {
                //string query = "SELECT [id],[CategoryID], CONVERT(varchar,LastUpdate,101) as LastUpdate,[UniqueID],[LegalName],[DBAName],[USDOTNumber],[ApcantID],[CANumber] FROM [dbo].[Companies] WHERE Deleted='False' AND CategoryID IN (" + selectedNodeArray + ")";
                string query = "SELECT [id],[CategoryID], CONVERT(varchar,LastUpdate,101) as LastUpdate,[UniqueID],[LegalName],[DBAName],[USDOTNumber],[ApcantID],[CANumber] FROM [dbo].[Companies] WHERE Deleted='False'";
                dt = repository.SelectAllRunner(query);
            }
            else
            {
                string query = q;
                dt = repository.SelectAllRunner(query);
            }

            filteredDataGridView.DataSource = dt;
            filteredDataGridView.Columns[0].Visible = false;
            filteredDataGridView.Columns[1].Visible = false;
            filteredDataGridView.ClearSelection();

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "isSelectedForSendcheckBoxColumn";
            filteredDataGridView.Columns.Insert(0, checkBoxColumn);

        }

        private void ccb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = cityCheckedComboBox.Items[e.Index] as CCBoxItem;
            //txtOut.AppendText(string.Format("Item '{0}' is about to be {1}\r\n", item.Name, e.NewValue.ToString()));
        }

        private void cityCheckedComboBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = cityCheckedComboBox.Items[e.Index] as CCBoxItem;
            if (!citySelected.Contains(item))
            {
                citySelected.Add(item);
            }
            getAllFilters();
        }
        private void countryCheckedComboBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = countryCheckedComboBox.Items[e.Index] as CCBoxItem;
            if (!countrySelected.Contains(item))
            {
                countrySelected.Add(item);
            }
            getAllFilters();
        }
        private void stateCheckedComboBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = stateCheckedComboBox.Items[e.Index] as CCBoxItem;
            if (!stateSelected.Contains(item))
            {
                stateSelected.Add(item);
            }
            getAllFilters();
        }
         

        /**/
        public void getAllFilters()
        {
            _citySelected = "";
            _stateSelected = "";
            _countrySelected = "";
            _categorySelected = "CategoryID";
            //_lastUpdateFromTextBox = string.IsNullOrEmpty(lastUpdateFromTextBox.Text.Trim()) ? "convert(datetime,'1800-01-01T00:00:00.000')" : $"'{lastUpdateFromTextBox.Text.Trim()}'";
            //_lastUpdateToTextBox = string.IsNullOrEmpty(lastUpdateToTextBox.Text.Trim()) ? "convert(datetime,'9999-12-31T23:59:59.997')" : $"'{lastUpdateToTextBox.Text.Trim()}'";
            _legalNameTextBox = string.IsNullOrEmpty(legalNameTextBox.Text.Trim()) ? string.Empty : legalNameTextBox.Text.Trim();
            _dbaNameTextBox = string.IsNullOrEmpty(dbaNameTextBox.Text.Trim()) ? string.Empty : dbaNameTextBox.Text.Trim();
            _fromUsDotNumberTextBox = string.IsNullOrEmpty(fromUSDOTTextBox.Text.Trim()) ? "0" : $"'{fromUSDOTTextBox.Text.Trim()}'";
            _toUsDotNumberTextBox = string.IsNullOrEmpty(toUSDOTTextBox.Text.Trim()) ? "'999999999999999'" : $"'{toUSDOTTextBox.Text.Trim()}'";
            _mcNumberTextBox = string.IsNullOrEmpty(mcNumberTextBox.Text.Trim()) ? string.Empty : mcNumberTextBox.Text.Trim();
            _fromCanNumberTextBox = string.IsNullOrEmpty(fromCATextBox.Text.Trim()) ? "'0'" : $"'{fromCATextBox.Text.Trim()}'";
            _toCanNumberTextBox = string.IsNullOrEmpty(toCATextBox.Text.Trim()) ? "'999999999999999' or LEN(TRIM(CANumber)) = 0" : $"'{toCATextBox.Text.Trim()}'";
            _fromApcantIDTextBox = string.IsNullOrEmpty(fromApcantIDTextBox.Text.Trim()) ? "'0'" : $"'{fromApcantIDTextBox.Text.Trim()}'";
            _toApcantIDTextBox = string.IsNullOrEmpty(toApcantIDTextBox.Text.Trim()) ? "'999999999999999'" : $"'{toApcantIDTextBox.Text.Trim()}'";
            _fromPhoneTextBox = string.IsNullOrEmpty(fromPhoneTextBox.Text.Trim()) ? "'0'" : $"'{fromPhoneTextBox.Text.Trim()}'";
            _toPhoneTextBox = string.IsNullOrEmpty(toPhoneTextBox.Text.Trim()) ? "'999999999999999'" : $"'{toPhoneTextBox.Text.Trim()}'";
            _fromFaxTextBox = string.IsNullOrEmpty(faxFromTextBox.Text.Trim()) ? "'0'" : $"'{faxFromTextBox.Text.Trim()}'";
            _toFaxTextBox = string.IsNullOrEmpty(faxToTextBox.Text.Trim()) ? "'999999999999999'" : $"'{faxToTextBox.Text.Trim()}'";
            _fromZipCodeTextBox = string.IsNullOrEmpty(fromZipCodeTextBox.Text.Trim()) ? "'0'" : $"'{fromZipCodeTextBox.Text.Trim()}'";
            _toZipCodeTextBox = string.IsNullOrEmpty(toZipCoeTextBox.Text.Trim()) ? "'999999999999999' or LEN(TRIM(Zip)) = 0" : $"'{toZipCoeTextBox.Text.Trim()}'";

            for (int i = 0; i < citySelected.Count; i++)
            {
                if (i == citySelected.Count - 1)
                {
                    _citySelected = _citySelected + $"'{citySelected[i].Name}'";
                }
                else
                {
                    _citySelected = _citySelected + $"'{citySelected[i].Name}',";
                }
            }


            for (int i = 0; i < stateSelected.Count; i++)
            {
                if (i == stateSelected.Count - 1)
                {
                    _stateSelected = _stateSelected + $"'{stateSelected[i].Name}'";
                }
                else
                {
                    _stateSelected = _stateSelected + $"'{stateSelected[i].Name}',";

                }
            }

            for (int i = 0; i < countrySelected.Count; i++)
            {
                if (i == countrySelected.Count - 1)
                {
                    _countrySelected = _countrySelected + $"'{countrySelected[i].Name}'";
                }
                else
                {
                    _countrySelected = _countrySelected + $"'{countrySelected[i].Name}',";

                }
            }

            for (int i = 0; i < categorySelected.Count; i++)
            {
                if (i == categorySelected.Count - 1)
                {
                    _categorySelected = _categorySelected + $"'{categorySelected[i].ID}'";
                }
                else
                {
                    _categorySelected = _categorySelected + $"'{categorySelected[i].ID}',";
                }
            }

            string q = $@"SELECT distinct NPN_Value,
                Companies.[id],
                [CategoryID],
                CONVERT(varchar,LastUpdate,101) as LastUpdate,
                [UniqueID],
                [LegalName],
                [DBAName],
                [USDOTNumber],
                [ApcantID],
                [CANumber] 
                FROM Companies 
                INNER JOIN Contacts ON Companies.ID = Contacts.CompanyID 
                WHERE Contacts.Deleted='False' 
                AND Companies.Deleted='False'
                AND LastUpdate between {_lastUpdateFromTextBox} and {_lastUpdateToTextBox}
                AND  LegalName LIKE '%{_legalNameTextBox}%' 
                AND  DBAName LIKE '%{_dbaNameTextBox}%' 
                AND  Country in ({(String.IsNullOrEmpty(_countrySelected) ? "Country" : _countrySelected)})
                AND  State in ({(String.IsNullOrEmpty(_stateSelected) ? "State" : _stateSelected)})
                AND  City in ({(String.IsNullOrEmpty(_citySelected) ? "City" : _citySelected)})
                AND  (Zip between {_fromZipCodeTextBox} and {_toZipCodeTextBox})
                --AND  USDOTNumber between {_fromUsDotNumberTextBox} and {_toUsDotNumberTextBox}
                AND  (CANumber between {_fromCanNumberTextBox} and {_toCanNumberTextBox})
                AND  ApcantID between {_fromApcantIDTextBox} and {_toApcantIDTextBox}
                AND npn_value in (select npn_value from Contacts 
									where NPN_Value between {_fromPhoneTextBox} and {_toPhoneTextBox} or npn_value = '' and type=4)
				and npn_value in (select npn_value from Contacts 
									where NPN_Value between {_fromFaxTextBox} and {_toFaxTextBox} or npn_value = '' and type=5)
                AND CategoryID IN ({_categorySelected})";

            DataTable dataTable = repository.SelectAllRunner(q);
            filteredDataGridView.DataSource = dataTable;
        }

        private void component_TextChanged(object sender, EventArgs e)
        {
            getAllFilters();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in filteredDataGridView.Rows)
                {

                    if ((bool)(row.Cells["isSelectedForSendcheckBoxColumn"].Value == null ? false : row.Cells["isSelectedForSendcheckBoxColumn"].Value))
                    {
                        var response = repository.InsertNotes(row.Cells["id"].Value.ToString(), titleTextBox.Text.Trim(), noteTxtBox.Text.Trim());
                        if (!response)
                        {
                            MessageBox.Show("An Error Ocured", "Warnning", MessageBoxButtons.OKCancel);
                        }
                    }
                }
                titleTextBox.Text = string.Empty;
                noteTxtBox.Text = string.Empty;

                getAllFilters();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Warnning", MessageBoxButtons.OKCancel);
            }



        }

        private void phoneBookCheckedComboBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CCBoxItem item = phoneBookCheckedComboBox.Items[e.Index] as CCBoxItem;
            item.IsChecked = e.NewValue.ToString();
            if (!phoneBookSelected.Any(a => a.ID.ToString() == item.ID.ToString()))
            {
                //قبلا در لیست نبوده
                phoneBookSelected.Add(item);
                if (item.Name.Trim().ToUpper() == "ALL")
                {
                    CategoryComboBoxFillDataSource(null, null);
                }
                else
                {
                    CategoryComboBoxFillDataSource(null, item.ID);

                }
            }
            else
            {

                //قبل در لیست بوده
                if (item.IsChecked == "Unchecked")
                {
                    phoneBookSelected.Remove(item);

                    categoryCheckedComboBox.Items.Clear();

                    foreach (var data in phoneBookSelected)
                    {
                        if (data.Name.Trim().ToUpper() == "ALL")
                        {
                            CategoryComboBoxFillDataSource(null, null);
                        }
                        else
                        {
                            CategoryComboBoxFillDataSource(null, data.ID);

                        }
                    }

                    //foreach (var data in phoneBookCheckedComboBox.Items)
                    //{
                    //    if (data is CCBoxItem)
                    //    {
                    //        CCBoxItem newItem = data as CCBoxItem;
                    //        var itemInPhoneBook = phoneBookSelected.Where(s => s.ID == newItem.ID).Cast<CCBoxItem>();
                    //        newItem.IsChecked = ((CCBoxItem)itemInPhoneBook).IsChecked;
                    //        if (newItem.IsChecked == "Checked")
                    //        {
                    //            if (newItem.Name.Trim().ToUpper() == "ALL")
                    //            {
                    //                CategoryComboBoxFillDataSource(null, null);
                    //            }
                    //            else
                    //            {
                    //                CategoryComboBoxFillDataSource(null, newItem.ID);

                    //            }
                    //        }
                    //    }

                    //}

                }

            }

        }

        private void categoryCheckedComboBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            CCBoxItem item = categoryCheckedComboBox.Items[e.Index] as CCBoxItem;
            if (!categorySelected.Contains(item))
            {
                categorySelected.Add(item);
            }
            getAllFilters();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lastUpdateGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
