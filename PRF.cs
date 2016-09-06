﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AdHOC_Automation_APP
{
    public class PRF
    {
        public string JobID;
        public string JobName;
        public string ClientID;
        public string PRFStatus;
        public DateTime OrderSubmitted;
        public string SubmittedBy;
        public string AccountManager;
        public string CustomerName;
        public string TotalRevenue;
        public string CreativeFileName;
        public DateTime RequestedDropDate;
        public string PropertyContactName;
        public string PropertyContactPhone;
        public string CreativeContactName;
        public string CreativeContactPhone;
//        public string CreativeReceived;
        public DateTime CreativeReceived;
        public string DataContactName;
        public string DataContactPhone;
        public DateTime RequestedInHomeDate;
        public string ProjectType;
        public string ActualDevHours;
        public string BilledDevHours;
        public int QuantityFinishedPieces;
        public string Print;
        public string Stock;
        public string PaperWeight;
        public string SheetWidth;
        public string SheetHeight;
        public string CutWidth;
        public string CutHeight;
        public string FinishedWidth;
        public string FinishedHeight;
        public string Envelope;
        public string QuantitySheets;
        public string Imposition;
        public int Pages;
        public int Variations;
        public string BarcodeTypes;
        public bool TwoD;
        public bool IMB;
        public bool TwoofFiveInterleaved;
        public bool ThreeofNine;
        public bool Postnet;
        public bool Bleed;
        public string BleedSize;
        public string Gutter;
        public string Press;
        public bool IGEN;
        public bool NUVERA;
        public bool InkJet;
        public bool BaseStock;
        public string OutsourceTradePartner;
//        public string OutsourceDeliveryDate;
        public DateTime OutsourceDeliveryDate;
        public string Finishing1;
        public string Finishing2;
        public string  Finishing3;
        public string SpecialInstructions;
        public string MailingType;
        public bool CASS;
        public bool NCOA;
        public bool Presort;
        public bool IMBBarcode;
        public bool SourceLink;
        public string MailingClass;
        public string MailPieceWeight;
        public string MailPieceThickness;
        public string MailingAgentContactName;
        public string MailingAgentContactPhone;
        public string MailingAgentContactEmail;
        public string CompanyName;
        public string CompanyAddress;
        public string CompanyCity;
        public string CompanyState;
        public string CompanyZip;
        public int PermitNumber;
        public string MailDropZipCode;
        public string IssuingPostOffice;
        public string PermitContactName;
        public string PermitContactPhone;
        public string PermitContactEmail;
        public string IndiciaHolderName;
        public string IndiciaHolderAddress;
        public string IndiciaHolderCity;
        public string IndiciaHolderState;
        public string IndiciaHolderZip;
        public string MailingOrgContactName;
        public string MailingOrgCompanyName;
        public string MailingOrgAddress;
        public string MailingOrgCity;
        public string MailingOrgState;
        public string MailingOrgZip;
        public string MailingOrgTelephone;
        public string MailingOrgEmail;
        public string MailingOrgMailerID;
        public string MailingOrgNonProfitAuthNo;
        public string DataFileName;
        public string DataFileLocation;
        public DateTime DataReceived;
        public string DataFileType;
        public string SeedListFileName;
        public int TotalVariables;
        public string TotalSeeds;
        public string FTPSiteURL;
        public string FTPUserName;
        public string FTPPassword;
        public string FTPAdditionalInfo;
        public string FTP2SiteURL;
        public string FTP2UserName;
        public string FTP2Password;
        public string FTP2AdditionalInfo;
        public string ApprovedBy;
        public string AssignedDeveloper;
        public double EstimatedHours;
        public string DataProofEstimate;
        public string ProjectNumber;
        public string Comments;
        public int IMBStart;
        public int IMBEnd;
        public decimal CUSTOMER_ID;
//        public string EstimatedProdDate;
        public DateTime EstimatedProdDate;
        public int Priority;
        public string Location;
        /*
        public bool IsT400;
        public bool IsDedup;
        public bool IsOutputsCombined;
        public bool IsFTP;
        public string MailingAgentMID;
        public string MailingAgentCRID;
        public string MailingOwnerMID;
        public string MailingOwnerCRID;
        public string CAPSAccount;
         * */


        public PRF()
        {
            this.JobID = "";
            this.JobName = "";
            this.ClientID = "";
            this.PRFStatus = "";
            this.OrderSubmitted = new DateTime();
            this.SubmittedBy = "";
            this.AccountManager = "";
            this.CustomerName = "";
            this.TotalRevenue = "";
            this.CreativeFileName = "";
            this.RequestedDropDate = new DateTime();
            this.PropertyContactName = "";
            this.PropertyContactPhone = "";
            this.CreativeContactName = "";
            this.CreativeContactPhone = "";
            this.CreativeReceived = new DateTime();
            this.DataContactName = "";
            this.DataContactPhone = "";
            this.RequestedInHomeDate = new DateTime();
            this.ProjectType = "";
            this.ActualDevHours = "";
            this.BilledDevHours = "";
            this.QuantityFinishedPieces = 0;
            this.Print = "";
            this.Stock = "";
            this.PaperWeight = "";
            this.SheetWidth = "";
            this.SheetHeight = "";
            this.CutWidth = "";
            this.CutHeight = "";
            this.FinishedWidth = "";
            this.FinishedHeight = "";
            this.Envelope = "";
            this.QuantitySheets = "";
            this.Imposition = "";
            this.Pages = 0;
            this.Variations = 0;
            this.BarcodeTypes = "";
            this.TwoD = false;
            this.IMB = false;
            this.TwoofFiveInterleaved = false;
            this.ThreeofNine = false;
            this.Postnet = false;
            this.Bleed = false;
            this.BleedSize = "";
            this.Gutter = "";
            this.Press = "";
            this.IGEN = false;
            this.NUVERA = false;
            this.InkJet = false;
            this.BaseStock = false;
            this.OutsourceTradePartner = "";
            this.OutsourceDeliveryDate = new DateTime();
            this.Finishing1 = "";
            this.Finishing2 = "";
            this.Finishing3 = "";
            this.SpecialInstructions = "";
            this.MailingType = "";
            this.CASS = false;
            this.NCOA = false;
            this.Presort = false;
            this.IMBBarcode = false;
            this.SourceLink = false;
            this.MailingClass = "";
            this.MailPieceWeight = "";
            this.MailPieceThickness = "";
            this.MailingAgentContactName = "";
            this.MailingAgentContactPhone = "";
            this.MailingAgentContactEmail = "";
            this.CompanyName = "";
            this.CompanyAddress = "";
            this.CompanyCity = "";
            this.CompanyState = "";
            this.CompanyZip = "";
            this.PermitNumber = 0;
            this.MailDropZipCode = "";
            this.IssuingPostOffice = "";
            this.PermitContactName = "";
            this.PermitContactPhone = "";
            this.PermitContactEmail = "";
            this.IndiciaHolderName = "";
            this.IndiciaHolderAddress = "";
            this.IndiciaHolderCity = "";
            this.IndiciaHolderState = "";
            this.IndiciaHolderZip = "";
            this.MailingOrgContactName = "";
            this.MailingOrgCompanyName = "";
            this.MailingOrgAddress = "";
            this.MailingOrgCity = "";
            this.MailingOrgState = "";
            this.MailingOrgZip = "";
            this.MailingOrgTelephone = "";
            this.MailingOrgEmail = "";
            this.MailingOrgMailerID = "";
            this.MailingOrgNonProfitAuthNo = "";
            this.DataFileName = "";
            this.DataFileLocation = "";
            this.DataReceived = new DateTime();
            this.DataFileType = "";
            this.SeedListFileName = "";
            this.TotalVariables = 0;
            this.TotalSeeds = "";
            this.FTPSiteURL = "";
            this.FTPUserName = "";
            this.FTPPassword = "";
            this.FTPAdditionalInfo = "";
            this.FTP2SiteURL = "";
            this.FTP2UserName = "";
            this.FTP2Password = "";
            this.FTP2AdditionalInfo = "";
            this.ApprovedBy = "";
            this.AssignedDeveloper = "";
            this.EstimatedHours = 0.00;
            this.DataProofEstimate = "";
            this.ProjectNumber = "";
            this.Comments = "";
            this.IMBStart = 0;
            this.IMBEnd = 0;
            this.CUSTOMER_ID = 0;
            this.EstimatedProdDate = new DateTime();
            this.Priority = 0;
            this.Location = "";
            /*
            this.IsT400 = false;
            this.IsDedup = false;
            this.IsOutputsCombined = false;
            this.IsFTP = false;
            this.MailingAgentMID = "";
            this.MailingAgentCRID = "";
            this.MailingOwnerMID = "";
            this.MailingOwnerCRID = "";
            this.CAPSAccount = "";
             * */
        }

        public PRF(string PRFNum)
        {
            this.JobID = PRFNum;
            this.JobName = "";
            this.ClientID = "";
            this.PRFStatus = "";
            this.OrderSubmitted = new DateTime();
            this.SubmittedBy = "";
            this.AccountManager = "";
            this.CustomerName = "";
            this.TotalRevenue = "";
            this.CreativeFileName = "";
            this.RequestedDropDate = new DateTime();
            this.PropertyContactName = "";
            this.PropertyContactPhone = "";
            this.CreativeContactName = "";
            this.CreativeContactPhone = "";
            this.CreativeReceived = new DateTime();
            this.DataContactName = "";
            this.DataContactPhone = "";
            this.RequestedInHomeDate = new DateTime();
            this.ProjectType = "";
            this.ActualDevHours = "";
            this.BilledDevHours = "";
            this.QuantityFinishedPieces = 0;
            this.Print = "";
            this.Stock = "";
            this.PaperWeight = "";
            this.SheetWidth = "";
            this.SheetHeight = "";
            this.CutWidth = "";
            this.CutHeight = "";
            this.FinishedWidth = "";
            this.FinishedHeight = "";
            this.Envelope = "";
            this.QuantitySheets = "";
            this.Imposition = "";
            this.Pages = 0;
            this.Variations = 0;
            this.BarcodeTypes = "";
            this.TwoD = false;
            this.IMB = false;
            this.TwoofFiveInterleaved = false;
            this.ThreeofNine = false;
            this.Postnet = false;
            this.Bleed = false;
            this.BleedSize = "";
            this.Gutter = "";
            this.Press = "";
            this.IGEN = false;
            this.NUVERA = false;
            this.InkJet = false;
            this.BaseStock = false;
            this.OutsourceTradePartner = "";
            this.OutsourceDeliveryDate = new DateTime();
            this.Finishing1 = "";
            this.Finishing2 = "";
            this.Finishing3 = "";
            this.SpecialInstructions = "";
            this.MailingType = "";
            this.CASS = false;
            this.NCOA = false;
            this.Presort = false;
            this.IMBBarcode = false;
            this.SourceLink = false;
            this.MailingClass = "";
            this.MailPieceWeight = "";
            this.MailPieceThickness = "";
            this.MailingAgentContactName = "";
            this.MailingAgentContactPhone = "";
            this.MailingAgentContactEmail = "";
            this.CompanyName = "";
            this.CompanyAddress = "";
            this.CompanyCity = "";
            this.CompanyState = "";
            this.CompanyZip = "";
            this.PermitNumber = 0;
            this.MailDropZipCode = "";
            this.IssuingPostOffice = "";
            this.PermitContactName = "";
            this.PermitContactPhone = "";
            this.PermitContactEmail = "";
            this.IndiciaHolderName = "";
            this.IndiciaHolderAddress = "";
            this.IndiciaHolderCity = "";
            this.IndiciaHolderState = "";
            this.IndiciaHolderZip = "";
            this.MailingOrgContactName = "";
            this.MailingOrgCompanyName = "";
            this.MailingOrgAddress = "";
            this.MailingOrgCity = "";
            this.MailingOrgState = "";
            this.MailingOrgZip = "";
            this.MailingOrgTelephone = "";
            this.MailingOrgEmail = "";
            this.MailingOrgMailerID = "";
            this.MailingOrgNonProfitAuthNo = "";
            this.DataFileName = "";
            this.DataFileLocation = "";
            this.DataReceived = new DateTime();
            this.DataFileType = "";
            this.SeedListFileName = "";
            this.TotalVariables = 0;
            this.TotalSeeds = "";
            this.FTPSiteURL = "";
            this.FTPUserName = "";
            this.FTPPassword = "";
            this.FTPAdditionalInfo = "";
            this.FTP2SiteURL = "";
            this.FTP2UserName = "";
            this.FTP2Password = "";
            this.FTP2AdditionalInfo = "";
            this.ApprovedBy = "";
            this.AssignedDeveloper = "";
            this.EstimatedHours = 0.00;
            this.DataProofEstimate = "";
            this.ProjectNumber = "";
            this.Comments = "";
            this.IMBStart = 0;
            this.IMBEnd = 0;
            this.CUSTOMER_ID = 0;
            this.EstimatedProdDate = new DateTime();
            this.Priority = 0;
            this.Location = "";

            DBCommunication.populatePRF(this);
        }
        
       }
    }

