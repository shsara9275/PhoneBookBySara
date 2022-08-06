using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Data.OleDb;

namespace ContactApp
{
    class ContanctsRepository : IContanctsRepository
    {

        private string connectionString = @"Data Source=DESKTOP-4D2NIHO\SQLEXPRESS;Initial Catalog=PhoneBook;Integrated Security=true";

        public DataTable Search(string parameter)
        {
            throw new NotImplementedException();
        }

        public DataTable SelcetRow(int contactId)
        {
            throw new NotImplementedException();
        }

        public async Task<DataTable> SelectAllRunnerAsync(string query)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                await Task.Run(() => { adapter.Fill(data); });
                return data;

            }
            catch (Exception ex)
            {
                DataTable data = new DataTable();
                return data;
            }

        }

        public DataTable SelectAllRunner(string query)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;

            }
            catch (Exception ex)
            {
                DataTable data = new DataTable();
                return data;
            }
        }
        public bool ExistRunner(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable SelectAll()
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAllPhoneBook()
        {
            string query = "SELECT [ID],[Title] FROM [dbo].[PhoneBooks] WHERE Deleted='False' ORDER BY [CreateDate]";
            return SelectAllRunner(query);
        }
        public DataTable SelectAllCategory()
        {
            string query = "SELECT [ID],[PhoneBookID],[ParentID],[Title],[Code],[IsNode],[Deleted] FROM [dbo].[Categories] WHERE Deleted='False' AND ParentID = '7cf2f60e-6903-4cb4-b642-0b060aacf2d9'";
            return SelectAllRunner(query);

        }
        public DataTable SelectGVCategory()
        {
            string query = @"SELECT B.ID 
	                          ,B.Title as Title
	                          ,A.Title as Parent
	                          ,PhoneBooks.Title as PhoneTitle
                              ,B.Code
                              ,B.IsNode
                              ,A.Deleted as CatDel
	                          ,PhoneBooks.Deleted as PhoneDel
	                      FROM Categories A, Categories B 
			                JOIN PhoneBooks ON B.PhoneBookID = PhoneBooks.ID WHERE B.ParentID = A.ID AND B.Deleted='False'";
            return SelectAllRunner(query);

        }
        public DataTable GetAllCategoriesByPhoneBookID(string PhoneBookID)
        {

            string query = $"SELECT [ID],[Title],[ParentID] FROM [dbo].[Categories] WHERE Deleted='False' AND PhoneBookID='{PhoneBookID}' AND Title != 'None'";
            return SelectAllRunner(query);

        }
        public DataTable GetDocketNumberByCompanyID(string CompanyID) {
            string query = $"SELECT [ID],[CompanyID],[DocketNumber] FROM [dbo].[DocketNumbers] WHERE Deleted='False' AND CompanyID='{CompanyID}' Order By CreateDate DESC";
            return SelectAllRunner(query);

        }
        public DataTable GetNoteByCompanyID(string CompanyID) {
            string query = $"SELECT [ID],[CompanyID],[Title],[Contents] FROM [dbo].[Notes] WHERE Deleted='False' AND CompanyID='{CompanyID}' Order By CreateDate DESC";
            return SelectAllRunner(query);

        }
        public DataTable GetPhoneNumberByCompanyID(string CompanyID) {
            string query = $"SELECT [ID],[Type],[Value] AS Phone FROM [dbo].[Contacts] WHERE Deleted='False' AND Type=4 AND CompanyID='{CompanyID}' Order By CreateDate DESC";
            return SelectAllRunner(query);

        }
        public DataTable GetFaxByCompanyID(string CompanyID) {
            string query = $"SELECT [ID],[Type],[Value] AS Fax FROM [dbo].[Contacts] WHERE Deleted='False' AND Type=5 AND CompanyID='{CompanyID}' Order By CreateDate DESC";
            return SelectAllRunner(query);

        }

        public DataTable GetCategoriesByPhoneBookID(string PhoneBookID)
        {
            string query = $"SELECT [ID],[Title],[ParentID],[PhoneBookID] FROM [dbo].[Categories] WHERE Deleted='False' AND PhoneBookID='{PhoneBookID}' AND Title != 'None' AND ParentID = '7cf2f60e-6903-4cb4-b642-0b060aacf2d9'  ORDER BY [CreateDate]";
            return SelectAllRunner(query);

        }
        public DataTable GetCategoriesForComboByPhoneBook(string PhoneBookName)
        {
            string PhoneBookID = GetIdByItem($"PhoneBooks WHERE Title='{PhoneBookName}'");

            string query = $"SELECT [ID],[Title],[ParentID] FROM [dbo].[Categories] WHERE Deleted='False' AND PhoneBookID='{PhoneBookID}' AND Title != 'None' AND ParentID = '7cf2f60e-6903-4cb4-b642-0b060aacf2d9'";
            return SelectAllRunner(query);

        }
        public DataTable GetCategoriesByParentID(string ParentID)
        {

            string query = $"SELECT [ID],[Title],[ParentID],[PhoneBookID] FROM [dbo].[Categories] WHERE Deleted='False' AND ParentID='{ParentID}' ORDER BY [Title]";
            return SelectAllRunner(query);

        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            OleDbConnection con = new OleDbConnection(conn);


            try
            {
                OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con); //here we read data from sheet1  
                oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return dtexcel;
        }

        public DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                if (csv_file_path.EndsWith(".csv"))
                {
                    using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path))
                    {
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        //read column
                        string[] colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }
                        while (!csvReader.EndOfData)
                        {
                            string[] fieldData = csvReader.ReadFields();
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            csvData.Rows.Add(fieldData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return csvData;
        }

        public DataTable SelectAllCompaniesField()
        {
            string query = @"SELECT COLUMN_NAME
                            FROM INFORMATION_SCHEMA.COLUMNS
                            WHERE TABLE_NAME = N'Companies'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            DataRowCollection itemColumns = data.Rows;
            itemColumns[0].Delete();
            itemColumns[1].Delete();
            itemColumns[9].Delete();
            return data;
        }

        public bool DeleteCategories(string categoriesId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "UPDATE Categories SET Deleted='True' WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", categoriesId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool DeleteCompanies(string companiesId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "UPDATE Companies SET Deleted='True' WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", companiesId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeleteCompaniesByCategoryID(string categoryID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "UPDATE Companies SET Deleted='True' WHERE CategoryID=@CategoryID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@CategoryID", categoryID);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool DeleteContact(int contactId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteNotes(string notesId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "UPDATE Notes SET Deleted='True' WHERE ID=@notesId";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@notesId", notesId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool DeletePhoneBook(string phoneBookId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "UPDATE PhoneBooks SET Deleted='True' WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", phoneBookId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Insert(string name, string family, string mobile, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Insert Into MyContacts (Name,Family,Email,Age,Mobile,Address) values (@Name,@Family,@Email,@Age,@Mobile,@Address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool InsertCategories(string PhoneBookID, string ParentID, string Title, string Code, bool IsNode, bool Deleted)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                PhoneBookID = GetIdByItem($"PhoneBooks WHERE Title='{PhoneBookID}'");
                ParentID = GetIdByItem($"Categories WHERE Title='{ParentID}'");
            }
            catch (Exception exception)
            {
                Debug.Write(exception.Message);
            }
            try
            {
    
                Guid ID = Guid.NewGuid();

                string query = "Insert Into Categories(ID,PhoneBookID,ParentID,Title,Code,IsNode) values (@ID, @PhoneBookID, @ParentID, @Title, @Code, @IsNode)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Title", Title);
                command.Parameters.AddWithValue("@PhoneBookID", PhoneBookID);
                command.Parameters.AddWithValue("@ParentID", ParentID);
                command.Parameters.AddWithValue("@Code", Code);
                command.Parameters.AddWithValue("@IsNode", IsNode);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Debug.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public string InsertCompanies(string CategoryID, string USDOTNumber, string DocketNumber, string LegalName, string DBAName, int ApcantID, int USDOT, string CANumber, bool Deleted, string UniqueID, string LastUpdate)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                if(LastUpdate == "")
                {
                    LastUpdate = DateTime.Now.ToString();
                }

                Guid ID = Guid.NewGuid();
                string query = "Insert Into Companies(ID,CategoryID,USDOTNumber,DocketNumber,LegalName,DBAName,ApcantID,USDOT,CANumber,UniqueID,LastUpdate) values (@ID, @CategoryID, @USDOTNumber, @DocketNumber, @LegalName, @DBAName, @ApcantID, @USDOT, @CANumber, @UniqueID, @LastUpdate)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@CategoryID", CategoryID);
                command.Parameters.AddWithValue("@USDOTNumber", USDOTNumber);
                command.Parameters.AddWithValue("@DocketNumber", DocketNumber);
                command.Parameters.AddWithValue("@LegalName", LegalName);
                command.Parameters.AddWithValue("@DBAName", DBAName);
                command.Parameters.AddWithValue("@ApcantID", ApcantID);
                command.Parameters.AddWithValue("@USDOT", USDOT);
                command.Parameters.AddWithValue("@CANumber", CANumber);
                command.Parameters.AddWithValue("@UniqueID", UniqueID);
                command.Parameters.AddWithValue("@LastUpdate", LastUpdate);
                connection.Open();
                command.ExecuteNonQuery();
                return ID.ToString();
            }
            catch (Exception exception)
            {
                Debug.Write(exception.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool InsertContact(string CompanyID, int Type, string Value, string Address, string City, string Zip, string Country, string State)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {

                Guid ID = Guid.NewGuid();

                string query = "Insert Into Contacts(ID,CompanyID,Type,Value,Address,City,Zip,Country,State) Values (@ID,@CompanyID,@Type,@Value,@Address,@City,@Zip,@Country,@State)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@CompanyID", CompanyID);
                command.Parameters.AddWithValue("@Type", Type);
                command.Parameters.AddWithValue("@Value", Value);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@City", City);
                command.Parameters.AddWithValue("@Zip", Zip);
                command.Parameters.AddWithValue("@Country", Country);
                command.Parameters.AddWithValue("@State", State);


                connection.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch (Exception exception)
            {
                Debug.Write(exception.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }

        public bool InsertNotes(string CompanyID, string Title, string Contents)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "Insert Into Notes(ID,CompanyID,Title,Contents) values (@ID, @CompanyID, @Title, @Contents)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Title", Title);
                command.Parameters.AddWithValue("@Contents", Contents);
                command.Parameters.AddWithValue("@CompanyID", CompanyID);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool InsertPhoneBook(string Title)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "Insert Into PhoneBooks(ID,Title) values (@ID, @Title)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Title", Title);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool InsertDocketNumber(string CompanyID,string DN)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "Insert Into DocketNumbers(ID,CompanyID,DocketNumber) values (@ID, @CompanyID, @DN)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@DN", DN);
                command.Parameters.AddWithValue("@CompanyID", CompanyID);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool SaveItem(string Data)
        {
            throw new NotImplementedException();
        }


        public bool UpdateCategories(string categoriesId, string Title)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                string query = "UPDATE Categories SET Title=@Title WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", categoriesId);
                command.Parameters.AddWithValue("@Title", Title);


                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool UpdateCompanies(string CompanyID, string USDOTNumber, string LegalName, string DBAName, int ApcantID, int USDOT, string CANumber, string LastUpdate)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (LastUpdate == "")
                {
                    LastUpdate = DateTime.Now.ToString();
                }
                string query = "UPDATE [dbo].[Companies] SET USDOTNumber=@USDOTNumber,LegalName=@LegalName,DBAName=@DBAName,ApcantID=@ApcantID,CANumber=@CANumber,LastUpdate=@LastUpdate WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", CompanyID);
                command.Parameters.AddWithValue("@USDOTNumber", USDOTNumber);
                command.Parameters.AddWithValue("@LegalName", LegalName);
                command.Parameters.AddWithValue("@DBAName", DBAName);
                command.Parameters.AddWithValue("@ApcantID", ApcantID);
                command.Parameters.AddWithValue("@USDOT", USDOT);
                command.Parameters.AddWithValue("@CANumber", CANumber);
                command.Parameters.AddWithValue("@LastUpdate", LastUpdate);


                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool UpdateContact(string contactId, string Value, string Address, string City, string Zip, string Country, string State)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "UPDATE Contacts SET Value=@Value,Address=@Address,City=@City,Zip=@Zip,Country=@Country,State=@State WHERE ID=@contactId";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@contactId", contactId);
                command.Parameters.AddWithValue("@Value", Value);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@City", City);
                command.Parameters.AddWithValue("@Zip", Zip);
                command.Parameters.AddWithValue("@Country", Country);
                command.Parameters.AddWithValue("@State", State);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool UpdateNotes(string notesId, string Title, string Contents)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "UPDATE Notes SET Title=@Title,Contents=@Contents WHERE ID=@notesId";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@notesId", notesId);
                command.Parameters.AddWithValue("@Title", Title);
                command.Parameters.AddWithValue("@Contents", Contents);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }


        public bool UpdatePhoneBook(string phoneBookId, string Title)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "UPDATE PhoneBooks SET Title=@Title WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", phoneBookId);
                command.Parameters.AddWithValue("@Title", Title);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdatePhoneNumber(string PhoneID, string PN)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "UPDATE Contacts SET Value=@PN WHERE ID=@PhoneID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PhoneID", PhoneID);
                command.Parameters.AddWithValue("@PN", PN);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateDocketNumber(string DocketID, string DN)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "UPDATE DocketNumbers SET DocketNumber=@DN WHERE ID=@DocketID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@DocketID", DocketID);
                command.Parameters.AddWithValue("@DN", DN);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeleteDocketNumber(string DocketID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "UPDATE DocketNumbers SET Deleted='True' WHERE ID=@DocketID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@DocketID", DocketID);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeletePhoneNumber(string PhoneID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "UPDATE Contacts SET Deleted='True' WHERE ID=@PhoneID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PhoneID", PhoneID);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public string GetIdByItem(string query)
        {
            string q = "SELECT [ID] FROM " + query;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(q, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            string ID = data.Rows[0][0].ToString();
            Debug.Write("\n", ID);
            return ID;

        }
        public string GetItemById(string query)
        {
            string q = "SELECT [Title] FROM " + query;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(q, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            string ID = data.Rows[0][0].ToString();
            Debug.Write("\n", ID);
            return ID;
        }

        public bool DeleteCategoriesByPhoneBook(string phoneBookId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Guid ID = Guid.NewGuid();

                string query = "UPDATE Categories SET Deleted='True' WHERE PhoneBookID=@PhoneBookID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PhoneBookID", phoneBookId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
