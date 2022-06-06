using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace ContactApp
{
    interface IContanctsRepository
    {
        DataTable SelectAllRunner(string query);
        DataTable SelectAll();
        bool ExistRunner(string query);
        DataTable SelectAllCompaniesField();
        DataTable SelectAllPhoneBook();
        DataTable SelectAllCategory();
        DataTable SelectGVCategory();
        DataTable SelcetRow(int contactId);
        string GetIdByItem(string query);
        DataTable GetAllCategoriesByPhoneBookID(string PhoneBookID);
        DataTable GetCategoriesByPhoneBookID(string PhoneBookID);
        DataTable GetDocketNumberByCompanyID(string CompanyID);
        DataTable GetPhoneNumberByCompanyID(string CompanyID);
        DataTable GetFaxByCompanyID(string CompanyID);
        DataTable GetNoteByCompanyID(string CompanyID);

        DataTable GetCategoriesForComboByPhoneBook(string PhoneBookName);
        DataTable GetCategoriesByParentID(string ParentID);
        DataTable Search(string parameter);
        DataTable ReadExcel(string fileName, string fileExt);
        DataTable GetDataTabletFromCSVFile(string csv_file_path);

        bool InsertContact(string CompanyID, int Type, string Value, string Address, string City, string Zip, string Country, string State);
        bool InsertNotes(string CompanyID, string Title, string Contents);
        bool InsertPhoneBook(string Title);
        bool InsertDocketNumber(string CompanyID, string DN);
        string InsertCompanies(string CategoryID, string USDOTNumber, string DocketNumber, string LegalName, string DBAName, int ApcantID, int USDOT, string CANumber, bool Deleted, string UniqueID, string LastUpdate);
        bool InsertCategories(string PhoneBookID, string ParentID, string Title, string Code, bool IsNode, bool Deleted);
        bool UpdateContact(string contactId, string Value, string Address, string City, string Zip, string Country, string State);
        bool UpdateNotes(string notesId, string Title, string Contents);
        bool UpdatePhoneBook(string phoneBookId, string Title);
        bool UpdateDocketNumber(string DocketID, string DN);
        bool UpdatePhoneNumber(string PhoneID, string PN);
        bool DeleteDocketNumber(string DocketID);
        bool DeletePhoneNumber(string PhoneID);
        bool UpdateCompanies(string CompanyID, string USDOTNumber, string LegalName, string DBAName, int ApcantID, int USDOT, string CANumber, string LastUpdate);
        bool UpdateCategories(string categoriesId, string Title);
        bool DeleteContact(int contactId);
        bool DeleteNotes(string notesId);
        bool DeletePhoneBook(string phoneBookId);
        bool DeleteCompanies(string companiesId);
        bool DeleteCategories(string categoriesId);
        bool DeleteCategoriesByPhoneBook(string phoneBookId);
        bool DeleteCompaniesByCategoryID(string categoryID);

        bool SaveItem(string Data);


    }
}



