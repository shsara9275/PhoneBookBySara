using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ContactApp
{

    public partial class mainWindow : Form
    {
        IContanctsRepository repository;
        bool TVEditMode = true;
        bool PNEditMode = false;
        bool ContactEditMode = false;
        string selectedNodeTag;
        string selectedNodeTxt;
        string selectedNodeParentTag;
        string selectedNodeName;
        string selectedNodeParentName;
        string selectedNodePhoneBookTag;
        string CompanyID;
        string emailID;
        string webID;
        string addrID;
        string addr2ID;
        public DataTable param;
        string LastUpdate;

        public mainWindow()
        {
            InitializeComponent();
            repository = new ContanctsRepository();
            treeView1.NodeMouseClick += (sender, args) => treeView1.SelectedNode = args.Node;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("id");
            dt2.Columns.Add("note_name");
            var dr3 = dt2.NewRow();
            dr3["id"] = "1";
            dr3["note_name"] = "test";
            dt2.Rows.Add(dr3);

            dataGridView2.DataSource = dt2;

            this.MinimumSize = new Size(890, 610);


        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            EditContact.Enabled = false;
            DiscardContact.Enabled = false;
            SaveContact.Enabled = false;
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            maskedTextBox2.Clear();
            textBox2.Clear();


        }

        private void mainWindow_Activated(object sender, EventArgs e)
        {

            Debug.Write("\n$$$$$$$$$$$$$$$$$$$$$$$$$$AC\n");
            //dataGridView1.Columns[0].Visible = false;

            filltreeview();

            //toolStripComboBox1.ComboBox.DataSource = repository.SelectAllCompaniesField();
            toolStripComboBox1.ComboBox.DataSource = new object[] { "UniqueID", "LegalName", "DBAName", "USDOTNumber", "ApcantID", "CANumber" };

            //DiscardContact.Enabled = false;
            //SaveContact.Enabled = false;


        }

        private void LoadTree()
        {
            TreeNode root = new TreeNode()
            {
                Tag = Guid.Empty.ToString(),
                Text = "Main",
            };


            var phonebooks = repository.SelectAllPhoneBook();
            foreach (DataRow row in phonebooks.Rows)
            {
                TreeNode node1 = new TreeNode()
                {
                    Tag = row[0].ToString(),
                    Text = row[1].ToString(),
                };

                var categories = repository.GetCategoriesByParentID(row[0].ToString());
                foreach (DataRow category in categories.Rows)
                {
                    TreeNode node2 = new TreeNode()
                    {
                        Tag = category[0].ToString(),
                        Text = category[1].ToString(),
                    };
                    node1.Nodes.Add(node2);
                }

                root.Nodes.Add(node1);

            }

            treeView1.Nodes.Add(root);
        }


        private void PopulateTreeView(DataTable CategoryDT, string ParentID, TreeNode treeNode)
        {
            TreeNode child;
            foreach (DataRow row in CategoryDT.Rows)
            {
                string rowID = row[2].ToString();

                if (rowID != null)
                {
                    child = new TreeNode
                    {
                        Text = row[1].ToString(),
                        Tag = row[0].ToString() + "/" + row[3].ToString(),
                        Name = "1",

                    };
                    TreeNode newChild = new TreeNode
                    {
                        Text = "\U00002795",
                        Tag = "new_category",

                    };
                    if (ParentID.Split('/')[0] != null)
                    {
                        ParentID = ParentID.Split('/')[0];
                    }
                    if (ParentID == rowID)
                    {
                        DataTable dtChild = repository.GetCategoriesByParentID(child.Tag.ToString());
                        PopulateTreeView(dtChild, child.Tag.ToString(), child);
                        child.Nodes.Add(newChild);
                        treeNode.Nodes.Add(child);
                    }
                    else
                    {
                        treeNode.Nodes.Add(child);
                    }
                }

            }

        }

        private void filltreeview()
        {

            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            TreeNode mainNode = new TreeNode();
            mainNode.Name = "mainNode";
            mainNode.Text = "Main";
            mainNode.Tag = "mainNode";
            DataTable PhoneBooks = repository.SelectAllPhoneBook();
            foreach (DataRow row in PhoneBooks.Rows)
            {
                TreeNode child = new TreeNode
                {
                    Text = row["Title"].ToString(),
                    Tag = row["ID"].ToString(),
                    Name = "0",
                };

                TreeNode newChild = new TreeNode
                {
                    Text = "\U00002795",
                    Tag = "new_phonebook",
                };
                DataTable Categories = repository.GetCategoriesByPhoneBookID(child.Tag.ToString());

                if (Categories != null)
                {

                    PopulateTreeView(Categories, "7cf2f60e-6903-4cb4-b642-0b060aacf2d9", child);
                    child.Nodes.Add(newChild);
                }
                mainNode.Nodes.Add(child);


            }
            TreeNode newParent = new TreeNode
            {
                Text = "\U00002795",
                Tag = "new_phonebook",
            };
            mainNode.Nodes.Add(newParent);
            treeView1.Nodes.Add(mainNode);

            treeView1.ExpandAll();
            treeView1.EndUpdate();
        }

        private void AddNode_Click(object sender, EventArgs e)
        {



        }

        private void AddContact_Click(object sender, EventArgs e)
        {
            ContactEditMode = false;
            DiscardContact.Enabled = true;
            SaveContact.Enabled = true;

            AddContact.Enabled = false;
            EditContact.Enabled = false;
            DeleteContact.Enabled = false;
            ImportExel.Enabled = false;

            tabControl1.Enabled = true;
            tabControl1.Visible = true;

            dataGridView1.Enabled = false;
            panel3.Visible = true;
            panel4.Enabled = true;
            maskedTextBox2.Enabled = true;
            maskedTextBox2.ReadOnly = false;

            //********************************
            //groupBox6.Enabled = false;
            groupBox6.Enabled = true;

            //groupBox3.Enabled = false;
            groupBox3.Enabled = true;
            //********************************

            tabControl1.Visible = true;
            //*********************************
            //tabPage1.Enabled = true;
            panel11.Enabled = true;
            panel10.Enabled = true;
            panel8.Enabled = true;
            groupBox3.Enabled = true;
            closeButton.Enabled = false;
            //**********************************
            tabPage3.Enabled = false;

            dataGridView1.ClearSelection();
            dataGridView2.DataSource = new object();
            dataGridView3.DataSource = new object();
            dataGridView4.DataSource = new object();
            dataGridView5.DataSource = new object();
            maskedTextBox2.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            docketNumbermaskedTextBox.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox18.Clear();
            maskedTextBox1.Clear();
            docketNumbermaskedTextBox.Clear();
            textBox16.Clear();
            textBox17.Clear();

        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    Debug.Write(panel1.Controls.Count);

        //    int PhoneCount = panel1.Controls.OfType<TextBox>().ToList().Count;

        //    TextBox Phone = new TextBox();
        //    ComboBox PhoneCombo = new ComboBox();
        //    Button PhoneBtn = new Button();

        //    Phone.Name = "txt_" + PhoneCount;
        //    PhoneCombo.Name = "combo_" + PhoneCount;
        //    PhoneCombo.Items.Add("Phone");
        //    PhoneCombo.Items.Add("Fax");

        //    PhoneBtn.Name = "btn_" + PhoneCount;
        //    PhoneBtn.Image = Image.FromFile("C:\\Users\\Mr.RooT\\Downloads\\delete_unapprove_discard_remove_x_red_icon-icons.com_55984 (1).png");
        //    PhoneBtn.Name = "btnDelete_" + PhoneCount;


        //    Phone.Size = new Size(100, 20);

        //    PhoneCombo.Size = new Size(66, 21);
        //    PhoneBtn.Size = new Size(20, 20);

        //    Phone.Location = new Point(88, (30 * PhoneCount));
        //    PhoneCombo.Location = new Point(13, (30 * PhoneCount));
        //    PhoneBtn.Location = new Point(190, (30 * PhoneCount));

        //    PhoneBtn.Click += new System.EventHandler(this.btnDelete_Click);

        //    panel1.Controls.Add(Phone);
        //    panel1.Controls.Add(PhoneCombo);
        //    panel1.Controls.Add(PhoneBtn);
        //    panel1.Show();
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    //Reference the Button which was clicked.
        //    Button button = (sender as Button);

        //    //Determine the Index of the Button.
        //    int index = int.Parse(button.Name.Split('_')[1]);

        //    //Find the TextBox using Index and remove it.
        //    panel1.Controls.Remove(panel1.Controls.Find("txt_" + index, true)[0]);
        //    panel1.Controls.Remove(panel1.Controls.Find("combo_" + index, true)[0]);

        //    //Remove the Button.
        //    panel1.Controls.Remove(button);

        //    //Rearranging the Location controls.
        //    foreach (Button btn in panel1.Controls.OfType<Button>())
        //    {
        //        int controlIndex = int.Parse(btn.Name.Split('_')[1]);
        //        if (controlIndex > index)
        //        {
        //            TextBox txt = (TextBox)panel1.Controls.Find("txt_" + controlIndex, true)[0];
        //            ComboBox combo = (ComboBox)panel1.Controls.Find("combo_" + controlIndex, true)[0];
        //            btn.Top = btn.Top - 30;
        //            combo.Top = combo.Top - 30;
        //            txt.Top = txt.Top - 30;
        //        }
        //    }
        //}


        private async void ImportExel_Click(object sender, EventArgs e)
        {
            if (selectedNodeName == "1")
            {
                string filePath = string.Empty;
                string fileExt = string.Empty;


                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;


                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
                    {
                        filePath = openFileDialog.FileName; //get the path of the file  
                        fileExt = Path.GetExtension(filePath); //get the file extension  
                        if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                        {
                            try
                            {
                                DataTable dtExcel = new DataTable();
                                dtExcel = repository.ReadExcel(filePath, fileExt); //read excel file  
                                var rows = (from r in dtExcel.AsEnumerable() select r).Skip(1);
                                foreach (DataRow row in rows)
                                {
                                    var date = row[0].ToString().Split('/');
                                    string LastUpdate = $"{date[2]}-{date[0]}-{date[1]} 00:00:00.000";
                                    var phones = row[4].ToString().Split('/');
                                    var note = row[14].ToString().Split(':');
                                    var companyID = repository.InsertCompanies(selectedNodeTag, row[15].ToString(), "", row[2].ToString(), row[3].ToString(), int.Parse(row[18].ToString()), int.Parse(row[15].ToString()), row[17].ToString(), false, row[1].ToString(), LastUpdate);



                                    if (companyID != null)
                                    {
                                        var resAddr = repository.InsertContact(companyID, 0, "", row[6].ToString(), row[8].ToString(), row[11].ToString(), row[10].ToString(), row[9].ToString());
                                        var resAddr2 = repository.InsertContact(companyID, 1, "", row[7].ToString(), "", "", "", "");
                                        var resWebSite = repository.InsertContact(companyID, 2, row[13].ToString(), "", "", "", "", "");
                                        var resEmail = repository.InsertContact(companyID, 3, row[12].ToString(), "", "", "", "", "");
                                        var phoneNumbber = repository.InsertContact(companyID, 4, row[4].ToString(), "", "", "", "", "");
                                        var faxNumbber = repository.InsertContact(companyID, 5, row[5].ToString(), "", "", "", "", "");
                                        var resPhone = repository.InsertNotes(companyID, note[0], note[1]);
                                        var docket = repository.InsertDocketNumber(companyID, row[16].ToString());

                                    }
                                }
                                //dataGridView1.DataSource = dtExcel;

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                        else if (fileExt.CompareTo(".csv") == 0)
                        {
                            try
                            {


                                DataTable dtNew = new DataTable();
                                dtNew = repository.GetDataTabletFromCSVFile(filePath);
                                if (dtNew.Rows != null && dtNew.Rows.Count != 0 && dtNew.Rows.ToString() != String.Empty)
                                {
                                    dataGridView1.DataSource = dtNew;
                                }
                                else
                                {
                                    MessageBox.Show("There is no data in this file", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                var rows = (from r in dtNew.AsEnumerable() select r).Skip(1);
                                foreach (DataRow row in rows)
                                {

                                    if (!string.IsNullOrEmpty(row[0].ToString()))
                                    {
                                        if (row[0].ToString().Length < 8)
                                        {
                                            row[0] = '0' + row[0].ToString();
                                        }

                                        var year = row[0].ToString().Substring(4);
                                        var month = row[0].ToString().Substring(0, 2);
                                        var day = row[0].ToString().Substring(2, 2);
                                        LastUpdate = $"{year}-{month}-{day} 00:00:00.000";
                                    }
                                    //var phones = row[1].ToString().Split('/');
                                    //var note = row[14].ToString().Split(':');
                                    var companyID = repository.InsertCompanies(selectedNodeTag, row[2].ToString(), "", row[8].ToString(), row[9].ToString(), Convert.ToInt32(row[6] is DBNull ? 0 : row[6]), 0, row[5].ToString(), false, row[1].ToString(), LastUpdate);


                                    if (companyID != null)
                                    {
                                        if (!string.IsNullOrWhiteSpace(row[46].ToString()) || !string.IsNullOrWhiteSpace(row[47].ToString()) || !string.IsNullOrWhiteSpace(row[48].ToString()) || !string.IsNullOrWhiteSpace(row[49].ToString())
                                            || !string.IsNullOrWhiteSpace(row[50].ToString()) || !string.IsNullOrWhiteSpace(row[51].ToString()) || !string.IsNullOrWhiteSpace(row[52].ToString())
                                            || !string.IsNullOrWhiteSpace(row[53].ToString()) || !string.IsNullOrWhiteSpace(row[54].ToString()))
                                        {
                                            var resAddr = repository.InsertContact(companyID, 0, "", row[48].ToString(), row[49].ToString(), row[52].ToString(), row[53].ToString(), row[51].ToString());
                                        }

                                        //var resAddr2 = repository.InsertContact(companyID, 1, "", row[5].ToString(), "", "", "", "");

                                        var resWebSite = repository.InsertContact(companyID, 2, row[60].ToString(), "", "", "", "", "");
                                        var resEmail = repository.InsertContact(companyID, 3, row[61].ToString(), "", "", "", "", "");

                                        //INSERT NOTES
                                        if (!string.IsNullOrWhiteSpace(row[32].ToString()))
                                        {
                                            var resNote = repository.InsertNotes(companyID, "", row[32].ToString());
                                        }
                                        if (!string.IsNullOrWhiteSpace(row[33].ToString()))
                                        {
                                            var resNote = repository.InsertNotes(companyID, "", row[33].ToString());
                                        }
                                        if (!string.IsNullOrWhiteSpace(row[34].ToString()))
                                        {
                                            var resNote = repository.InsertNotes(companyID, "", row[34].ToString());
                                        }
                                        if (!string.IsNullOrWhiteSpace(row[35].ToString()))
                                        {
                                            var resNote = repository.InsertNotes(companyID, "", row[35].ToString());
                                        }
                                        if (!string.IsNullOrWhiteSpace(row[36].ToString()))
                                        {
                                            var resNote = repository.InsertNotes(companyID, "", row[36].ToString());
                                        }
                                        if (!string.IsNullOrWhiteSpace(row[37].ToString()))
                                        {
                                            var resNote = repository.InsertNotes(companyID, "", row[37].ToString());
                                        }

                                        //INSERT PHONES
                                        if (!string.IsNullOrWhiteSpace(row[42].ToString()))
                                        {
                                            var phoneNumbber = repository.InsertContact(companyID, 4, row[42].ToString(), "", "", "", "", "");
                                        }
                                        if (!string.IsNullOrWhiteSpace(row[43].ToString()))
                                        {
                                            var phoneNumbber = repository.InsertContact(companyID, 4, row[43].ToString(), "", "", "", "", "");
                                        }

                                        //INSERT FAX
                                        if (!string.IsNullOrWhiteSpace(row[44].ToString()))
                                        {
                                            var faxNumbber = repository.InsertContact(companyID, 5, row[44].ToString(), "", "", "", "", "");
                                        }
                                        if (!string.IsNullOrWhiteSpace(row[45].ToString()))
                                        {
                                            var faxNumbber = repository.InsertContact(companyID, 5, row[45].ToString(), "", "", "", "", "");
                                        }

                                        //INSERT DOCKETNUMBER
                                        if (!string.IsNullOrWhiteSpace(row[3].ToString()))
                                        {
                                            var docket1 = repository.InsertDocketNumber(companyID, row[3].ToString());
                                        }
                                        if (!string.IsNullOrWhiteSpace(row[4].ToString()))
                                        {
                                            var docket2 = repository.InsertDocketNumber(companyID, row[4].ToString());
                                        }

                                    }
                                }

                                string selectednode = getCategoryAndChild(selectedNodeTag.Split('/')[0]);

                                FillDataGrid(selectednode, null);

                                MessageBox.Show("contact Add Secssesfuly ", "Sucssed", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                if (dataGridView1.Rows.Count == 0)
                                {
                                    MessageBox.Show("There is no data in this file", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                            }
                            catch (Exception ex)
                            {
                                var stackTrace = ex.StackTrace;
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please choose .xls or .xlsx or .csv file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("Please Select a Category!", "Warnning", MessageBoxButtons.OK);

            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Please Select Item In Group TreeView.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //custom messageBox to show error  

            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string str = treeView1.SelectedNode.FullPath.ToString();
            string[] tokens = str.Split('\\');

            foreach (var item in tokens)
            {
                Debug.Write(item + "\n");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        public void SaveContact_Click(object sender, EventArgs e)
        {
            if (ContactEditMode)
            {
                if (MessageBox.Show("Are You Sure About Save Change?", "Warnning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //dataGridView1.Size = new Size(this.Size.Width - 215, this.Size.Height - 100);
                    treeView1.Size = new Size(treeView1.Size.Width, this.Size.Height - 100);
                    tabControl1.Visible = false;
                    AddContact.Enabled = true;
                    EditContact.Enabled = true;
                    DeleteContact.Enabled = true;
                    ImportExel.Enabled = true;
                    dataGridView1.ClearSelection();
                    dataGridView1.Enabled = true;
                    treeView1.Enabled = true;
                    panel3.Visible = false;
                    EditContact.Enabled = false;
                    DiscardContact.Enabled = false;
                    SaveContact.Enabled = false;

                    bool isSuccess;
                    int apN;
                    bool ap = int.TryParse(textBox8.Text, out apN);
                    if (!ap)
                    {
                        apN = 0;
                    }

                    int usdot;
                    bool usdt = int.TryParse(textBox6.Text, out usdot);
                    if (!usdt)
                    {
                        usdot = 0;
                    }

                    var res = repository.UpdateCompanies(CompanyID, textBox6.Text, textBox2.Text, textBox3.Text, apN, usdot, textBox7.Text, "");

                    if (addrID != "")
                    {
                        isSuccess = repository.UpdateContact(addrID, "", textBox10.Text, textBox14.Text, textBox15.Text, textBox12.Text, textBox13.Text);
                    }
                    else
                    {
                        isSuccess = repository.InsertContact(CompanyID, 0, "", textBox10.Text, textBox14.Text, textBox15.Text, textBox12.Text, textBox13.Text);

                    }

                    if (addr2ID != "")
                    {
                        isSuccess = repository.UpdateContact(addr2ID, "", textBox11.Text, "", "", "", "");

                    }
                    else
                    {
                        isSuccess = repository.InsertContact(CompanyID, 1, "", textBox11.Text, "", "", "", "");

                    }
                    if (webID != "")
                    {
                        isSuccess = repository.UpdateContact(webID, textBox4.Text, "", "", "", "", "");
                    }
                    else
                    {
                        isSuccess = repository.InsertContact(CompanyID, 2, textBox4.Text, "", "", "", "", "");

                    }
                    if (emailID != "")
                    {
                        isSuccess = repository.UpdateContact(emailID, textBox5.Text, "", "", "", "", "");
                    }
                    else
                    {
                        isSuccess = repository.InsertContact(CompanyID, 3, textBox5.Text, "", "", "", "", "");
                    }

                    if (isSuccess == true)
                    {
                        string selectednode = getCategoryAndChild(selectedNodeTag.Split('/')[0]);

                        FillDataGrid(selectednode, null);

                        MessageBox.Show("Contact Update Secssesfuly ", "Sucssed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DiscardContact.Enabled = true;
                    SaveContact.Enabled = true;
                }
            }
            else
            {
                if (selectedNodeName == "1")
                {
                    //if (MessageBox.Show("Are You Sure About Save Change?", "Warnning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //{
                    bool existUID = maskedTextBox2.Text.ToString() == "" ? false : true;
                    var res = repository.SelectAllRunner($"SELECT UniqueID FROM Companies WHERE EXISTS (SELECT UniqueID FROM Companies WHERE Deleted='False' AND UniqueID='{maskedTextBox2.Text}') AND Deleted='False' AND UniqueID='{maskedTextBox2.Text}'");
                    bool existCompanry = res.Rows.Count == 0 ? false : true;

                    if (existUID)
                    {
                        if (!existCompanry)
                        {
                            //dataGridView1.Size = new Size(this.Size.Width - 215, this.Size.Height - 100);
                            treeView1.Size = new Size(treeView1.Size.Width, this.Size.Height - 100);
                            //tabControl1.Visible = false;
                            AddContact.Enabled = true;
                            EditContact.Enabled = true;
                            DeleteContact.Enabled = true;
                            ImportExel.Enabled = true;
                            dataGridView1.ClearSelection();
                            dataGridView1.Enabled = true;
                            treeView1.Enabled = true;
                            //panel3.Visible = false;
                            EditContact.Enabled = false;
                            DiscardContact.Enabled = false;
                            SaveContact.Enabled = false;
                            bool isSuccess = false;
                            string massage;
                            int apN;
                            bool ap = int.TryParse(textBox8.Text, out apN);
                            if (!ap)
                            {
                                apN = 0;
                            }

                            int usdot;
                            bool usdt = int.TryParse(textBox6.Text, out usdot);
                            if (!usdt)
                            {
                                usdot = 0;
                            }

                            CompanyID = repository.InsertCompanies(selectedNodeTag, textBox6.Text, "", textBox2.Text, textBox3.Text, apN, usdot, textBox7.Text, false, maskedTextBox2.Text.ToString(), "");
                            if (CompanyID != null)
                            {
                                var resAddr = repository.InsertContact(CompanyID, 0, "", textBox10.Text, textBox14.Text, textBox15.Text, textBox12.Text, textBox13.Text);
                                var resAddr2 = repository.InsertContact(CompanyID, 1, "", textBox11.Text, "", "", "", "");
                                var resWebSite = repository.InsertContact(CompanyID, 2, textBox4.Text, "", "", "", "", "");
                                var resEmail = repository.InsertContact(CompanyID, 3, textBox5.Text, "", "", "", "", "");

                                foreach (DataGridViewRow row in dataGridView4.Rows)
                                {
                                    var docketNumber = repository.InsertDocketNumber(CompanyID, row.Cells["value"].Value.ToString());

                                }
                                
                                foreach (DataGridViewRow row in dataGridView3.Rows)
                                {
                                    
                                    var phoneNumber = repository.InsertContact(CompanyID, 5, row.Cells["value"].Value.ToString(), "", "", "", "", "");

                                }
                                
                                foreach (DataGridViewRow row in dataGridView5.Rows)
                                {
                                    var faxNumber = repository.InsertContact(CompanyID, 4, row.Cells["value"].Value.ToString(), "", "", "", "", "");

                                }

                                isSuccess = true;
                            }


                            if (isSuccess == true)
                            {
                                groupBox6.Enabled = true;
                                groupBox3.Enabled = true;
                                tabPage3.Enabled = true;
                                groupBox7.Enabled = true;
                                string selectednode = getCategoryAndChild(selectedNodeTag.Split('/')[0]);

                                FillDataGrid(selectednode, null);

                                MessageBox.Show("contact Add Secssesfuly ", "Sucssed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show($"UniqueID is Exist in Please Change It!", "Warnning", MessageBoxButtons.OK);

                        }
                    }
                    else
                    {
                        MessageBox.Show("UniqueID is Require Please Fill It!", "Warnning", MessageBoxButtons.OK);

                    }

                    //}
                    //else
                    //{
                    //    DiscardContact.Enabled = true;
                    //    SaveContact.Enabled = true;
                    //}
                }
                else
                {
                    MessageBox.Show("Please Select a Category!", "Warnning", MessageBoxButtons.OK);
                }
            }

        }

        private void DiscardContact_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure About Discard Change?", "Warnning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //dataGridView1.Size = new Size(this.Size.Width - 215, this.Size.Height - 100);
                treeView1.Size = new Size(treeView1.Size.Width, this.Size.Height - 100);
                tabControl1.Visible = false;
                AddContact.Enabled = true;
                EditContact.Enabled = true;
                DeleteContact.Enabled = true;
                ImportExel.Enabled = true;
                dataGridView1.ClearSelection();
                dataGridView1.Enabled = true;
                treeView1.Enabled = true;
                EditContact.Enabled = false;
                DiscardContact.Enabled = false;
                SaveContact.Enabled = false;
                panel3.Visible = false;


            }
            else
            {
                DiscardContact.Enabled = true;
                SaveContact.Enabled = true;
            }
        }

        private void EditContact_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DiscardContact.Enabled = true;
                SaveContact.Enabled = true;
                dataGridView1.CurrentRow.Selected = true;

                AddContact.Enabled = false;
                EditContact.Enabled = false;
                DeleteContact.Enabled = false;
                ImportExel.Enabled = false;

                tabControl1.Enabled = true;

                dataGridView1.Enabled = false;
                ContactEditMode = true;
                groupBox6.Enabled = true;
                groupBox3.Enabled = true;
                tabPage1.Enabled = true;
                tabPage3.Enabled = true;
                panel4.Enabled = true;

            }
        }


        private void SaveContact2_Click(object sender, EventArgs e)
        {

        }

        private void CanseleContact_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are You Sure About Discard Change?", "Warnning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            this.Size = new Size(874, 320);
            tabControl1.Visible = false;
            //}
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            search searchForm = new search(this);
            searchForm.ShowDialog(this);
            if (searchForm.DialogResult == DialogResult.OK)
            {
                dataGridView1.DataSource = param;
            }

        }

        private void mainWindow_SizeChanged(object sender, EventArgs e)
        {


            //Debug.Write(pageStatus);
            //if (pageStatus)
            //{
            //    dataGridView1.Size = new Size(this.Size.Width - 215, this.Size.Height / 3);
            //    treeView1.Size = new Size(treeView1.Size.Width, this.Size.Height / 3);
            //    tabControl1.Location = new Point(tabControl1.Location.X, treeView1.Size.Height + 60);
            //    tabControl1.Size = new Size(this.Size.Width - 40, this.Size.Height - dataGridView1.Size.Height - 110);
            //    groupBox2.Size = new Size(groupBox2.Size.Width, tabPage1.Size.Height/2);
            //}
            //else
            //{
            //    dataGridView1.Size = new Size(this.Size.Width - 215, this.Size.Height - 100);
            //    treeView1.Size = new Size(treeView1.Size.Width, this.Size.Height - 100);
            //}

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                //jahate namayeshe recorde entekhabi balaye girid
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.CurrentRow.Index;

                maskedTextBox2.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                docketNumbermaskedTextBox.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox18.Clear();
                maskedTextBox1.Clear();
                docketNumbermaskedTextBox.Clear();
                textBox16.Clear();
                textBox17.Clear();


                dataGridView2.DataSource = new object();
                dataGridView3.DataSource = new object();
                dataGridView4.DataSource = new object();
                CompanyID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                EditContact.Enabled = true;
                dataGridView1.CurrentRow.Selected = true;
                tabControl1.Visible = true;
                //baraye inke hamishe panele aval namayesh dade shavad
                tabControl1.SelectedIndex = 0;
                //**********************************
                //tabPage1.Enabled = false;
                panel11.Enabled = false;
                panel10.Enabled = false;
                panel8.Enabled = false;
                groupBox3.Enabled = false;
                closeButton.Enabled = true;
                //**********************************
                tabPage3.Enabled = false;
                string q = $"SELECT [id],[CategoryID],CONVERT(varchar,LastUpdate,101) as LastUpdate,[UniqueID],[LegalName],[DBAName],[USDOTNumber],[ApcantID],[CANumber] FROM Companies WHERE  Deleted='False' AND ID='{CompanyID}'";
                DataTable data = repository.SelectAllRunner(q);
                if (data.Rows.Count != 0)
                {
                    DataRow dRow = data.Rows[0];
                    textBox18.Text = dRow[2].ToString();

                }

                string qemail = $"SELECT Value,ID FROM Contacts WHERE Deleted='False' AND Type = 3 AND CompanyID='{CompanyID}'";
                DataTable emaildata = repository.SelectAllRunner(qemail);
                if (emaildata.Rows.Count != 0)
                {
                    DataRow emaildRow = emaildata.Rows[0];
                    emailID = emaildRow[1].ToString();
                    textBox5.Text = emaildRow[0].ToString();
                }
                else
                {
                    emailID = "";
                }

                string qweb = $"SELECT Value,ID FROM Contacts WHERE Deleted='False' AND Type = 2 AND CompanyID='{CompanyID}'";
                DataTable webData = repository.SelectAllRunner(qweb);
                if (webData.Rows.Count != 0)
                {
                    DataRow webRow = webData.Rows[0];
                    webID = webRow[1].ToString();
                    textBox4.Text = webRow[0].ToString();

                }
                else
                {
                    webID = "";
                }

                string qAddr = $"SELECT Address, City, Country, Zip, State, ID FROM Contacts WHERE Deleted='False' AND Type = 0 AND CompanyID='{CompanyID}'";
                DataTable addrData = repository.SelectAllRunner(qAddr);
                if (addrData.Rows.Count != 0)
                {
                    DataRow addrRow = addrData.Rows[0];
                    addrID = addrRow[5].ToString();
                    textBox10.Text = addrRow[0].ToString();
                    textBox12.Text = addrRow[2].ToString();
                    textBox13.Text = addrRow[4].ToString();
                    textBox14.Text = addrRow[1].ToString();
                    textBox15.Text = addrRow[3].ToString();
                }
                else
                {
                    addrID = "";
                }

                string qAddr2 = $"SELECT Address, ID FROM Contacts WHERE Deleted='False' AND Type = 1 AND CompanyID='{CompanyID}'";
                DataTable addr2Data = repository.SelectAllRunner(qAddr2);
                if (addr2Data.Rows.Count != 0)
                {
                    DataRow addr2Row = addr2Data.Rows[0];
                    textBox11.Text = addr2Row[0].ToString();
                    addr2ID = addr2Row[1].ToString();

                }
                else
                {
                    addr2ID = "";
                }




                maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

                maskedTextBox2.ReadOnly = true;
                panel4.Enabled = false;
                panel3.Visible = true;
                FillDNGv();
                FillPNGv();
                FillNoteGv();
                dataGridView2.ClearSelection();
                dataGridView3.ClearSelection();
                dataGridView4.ClearSelection();
                dataGridView5.ClearSelection();


            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                //jahate namayeshe recorde entekhabi balaye girid
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.CurrentRow.Index;
                //baraye inke hamishe panele aval namayesh dade shavad
                tabControl1.SelectedIndex = 0;
                DiscardContact.Enabled = true;
                SaveContact.Enabled = true;
                AddContact.Enabled = false;
                EditContact.Enabled = false;
                DeleteContact.Enabled = false;
                ImportExel.Enabled = false;
                tabControl1.Enabled = true;
                dataGridView1.Enabled = true;
                treeView1.Enabled = false;
                ContactEditMode = true;
                groupBox6.Enabled = true;
                groupBox3.Enabled = true;
                //******************************
                //tabPage1.Enabled = true;
                panel11.Enabled = true;
                panel10.Enabled = true;
                panel8.Enabled = true;
                panel9.Enabled = true;
                groupBox3.Enabled = true;
                maskedTextBox1.Enabled = true;
                closeButton.Enabled = false;
                //******************************
                tabPage3.Enabled = true;
                panel4.Enabled = true;

            }
        }

        private void editNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Text != "\U00002795" && TVEditMode)
            {

                TVEditMode = false;
                Point nodeTextLocation = treeView1.SelectedNode.Bounds.Location;

                TextBox nodeTxtBox = new TextBox();
                nodeTxtBox.Multiline = true;
                nodeTxtBox.Name = "nodeTxtBox";
                nodeTxtBox.Font = new Font(nodeTxtBox.Font.FontFamily, 7);
                nodeTxtBox.Size = new Size(100, 19);
                nodeTxtBox.Text = treeView1.SelectedNode.Text;
                nodeTxtBox.Location = new Point(nodeTextLocation.X, nodeTextLocation.Y - 1);
                nodeTxtBox.KeyDown += new KeyEventHandler((object senders, KeyEventArgs keyEvent) => node_txt_box_enter(senders, keyEvent, treeView1.SelectedNode.Tag));

                treeView1.Controls.Add(nodeTxtBox);
                Debug.Write(nodeTextLocation.ToString());
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        public void new_node_txt_box_enter(object sender, KeyEventArgs e, object parentID)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult dr = MessageBox.Show("Are You Sure About Save Change?", "Warnning", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    Debug.Write(parentID);

                    if (selectedNodeParentName == "mainNode")
                    {
                        var res = repository.InsertPhoneBook(treeView1.Controls.Find("nodeTxtBox", true)[0].Text);
                    }
                    else if (selectedNodeParentName == "0")
                    {
                        var res = repository.InsertCategories(selectedNodeParentTag, "7cf2f60e-6903-4cb4-b642-0b060aacf2d9", treeView1.Controls.Find("nodeTxtBox", true)[0].Text, "", false, false);

                    }
                    else
                    {
                        var res = repository.InsertCategories(selectedNodeParentTag.Split('/')[1], selectedNodeParentTag, treeView1.Controls.Find("nodeTxtBox", true)[0].Text, "", false, false);

                    }
                    treeView1.Controls.Remove(treeView1.Controls.Find("nodeTxtBox", true)[0]);
                    TVEditMode = true;
                    filltreeview();

                    //Debug.Write(treeView1.SelectedNode.Parent.Text);
                    //repository.InsertCategories(parentID.ToString(),)

                }
                else if (dr == DialogResult.No)
                {
                    treeView1.Controls.Remove(treeView1.Controls.Find("nodeTxtBox", true)[0]);
                    TVEditMode = true;
                }
            }
        }

        public void node_txt_box_enter(object sender, KeyEventArgs e, object a)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult dr = MessageBox.Show("Are You Sure About Save Change?", "Warnning", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    Debug.Write(a);
                    if (selectedNodeName == "0")
                    {
                        var res = repository.UpdatePhoneBook(selectedNodeTag, treeView1.Controls.Find("nodeTxtBox", true)[0].Text);
                    }
                    else
                    {
                        var res = repository.UpdateCategories(selectedNodeTag.Split('/')[0], treeView1.Controls.Find("nodeTxtBox", true)[0].Text);

                    }
                    treeView1.Controls.Remove(treeView1.Controls.Find("nodeTxtBox", true)[0]);
                    TVEditMode = true;
                    filltreeview();


                }
                else if (dr == DialogResult.No)
                {
                    treeView1.Controls.Remove(treeView1.Controls.Find("nodeTxtBox", true)[0]);
                    TVEditMode = true;
                }

            }
        }

        public void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //فعال شدن دکمه ادد دستی
            if (treeView1.SelectedNode.Level >= 2)
            //if (selectedNodeName == "1")
            {

                AddContact.Enabled = true;
            }
            else
            {
                AddContact.Enabled = false;
            }

            if (treeView1.SelectedNode.Text != "Main")
            {
                selectedNodeTag = treeView1.SelectedNode.Tag.ToString();
                selectedNodeTxt = treeView1.SelectedNode.Text.ToString();
                selectedNodeName = treeView1.SelectedNode.Name.ToString();
                selectedNodeParentTag = treeView1.SelectedNode.Parent.Tag.ToString();
                selectedNodeParentName = treeView1.SelectedNode.Parent.Name.ToString();

                if (treeView1.SelectedNode.Text != "\U00002795" && treeView1.SelectedNode.Name != "0")
                {
                    textBox19.Text = treeView1.SelectedNode.FullPath.ToString();
                    string selectednode = getCategoryAndChild(selectedNodeTag.Split('/')[0]);
                    FillDataGrid(selectednode, null);

                }
                else if (treeView1.SelectedNode.Text != "\U00002795" && treeView1.SelectedNode.Name != "1")
                {
                    string selectednode = "";
                    List<string> NodeArray = new List<string>();

                    DataTable Categories = repository.GetCategoriesByPhoneBookID(selectedNodeTag);
                    if (Categories.Rows.Count != 0)
                    {
                        foreach (DataRow row in Categories.Rows)
                        {
                            NodeArray.Add(getCategoryAndChild(row[0].ToString()));
                            selectednode = string.Join(", ", NodeArray);

                        }
                        FillDataGrid(selectednode, null);
                    }
                }


                treeView1.HideSelection = false;
            }
            else
            {
                FillDataGrid(null, @"SELECT 
                                    Companies.[id],
                                    [CategoryID],
                                    CONVERT(varchar, LastUpdate, 101) as LastUpdate,
                                    [UniqueID],
                                    [LegalName],
                                    [DBAName],
                                    [USDOTNumber],
                                    [ApcantID],
                                    [CANumber],
                                    Contacts.Address,
                                    Contacts.City,
                                    Contacts.State,
                                    Contacts.Country
                                FROM[dbo].[Companies]
                                left join Contacts on Companies.id = Contacts.CompanyID and Contacts.Type=0
                                WHERE Companies.Deleted = 'False' 
                                Order By Companies.CreateDate DESC");

            }
        }

        private string getCategoryAndChild(string CategoryID)
        {
            List<string> NodeArray = new List<string>();
            NodeArray.Add("'" + CategoryID + "'");
            DataTable dt = repository.GetCategoriesByParentID(CategoryID);
            foreach (DataRow row in dt.Rows)
            {
                //NodeArray.Add("'" + row[0].ToString() + "'");
                string child = getCategoryAndChild(row[0].ToString());
                NodeArray.Add(child);

            }
            string NodeArrayString = string.Join(", ", NodeArray);

            return NodeArrayString;
        }

        private void FillDataGrid(string selectedNodeArray, string q)
        {
            DataTable dt;
            if (q == null)
            {
                string query = @"SELECT 
                                    Companies.[id],
                                    [CategoryID], 
                                    CONVERT(varchar,LastUpdate,101) as LastUpdate,
                                    [UniqueID],
                                    [LegalName],
                                    [DBAName],
                                    [USDOTNumber],
                                    [ApcantID],
                                    [CANumber],
                                    Contacts.Address, 
                                    Contacts.City,
                                    Contacts.State,
                                    Contacts.Country 
                                FROM [dbo].[Companies] 
                                left join Contacts on Companies.id = Contacts.CompanyID  and Contacts.Type=0
                                WHERE Companies.Deleted='False' AND Companies.CategoryID IN (" + selectedNodeArray + ") Order By Companies.CreateDate DESC";
                dt = repository.SelectAllRunner(query);
            }
            else
            {
                string query = q;
                dt = repository.SelectAllRunner(query);
            }
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.ClearSelection();
            }
            
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            string searchField = toolStripComboBox1.ComboBox.SelectedValue.ToString();
            string searchText = toolStripTextBox2.Text;
            string query = $"SELECT [id],[CategoryID],[LastUpdate],[UniqueID],[LegalName],[DBAName],[USDOTNumber],[ApcantID],[CANumber] FROM Companies WHERE Deleted = 'False' AND {searchField} LIKE '%{searchText}%'";
            DataTable resualt = repository.SelectAllRunner(query);
            dataGridView1.DataSource = resualt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
        }

        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Text == "\U00002795" && TVEditMode)
            {


                TVEditMode = false;
                Point nodeTextLocation = treeView1.SelectedNode.Bounds.Location;

                TextBox nodeTxtBox = new TextBox();
                nodeTxtBox.Multiline = true;
                nodeTxtBox.Name = "nodeTxtBox";
                nodeTxtBox.Font = new Font(nodeTxtBox.Font.FontFamily, 7);
                nodeTxtBox.Size = new Size(100, 19);

                nodeTxtBox.Location = new Point(nodeTextLocation.X, nodeTextLocation.Y - 1);

                //nodeTxtBox.KeyDown += new KeyEventHandler((object senders, KeyEventArgs keyEvent) => new_node_txt_box_enter(senders, keyEvent, treeView1.SelectedNode.Tag));
                nodeTxtBox.KeyDown += new KeyEventHandler((object senders, KeyEventArgs keyEvent) => new_node_txt_box_enter(senders, keyEvent, treeView1.SelectedNode.Parent.Tag));

                treeView1.Controls.Add(nodeTxtBox);
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void deleteNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Text != "\U00002795")
            {
                DialogResult dr = MessageBox.Show("Are You Sure About Delete Item?", "Warnning", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    if (selectedNodeName == "0")
                    {
                        DataTable Categories = repository.GetCategoriesByPhoneBookID(selectedNodeTag);
                        foreach (DataRow row in Categories.Rows)
                        {
                            repository.DeleteCompaniesByCategoryID(row[0].ToString());

                        }
                        repository.DeleteCategoriesByPhoneBook(selectedNodeTag);
                        repository.DeletePhoneBook(selectedNodeTag);
                    }
                    else
                    {
                        repository.DeleteCompaniesByCategoryID(selectedNodeTag);
                        repository.DeleteCategories(selectedNodeTag);

                    }
                    string selectednode = getCategoryAndChild(selectedNodeTag.Split('/')[0]);

                    FillDataGrid(selectednode, null);
                    filltreeview();


                }
            }
        }

        private void DeleteContact_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Are You Sure About Delete Item?", "Warnning", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow record in dataGridView1.SelectedRows)
                    {

                        var res = repository.DeleteCompanies(record.Cells[0].Value.ToString());
                    }

                    string selectednode = getCategoryAndChild(selectedNodeTag.Split('/')[0]);
                    FillDataGrid(selectednode, null);

                }
            }
        }

        

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dt2;
            if (docketNumbermaskedTextBox.Text != null && docketNumbermaskedTextBox.Text.Trim().Length > 1)
            {
                if (dataGridView4.Rows.Count > 0 )
                {
                     dt2 = (DataTable)dataGridView4.DataSource;
                   
                    var dr3 = dt2.NewRow();
                    dr3["value"] = docketNumbermaskedTextBox.Text;

                    dt2.Rows.Add(dr3);

                }

                else
                {
                     dt2 = new DataTable();
                    dt2.Columns.Add("value");

                    var dr3 = dt2.NewRow();
                    dr3["value"] = docketNumbermaskedTextBox.Text;

                    dt2.Rows.Add(dr3);

                }
                dataGridView4.DataSource = dt2;
                docketNumbermaskedTextBox.Text = "";

            }
            else
            {
                MessageBox.Show("Docketnumber can't be empty", "Warnning", MessageBoxButtons.OKCancel);
            }

        }

        private void FillDNGv()
        {
            DataTable dt = repository.GetDocketNumberByCompanyID(CompanyID);
            dataGridView4.DataSource = dt;
            dataGridView4.Columns[0].Visible = false;
            dataGridView4.Columns[1].Visible = false;
        }
        private void FillNoteGv()
        {
            DataTable dt = repository.GetNoteByCompanyID(CompanyID);
            dataGridView2.DataSource = dt;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[2].Width = 300;
            dataGridView2.Columns[3].Width = 800;

        }
        private void FillPNGv()
        {
            DataTable pdt = repository.GetPhoneNumberByCompanyID(CompanyID);
            DataTable fdt = repository.GetFaxByCompanyID(CompanyID);
            dataGridView3.DataSource = pdt;
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[1].Visible = false;
            dataGridView5.DataSource = fdt;
            dataGridView5.Columns[0].Visible = false;
            dataGridView5.Columns[1].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are You Sure About Add Item?", "Warnning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            if (maskedTextBox1.Text != null && !string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrEmpty(textBox17.Text))
            {
                var resPhone = repository.InsertNotes(CompanyID, textBox16.Text, textBox17.Text);
                FillNoteGv();
                textBox16.Text = string.Empty;
                textBox17.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Title and content can't be empty", "Warnning", MessageBoxButtons.OKCancel);
            }
            //}

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Replace('(', ' ').Replace(')', ' ').Replace('-', ' ').Trim().Length > 0)
            {
                bool resPhone = false;
                if (comboBox1.SelectedIndex == 1)
                {
                    if (dataGridView3.Rows.Count > 0)
                    {
                        DataTable dt2 = (DataTable)dataGridView3.DataSource;

                        var dr3 = dt2.NewRow();
                        dr3["value"] = maskedTextBox1.Text;

                        dt2.Rows.Add(dr3);
                        dataGridView3.DataSource = dt2;

                    }

                    else
                    {
                        DataTable dt2 = new DataTable();
                        dt2.Columns.Add("value");

                        var dr3 = dt2.NewRow();
                        dr3["value"] = maskedTextBox1.Text;

                        dt2.Rows.Add(dr3);
                        dataGridView3.DataSource = dt2;

                    }
                }
                else if (comboBox1.SelectedIndex == 0)
                {
                    if (dataGridView5.Rows.Count > 0)
                    {
                        DataTable dt2 = (DataTable)dataGridView5.DataSource;

                        var dr3 = dt2.NewRow();
                        dr3["value"] = maskedTextBox1.Text;

                        dt2.Rows.Add(dr3);
                        dataGridView5.DataSource = dt2;
                    }

                    else
                    {
                        DataTable dt2 = new DataTable();
                        dt2.Columns.Add("value");

                        var dr3 = dt2.NewRow();
                        dr3["value"] = maskedTextBox1.Text;

                        dt2.Rows.Add(dr3);
                        dataGridView5.DataSource = dt2;
                    }

                }
                    maskedTextBox1.Text = "";

            }
            else
            {
                MessageBox.Show("Number can't be empty", "Warnning", MessageBoxButtons.OKCancel);
            }
            //}

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are You Sure About Update Item?", "Warnning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            if (dataGridView4.CurrentRow != null)
            {
                repository.UpdateDocketNumber(dataGridView4.CurrentRow.Cells[0].Value.ToString(), docketNumbermaskedTextBox.Text);
                FillDNGv();

            }
            //}

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.CurrentRow != null)
            {
                docketNumbermaskedTextBox.Text = dataGridView4.CurrentRow.Cells["value"].Value.ToString();

            }
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView5.ClearSelection();
            if (dataGridView3.CurrentRow != null)
            {
                if (dataGridView3.CurrentRow.Cells[1].Value.ToString() == "4")
                {
                    maskedTextBox1.ReadOnly = true;
                    maskedTextBox1.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                    comboBox1.SelectedIndex = 1;

                }

            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.ClearSelection();

            if (dataGridView5.CurrentRow != null)
            {
                if (dataGridView5.CurrentRow.Cells[1].Value.ToString() == "5")
                {
                    maskedTextBox1.ReadOnly = true;
                    maskedTextBox1.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString();
                    comboBox1.SelectedIndex = 0;

                }

            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                textBox16.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox17.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are You Sure About Delete Item?", "Warnning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            if (dataGridView4.CurrentRow != null)
            {
                repository.DeleteDocketNumber(dataGridView4.CurrentRow.Cells[0].Value.ToString());
                FillDNGv();

            }
            //}
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are You Sure About Update Item?", "Warnning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            if (dataGridView3.CurrentRow != null)
            {
                repository.UpdatePhoneNumber(dataGridView3.CurrentRow.Cells[0].Value.ToString(), maskedTextBox1.Text);
                FillPNGv();

            }
            //}


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are You Sure About Update Item?", "Warnning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            if (dataGridView2.CurrentRow != null && !string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrEmpty(textBox17.Text))
            {
                repository.UpdateNotes(dataGridView2.CurrentRow.Cells[0].Value.ToString(), textBox16.Text, textBox17.Text);
                FillNoteGv();
                textBox16.Text = string.Empty;
                textBox17.Text = string.Empty;

            }
            else
            {
                MessageBox.Show("Title and content can't be empty", "Warnning", MessageBoxButtons.OKCancel);
            }
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are You Sure About Delete Item?", "Warnning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            if (dataGridView3.CurrentRow != null)
            {

                if (comboBox1.SelectedIndex == 1)
                {
                    repository.DeletePhoneNumber(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                    FillPNGv();
                }
                else if (comboBox1.SelectedIndex == 0)
                {
                    repository.DeletePhoneNumber(dataGridView5.CurrentRow.Cells[0].Value.ToString());
                    FillPNGv();

                }
            }



            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are You Sure About Delete Item?", "Warnning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            if (dataGridView2.CurrentRow != null)
            {
                repository.DeleteNotes(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                FillNoteGv();


            }
            //}
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.ReadOnly = false;
            comboBox1.Enabled = false;
            PNEditMode = true;

        }


        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && PNEditMode)
            {
                var ms = MessageBox.Show("Are You Sure About Save Change?", "Warnning", MessageBoxButtons.YesNoCancel);
                if (ms == DialogResult.Yes)
                {
                    if (comboBox1.SelectedIndex == 1)
                    {
                        if (dataGridView3.CurrentRow != null)
                        {
                            repository.UpdatePhoneNumber(dataGridView3.CurrentRow.Cells[0].Value.ToString(), maskedTextBox1.Text);

                        }
                    }
                    else if (comboBox1.SelectedIndex == 0)
                    {
                        if (dataGridView3.CurrentRow != null)
                        {
                            repository.UpdatePhoneNumber(dataGridView5.CurrentRow.Cells[0].Value.ToString(), maskedTextBox1.Text);


                        }
                    }
                    FillPNGv();
                    maskedTextBox1.ReadOnly = false;
                    maskedTextBox1.Text = "";
                    comboBox1.Enabled = true;
                    dataGridView3.ClearSelection();
                    dataGridView5.ClearSelection();
                }
                else if (ms == DialogResult.No)
                {
                    maskedTextBox1.ReadOnly = false;
                    maskedTextBox1.Text = "";
                    comboBox1.Enabled = true;
                    dataGridView3.ClearSelection();
                    dataGridView5.ClearSelection();
                }
            }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.ReadOnly = false;
            comboBox1.Enabled = false;
            PNEditMode = true;

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void sendNoteToolStripButton_Click(object sender, EventArgs e)
        {
            SendNote sendNoteForm = new SendNote();
            sendNoteForm.ShowDialog(this);
            //if (sendNoteForm.DialogResult == DialogResult.OK)
            //{
            //    dataGridView1.DataSource = param;
            //}
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            treeView1.Size = new Size(treeView1.Size.Width, this.Size.Height - 100);
            tabControl1.Visible = false;
            AddContact.Enabled = true;
            EditContact.Enabled = true;
            DeleteContact.Enabled = true;
            ImportExel.Enabled = true;
            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
            treeView1.Enabled = true;
            EditContact.Enabled = false;
            DiscardContact.Enabled = false;
            SaveContact.Enabled = false;
            panel3.Visible = false;
        }
    }
}
