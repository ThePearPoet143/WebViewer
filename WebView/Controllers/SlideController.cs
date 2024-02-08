using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebView.Models;
using WebView.ViewModel;
using WebView.Utility;
using System.Globalization;

namespace WebView.Controllers
{
    public class SlideController : Controller
    {
        private string ImageFolderPath { get; set; } //&&RL

        // GET: Slide
        public ActionResult Index()
        {
            List<VMSlide> vm = new List<VMSlide>();
            string constr = ConfigurationManager.ConnectionStrings["IkoConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"if object_id('tempdb..#tempLevel0','u') is not null
drop table #tempLevel0
if object_id('tempdb..#tempLevel1','u') is not null
drop table #tempLevel1

 SELECT distinct s.Barcode,sras.ID sliderunAppscanID, s.Accession, s.CaseNumber as 'Case', 
                r.ID sliderunID, r.StartTime, r.DurationInSeconds as ScanTime, r.TestOutcome as ScanResult, r.LampHoursStart, r.TransferStartTime, r.TransferEndTime, r.Archived, r.Purged, 
                p.FirstName, p.LastName, 
                st.Description as 'Type', 
                sa.ID slideAreaID, sa.Name as Area, 
               sc.Name as Ikoniscope, 
                sras.NumberOfNuclei as NucleiLow, 
                sras.NumberOfTargets TargetsLow, 
                sras.TargetDensityPerSquareMillimeter Density
                , gas.ScanLevel 
                into #tempLevel0
                FROM SlideRun r 
                INNER JOIN Slide s ON r.SlideID = s.ID 
                INNER JOIN SlideTypeAssociation sta ON sta.ID = r.SlideTypeAssociationID 
                INNER JOIN SlideType st ON st.ID = sta.SlideTypeID 
               INNER JOIN Patient p ON s.PatientID = p.ID 
               INNER JOIN SlideArea sa ON r.SlideAreaID = sa.ID 
               INNER JOIN Scanner sc ON r.ScannerID = sc.ID 
               LEFT JOIN SlideRunAppScan sras ON r.ID = sras.SlideRunID 
               LEFT JOIN GenericAppScan gas ON sras.GenericAppScanID = gas.ID
                 where gas.ScanLevel =0
               order by StartTime desc
             

               SELECT distinct s.Barcode,sras.ID sliderunAppscanID, s.Accession, s.CaseNumber as 'Case', 
                r.ID sliderunID, r.StartTime, r.DurationInSeconds as ScanTime, r.TestOutcome as ScanResult, r.LampHoursStart, r.TransferStartTime, r.TransferEndTime, r.Archived, r.Purged, 
                p.FirstName, p.LastName, 
                st.Description as 'Type', 
                sa.ID slideAreaID, sa.Name as Area, 
               sc.Name as Ikoniscope, 
                sras.NumberOfNuclei as NucleiLow, 
                sras.NumberOfTargets TargetsHi, 
                sras.TargetDensityPerSquareMillimeter Density
                , gas.ScanLevel 
                into #tempLevel1
                FROM SlideRun r 
                INNER JOIN Slide s ON r.SlideID = s.ID 
                INNER JOIN SlideTypeAssociation sta ON sta.ID = r.SlideTypeAssociationID 
                INNER JOIN SlideType st ON st.ID = sta.SlideTypeID 
               INNER JOIN Patient p ON s.PatientID = p.ID 
               INNER JOIN SlideArea sa ON r.SlideAreaID = sa.ID 
               INNER JOIN Scanner sc ON r.ScannerID = sc.ID 
               LEFT JOIN SlideRunAppScan sras ON r.ID = sras.SlideRunID 
               LEFT JOIN GenericAppScan gas ON sras.GenericAppScanID = gas.ID
                 where gas.ScanLevel =1
               order by StartTime desc
               
               select l.*,h.TargetsHi from #tempLevel0 l
               left join #tempLevel1 h on l.Barcode = h.Barcode and l.StartTime = h.StartTime
               order by l.StartTime desc";
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        VMSlide item = new VMSlide();
                        item.Barcode = r["Barcode"].ToString();
                        item.Accession = r["Accession"].ToString();
                        item.Case = r["Case"].ToString();
                        item.FirstName = r["FirstName"].ToString();
                        item.LastName = r["LastName"].ToString();
                        item.StartTime = r["StartTime"].ToString();
                        item.Area = r["Area"].ToString();
                        item.Ikoniscope = r["Ikoniscope"].ToString();
                        item.ScanTime = r["ScanTime"].ToString();
                        item.ScanResult = r["ScanResult"].ToString();
                        item.NucleiLow = r["NucleiLow"].ToString();
                        item.TargetsHi = r["TargetsHi"].ToString();
                        item.TargetsLow = r["TargetsLow"].ToString();
                        item.Density = r["Density"].ToString();
                        item.SliderunAppscanID = r["sliderunAppscanID"].ToString();
                        vm.Add(item);
                    }
                    con.Close();
                }
            }
            return View(vm);
        }
        public ActionResult Detail(string barcode, string startTime, string sliderunAppscanID)
        {
            VMSlideRun vm = new VMSlideRun();
            vm.SlideDetails = new VMSlide
            {
                Barcode = barcode,
                StartTime = startTime,
                // Include other properties as needed
            };
            // Construct the image folder path based on Barcode and StartTime.
            DateTime startTimeDateTime = DateTime.Parse(startTime);
            ViewBag.ImageFolderPath = $"{startTimeDateTime.ToString("yyyyMMdd.HHmm")}.{barcode}"; 

            FieldMetrics fm = new FieldMetrics(new DoubletF());
            List<FieldLowDetail> lstFieldLow = new List<FieldLowDetail>();
            string constr = ConfigurationManager.ConnectionStrings["IkoConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"if object_id('tempdb..#tempField','u') is not null
drop table #tempField
if object_id('tempdb..#tempTarget','u') is not null
drop table #tempTarget

declare @sliderunappscanid int
set  @sliderunappscanid = 1364

select * 
into #tempField
from field where sliderunAppscanID =" + sliderunAppscanID +@" 
select f.ID ,count(*) TargetHi
into #tempTarget
from field f
join Target t on t.FieldID = f.ID
where f.SlideRunAppScanID =" + sliderunAppscanID +
@" group by f.id

select a.* , b.TargetHi 
from #tempField a
left join #tempTarget b on a.ID = b.id order by visitsequence";
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        FieldLowDetail item = new FieldLowDetail();
                        item.ID = r["VisitSequence"] != DBNull.Value? r["VisitSequence"].ToString() : "";
                        item.Nuclei = r["NumberOfNuclei"] != DBNull.Value ? r["NumberOfNuclei"].ToString() : "";
                        item.SeqNum = r["VisitSequence"] != DBNull.Value ? r["VisitSequence"].ToString() : "";
                        item.TargetHi = r["TargetHi"] != DBNull.Value ? r["TargetHi"].ToString() : "";
                        item.TargetLow = r["NumberOfTargets"] != DBNull.Value ? r["NumberOfTargets"].ToString() : "";
                        item.xPosition = r["FieldLocationXInMicron"] != DBNull.Value ? r["FieldLocationXInMicron"].ToString() : "";
                        item.yPosition = r["FieldLocationYInMicron"] != DBNull.Value ? r["FieldLocationYInMicron"].ToString() : "";
                        int xpos = Convert.ToInt32(item.xPosition);
                        int ypos = Convert.ToInt32(item.yPosition);
                        
                        item.Field = Math.Round((fm.GetGridPosition(new DoubletF(xpos, ypos)).X + fm.GetGridPosition(new DoubletF(xpos, ypos)).Y*21.45)).ToString();
                        lstFieldLow.Add(item);
                    }
                    con.Close();
                }
              
                vm.lstFieldLow = lstFieldLow;

            }
            return View(vm);
        }
        public ActionResult RetrieveImage(string barcode, string startTime, int id)
        {
            // Construct the image folder path based on Barcode and StartTime.
            DateTime startTimeDateTime = DateTime.Parse(startTime);
            string imageFolderPath = $"{startTimeDateTime.ToString("yyyyMMdd.HHmm")}.{barcode}";

            // Construct the full path to the image file
            string imagePath = $"E:/Images/{imageFolderPath}/Level0/Fields/{id:0000000}/Channel0_SL0.png";

            // Check if the image file exists
            if (System.IO.File.Exists(imagePath))
            {
                // Read the image file into a byte array
                byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

                // Return the image file as a FileResult
                return File(imageBytes, "image/png"); // Adjust the content type based on the actual image format
            }
            else
            {
                // Return a HTTP 404 Not Found response if the image file does not exist
                return HttpNotFound();
            }
        }
    }
}