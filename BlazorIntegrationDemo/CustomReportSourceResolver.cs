using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Telerik.Reporting;
using Telerik.Reporting.Services;
using Models;

namespace CSharp.Net5.BlazorIntegrationDemo
{
    public class CustomReportSourceResolver : IReportSourceResolver
    {
        //Variable for currency
        private static string currency;
        //Variable for the path of the report
        private static string reportpath; 

        //Data TableVariables
        private static System.Data.DataTable CarbonGraphDataTable = new System.Data.DataTable();
        private static System.Data.DataTable PPNCompliantCarbonGraphDataTable = new System.Data.DataTable();
        private static System.Data.DataTable SocialCompletedProjectsDataTable = new System.Data.DataTable();
        private static System.Data.DataTable SocialUpcomingProjectsDataTable = new System.Data.DataTable();
        private static System.Data.DataTable SocialPieChartDataTable = new System.Data.DataTable();
        private static System.Data.DataTable CarbonPieChartOne = new System.Data.DataTable();
        private static System.Data.DataTable CarbonBarchartScopes = new System.Data.DataTable();
        private static System.Data.DataTable CarbonCompletedProjectsDataTable = new System.Data.DataTable();
        private static System.Data.DataTable CarbonUpcomingProjectsDataTable = new System.Data.DataTable();
        private static System.Data.DataTable CarbonExceptionsDataTable = new System.Data.DataTable();

        //Variable for the Event action to ensure that  variables are properly set
        public event Action onChange;


        //Getters and Setters
        public string getReportPath()
        {
            return reportpath;
        }

        public void setReporthPath(string CurrentReportPath)
        {
            reportpath = CurrentReportPath;
            NotifyStateChanged();
        }

        public void SetCarbonGraphDataTable(DataTable CarbonData)
        {
            CarbonGraphDataTable = CarbonData.Copy();
            NotifyStateChanged();
        }

        public DataTable GetCarbonGraphDataTable()
        {
            return CarbonGraphDataTable;
        }

        public void SetPPNCompliantCarbonGraphDataTable(DataTable CarbonData)
        {
            PPNCompliantCarbonGraphDataTable = CarbonData.Copy();
            NotifyStateChanged();
        }

        public DataTable GetPPNCompliantCarbonGraphDataTable()
        {
            return PPNCompliantCarbonGraphDataTable;
        }

        public void SetCarbonPieChartOneDataTable(DataTable CarbonData)
        {
            CarbonPieChartOne = CarbonData.Copy();
            NotifyStateChanged();
        }

        public void SetCarbonBarChartDataTable(DataTable CarbonData)
        {
            CarbonBarchartScopes = CarbonData.Copy();
            NotifyStateChanged();
        }

        public void SetCarbonCompletedProjectDataTable(DataTable CarbonData)
        {
            CarbonCompletedProjectsDataTable = CarbonData.Copy();
            NotifyStateChanged();
        }

        public void SetCarbonUpcomingProjecthDataTable(DataTable CarbonData)
        {
            CarbonUpcomingProjectsDataTable = CarbonData.Copy();
            NotifyStateChanged();
        }

        public void SetCarbonExceptionDataTable(DataTable CarbonData)
        {
            CarbonExceptionsDataTable = CarbonData.Copy();
            NotifyStateChanged();
        }

        public void SetSocialCompletedProjectDataTable(DataTable SocialData)
        {
            SocialCompletedProjectsDataTable = SocialData.Copy();
            NotifyStateChanged();
        }

        public void SetSocialUpcomingProjecthDataTable(DataTable SocialData)
        {
            SocialUpcomingProjectsDataTable = SocialData.Copy();
            NotifyStateChanged();
        }

        public void SetSocialPieChartDataTable(DataTable SocialData)
        {
            SocialPieChartDataTable = SocialData.Copy();
            NotifyStateChanged();
        }

        public void SetCurrency(string OrgCurrency)
        {
            currency = OrgCurrency;
            NotifyStateChanged();
        }


        //Method to notify that a variable has been changed
        private void NotifyStateChanged()
        {
            onChange?.Invoke();
        }


