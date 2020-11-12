using _1275_MIRKAM_CUSTOMER_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace _1275_MIRKAM_CUSTOMER_API.DataBase
{
    public class DBParser
    {
        /// <summary>
        /// The singleton instance
        /// </summary>
        private static DBParser m_instance;
        /// <summary>
        /// General command
        /// </summary>
        private GeneralCmd m_GeneralCmd;

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DBParser));

        readonly string m_connectionString = ConfigurationManager.ConnectionStrings["tnuott"].ConnectionString;

        /// <summary>
        /// constructor
        /// </summary>
        private DBParser()
        {
            m_GeneralCmd = new GeneralCmd();
           
        }


        /// <summary>
        /// Get the singleton instance
        /// </summary>
        /// <returns>The singleton instance</returns>
        public static DBParser Instance()
        {
            if (m_instance == null)
            {
                m_instance = new DBParser();
            }
            return m_instance;
        }

        /// <summary>
        /// read string that must not be empty - if it is emty - set the valid data flag to be false
        /// </summary>
        /// <param name="curReader">the current reader</param>
        /// <param name="clmName">the coulumn name</param>
        /// <returns>the string</returns>
        private string ReadString(OracleDataReader curReader, string clmName)
        {
            string val = null;
            try
            {
                if (curReader[clmName] != null)
                {
                    val = curReader[clmName].ToString();
                }
            }
            catch
            {
                string errMsg = "Error: Invalid colum name: " + clmName;
                throw new Exception(errMsg);

            }
            return val;
        }
     
        /// <summary>
        /// read int that must not be empty - if it is emty - set the valid data flag to be false
        /// </summary>
        /// <param name="curReader">the current reader</param>
        /// <param name="clmName">the coulumn name</param>
        /// <returns>the int</returns>
        private int ReadInt(OracleDataReader curReader, string clmName)
        {
            int val = 0;
            string str = ReadString(curReader, clmName);
            val = Convert.ToInt32(str);
            return val;
        }

        /// <summary>
        /// read date time that must not be empty - if it is emty - set the valid data flag to be false
        /// </summary>
        /// <param name="curReader">the current reader</param>
        /// <param name="clmName">the coulumn name</param>
        /// <returns>the int</returns>
        private DateTime ReadDateTime(OracleDataReader curReader, string clmName)
        {
            DateTime val = DateTime.Now;
            string str = ReadString(curReader, clmName);
            val = Convert.ToDateTime(str);
            return val;
        }

        [Obsolete("Message")]
        public bool InsertCustomer(Customer customer, out string ErrorMessage)
        {          
            using (OracleConnection connection = new OracleConnection(m_connectionString))
            {
                try
                {
                    ErrorMessage = "";
                    connection.Open();
                        try
                        {
                            bool isIdExist = IsValueExist(customer.RequestID, "REQUESTID", "TBL_MIRKAM_CUSTOMER_1275");
                            if (!isIdExist)
                            {
                                m_GeneralCmd.TableName = "TBL_MIRKAM_CUSTOMER_1275";
                                m_GeneralCmd.AddInsertValue("RequestID", customer.RequestID);
                                m_GeneralCmd.AddInsertValue("Status", 0);
                                m_GeneralCmd.AddInsertValue("CustomerNumber", customer.CustomerNumber);
                                m_GeneralCmd.AddInsertValue("CustomerName", customer.CustomerName);
                                m_GeneralCmd.AddInsertValue("IDBusiness", customer.IDBusiness);
                                m_GeneralCmd.AddInsertValue("PayeeCode", customer.PayeeCode);
                                m_GeneralCmd.AddInsertValue("CustomerType", customer.CustomerType);
                                m_GeneralCmd.AddInsertValue("PartnershipVat", customer.PartnershipVat);
                                m_GeneralCmd.AddInsertValue("Shared", customer.Shared);
                                m_GeneralCmd.AddInsertValue("Street", customer.Street);
                                m_GeneralCmd.AddInsertValue("House", customer.House);
                                m_GeneralCmd.AddInsertValue("Entrance", customer.Entrance);
                                m_GeneralCmd.AddInsertValue("Apartment", customer.Apartment);
                                m_GeneralCmd.AddInsertValue("City", customer.City);
                                m_GeneralCmd.AddInsertValue("ZIP", customer.ZIP);
                                m_GeneralCmd.AddInsertValue("Pob", customer.Pob);
                                m_GeneralCmd.AddInsertValue("PobZip", customer.PobZip);
                                m_GeneralCmd.AddInsertValue("Phone1", customer.Phone1);
                                m_GeneralCmd.AddInsertValue("Phone2", customer.Phone2);
                                m_GeneralCmd.AddInsertValue("Phone3", customer.Phone3);
                                m_GeneralCmd.AddInsertValue("Fax", customer.Fax);
                                m_GeneralCmd.AddInsertValue("ContactMan1", customer.ContactMan1);
                                m_GeneralCmd.AddInsertValue("ContactMan1Occupation", customer.ContactMan1Occupation);
                                m_GeneralCmd.AddInsertValue("ContactMan1Phone", customer.ContactMan1Phone);
                                m_GeneralCmd.AddInsertValue("ContactMan2", customer.ContactMan2);
                                m_GeneralCmd.AddInsertValue("ContactMan2Occupation", customer.ContactMan2Occupation);
                                m_GeneralCmd.AddInsertValue("ContactMan2Phone", customer.ContactMan2Phone);
                                m_GeneralCmd.AddInsertValue("ContactMen", customer.GetContactManIDStr());
                                m_GeneralCmd.AddInsertValue("Email", customer.Email);
                                m_GeneralCmd.AddInsertValue("SendMonthReportByEmail", customer.SendMonthReportByEmail);
                                m_GeneralCmd.AddInsertValue("IssueMonthlyTransactionFile", customer.IssueMonthlyTransactionFile);
                                m_GeneralCmd.AddInsertValue("AttachPromotionData", customer.AttachPromotionData);
                                m_GeneralCmd.AddInsertValue("LogoAuthCode", customer.LogoAuthCode);
                                m_GeneralCmd.AddInsertValue("FuelDevice1", customer.FuelDevice1);
                                m_GeneralCmd.AddInsertValue("FuelDevice2", customer.FuelDevice2);
                                m_GeneralCmd.AddInsertValue("FuelDevice3", customer.FuelDevice3);
                                m_GeneralCmd.AddInsertValue("FuelDevice4", customer.FuelDevice4);
                                m_GeneralCmd.AddInsertValue("FuelDevice5", customer.FuelDevice5);
                                m_GeneralCmd.AddInsertValue("FuelDevice6", customer.FuelDevice6);
                                m_GeneralCmd.AddInsertValue("FuelDevice7", customer.FuelDevice7);
                                m_GeneralCmd.AddInsertValue("PrefferedFuelDeviceProvider", customer.PrefferedFuelDeviceProvider);
                                m_GeneralCmd.AddInsertValue("JoinDate", customer.JoinDate);
                                m_GeneralCmd.AddInsertValue("LastAgreementDate", customer.LastAgreementDate);
                                m_GeneralCmd.AddInsertValue("AgreementVersionDate", customer.AgreementVersionDate);
                                m_GeneralCmd.AddInsertValue("IfThereAreSubCustomers", customer.IfThereAreSubCustomers);
                                m_GeneralCmd.AddInsertValue("ChargeLevel", customer.ChargeLevel);
                                m_GeneralCmd.AddInsertValue("Bank", customer.Bank);
                                m_GeneralCmd.AddInsertValue("BankBranch", customer.BankBranch);
                                m_GeneralCmd.AddInsertValue("BankAccount", customer.BankAccount);
                                m_GeneralCmd.AddInsertValue("CreditCard", customer.CreditCard);
                                m_GeneralCmd.AddInsertValue("CreditCardLastDigits", customer.CreditCardLastDigits);
                                m_GeneralCmd.AddInsertValue("CreditCardToken", customer.CreditCardToken);
                                m_GeneralCmd.AddInsertValue("CreditCardValidDate", customer.CreditCardValidDate);
                                m_GeneralCmd.AddInsertValue("PriceListNumber", customer.PriceListNumber);
                                m_GeneralCmd.AddInsertValue("CreditDaysSolar", customer.CreditDaysSolar);
                                m_GeneralCmd.AddInsertValue("CreditDaysBenzin", customer.CreditDaysBenzin);
                                m_GeneralCmd.AddInsertValue("OpenAccountAuto", customer.OpenAccountAuto);
                                m_GeneralCmd.AddInsertValue("AccountGroup", customer.AccountGroup);
                                m_GeneralCmd.AddInsertValue("AccountingNumber", customer.AccountingNumber);
                                m_GeneralCmd.AddInsertValue("NonDebitableCustomerERPNumber", customer.NonDebitableCustomerERPNumber);
                                m_GeneralCmd.AddInsertValue("ObligoMonth", customer.ObligoMonth);
                                m_GeneralCmd.AddInsertValue("ObligoMonthUpdateAllowed", customer.ObligoMonthUpdateAllowed);
                                m_GeneralCmd.AddInsertValue("ObligoCreditLimit", customer.ObligoCreditLimit);
                                m_GeneralCmd.AddInsertValue("BlockIfOverpassed", customer.BlockIfOverpassed);
                                m_GeneralCmd.AddInsertValue("LimitForDevicesForInheritance", customer.LimitForDevicesForInheritance);
                                m_GeneralCmd.AddInsertValue("Blo", customer.Blo);
                                m_GeneralCmd.AddInsertValue("BloBillingServiceCode", customer.BloBillingServiceCode);
                                m_GeneralCmd.AddInsertValue("VatFree", customer.VatFree);
                                m_GeneralCmd.AddInsertValue("ReferenceSource", customer.ReferenceSource);
                                m_GeneralCmd.AddInsertValue("BonusGroup", customer.BonusGroup);
                                m_GeneralCmd.AddInsertValue("ClientCoversion", customer.ClientCoversion);
                                m_GeneralCmd.AddInsertValue("InternalStationOperator", customer.InternalStationOperator);
                                m_GeneralCmd.AddInsertValue("CustomerCharacteristic", customer.CustomerCharacteristic);
                                m_GeneralCmd.AddInsertValue("CustomerCategory", customer.CustomerCategory);
                                m_GeneralCmd.AddInsertValue("Marketer", customer.Marketer);
                                m_GeneralCmd.AddInsertValue("Recruiter", customer.Recruiter);
                                m_GeneralCmd.AddInsertValue("StationGroup", customer.StationGroup);
                                m_GeneralCmd.AddInsertValue("StationGroupOperationType", customer.StationGroupOperationType);
                                m_GeneralCmd.AddInsertValue("UseOfSecretCode", customer.UseOfSecretCode);
                                m_GeneralCmd.AddInsertValue("ContstantPrice", customer.ContstantPrice);
                                m_GeneralCmd.AddInsertValue("verifyvehiclenumberfor", customer.VerifyVehicleNumberForInheritance);
                                m_GeneralCmd.AddInsertValue("CarWashing", customer.CarWashing);
                                m_GeneralCmd.AddInsertValue("ShtifomatUsing", customer.ShtifomatUsing);
                                m_GeneralCmd.AddInsertValue("Shti", customer.Shti);
                                m_GeneralCmd.AddInsertValue("Comment1", customer.Comment1);
                                m_GeneralCmd.AddInsertValue("Comment2", customer.Comment2);
                                m_GeneralCmd.AddInsertValue("Comment3", customer.Comment3);
                                m_GeneralCmd.AddInsertValue("Comment4", customer.Comment4);
                                m_GeneralCmd.AddInsertValue("Comment5", customer.Comment5);
                                m_GeneralCmd.AddInsertValue("Comment6", customer.Comment6);
                                m_GeneralCmd.AddInsertValue("ContactManToSendCards", customer.ContactManToSendCards);
                                m_GeneralCmd.AddInsertValue("ContactManToSendCardsOcc", customer.ContactManToSendCardsOccupation);
                                m_GeneralCmd.AddInsertValue("ContactManToSendCardsPhone", customer.ContactManToSendCardsPhone);
                                m_GeneralCmd.AddInsertValue("ContactManToSendCardsStreet", customer.ContactManToSendCardsStreet);
                                m_GeneralCmd.AddInsertValue("ContactManToSendCardsHouse", customer.ContactManToSendCardsHouse);
                                m_GeneralCmd.AddInsertValue("ContactManToSendCardsEntrance", customer.ContactManToSendCardsEntrance);
                                m_GeneralCmd.AddInsertValue("ContactManToSendCardsAppart", customer.ContactManToSendCardsAppartment);
                                m_GeneralCmd.AddInsertValue("ContactManToSendCardsCity", customer.ContactManToSendCardsCity);
                                m_GeneralCmd.AddInsertValue("ContactManToSendCardsZip", customer.ContactManToSendCardsZip);
                                m_GeneralCmd.AddInsertValue("ContactManToSendCardsComments", customer.ContactManToSendCardsComments);
                                m_GeneralCmd.AddInsertValue("YearBillingFee", customer.YearBillingFee);
                                m_GeneralCmd.AddInsertValue("YearBillingFeeForFuelDevice", customer.YearBillingFeeForFuelDevice);
                                m_GeneralCmd.AddInsertValue("YearBillingFeeForFueCard", customer.YearBillingFeeForFueCard);
                                m_GeneralCmd.AddInsertValue("YearsBillingFree", customer.YearsBillingFree);
                                m_GeneralCmd.AddInsertValue("MonthlyBillingFee", customer.MonthlyBillingFee);
                                m_GeneralCmd.AddInsertValue("MonthlyBillingFeeForFuelDevice", customer.MonthlyBillingFeeForFuelDevice);
                                m_GeneralCmd.AddInsertValue("MonthlyBillingFeeForFuelCard", customer.MonthlyBillingFeeForFuelCard);
                                m_GeneralCmd.AddInsertValue("MonthsBillingFree", customer.MonthsBillingFree);
                                m_GeneralCmd.AddInsertValue("BillingSumForFuelDevice1", customer.BillingSumForFuelDevice1);
                                m_GeneralCmd.AddInsertValue("BillingSumForFuelDevice2", customer.BillingSumForFuelDevice2);
                                m_GeneralCmd.AddInsertValue("BillingSumForFuelDevice3", customer.BillingSumForFuelDevice3);
                                m_GeneralCmd.AddInsertValue("BillingSumForFuelDevice4", customer.BillingSumForFuelDevice4);
                                m_GeneralCmd.AddInsertValue("BillingSumForFuelDevice5", customer.BillingSumForFuelDevice5);
                                m_GeneralCmd.AddInsertValue("BillingSumForFuelDevice6", customer.BillingSumForFuelDevice6);
                                m_GeneralCmd.AddInsertValue("BillingSumForFuelDevice7", customer.BillingSumForFuelDevice7);
                                m_GeneralCmd.AddInsertValue("UpdateBy", customer.UpdateBy);
                                m_GeneralCmd.AddInsertValue("CRMNumber", customer.CRMNumber);
                                m_GeneralCmd.SetCmd("insert into {0} ({1}) values ({2})", new string[] { m_GeneralCmd.TableName, m_GeneralCmd.GetInsertColumn(), m_GeneralCmd.GetInsertValue() });
                            using (OracleCommand command = new OracleCommand(m_GeneralCmd.GetCmd(), connection))
                                {
                                    command.CommandTimeout = 5000;
                                    int result = command.ExecuteNonQuery();
                                    if (result > 0)
                                    {
                                        foreach(ContactMan contactMan in customer.ContactMen)
                                        {
                                            bool response =  InsertContactMan(contactMan, out ErrorMessage);
                                            if (!response)
                                            {
                                                return false;
                                            }
                                        }
                                        return true;
                                    }
                                    else
                                    {
                                        ErrorMessage = $"Error when try insert customer name : {customer.CustomerName} into DataBase";
                                        return false;
                                    }

                                }
                            }
                       
                            else
                            {
                                 return UpdateCustomer(customer, customer.RequestID, out ErrorMessage);
                            }
                        }
                        catch (Exception ex)
                        {
                              ErrorMessage = $"Exception when insert data to data base , error message: {ex.Message}";
                             log.Error(ErrorMessage);
                            
                        }
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Exception when try insert Customer, error message: {ex.Message}";
                    log.Error(ErrorMessage);
                    return false;
                }
                finally
                {
                    connection.Close();

                }
            }
            return false;
        }


        [Obsolete("Message")]
        public bool UpdateCustomer (Customer customer , string requestId, out string ErrorMessage)
        {
            using (OracleConnection connection = new OracleConnection(m_connectionString))
            {
                try
                {
                    ErrorMessage = "";
                    connection.Open();
                    try
                    {
                            m_GeneralCmd.TableName = "TBL_MIRKAM_CUSTOMER_1275";
                            m_GeneralCmd.AddWhereKeyVal("RequestID", requestId);
                            m_GeneralCmd.AddUpdateValue("Status", customer.Status);
                            m_GeneralCmd.AddUpdateValue("CustomerNumber", customer.CustomerNumber);
                            m_GeneralCmd.AddUpdateValue("IDBusiness", customer.IDBusiness);
                            m_GeneralCmd.AddUpdateValue("PayeeCode", customer.PayeeCode);
                            m_GeneralCmd.AddUpdateValue("CustomerType", customer.CustomerType);
                            m_GeneralCmd.AddUpdateValue("PartnershipVat", customer.PartnershipVat);
                            m_GeneralCmd.AddUpdateValue("Shared", customer.Shared);
                            m_GeneralCmd.AddUpdateValue("Street", customer.Street);
                            m_GeneralCmd.AddUpdateValue("House", customer.House);
                            m_GeneralCmd.AddUpdateValue("Entrance", customer.Entrance);
                            m_GeneralCmd.AddUpdateValue("Apartment", customer.Apartment);
                            m_GeneralCmd.AddUpdateValue("City", customer.City);
                            m_GeneralCmd.AddUpdateValue("ZIP", customer.ZIP);
                            m_GeneralCmd.AddUpdateValue("Pob", customer.Pob);
                            m_GeneralCmd.AddUpdateValue("PobZip", customer.PobZip);
                            m_GeneralCmd.AddUpdateValue("Phone1", customer.Phone1);
                            m_GeneralCmd.AddUpdateValue("Phone2", customer.Phone2);
                            m_GeneralCmd.AddUpdateValue("Phone3", customer.Phone3);
                            m_GeneralCmd.AddUpdateValue("Fax", customer.Fax);
                            m_GeneralCmd.AddUpdateValue("ContactMan1", customer.ContactMan1);
                            m_GeneralCmd.AddUpdateValue("ContactMan1Occupation", customer.ContactMan1Occupation);
                            m_GeneralCmd.AddUpdateValue("ContactMan1Phone", customer.ContactMan1Phone);
                            m_GeneralCmd.AddUpdateValue("ContactMan2", customer.ContactMan2);
                            m_GeneralCmd.AddUpdateValue("ContactMan2Occupation", customer.ContactMan2Occupation);
                            m_GeneralCmd.AddUpdateValue("ContactMan2Phone", customer.ContactMan2Phone);
                            m_GeneralCmd.AddUpdateValue("ContactMen", customer.GetContactManIDStr());
                            m_GeneralCmd.AddUpdateValue("Email", customer.Email);
                            m_GeneralCmd.AddUpdateValue("SendMonthReportByEmail", customer.SendMonthReportByEmail);
                            m_GeneralCmd.AddUpdateValue("IssueMonthlyTransactionFile", customer.IssueMonthlyTransactionFile);
                            m_GeneralCmd.AddUpdateValue("AttachPromotionData", customer.AttachPromotionData);
                            m_GeneralCmd.AddUpdateValue("LogoAuthCode", customer.LogoAuthCode);
                            m_GeneralCmd.AddUpdateValue("FuelDevice1", customer.FuelDevice1);
                            m_GeneralCmd.AddUpdateValue("FuelDevice2", customer.FuelDevice2);
                            m_GeneralCmd.AddUpdateValue("FuelDevice3", customer.FuelDevice3);
                            m_GeneralCmd.AddUpdateValue("FuelDevice4", customer.FuelDevice4);
                            m_GeneralCmd.AddUpdateValue("FuelDevice5", customer.FuelDevice5);
                            m_GeneralCmd.AddUpdateValue("FuelDevice6", customer.FuelDevice6);
                            m_GeneralCmd.AddUpdateValue("FuelDevice7", customer.FuelDevice7);
                            m_GeneralCmd.AddUpdateValue("PrefferedFuelDeviceProvider", customer.PrefferedFuelDeviceProvider);
                            m_GeneralCmd.AddUpdateValue("JoinDate", customer.JoinDate);
                            m_GeneralCmd.AddUpdateValue("LastAgreementDate", customer.LastAgreementDate);
                            m_GeneralCmd.AddUpdateValue("AgreementVersionDate", customer.AgreementVersionDate);
                            m_GeneralCmd.AddUpdateValue("IfThereAreSubCustomers", customer.IfThereAreSubCustomers);
                            m_GeneralCmd.AddUpdateValue("ChargeLevel", customer.ChargeLevel);
                            m_GeneralCmd.AddUpdateValue("Bank", customer.Bank);
                            m_GeneralCmd.AddUpdateValue("BankBranch", customer.BankBranch);
                            m_GeneralCmd.AddUpdateValue("BankAccount", customer.BankAccount);
                            m_GeneralCmd.AddUpdateValue("CreditCard", customer.CreditCard);
                            m_GeneralCmd.AddUpdateValue("CreditCardLastDigits", customer.CreditCardLastDigits);
                            m_GeneralCmd.AddUpdateValue("CreditCardToken", customer.CreditCardToken);
                            m_GeneralCmd.AddUpdateValue("CreditCardValidDate", customer.CreditCardValidDate);
                            m_GeneralCmd.AddUpdateValue("PriceListNumber", customer.PriceListNumber);
                            m_GeneralCmd.AddUpdateValue("CreditDaysSolar", customer.CreditDaysSolar);
                            m_GeneralCmd.AddUpdateValue("CreditDaysBenzin", customer.CreditDaysBenzin);
                            m_GeneralCmd.AddUpdateValue("OpenAccountAuto", customer.OpenAccountAuto);
                            m_GeneralCmd.AddUpdateValue("AccountGroup", customer.AccountGroup);
                            m_GeneralCmd.AddUpdateValue("AccountingNumber", customer.AccountingNumber);
                            m_GeneralCmd.AddUpdateValue("NonDebitableCustomerERPNumber", customer.NonDebitableCustomerERPNumber);
                            m_GeneralCmd.AddUpdateValue("ObligoMonth", customer.ObligoMonth);
                            m_GeneralCmd.AddUpdateValue("ObligoMonthUpdateAllowed", customer.ObligoMonthUpdateAllowed);
                            m_GeneralCmd.AddUpdateValue("ObligoCreditLimit", customer.ObligoCreditLimit);
                            m_GeneralCmd.AddUpdateValue("BlockIfOverpassed", customer.BlockIfOverpassed);
                            m_GeneralCmd.AddUpdateValue("LimitForDevicesForInheritance", customer.LimitForDevicesForInheritance);
                            m_GeneralCmd.AddUpdateValue("Blo", customer.Blo);
                            m_GeneralCmd.AddUpdateValue("BloBillingServiceCode", customer.BloBillingServiceCode);
                            m_GeneralCmd.AddUpdateValue("VatFree", customer.VatFree);
                            m_GeneralCmd.AddUpdateValue("ReferenceSource", customer.ReferenceSource);
                            m_GeneralCmd.AddUpdateValue("BonusGroup", customer.BonusGroup);
                            m_GeneralCmd.AddUpdateValue("ClientCoversion", customer.ClientCoversion);
                            m_GeneralCmd.AddUpdateValue("InternalStationOperator", customer.InternalStationOperator);
                            m_GeneralCmd.AddUpdateValue("CustomerCharacteristic", customer.CustomerCharacteristic);
                            m_GeneralCmd.AddUpdateValue("CustomerCategory", customer.CustomerCategory);
                            m_GeneralCmd.AddUpdateValue("Marketer", customer.Marketer);
                            m_GeneralCmd.AddUpdateValue("Recruiter", customer.Recruiter);
                            m_GeneralCmd.AddUpdateValue("StationGroup", customer.StationGroup);
                            m_GeneralCmd.AddUpdateValue("StationGroupOperationType", customer.StationGroupOperationType);
                            m_GeneralCmd.AddUpdateValue("UseOfSecretCode", customer.UseOfSecretCode);
                            m_GeneralCmd.AddUpdateValue("ContstantPrice", customer.ContstantPrice);
                            m_GeneralCmd.AddUpdateValue("verifyvehiclenumberfor", customer.VerifyVehicleNumberForInheritance);
                            m_GeneralCmd.AddUpdateValue("CarWashing", customer.CarWashing);
                            m_GeneralCmd.AddUpdateValue("ShtifomatUsing", customer.ShtifomatUsing);
                            m_GeneralCmd.AddUpdateValue("Shti", customer.Shti);
                            m_GeneralCmd.AddUpdateValue("Comment1", customer.Comment1);
                            m_GeneralCmd.AddUpdateValue("Comment2", customer.Comment2);
                            m_GeneralCmd.AddUpdateValue("Comment3", customer.Comment3);
                            m_GeneralCmd.AddUpdateValue("Comment4", customer.Comment4);
                            m_GeneralCmd.AddUpdateValue("Comment5", customer.Comment5);
                            m_GeneralCmd.AddUpdateValue("Comment6", customer.Comment6);
                            m_GeneralCmd.AddUpdateValue("ContactManToSendCards", customer.ContactManToSendCards);
                            m_GeneralCmd.AddUpdateValue("ContactManToSendCardsOcc", customer.ContactManToSendCardsOccupation);
                            m_GeneralCmd.AddUpdateValue("ContactManToSendCardsPhone", customer.ContactManToSendCardsPhone);
                            m_GeneralCmd.AddUpdateValue("ContactManToSendCardsStreet", customer.ContactManToSendCardsStreet);
                            m_GeneralCmd.AddUpdateValue("ContactManToSendCardsHouse", customer.ContactManToSendCardsHouse);
                            m_GeneralCmd.AddUpdateValue("ContactManToSendCardsEntrance", customer.ContactManToSendCardsEntrance);
                            m_GeneralCmd.AddUpdateValue("ContactManToSendCardsAppart", customer.ContactManToSendCardsAppartment);
                            m_GeneralCmd.AddUpdateValue("ContactManToSendCardsCity", customer.ContactManToSendCardsCity);
                            m_GeneralCmd.AddUpdateValue("ContactManToSendCardsZip", customer.ContactManToSendCardsZip);
                            m_GeneralCmd.AddUpdateValue("ContactManToSendCardsComments", customer.ContactManToSendCardsComments);
                            m_GeneralCmd.AddUpdateValue("YearBillingFee", customer.YearBillingFee);
                            m_GeneralCmd.AddUpdateValue("YearBillingFeeForFuelDevice", customer.YearBillingFeeForFuelDevice);
                            m_GeneralCmd.AddUpdateValue("YearBillingFeeForFueCard", customer.YearBillingFeeForFueCard);
                            m_GeneralCmd.AddUpdateValue("YearsBillingFree", customer.YearsBillingFree);
                            m_GeneralCmd.AddUpdateValue("MonthlyBillingFee", customer.MonthlyBillingFee);
                            m_GeneralCmd.AddUpdateValue("MonthlyBillingFeeForFuelDevice", customer.MonthlyBillingFeeForFuelDevice);
                            m_GeneralCmd.AddUpdateValue("MonthlyBillingFeeForFuelCard", customer.MonthlyBillingFeeForFuelCard);
                            m_GeneralCmd.AddUpdateValue("MonthsBillingFree", customer.MonthsBillingFree);
                            m_GeneralCmd.AddUpdateValue("BillingSumForFuelDevice1", customer.BillingSumForFuelDevice1);
                            m_GeneralCmd.AddUpdateValue("BillingSumForFuelDevice2", customer.BillingSumForFuelDevice2);
                            m_GeneralCmd.AddUpdateValue("BillingSumForFuelDevice3", customer.BillingSumForFuelDevice3);
                            m_GeneralCmd.AddUpdateValue("BillingSumForFuelDevice4", customer.BillingSumForFuelDevice4);
                            m_GeneralCmd.AddUpdateValue("BillingSumForFuelDevice5", customer.BillingSumForFuelDevice5);
                            m_GeneralCmd.AddUpdateValue("BillingSumForFuelDevice6", customer.BillingSumForFuelDevice6);
                            m_GeneralCmd.AddUpdateValue("BillingSumForFuelDevice7", customer.BillingSumForFuelDevice7);
                            m_GeneralCmd.AddUpdateValue("UpdateBy", customer.UpdateBy);
                            m_GeneralCmd.AddUpdateValue("CRMNumber", customer.CRMNumber);
                            m_GeneralCmd.SetCmd($"update {m_GeneralCmd.TableName} set {m_GeneralCmd.GetSetValue()} where {m_GeneralCmd.GetWhereKeyValue()}");
                            using (OracleCommand command = new OracleCommand(m_GeneralCmd.GetCmd(), connection))
                            {
                                command.CommandTimeout = 5000;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    foreach (ContactMan contactMan in customer.ContactMen)
                                    {
                                        bool response = UpdateContactMan(contactMan, contactMan.ContactManID, out ErrorMessage);
                                        if (!response)
                                        {
                                           ErrorMessage = $"Error when try Update contact man name {contactMan.ContactManName}";
                                           log.Error(ErrorMessage);
                                           return false;
                                        }
                                    }
                                    return true;
                                }
                                else
                                {
                                  ErrorMessage = $"Error when try Update customer name: '{customer.CustomerName}', Error Message: Request Id: '{requestId}' is not exist";
                                  log.Error(ErrorMessage);
                                return false;
                                }

                            }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = $"Exception when Update customer name: '{customer.CustomerName}' , Error message: {ex.Message}";
                        log.Error(ErrorMessage);
                        
                    }
                }
                catch (Exception ex)
                {
                    //insert log error message
                    ErrorMessage = $"Exception when try Update customer, error message: {ex.Message}";
                    log.Error(ErrorMessage);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return false;
        }

        [Obsolete("Message")]
        public bool InsertSubCustomer (SubCustomer subCustomer, out string ErrorMessage)
        {
            using (OracleConnection connection = new OracleConnection(m_connectionString))
            {
                try
                {
                    ErrorMessage = "";
                    connection.Open();
                    try
                    {
                        bool isIdExist = IsValueExist(subCustomer.RequestID, "REQUESTID", "TBL_MIRKAM_SUBCUSTOMER_1275");
                        if (!isIdExist)
                        {
                            m_GeneralCmd.TableName = "TBL_MIRKAM_SUBCUSTOMER_1275"; 
                            m_GeneralCmd.AddInsertValue("RequestID", subCustomer.RequestID);
                            m_GeneralCmd.AddInsertValue("Status", 0);
                            m_GeneralCmd.AddInsertValue("CustomerNumber", subCustomer.CustomerNumber);
                            m_GeneralCmd.AddInsertValue("SubCustomerNumber", subCustomer.SubCustomerNumber);
                            m_GeneralCmd.AddInsertValue("SubCustomerName", subCustomer.SubCustomerName);
                            m_GeneralCmd.AddInsertValue("IDBusiness", subCustomer.IDBusiness);
                            m_GeneralCmd.AddInsertValue("PartnershipVat", subCustomer.PartnershipVat);
                            m_GeneralCmd.AddInsertValue("Street", subCustomer.Street);
                            m_GeneralCmd.AddInsertValue("House", subCustomer.House);
                            m_GeneralCmd.AddInsertValue("Entrance", subCustomer.Entrance);
                            m_GeneralCmd.AddInsertValue("Apartment", subCustomer.Apartment);
                            m_GeneralCmd.AddInsertValue("City", subCustomer.City);
                            m_GeneralCmd.AddInsertValue("ZIP", subCustomer.ZIP);
                            m_GeneralCmd.AddInsertValue("Pob", subCustomer.Pob);
                            m_GeneralCmd.AddInsertValue("PobZip", subCustomer.PobZip);
                            m_GeneralCmd.AddInsertValue("Phone1", subCustomer.Phone1);
                            m_GeneralCmd.AddInsertValue("Phone2", subCustomer.Phone2);
                            m_GeneralCmd.AddInsertValue("Phone3", subCustomer.Phone3);
                            m_GeneralCmd.AddInsertValue("Fax", subCustomer.Fax);
                            m_GeneralCmd.AddInsertValue("ContactMan1", subCustomer.ContactMan1);
                            m_GeneralCmd.AddInsertValue("ContactMan1Occupation", subCustomer.ContactMan1Occupation);
                            m_GeneralCmd.AddInsertValue("ContactMan1Phone", subCustomer.ContactMan1Phone);
                            m_GeneralCmd.AddInsertValue("ContactMan2", subCustomer.ContactMan2);
                            m_GeneralCmd.AddInsertValue("ContactMan2Occupation", subCustomer.ContactMan2Occupation);
                            m_GeneralCmd.AddInsertValue("ContactMan2Phone", subCustomer.ContactMan2Phone);
                            m_GeneralCmd.AddInsertValue("ContactMen", subCustomer.GetContactManIDStr());
                            m_GeneralCmd.AddInsertValue("Email", subCustomer.Email);
                            m_GeneralCmd.AddInsertValue("SendMonthReportByEmail", subCustomer.SendMonthReportByEmail);
                            m_GeneralCmd.AddInsertValue("IssueMonthlyTransactionFile", subCustomer.IssueMonthlyTransactionFile);
                            m_GeneralCmd.AddInsertValue("AttachPromotionData", subCustomer.AttachPromotionData);
                            m_GeneralCmd.AddInsertValue("LogoAuthCode", subCustomer.LogoAuthCode);
                            m_GeneralCmd.AddInsertValue("FuelDevice1", subCustomer.FuelDevice1);
                            m_GeneralCmd.AddInsertValue("FuelDevice2", subCustomer.FuelDevice2);
                            m_GeneralCmd.AddInsertValue("FuelDevice3", subCustomer.FuelDevice3);
                            m_GeneralCmd.AddInsertValue("FuelDevice4", subCustomer.FuelDevice4);
                            m_GeneralCmd.AddInsertValue("FuelDevice5", subCustomer.FuelDevice5);
                            m_GeneralCmd.AddInsertValue("FuelDevice6", subCustomer.FuelDevice6);
                            m_GeneralCmd.AddInsertValue("FuelDevice7", subCustomer.FuelDevice7);
                            m_GeneralCmd.AddInsertValue("PrefferedFuelDeviceProvider", subCustomer.PrefferedFuelDeviceProvider);
                            m_GeneralCmd.AddInsertValue("JoinDate", subCustomer.JoinDate);
                            m_GeneralCmd.AddInsertValue("LastAgreementDate", subCustomer.LastAgreementDate);
                            m_GeneralCmd.AddInsertValue("AgreementVersionDate", subCustomer.AgreementVersionDate);
                            m_GeneralCmd.AddInsertValue("ChargeLevel", subCustomer.ChargeLevel);
                            m_GeneralCmd.AddInsertValue("Bank", subCustomer.Bank);
                            m_GeneralCmd.AddInsertValue("BankBranch", subCustomer.BankBranch);
                            m_GeneralCmd.AddInsertValue("BankAccount", subCustomer.BankAccount);
                            m_GeneralCmd.AddInsertValue("CreditCard", subCustomer.CreditCard);
                            m_GeneralCmd.AddInsertValue("CreditCardLastDigits", subCustomer.CreditCardLastDigits);
                            m_GeneralCmd.AddInsertValue("CreditCardToken", subCustomer.CreditCardToken);
                            m_GeneralCmd.AddInsertValue("CreditCardValidDate", subCustomer.CreditCardValidDate);
                            m_GeneralCmd.AddInsertValue("PriceListNumber", subCustomer.PriceListNumber);
                            m_GeneralCmd.AddInsertValue("CreditDaysSolar", subCustomer.CreditDaysSolar);
                            m_GeneralCmd.AddInsertValue("CreditDaysBenzin", subCustomer.CreditDaysBenzin);
                            m_GeneralCmd.AddInsertValue("AccountGroup", subCustomer.AccountGroup);
                            m_GeneralCmd.AddInsertValue("AccountingNumber", subCustomer.AccountingNumber);
                            m_GeneralCmd.AddInsertValue("NonDebitableCustomerERPNumber", subCustomer.NonDebitableCustomerERPNumber);
                            m_GeneralCmd.AddInsertValue("ObligoMonth", subCustomer.ObligoMonth);
                            m_GeneralCmd.AddInsertValue("ObligoMonthUpdateAllowed", subCustomer.ObligoMonthUpdateAllowed);
                            m_GeneralCmd.AddInsertValue("ObligoCreditLimit", subCustomer.ObligoCreditLimit);
                            m_GeneralCmd.AddInsertValue("BlockIfOverpassed", subCustomer.BlockIfOverpassed);
                            m_GeneralCmd.AddInsertValue("LimitForDevicesForInheritance", subCustomer.LimitForDevicesForInheritance);
                            m_GeneralCmd.AddInsertValue("Blo", subCustomer.Blo);
                            m_GeneralCmd.AddInsertValue("BloBillingServiceCode", subCustomer.BloBillingServiceCode);
                            m_GeneralCmd.AddInsertValue("VatFree", subCustomer.VatFree);
                            m_GeneralCmd.AddInsertValue("ReferenceSource", subCustomer.ReferenceSource);
                            m_GeneralCmd.AddInsertValue("BonusGroup", subCustomer.BonusGroup);
                            m_GeneralCmd.AddInsertValue("ClientCoversion", subCustomer.ClientCoversion);
                            m_GeneralCmd.AddInsertValue("InternalStationOperator", subCustomer.InternalStationOperator);
                            m_GeneralCmd.AddInsertValue("Marketer", subCustomer.Marketer);
                            m_GeneralCmd.AddInsertValue("StationGroup", subCustomer.StationGroup);
                            m_GeneralCmd.AddInsertValue("StationGroupOperationType", subCustomer.StationGroupOperationType);
                            m_GeneralCmd.AddInsertValue("UseOfSecretCode", subCustomer.UseOfSecretCode);
                            m_GeneralCmd.AddInsertValue("verifyvehiclenumberfor", subCustomer.VerifyVehicleNumberForInheritance);
                            m_GeneralCmd.AddInsertValue("CarWashing", subCustomer.CarWashing);
                            m_GeneralCmd.AddInsertValue("ShtifomatUsing", subCustomer.ShtifomatUsing);
                            m_GeneralCmd.AddInsertValue("ContactManToSendCards", subCustomer.ContactManToSendCards);
                            m_GeneralCmd.AddInsertValue("ContactManToSendCardsOcc", subCustomer.ContactManToSendCardsOccupation);
                            m_GeneralCmd.AddInsertValue("ContactManToSendCardsPhone", subCustomer.ContactManToSendCardsPhone);
                            m_GeneralCmd.AddInsertValue("ContactManToSendCardsStreet", subCustomer.ContactManToSendCardsStreet);
                            m_GeneralCmd.AddInsertValue("ContactManToSendCardsHouse", subCustomer.ContactManToSendCardsHouse);
                            m_GeneralCmd.AddInsertValue("ContactManToSendCardsEntrance", subCustomer.ContactManToSendCardsEntrance);
                            m_GeneralCmd.AddInsertValue("ContactManToSendCardsAppart", subCustomer.ContactManToSendCardsAppartment);
                            m_GeneralCmd.AddInsertValue("ContactManToSendCardsCity", subCustomer.ContactManToSendCardsCity);
                            m_GeneralCmd.AddInsertValue("ContactManToSendCardsZip", subCustomer.ContactManToSendCardsZip);
                            m_GeneralCmd.AddInsertValue("ContactManToSendCardsComments", subCustomer.ContactManToSendCardsComments);
                            m_GeneralCmd.AddInsertValue("CRMNumber", subCustomer.CRMNumber);
                            m_GeneralCmd.SetCmd("insert into {0} ({1}) values ({2})", new string[] { m_GeneralCmd.TableName, m_GeneralCmd.GetInsertColumn(), m_GeneralCmd.GetInsertValue() });

                            using (OracleCommand command = new OracleCommand(m_GeneralCmd.GetCmd(), connection))
                            {
                                command.CommandTimeout = 5000;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    foreach (ContactMan contactMan in subCustomer.ContactMen)
                                    {
                                        bool response = InsertContactMan(contactMan, out ErrorMessage);
                                        if (!response)
                                        {
                                            return false;
                                        }
                                    }
                                    return true;
                                }
                                else
                                {
                                    ErrorMessage = $"Exception when insert Sub Customer Name: '{subCustomer.SubCustomerName}' into  data base";
                                    log.Error(ErrorMessage);
                                    return false;
                                }

                            }
                        }

                        else
                        {
                            return UpdateSubCustomer(subCustomer, subCustomer.RequestID, out ErrorMessage);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = $"Exception when insert Sub Customer Name: '{subCustomer.SubCustomerName}' into  data base , error message: {ex.Message}";
                        log.Error(ErrorMessage);

                    }
                }
                catch (Exception ex)
                {
                    //insert log error message
                    ErrorMessage = $"Exception when try insert Sub Customer name '{subCustomer.SubCustomerName}', error message: {ex.Message}";
                    log.Error(ErrorMessage);
                    return false;
                }
                finally
                {
                    connection.Close();

                }
            }
            return false;
        }

        [Obsolete("Message")]
        public bool UpdateSubCustomer(SubCustomer subCustomer, string requestId, out string ErrorMessage)
        {
            using (OracleConnection connection = new OracleConnection(m_connectionString))
            {
                try
                {
                    ErrorMessage = "";
                    connection.Open();
                    m_GeneralCmd.TableName = "TBL_MIRKAM_SUBCUSTOMER_1275";
                    m_GeneralCmd.AddWhereKeyVal("RequestID", requestId);
                    m_GeneralCmd.AddUpdateValue("Status", subCustomer.Status);
                    m_GeneralCmd.AddUpdateValue("CustomerNumber", subCustomer.CustomerNumber);
                    m_GeneralCmd.AddUpdateValue("SubCustomerNumber", subCustomer.SubCustomerNumber);
                    m_GeneralCmd.AddUpdateValue("SubCustomerName", subCustomer.SubCustomerName);
                    m_GeneralCmd.AddUpdateValue("IDBusiness", subCustomer.IDBusiness);
                    m_GeneralCmd.AddUpdateValue("PartnershipVat", subCustomer.PartnershipVat);
                    m_GeneralCmd.AddUpdateValue("Street", subCustomer.Street);
                    m_GeneralCmd.AddUpdateValue("House", subCustomer.House);
                    m_GeneralCmd.AddUpdateValue("Entrance", subCustomer.Entrance);
                    m_GeneralCmd.AddUpdateValue("Apartment", subCustomer.Apartment);
                    m_GeneralCmd.AddUpdateValue("City", subCustomer.City);
                    m_GeneralCmd.AddUpdateValue("ZIP", subCustomer.ZIP);
                    m_GeneralCmd.AddUpdateValue("Pob", subCustomer.Pob);
                    m_GeneralCmd.AddUpdateValue("PobZip", subCustomer.PobZip);
                    m_GeneralCmd.AddUpdateValue("Phone1", subCustomer.Phone1);
                    m_GeneralCmd.AddUpdateValue("Phone2", subCustomer.Phone2);
                    m_GeneralCmd.AddUpdateValue("Phone3", subCustomer.Phone3);
                    m_GeneralCmd.AddUpdateValue("Fax", subCustomer.Fax);
                    m_GeneralCmd.AddUpdateValue("ContactMan1", subCustomer.ContactMan1);
                    m_GeneralCmd.AddUpdateValue("ContactMan1Occupation", subCustomer.ContactMan1Occupation);
                    m_GeneralCmd.AddUpdateValue("ContactMan1Phone", subCustomer.ContactMan1Phone);
                    m_GeneralCmd.AddUpdateValue("ContactMan2", subCustomer.ContactMan2);
                    m_GeneralCmd.AddUpdateValue("ContactMan2Occupation", subCustomer.ContactMan2Occupation);
                    m_GeneralCmd.AddUpdateValue("ContactMan2Phone", subCustomer.ContactMan2Phone);
                    m_GeneralCmd.AddUpdateValue("ContactMen", subCustomer.GetContactManIDStr());
                    m_GeneralCmd.AddUpdateValue("Email", subCustomer.Email);
                    m_GeneralCmd.AddUpdateValue("SendMonthReportByEmail", subCustomer.SendMonthReportByEmail);
                    m_GeneralCmd.AddUpdateValue("IssueMonthlyTransactionFile", subCustomer.IssueMonthlyTransactionFile);
                    m_GeneralCmd.AddUpdateValue("AttachPromotionData", subCustomer.AttachPromotionData);
                    m_GeneralCmd.AddUpdateValue("LogoAuthCode", subCustomer.LogoAuthCode);
                    m_GeneralCmd.AddUpdateValue("FuelDevice1", subCustomer.FuelDevice1);
                    m_GeneralCmd.AddUpdateValue("FuelDevice2", subCustomer.FuelDevice2);
                    m_GeneralCmd.AddUpdateValue("FuelDevice3", subCustomer.FuelDevice3);
                    m_GeneralCmd.AddUpdateValue("FuelDevice4", subCustomer.FuelDevice4);
                    m_GeneralCmd.AddUpdateValue("FuelDevice5", subCustomer.FuelDevice5);
                    m_GeneralCmd.AddUpdateValue("FuelDevice6", subCustomer.FuelDevice6);
                    m_GeneralCmd.AddUpdateValue("FuelDevice7", subCustomer.FuelDevice7);
                    m_GeneralCmd.AddUpdateValue("PrefferedFuelDeviceProvider", subCustomer.PrefferedFuelDeviceProvider);
                    m_GeneralCmd.AddUpdateValue("JoinDate", subCustomer.JoinDate);
                    m_GeneralCmd.AddUpdateValue("LastAgreementDate", subCustomer.LastAgreementDate);
                    m_GeneralCmd.AddUpdateValue("AgreementVersionDate", subCustomer.AgreementVersionDate);
                    m_GeneralCmd.AddUpdateValue("ChargeLevel", subCustomer.ChargeLevel);
                    m_GeneralCmd.AddUpdateValue("Bank", subCustomer.Bank);
                    m_GeneralCmd.AddUpdateValue("BankBranch", subCustomer.BankBranch);
                    m_GeneralCmd.AddUpdateValue("BankAccount", subCustomer.BankAccount);
                    m_GeneralCmd.AddUpdateValue("CreditCard", subCustomer.CreditCard);
                    m_GeneralCmd.AddUpdateValue("CreditCardLastDigits", subCustomer.CreditCardLastDigits);
                    m_GeneralCmd.AddUpdateValue("CreditCardToken", subCustomer.CreditCardToken);
                    m_GeneralCmd.AddUpdateValue("CreditCardValidDate", subCustomer.CreditCardValidDate);
                    m_GeneralCmd.AddUpdateValue("PriceListNumber", subCustomer.PriceListNumber);
                    m_GeneralCmd.AddUpdateValue("CreditDaysSolar", subCustomer.CreditDaysSolar);
                    m_GeneralCmd.AddUpdateValue("CreditDaysBenzin", subCustomer.CreditDaysBenzin);
                    m_GeneralCmd.AddUpdateValue("AccountGroup", subCustomer.AccountGroup);
                    m_GeneralCmd.AddUpdateValue("AccountingNumber", subCustomer.AccountingNumber);
                    m_GeneralCmd.AddUpdateValue("NonDebitableCustomerERPNumber", subCustomer.NonDebitableCustomerERPNumber);
                    m_GeneralCmd.AddUpdateValue("ObligoMonth", subCustomer.ObligoMonth);
                    m_GeneralCmd.AddUpdateValue("ObligoMonthUpdateAllowed", subCustomer.ObligoMonthUpdateAllowed);
                    m_GeneralCmd.AddUpdateValue("ObligoCreditLimit", subCustomer.ObligoCreditLimit);
                    m_GeneralCmd.AddUpdateValue("BlockIfOverpassed", subCustomer.BlockIfOverpassed);
                    m_GeneralCmd.AddUpdateValue("LimitForDevicesForInheritance", subCustomer.LimitForDevicesForInheritance);
                    m_GeneralCmd.AddUpdateValue("Blo", subCustomer.Blo);
                    m_GeneralCmd.AddUpdateValue("BloBillingServiceCode", subCustomer.BloBillingServiceCode);
                    m_GeneralCmd.AddUpdateValue("VatFree", subCustomer.VatFree);
                    m_GeneralCmd.AddUpdateValue("ReferenceSource", subCustomer.ReferenceSource);
                    m_GeneralCmd.AddUpdateValue("BonusGroup", subCustomer.BonusGroup);
                    m_GeneralCmd.AddUpdateValue("ClientCoversion", subCustomer.ClientCoversion);
                    m_GeneralCmd.AddUpdateValue("InternalStationOperator", subCustomer.InternalStationOperator);
                    m_GeneralCmd.AddUpdateValue("Marketer", subCustomer.Marketer);
                    m_GeneralCmd.AddUpdateValue("StationGroup", subCustomer.StationGroup);
                    m_GeneralCmd.AddUpdateValue("StationGroupOperationType", subCustomer.StationGroupOperationType);
                    m_GeneralCmd.AddUpdateValue("UseOfSecretCode", subCustomer.UseOfSecretCode);
                    m_GeneralCmd.AddUpdateValue("verifyvehiclenumberfor", subCustomer.VerifyVehicleNumberForInheritance);
                    m_GeneralCmd.AddUpdateValue("CarWashing", subCustomer.CarWashing);
                    m_GeneralCmd.AddUpdateValue("ShtifomatUsing", subCustomer.ShtifomatUsing);
                    m_GeneralCmd.AddUpdateValue("ContactManToSendCards", subCustomer.ContactManToSendCards);
                    m_GeneralCmd.AddUpdateValue("ContactManToSendCardsOcc", subCustomer.ContactManToSendCardsOccupation);
                    m_GeneralCmd.AddUpdateValue("ContactManToSendCardsPhone", subCustomer.ContactManToSendCardsPhone);
                    m_GeneralCmd.AddUpdateValue("ContactManToSendCardsStreet", subCustomer.ContactManToSendCardsStreet);
                    m_GeneralCmd.AddUpdateValue("ContactManToSendCardsHouse", subCustomer.ContactManToSendCardsHouse);
                    m_GeneralCmd.AddUpdateValue("ContactManToSendCardsEntrance", subCustomer.ContactManToSendCardsEntrance);
                    m_GeneralCmd.AddUpdateValue("ContactManToSendCardsAppart", subCustomer.ContactManToSendCardsAppartment);
                    m_GeneralCmd.AddUpdateValue("ContactManToSendCardsCity", subCustomer.ContactManToSendCardsCity);
                    m_GeneralCmd.AddUpdateValue("ContactManToSendCardsZip", subCustomer.ContactManToSendCardsZip);
                    m_GeneralCmd.AddUpdateValue("ContactManToSendCardsComments", subCustomer.ContactManToSendCardsComments);
                    m_GeneralCmd.AddUpdateValue("CRMNumber", subCustomer.CRMNumber);
                    m_GeneralCmd.SetCmd($"update {m_GeneralCmd.TableName} set {m_GeneralCmd.GetSetValue()} where {m_GeneralCmd.GetWhereKeyValue()}");

                            using (OracleCommand command = new OracleCommand(m_GeneralCmd.GetCmd(), connection))
                            {
                                command.CommandTimeout = 5000;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    foreach (ContactMan contactMan in subCustomer.ContactMen)
                                    {
                                        bool response = UpdateContactMan(contactMan, contactMan.ContactManID, out ErrorMessage);
                                        if (!response)
                                        {
                                          ErrorMessage = $"Error when try to update contact man  name {contactMan.ContactManName}";
                                          log.Error(ErrorMessage);
                                          return false;
                                        }
                                    }
                                    return true;
                                }
                                else
                                {
                                     ErrorMessage = $"Error when try Update customer name {subCustomer.CustomerName}, Error Message: Request Id: '{requestId}' is not exist";
                                     log.Error(ErrorMessage);
                           
                                   return false;
                                }

                            }

                }
                catch (Exception ex)
                {
                    //insert log error message
                    ErrorMessage = $"Exception when try update subcustomer, error message: {ex.Message}";
                    log.Error(ErrorMessage);
                    return false;
                }
                finally
                {
                    connection.Close();

                }
            }
        }

        [Obsolete("Message")]
        public bool InsertContactMan(ContactMan contactMan , out string ErrorMessage)
        {
            using (OracleConnection connection = new OracleConnection(m_connectionString))
            {
                try
                {
                    ErrorMessage = "";
                    connection.Open();
                    try
                    {
                        bool isIdExist = IsValueExist(contactMan.ContactManID, "CONTACTMANID", "TBL_CONTACT_MAN_1275");
                        if (!isIdExist)
                        {
                            m_GeneralCmd.TableName = "TBL_CONTACT_MAN_1275";
                            m_GeneralCmd.AddInsertValue("ContactManID", contactMan.ContactManID);
                            m_GeneralCmd.AddInsertValue("ContactManName", contactMan.ContactManName);
                            m_GeneralCmd.AddInsertValue("ContactManFamilyName", contactMan.ContactManFamilyName);
                            m_GeneralCmd.AddInsertValue("ContactManPosition", contactMan.ContactManPosition);
                            m_GeneralCmd.AddInsertValue("ContactManPhone", contactMan.ContactManPhone);
                            m_GeneralCmd.AddInsertValue("ContactManPhone2", contactMan.ContactManPhone2);
                            m_GeneralCmd.AddInsertValue("ContactManMobilePhone", contactMan.ContactManMobilePhone);
                            m_GeneralCmd.AddInsertValue("ContactManFax", contactMan.ContactManFax);
                            m_GeneralCmd.AddInsertValue("ContactManEmail", contactMan.ContactManEmail);
                            m_GeneralCmd.AddInsertValue("ContactManComment", contactMan.ContactManComment);
                      
                            m_GeneralCmd.SetCmd("insert into {0} ({1}) values ({2})", new string[] { m_GeneralCmd.TableName, m_GeneralCmd.GetInsertColumn(), m_GeneralCmd.GetInsertValue() });

                            using (OracleCommand command = new OracleCommand(m_GeneralCmd.GetCmd(), connection))
                            {
                                command.CommandTimeout = 5000;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    ErrorMessage = $"Error when try to insert Contact Man Name {contactMan.ContactManName}";
                                    log.Error(ErrorMessage);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return UpdateContactMan(contactMan, contactMan.ContactManID, out ErrorMessage);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = $"Exception when insert Contact Name {contactMan.ContactManName} into data base , error message: {ex.Message}";
                        log.Error(ErrorMessage);

                    }
                }
                catch (Exception ex)
                {
                    //insert log error message
                    ErrorMessage = $"Exception when try insert Contack Man, error message: {ex.Message}";
                    log.Error(ErrorMessage);
                    return false;
                }
                finally
                {
                    connection.Close();

                }
            }
            return false;
        }

        [Obsolete("Message")]
        private bool UpdateContactMan(ContactMan contactMan, int contactManID, out string ErrorMessage)
        {
            using (OracleConnection connection = new OracleConnection(m_connectionString))
            {
                try
                {
                    ErrorMessage = "";
                    connection.Open();
                    try
                    {
                        m_GeneralCmd.TableName = "TBL_CONTACT_MAN_1275";
                        m_GeneralCmd.AddWhereKeyVal("ContactManID", contactManID);
                        m_GeneralCmd.AddUpdateValue("ContactManName", contactMan.ContactManName);
                        m_GeneralCmd.AddUpdateValue("ContactManFamilyName", contactMan.ContactManFamilyName);
                        m_GeneralCmd.AddUpdateValue("ContactManPosition", contactMan.ContactManPosition);
                        m_GeneralCmd.AddUpdateValue("ContactManPhone", contactMan.ContactManPhone);
                        m_GeneralCmd.AddUpdateValue("ContactManPhone2", contactMan.ContactManPhone2);
                        m_GeneralCmd.AddUpdateValue("ContactManMobilePhone", contactMan.ContactManMobilePhone);
                        m_GeneralCmd.AddUpdateValue("ContactManFax", contactMan.ContactManFax);
                        m_GeneralCmd.AddUpdateValue("ContactManEmail", contactMan.ContactManEmail);
                        m_GeneralCmd.AddUpdateValue("ContactManComment", contactMan.ContactManComment);
                        m_GeneralCmd.SetCmd($"update {m_GeneralCmd.TableName} set {m_GeneralCmd.GetSetValue()} where {m_GeneralCmd.GetWhereKeyValue()}");

                        using (OracleCommand command = new OracleCommand(m_GeneralCmd.GetCmd(), connection))
                        {
                            command.CommandTimeout = 5000;
                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = $"Exception when update Contact Name {contactMan.ContactManName} to data base , error message: {ex.Message}";
                        log.Error(ErrorMessage);

                    }
                }
                catch (Exception ex)
                {
                    //insert log error message
                    ErrorMessage = $"Exception when try update Contack Man Name {contactMan.ContactManName}, error message: {ex.Message}";
                    log.Error(ErrorMessage);
                    return false;
                }
                finally
                {
                    connection.Close();

                }
            }
            return false;
        }

        [Obsolete("Message")]
        public bool IsValueExist<T>(T key,string value, string tableName)
        {

            using (OracleConnection connection = new OracleConnection(m_connectionString))
            {
                try
                {
                    connection.Open();
                    m_GeneralCmd.TableName = tableName; 
                    m_GeneralCmd.AddWhereKeyVal(value, key);
                    List<string> paramsArray = new List<string>() { m_GeneralCmd.TableName, m_GeneralCmd.GetWhereKeyValue() };
                    m_GeneralCmd.SetCmd($"select {value} from {m_GeneralCmd.TableName} where {m_GeneralCmd.GetWhereKeyValue()}");
                    using (OracleCommand command = new OracleCommand(m_GeneralCmd.GetCmd(), connection))
                    {
                        command.CommandTimeout = 5000;
                        OracleDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"Exception when try to check if id exist, error message: {ex.Message}");
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

    }
}