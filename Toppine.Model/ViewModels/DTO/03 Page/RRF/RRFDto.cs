using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toppine.Model.ViewModels.DTO
{
    public class RRFDto : PageDto
    {
        public int ID { get; set; }
        public DateTime? IssueDate { get; set; }  //Generate Time

        public string CRNRRF { get; set; }

        public int? VersionNo { get; set; }
        public int LocationCodeID { get; set; }                 //0时没有location code
        public string LocationCode { get; set; }
        public string Address { get; set; }
        public string AddressChinese { get; set; }

        public int TCID { get; set; }
        public string TCYear { get; set; }
        public string IssueOfficer { get; set; }

        public string IssueOfficerPost { get; set; }

        public string GeneralRemarks { get; set; }
        public string Urgency { get; set; }                         //Urgency
        public string UrgencyDesc { get; set; }
        public bool? HighRisk { get; set; }                        //High Risk 旧：HR(Y/N)

        public bool? CancelledRRF { get; set; }                    //Cancelled RRF

        public string FEHDType { get; set; }                       //FEHD Type  旧：FEHD(NT) or(T)  or(M)
        public string FEHDDesc { get; set; }

        public string ClaimType { get; set; }                      //Claim Type 旧：页面设置Enabled = false不变

        //SubConRemark
        public int DistrictID { get; set; } = 0;                    //0时没有district
        public string DistrictCode { get; set; }                   //District 旧：DID
        public bool? Measurement { get; set; }                     //Measurement
        public bool? FollowUp { get; set; }                        //Follow Up

        public bool? IsNight { get; set; }                      //夜单，勾选此项,导入根据PDF设置  ,Special Rules RRF第一项，除了subcon 會變成特定subcon，也會勾選夜單
        public bool? IsDay { get; set; }                        //转日单，需从夜单 转换过来 ，一定是先選擇夜單了，才會有轉日單選項提供選。

        public bool? IsHRW { get; set; }                         //选中高危工作
        public int? HRWContent { get; set; }                     //选中高危内容
        public string HRWContentDesc { get; set; }                //高危内容详细
        public string HRWContentOthers { get; set; }             //高危内容选择其他

        public string GenRemarks { get; set; }                    //Remarks_Gen
        public string SuRemarks { get; set; }                     //Remarks_Su

        public string SubConRef { get; set; }                   //SubConRef
        public string SubConRemark { get; set; }

        public string RRFRelation { get; set; }                   //RRF 旧:RRF No

        public string MWO { get; set; }                           //MWO 旧:MWONo
        public string WOBEP { get; set; }                         //WO（BEP)	 旧:WWONo
        public string MOrderNo { get; set; }                      //'M'Order No  旧:BPCDMONo


        public DateTime? DateForCommencement { get; set; }        //Date For Commencement
        public DateTime? TargetCompletionDate { get; set; }       //Target Completion Date
        public DateTime? ReportCompletionApp { get; set; }        //Report Completion(App)     旧：MPCDate
        public DateTime? TelephoneReportingDate { get; set; }     //Telephon eReporting Date 旧：TRDate
        public DateTime? TemporayCancel { get; set; }             //Temporay Cancel

        public DateTime? CancelledOn { get; set; }                //Cancelled On

        public int? AppStatus { get; set; }                     //App Status
        public string AppStatusDesc { get; set; } = "";            //App Status Desc
        public string DARRFStatus { get; set; }                   //SubconLogNo

        public string EditStatus { get; set; } = "";             //对应版面允许操作的字段，I：import允许更新的字段，B:Basic Infomation版面允许编辑的字段 


        //public List<RRFClientDto> RRFItemList { get; set; }        //RRF Item List

        //public List<SubConDto> SubConList { get; set; }              //返回SubCon，版面修改时，将修改后的数据保存在这个参数
        //public List<SubConLogDto> SubConLogList { get; set; }          //SubCon input部分

        //public List<ComplaintDto> ComplaintList { get; set; }          //Complaint部分

        //public RMWRelationSubDto Relation { get; set; }               //Relation
        //public RMWRelationSubDto RelationList { get; set; }          //过滤属性，设置Relation时临时使用
        //public List<DocumentSummaryDto> DocumentSummaryList { get; set; }          //过滤属性，设置Relation时临时使用

        //public List<RRFMWOCheckSubmissionShowDto> RRFMWOCheckSubmissionList { get; set; }   //INFORMATION CONTRACTOR
        //public List<MOrderPaymentVoucherClaimDto> MOrderList { get; set; }   //M Order List


        public string PDFPath { get; set; } = "";                        //原始的PDF文档路径
        public string QRPDFPath { get; set; } = "";                      //加上二维码和其它翻译后的 PDF文档路径

        public string ImportStatus { get; set; } = "";                   //Import，导入RRF后的状态，在自动或手动导入RRF时，如果DISTRICT/subcon没值，设置: I,导入成功后，设置为""

        //Work Detail
        public string WorkerName { get; set; }
        public string WorkerTel { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? LeavingTime { get; set; }
        public string DelayReason { get; set; }

        public DateTime? UpdateOn { get; set; }


        //Batching
        public string BatchNo { get; set; }
        public DateTime? BatchDate { get; set; }
        //Searhc


        //RRF Details -->Checker
        public DateTime? CheckerDocCheckDate { get; set; }
        public DateTime? CheckerSiteCheckDate { get; set; }

        public string SearchCRNRRF { get; set; } = "";
        public string SearchImportStatus { get; set; } = "";   //导入版面是传入: I ,状态为I的记录，只能出现在导入版面，SAVE后，才可以出现在RRF工种其它版面或参与其它计算与统计
        public string SearchFEHDType { get; set; } = "";       // 从菜单H ,FEHD(T):2,FEHD(M):3


        public DateTime? SearchIssueDateFrom { get; set; }
        public DateTime? SearchIssueDateTo { get; set; }
        public int? SearchDistrict { get; set; }

        public DateTime? SearchAppointmanetDateFrom { get; set; }                   //Appointmanet Date & Time (Form)
        public DateTime? SearchAppointmanetDateTo { get; set; }                      // Appointmanet Date & Time(To)
        //public DateTime? SearchTargetDateFrom { get; set; }
        //public DateTime? SearchTargetDateTo { get; set; }
        public string SearchLocation { get; set; } = "";
        public string SearchLocationCode { get; set; } = "";
        //public string SearchRRFStatus { get; set; } = "";
        // public string SearchPriority { get; set; } = "";
        public string SearchCategory { get; set; } = "";
        public string SearchDescription { get; set; } = "";
        //public DateTime? SearchSiteCompDateForm { get; set; }           //Site Completion Date (Form)    
        //public DateTime? SearchSiteCompDateTo { get; set; }             //Site Completion Date (To)
        public DateTime? SearchTelephoneReportingDateForm { get; set; }                //Telephone Reporting Date & Time (Form)
        public DateTime? SearchTelephoneReportingDateTo { get; set; }                  //Telephone Reporting Date & Time (To)
        public DateTime? SearchCallinReportCompDateForm { get; set; }         //Call in Report Completion (Form)
        public DateTime? SearchCallinReportCompDateTo { get; set; }           //Call in Report Completion(To)
        //public DateTime? SearchAttendedDateForm { get; set; }           //Attended Date & Time(Form)
        //public DateTime? SearchAttendedDateTo { get; set; }             // Attended Date & Time(To)
        public int? SearchMWOWO { get; set; } = 0;                      //MWO/WO
    }


    public class RRFTableDto
    {
        public int ID { get; set; }


        public string CRNRRF { get; set; }
        public string District { get; set; }

        public int? VersionNo { get; set; }
        public int LocationCodeID { get; set; }
        public string Location { get; set; }
        public string LocationCode { get; set; }
        public string Address { get; set; }
        public string AddressChinese { get; set; }
        public int TCID { get; set; }
        public string TCYear { get; set; }
        public string IssueOfficer { get; set; }

        public string IssueOfficerPost { get; set; }

        public string GeneralRemarks { get; set; }
        public string Urgency { get; set; }                       //Urgency
        public bool? HighRisk { get; set; }                      //High Risk 旧：HR(Y/N)

        public bool? CancelledRRF { get; set; }                  //Cancelled RRF

        public byte? FEHDType { get; set; }                      //FEHD Type  旧：FEHD(NT) or(T)  or(M)

        public string ClaimType { get; set; }                     //Claim Type 旧：页面设置Enabled = false不变

        //SubConRemark
        public int DistrictID { get; set; }
        public int DistrictCode { get; set; } //District 旧：DID
        public bool? Measurement { get; set; }                     //Measurement
        public bool? FollowUp { get; set; }                        //Follow Up
        public bool? IsNight { get; set; }                      //夜单，勾选此项,导入根据PDF设置  ,Special Rules RRF第一项，除了subcon 會變成特定subcon，也會勾選夜單
        public bool? IsDay { get; set; }                        //转日单，需从夜单 转换过来 ，一定是先選擇夜單了，才會有轉日單選項提供選。

        public bool? IsHRW { get; set; }                        //选中高危工作
        public int? HRWContent { get; set; }                     //选中高危内容
        public string HRWContentDes { get; set; }                //高危内容详细
        public string HRWContentOthers { get; set; }             //高危内容选择其他

        public string GenRemarks { get; set; }                    //Remarks_Gen
        public string SuRemarks { get; set; }                     //Remarks_Su



        public string RRFRelation { get; set; }                         //RRF 旧:RRF No

        public string MWO { get; set; }                           //MWO 旧:MWONo
        public string WOBEP { get; set; }                         //WO（BEP)	 旧:WWONo
        public string MOrderNo { get; set; }                      //'M'Order No  旧:BPCDMONo


        public DateTime? DateForCommencement { get; set; }        //Date For Commencement
        public DateTime? TargetCompletionDate { get; set; }       //Target Completion Date
        public DateTime? ReportCompletionApp { get; set; }        //Report Completion(App)     旧：MPCDate
        public DateTime? TelephoneReportingDate { get; set; }     //Telephon eReporting Date 旧：TRDate
        public DateTime? TemporayCancel { get; set; }             //Temporay Cancel

        public DateTime? CancelledOn { get; set; }                //Cancelled On

        public int AppStatus { get; set; } = 0;                    //App Status

        public string DARRFStatus { get; set; }                  //SubconLogNo

        public DateTime? CallinDateTime { get; set; }

        public DateTime? CRApptDate { get; set; }                //Client Request Appt Date  AND  Client Request Appt Time 

        public string CRApptTime { get; set; }                //Client Request Appt Date  AND  Client Request Appt Time 

        public DateTime? ATFCDate { get; set; }                //Client Request Appt Date  AND  Client Request Appt Time 

        public string ATFCTime { get; set; }                  //Appt Date From Contractor  AND Appt Time From Contractor 


        public int WorksNo { get; set; } = 0;
        public string QRPDFPath { get; set; } = "";

        //FEHDTM版本使用字段
        public string RRFStatus { get; set; } = "";

        public DateTime? CheckerSiteCheckDate { get; set; }

        public DateTime? ActualCompletionDate { get; set; }


        //Advance search
        public DateTime? IssueDate { get; set; }
        public string Category { get; set; }
        //public string Priority { get; set; }
        public List<string> Description { get; set; }
    }



    public class RRFTextToPDF
    {
        /// <summary>
        /// CRN
        /// </summary>
        public string CRNRRF { get; set; }
        public string Address { get; set; }
        public string AddressDetail { get; set; }
        public string APPDate { get; set; }
        public string APPTime { get; set; }
        public string Contact { get; set; }
        public string Tel { get; set; }

        public string QRcodePath { get; set; }   //二维码图片路径
        public string PdfSourcePath { get; set; }  //Pdf路径

    }


    public class RRFSearchDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int DistrictID { get; set; }
        public string SubCon { get; set; }
        public string FEHD { get; set; }
    }


    public class MWOSearchDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int DistrictID { get; set; }
        public string SubCon { get; set; }
    }

    public class WOSearchDto
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public int DistrictID { get; set; }
        public string SubCon { get; set; }
    }



    public class RRFSearchResultDelDto
    {
        public int ID { get; set; }
        public string CRNRRF { get; set; }
        public int TCID { get; set; }
        public string TCYear { get; set; }
        public string District { get; set; }
        public int DistrictID { get; set; }
        public string Urgency { get; set; }                       //Urgency
        public bool? HighRisk { get; set; }                      //High Risk 旧：HR(Y/N)
        public string HighRiskDesc { get; set; }

        public bool? IsHRW { get; set; }                        //高危工作
        public string IsHRWDesc { get; set; }                  //Yes.No


        public string SubCon { get; set; }
        public string BatchNo { get; set; }
        public int? VersionNo { get; set; }
        public int LocationCodeID { get; set; }
        public string Location { get; set; }
        public string LocationCode { get; set; }
        public string AddressEnglish { get; set; }
        public string AddressChinese { get; set; }
        public DateTime? IssueDate { get; set; }                //Cancelled On

        public string IssueOfficer { get; set; }

        public string IssueOfficerPost { get; set; }

        public string GeneralRemarks { get; set; }

        public bool? CancelledRRF { get; set; }                  //Cancelled RRF

        public string FEHDType { get; set; }                      //FEHD Type  旧：FEHD(NT) or(T)  or(M)

        public string ClaimType { get; set; }                     //Claim Type 旧：页面设置Enabled = false不变

        //SubConRemark

        public bool? Measurement { get; set; }                     //Measurement
        public bool? FollowUp { get; set; }                        //Follow Up
        public bool? IsNight { get; set; }                      //夜单，勾选此项,导入根据PDF设置  ,Special Rules RRF第一项，除了subcon 會變成特定subcon，也會勾選夜單
        public bool? IsDay { get; set; }                        //转日单，需从夜单 转换过来 ，一定是先選擇夜單了，才會有轉日單選項提供選。


        public int? HRWContent { get; set; }                     //选中高危内容
        public string HRWContentDes { get; set; }                //高危内容详细
        public string HRWContentOthers { get; set; }             //高危内容选择其他

        public string GenRemarks { get; set; }                    //Remarks_Gen
        public string SuRemarks { get; set; }                     //Remarks_Su

        //public string SubConRef { get; set; }                     //SubConRef
        //public string SubConRemark { get; set; }


        public string RRFRelation { get; set; }                         //RRF 旧:RRF No

        public string MWO { get; set; }                           //MWO 旧:MWONo
        public string WOBEP { get; set; }                         //WO（BEP)	 旧:WWONo
        public string MOrderNo { get; set; }                      //'M'Order No  旧:BPCDMONo


        public DateTime? DateForCommencement { get; set; }        //Date For Commencement
        public DateTime? TargetCompletionDate { get; set; }       //Target Completion Date
        public DateTime? ReportCompletionApp { get; set; }        //Report Completion(App)     旧：MPCDate
        public DateTime? TelephoneReportingDate { get; set; }     //Telephon eReporting Date 旧：TRDate
        public DateTime? TemporayCancel { get; set; }             //Temporay Cancel

        public DateTime? CancelledOn { get; set; }                //Cancelled On

        public int AppStatus { get; set; } = 0;                    //App Status

        public string DARRFStatus { get; set; }                  //SubconLogNo

        public DateTime? CallinDateTime { get; set; }

        public DateTime? CRApptDate { get; set; }                //Client Request Appt Date  AND  Client Request Appt Time 

        public string CRApptTime { get; set; }                //Client Request Appt Date  AND  Client Request Appt Time 

        public DateTime? ATFCDate { get; set; }                //Client Request Appt Date  AND  Client Request Appt Time 

        public string ATFCTime { get; set; }                  //Appt Date From Contractor  AND Appt Time From Contractor 


        public int WorksNo { get; set; } = 0;
        public string QRPDFPath { get; set; } = "";
        public int? TotalCount { get; set; } = 0;


    }

    public class RRFSearchResultDto
    {
        public int ID { get; set; }

        public string CRNRRF { get; set; }                            //MWONo
        public string CRNNo { get; set; }        //CRNNO
        public string MWONo { get; set; }
        public string RWONo { get; set; }                         //关联的 WONo
        public string MOrder { get; set; }                      //'M'Order No

        public string TCYear { get; set; }
        public string District { get; set; }
        public int DistrictID { get; set; }
        public string SubCon { get; set; }                        //SubCon
        public bool? HighRisk { get; set; }                      //High Risk
        public string HighRiskDesc { get; set; }                 //Yes.No
        public string SubConRemark { get; set; }                 //Subcon Remarks
        public string GenRemarks { get; set; }                    //Remarks_Gen
        public string SuRemarks { get; set; }                     //Remarks_Su


        public bool? Measurement { get; set; }                      //Measurement
        public string MeasurementDesc { get; set; }                 //Yes.No






        public bool? IsHRW { get; set; }                        //高危工作
        public string IsHRWDesc { get; set; }                  //Yes.No
        public int? HRWContent { get; set; }                     //选中高危内容


        public DateTime? DateForCommencement { get; set; }        //Date For Commencement
        public DateTime? CallinDateTime { get; set; }             //CallinDateTime

        public DateTime? ATFCDate { get; set; }                     //ATFCDate  Appointment Date
        public DateTime? TargetCompletionDate { get; set; }        //Target Completion Date
        public DateTime? TelephoneReportingDate { get; set; }           //TelephoneReportingDate
        public string DARRFStatus { get; set; }                  //SubconLogNo
        public int LocationCodeID { get; set; }
        public string LocationCode { get; set; }
        public string AddressEnglish { get; set; }
        public string AddressChinese { get; set; }
        public DateTime? IssueDate { get; set; }

        public int? TotalCount { get; set; } = 0;


    }

}
