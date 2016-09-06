using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace AdHOC_Automation_APP
{
    class DBCommunication
    {
        /*
         * opens communication to jobs table and populates PRF object(s) with data
         * */
        public static PRF populatePRF(PRF prf)
        {
            SqlConnectionStringBuilder conString = new SqlConnectionStringBuilder();
            conString.IntegratedSecurity = true;
            conString.DataSource = "oh50ms04\\Server_1";

            using (SqlConnection con = new SqlConnection(conString.ToString()))
            {
                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [MasterApp].[dbo].[Jobs] WHERE JobID = @jobID", con);
                command.Parameters.Add("@jobID", SqlDbType.Int);
                command.Parameters["@jobID"].Value = prf.JobID;
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mapDBQueryToPRF(prf, reader);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return prf;
        }

        /*
         * maps all columns to PRF fields
         * */
        private static void mapDBQueryToPRF(PRF prf, SqlDataReader reader)
        {
            
            prf.JobName = GetSafeString(reader, 1);
            prf.ClientID = GetSafeString(reader, 2);
            prf.PRFStatus = GetSafeString(reader, 3);
            prf.OrderSubmitted = GetSafeDateTime(reader, 4);
            prf.SubmittedBy = GetSafeString(reader, 5);
            prf.AccountManager = GetSafeString(reader, 6);
            prf.CustomerName = GetSafeString(reader, 7);
            prf.TotalRevenue = GetSafeString(reader, 8);
            prf.CreativeFileName = GetSafeString(reader, 9);
            prf.RequestedDropDate = GetSafeDateTime(reader, 10);
            prf.PropertyContactName = GetSafeString(reader, 11);
            prf.PropertyContactPhone = GetSafeString(reader, 12);
            prf.CreativeContactName = GetSafeString(reader, 13);
            prf.CreativeContactPhone = GetSafeString(reader, 14);
            prf.CreativeReceived = GetSafeDateTime(reader, 15);
            prf.DataContactName = GetSafeString(reader, 16);
            prf.DataContactPhone = GetSafeString(reader, 17);
            prf.RequestedInHomeDate = GetSafeDateTime(reader, 18);
            prf.ProjectType = GetSafeString(reader, 19);
            prf.ActualDevHours = GetSafeString(reader, 20);
            prf.BilledDevHours = GetSafeString(reader, 21);
            prf.QuantityFinishedPieces = GetSafeInt(reader, 22);
            prf.Print = GetSafeString(reader, 23);
            prf.Stock = GetSafeString(reader, 24);
            prf.PaperWeight = GetSafeString(reader, 25);
            prf.SheetWidth = GetSafeString(reader, 26);
            prf.SheetHeight = GetSafeString(reader, 27);
            prf.CutWidth = GetSafeString(reader, 28);
            prf.CutHeight = GetSafeString(reader, 29);
            prf.FinishedWidth = GetSafeString(reader, 30);
            prf.FinishedHeight = GetSafeString(reader, 31);
            prf.Envelope = GetSafeString(reader, 32);
            prf.QuantitySheets = GetSafeString(reader, 33);
            prf.Imposition = GetSafeString(reader, 34);
            prf.Pages = GetSafeInt(reader, 35);
            prf.Variations = GetSafeInt(reader, 36);
            prf.BarcodeTypes = GetSafeString(reader, 37);
            prf.TwoD = GetSafeBool(reader, 38);
            prf.IMB = GetSafeBool(reader, 39);
            prf.TwoofFiveInterleaved = GetSafeBool(reader, 40);
            prf.ThreeofNine = GetSafeBool(reader, 41);
            prf.Postnet = GetSafeBool(reader, 42);
            prf.Bleed = GetSafeBool(reader, 43);
            prf.BleedSize = GetSafeNVarChar(reader, 44);
            prf.Gutter = GetSafeNVarChar(reader, 45);
            prf.Press = GetSafeString(reader, 46);
            prf.IGEN = GetSafeBool(reader, 47);
            prf.NUVERA = GetSafeBool(reader, 48);
            prf.InkJet = GetSafeBool(reader, 49);
            prf.BaseStock = GetSafeBool(reader, 50);
            prf.OutsourceTradePartner = GetSafeString(reader, 51);
            prf.OutsourceDeliveryDate = GetSafeDateTime(reader, 52);
            prf.Finishing1 = GetSafeString(reader, 53);
            prf.Finishing2 = GetSafeString(reader, 54);
            prf.Finishing3 = GetSafeString(reader, 55);
            prf.SpecialInstructions = GetSafeString(reader, 56);
            prf.MailingType = GetSafeString(reader, 57);
            prf.CASS = GetSafeBool(reader, 58);
            prf.NCOA = GetSafeBool(reader, 59);
            prf.Presort = GetSafeBool(reader, 60);
            prf.IMBBarcode = GetSafeBool(reader, 61);
            prf.SourceLink = GetSafeBool(reader, 62);
            prf.MailingClass = GetSafeString(reader, 63);
            prf.MailPieceWeight = GetSafeString(reader, 64);
            prf.MailPieceThickness = GetSafeString(reader, 65);
            prf.MailingAgentContactName = GetSafeString(reader, 66);
            prf.MailingAgentContactPhone = GetSafeString(reader, 67);
            prf.MailingAgentContactEmail = GetSafeString(reader, 68);
            prf.CompanyName = GetSafeString(reader, 69);
            prf.CompanyAddress = GetSafeString(reader, 70);
            prf.CompanyCity = GetSafeString(reader, 71);
            prf.CompanyState = GetSafeString(reader, 72);
            prf.CompanyZip = GetSafeString(reader, 73);
            prf.PermitNumber = GetSafeInt(reader, 74);
            prf.MailDropZipCode = GetSafeString(reader, 75);
            prf.IssuingPostOffice = GetSafeString(reader, 76);
            prf.PermitContactName = GetSafeString(reader, 77);
            prf.PermitContactPhone = GetSafeString(reader, 78);
            prf.PermitContactEmail = GetSafeString(reader, 79);
            prf.IndiciaHolderName = GetSafeString(reader, 80);
            prf.IndiciaHolderAddress = GetSafeString(reader, 81);
            prf.IndiciaHolderCity = GetSafeString(reader, 82);
            prf.IndiciaHolderState = GetSafeString(reader, 83);
            prf.IndiciaHolderZip = GetSafeString(reader, 84);
            prf.MailingOrgContactName = GetSafeString(reader, 85);
            prf.MailingOrgCompanyName = GetSafeString(reader, 86);
            prf.MailingOrgAddress = GetSafeString(reader, 87);
            prf.MailingOrgCity = GetSafeString(reader, 88);
            prf.MailingOrgState = GetSafeString(reader, 89);
            prf.MailingOrgZip = GetSafeString(reader, 90);
            prf.MailingOrgTelephone = GetSafeString(reader, 91);
            prf.MailingOrgEmail = GetSafeString(reader, 92);
            prf.MailingOrgMailerID = GetSafeString(reader, 93);
            prf.MailingOrgNonProfitAuthNo = GetSafeString(reader, 94);
            prf.DataFileName = GetSafeString(reader, 95);
            prf.DataFileLocation = GetSafeString(reader, 96);
            prf.DataReceived = GetSafeDateTime(reader, 97);
            prf.DataFileType = GetSafeString(reader, 98);
            prf.SeedListFileName = GetSafeString(reader, 99);
            prf.TotalVariables = GetSafeInt(reader, 100);
            prf.TotalSeeds = GetSafeInt(reader, 101).ToString();
            prf.FTPSiteURL = GetSafeString(reader, 102);
            prf.FTPUserName = GetSafeString(reader, 103);
            prf.FTPPassword = GetSafeString(reader, 104);
            prf.FTPAdditionalInfo = GetSafeString(reader, 105);
            prf.FTP2SiteURL = GetSafeString(reader, 106);
            prf.FTP2UserName = GetSafeString(reader, 107);
            prf.FTP2Password = GetSafeString(reader, 108);
            prf.FTP2AdditionalInfo = GetSafeString(reader, 109);
            prf.ApprovedBy = GetSafeString(reader, 110);
            prf.AssignedDeveloper = GetSafeString(reader, 111);
            prf.EstimatedHours = GetSafeDouble(reader, 112);
            prf.DataProofEstimate = GetSafeString(reader, 113);
            prf.ProjectNumber = GetSafeString(reader, 114);
            prf.Comments = GetSafeString(reader, 115);
            prf.IMBStart = GetSafeInt(reader, 116);
            prf.IMBEnd = GetSafeInt(reader, 117);
            prf.CUSTOMER_ID = GetSafeDecimal(reader, 118);
            prf.EstimatedProdDate = GetSafeDateTime(reader, 119);
            prf.Priority = GetSafeInt(reader, 120);
            prf.Location = GetSafeString(reader, 121);
        }

        private static string GetSafeString(SqlDataReader reader, int i)
        {
            if (!reader.IsDBNull(i))
            {
                return reader.GetString(i);
            }
            else
            {
                return "";
            }
        }

        private static int GetSafeInt(SqlDataReader reader, int i)
        {
            if (!reader.IsDBNull(i))
            {
                return reader.GetInt32(i);
            }
            else
            {
                return 0;
            }
        }

        private static bool GetSafeBool(SqlDataReader reader, int i)
        {
             
            if (!reader.IsDBNull(i))
            {
                return reader.GetBoolean(i);
            }
            else
            {
                return false;
            }
        }

        private static double GetSafeDouble(SqlDataReader reader, int i)
        {

            if (!reader.IsDBNull(i))
            {
                return reader.GetDouble(i);
            }
            else
            {
                return 0;
            }
        }

        private static decimal GetSafeDecimal(SqlDataReader reader, int i)
        {

            if (!reader.IsDBNull(i))
            {
                return reader.GetDecimal(i);
            }
            else
            {
                return 0;
            }
        }

        private static DateTime GetSafeDateTime(SqlDataReader reader, int i)
        {

            if (!reader.IsDBNull(i))
            {
                return reader.GetDateTime(i);
            }
            else
            {
                return new DateTime();
            }
        }

        private static string GetSafeNVarChar(SqlDataReader reader, int i)
        {
            if (!reader.IsDBNull(i))
            {
                return reader.GetValue(i).ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
