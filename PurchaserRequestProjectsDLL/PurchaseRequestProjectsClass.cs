/* Title:           Purchase Request Projects Class
 * Date:            1-13-20
 * Author:          Terry HOlmes
 * 
 * Description:     This class is used for the purchase request projects */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace PurchaserRequestProjectsDLL
{
    public class PurchaseRequestProjectsClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        PurchaseRequestProjectsDataSet aPurchaseRequestProjectsDataSet;
        PurchaseRequestProjectsDataSetTableAdapters.purchaserequestprojectsTableAdapter aPurchaseRequestProjectsTableAdapter;

        InsertPurchaseRequestProjectEntryTableAdapters.QueriesTableAdapter aInsertPurchaseRequestProjectTableAdapter;

        FindPurchaseRequestProjectByJobNumberDataSet aFindPurchaseRequestProjectByJobNumberDataSet;
        FindPurchaseRequestProjectByJobNumberDataSetTableAdapters.FindPurchaseRequestProjectByJobNumberTableAdapter aFindPurchaseRequestProjectByJobNumberTableadapter;

        FindPurchaseRequestProjectByProjectIDDataSet aFindPurchaseRequestProjectByProjectIDDataSet;
        FindPurchaseRequestProjectByProjectIDDataSetTableAdapters.FindPurchaseRequestProjectByProjectIDTableAdapter aFindPurchaseRequestProjectByProjectIDTableAdapter;

        public FindPurchaseRequestProjectByProjectIDDataSet FindPurchaseRequestByProjectID(int intProjectID)
        {
            try
            {
                aFindPurchaseRequestProjectByProjectIDDataSet = new FindPurchaseRequestProjectByProjectIDDataSet();
                aFindPurchaseRequestProjectByProjectIDTableAdapter = new FindPurchaseRequestProjectByProjectIDDataSetTableAdapters.FindPurchaseRequestProjectByProjectIDTableAdapter();
                aFindPurchaseRequestProjectByProjectIDTableAdapter.Fill(aFindPurchaseRequestProjectByProjectIDDataSet.FindPurchaseRequestProjectByProjectID, intProjectID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Project Class // Find Purchase Request By Project ID " + Ex.Message);
            }

            return aFindPurchaseRequestProjectByProjectIDDataSet;
        }
        public FindPurchaseRequestProjectByJobNumberDataSet FindPurchaseRequestProjectByJobNumber(string strJobNumber)
        {
            try
            {
                aFindPurchaseRequestProjectByJobNumberDataSet = new FindPurchaseRequestProjectByJobNumberDataSet();
                aFindPurchaseRequestProjectByJobNumberTableadapter = new FindPurchaseRequestProjectByJobNumberDataSetTableAdapters.FindPurchaseRequestProjectByJobNumberTableAdapter();
                aFindPurchaseRequestProjectByJobNumberTableadapter.Fill(aFindPurchaseRequestProjectByJobNumberDataSet.FindPurchaseRequestProjectByJobNumber, strJobNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Project Class // Find Purchase Request Project By Job Number " + Ex.Message);
            }

            return aFindPurchaseRequestProjectByJobNumberDataSet;
        }
        public bool InsertPurchaseRequestProject(int intPONumber, string strJobNumber, int intProjectID)
        {
            bool blnFatalError = false;

            try
            {
                aInsertPurchaseRequestProjectTableAdapter = new InsertPurchaseRequestProjectEntryTableAdapters.QueriesTableAdapter();
                aInsertPurchaseRequestProjectTableAdapter.InsertPurchaseRequestProject(intPONumber, strJobNumber, intProjectID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Projects Class // Insert Purchase Request Project " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public PurchaseRequestProjectsDataSet GetPurchaseRequestProjectsInfo()
        {
            try
            {
                aPurchaseRequestProjectsDataSet = new PurchaseRequestProjectsDataSet();
                aPurchaseRequestProjectsTableAdapter = new PurchaseRequestProjectsDataSetTableAdapters.purchaserequestprojectsTableAdapter();
                aPurchaseRequestProjectsTableAdapter.Fill(aPurchaseRequestProjectsDataSet.purchaserequestprojects);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Reqeust Projects Class // Get Purchase Request Projects Info " + Ex.Message);
            }

            return aPurchaseRequestProjectsDataSet;
        }
        public void UpdatePurchaseRequestProjectsDB(PurchaseRequestProjectsDataSet aPurchaseRequestProjectsDataSet)
        {
            try
            {
                aPurchaseRequestProjectsTableAdapter = new PurchaseRequestProjectsDataSetTableAdapters.purchaserequestprojectsTableAdapter();
                aPurchaseRequestProjectsTableAdapter.Update(aPurchaseRequestProjectsDataSet.purchaserequestprojects);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Reqeust Projects Class // Update Purchase Request Projects DB " + Ex.Message);
            }
        }
    }
}