        public ReportSource Resolve(string report, OperationOrigin operationOrigin, IDictionary<string, object> currentParameterValues)
        {
            InstanceReportSource irs = new InstanceReportSource();

            //if statement to be used to set report items depending on the report path
            if (reportpath == "Reports/CarbonReductionReport.trdp")
            {
                var reportPackager = new ReportPackager();
                using (var sourceStream = System.IO.File.OpenRead("Reports/CarbonReductionReport.trdp"))
                {
                    var reportInstance = (Report)reportPackager.UnpackageDocument(sourceStream);
                    var graph1 = (Graph)reportInstance.Items.Find("graph1", true).FirstOrDefault();
                    var graph2 = (Graph)reportInstance.Items.Find("graph2", true).FirstOrDefault();
                    var graph3 = (Graph)reportInstance.Items.Find("graph3", true).FirstOrDefault();
                    var graph4 = (Graph)reportInstance.Items.Find("graph4", true).FirstOrDefault();
                    var graph5 = (Graph)reportInstance.Items.Find("graph5", true).FirstOrDefault();
                    var graph6 = (Graph)reportInstance.Items.Find("graph6", true).FirstOrDefault(); 
                    var graph7 = (Graph)reportInstance.Items.Find("graph7", true).FirstOrDefault();
                    var table3 = (Table)reportInstance.Items.Find("table3", true).FirstOrDefault();
                    var table4 = (Table)reportInstance.Items.Find("table4", true).FirstOrDefault();
                    var table5 = (Table)reportInstance.Items.Find("table5", true).FirstOrDefault();
                   
                    if (CarbonGraphDataTable == null)
                    {
                        Console.WriteLine("Get Help");
                    }
                    table4.DataSource = CarbonCompletedProjectsDataTable;
                    table5.DataSource = CarbonUpcomingProjectsDataTable;
                    graph1.DataSource = CarbonGraphDataTable;
                    graph2.DataSource = CarbonPieChartOne;
                    graph3.DataSource = CarbonPieChartOne;
                    graph4.DataSource = CarbonPieChartOne;
                    graph5.DataSource = CarbonPieChartOne;
                    graph6.DataSource = CarbonPieChartOne;
                    graph7.DataSource = CarbonBarchartScopes;
                    irs.ReportDocument = reportInstance;
                }
            }

            
            else if (reportpath == "Reports/SocialReductionReport.trdp")
            {
                var reportPackager = new ReportPackager();
                using (var sourceStream = System.IO.File.OpenRead("Reports/SocialReductionReport.trdp"))
                {
                    var reportInstance = (Report)reportPackager.UnpackageDocument(sourceStream);
                    var graph1 = (Graph)reportInstance.Items.Find("graph1", true).FirstOrDefault();
                    var table3 = (Table)reportInstance.Items.Find("table3", true).FirstOrDefault();
                    var table4 = (Table)reportInstance.Items.Find("table4", true).FirstOrDefault();

                    graph1.DataSource = SocialPieChartDataTable;

                    //Code that shows currency infront of data label
                    graph1.Series[0].DataPointLabelFormat = currency+ "{0:N2}";
                    
                    table3.DataSource = SocialUpcomingProjectsDataTable;
                    table4.DataSource = SocialCompletedProjectsDataTable;
                    irs.ReportDocument = reportInstance;
                }
            }

            else if(reportpath == "Reports/Report1.trdp")
            {
                var reportPackager = new ReportPackager();
                using (var sourceStream = System.IO.File.OpenRead("Reports/Report1.trdp"))
                {
                    var reportInstance = (Report)reportPackager.UnpackageDocument(sourceStream);
                    var table1 = (Table)reportInstance.Items.Find("table1", true).FirstOrDefault();
                    var graph1 = (Graph)reportInstance.Items.Find("graph1", true).FirstOrDefault();
                    var graph2 = (Graph)reportInstance.Items.Find("graph2", true).FirstOrDefault();
                    irs.ReportDocument = reportInstance;
                }
            }

            else if (reportpath == "Reports/ExceptionReport.trdp")
            {
                var reportPackager = new ReportPackager();
                using (var sourceStream = System.IO.File.OpenRead("Reports/ExceptionReport.trdp"))
                {
                    var reportInstance = (Report)reportPackager.UnpackageDocument(sourceStream);
                    irs.ReportDocument = reportInstance;
                }    

            }

            else if (reportpath == "Reports/SocialExceptionReport.trdp")
            {
                var reportPackager = new ReportPackager();
                using (var sourceStream = System.IO.File.OpenRead("Reports/SocialExceptionReport.trdp"))
                {
                    var reportInstance = (Report)reportPackager.UnpackageDocument(sourceStream);
                    irs.ReportDocument = reportInstance;
                }

            }

            else if (reportpath == "Reports/PPN0621CompliantCarbonReductionReport.trdp")
            {
                var reportPackager = new ReportPackager();
                using (var sourceStream = System.IO.File.OpenRead("Reports/PPN0621CompliantCarbonReductionReport.trdp"))
                {
                    var reportInstance = (Report)reportPackager.UnpackageDocument(sourceStream);
                    var graph1 = (Graph)reportInstance.Items.Find("graph1", true).FirstOrDefault();
                    var table4 = (Table)reportInstance.Items.Find("table4", true).FirstOrDefault();
                    var table5 = (Table)reportInstance.Items.Find("table5", true).FirstOrDefault();
                    if (CarbonGraphDataTable == null)
                    {
                        Console.WriteLine("Get Help");
                    }

                    table4.DataSource = CarbonCompletedProjectsDataTable;
                    table5.DataSource = CarbonUpcomingProjectsDataTable;
                    graph1.DataSource = PPNCompliantCarbonGraphDataTable;
                    irs.ReportDocument = reportInstance;
                }
            }

            return irs;


        }
    }
}