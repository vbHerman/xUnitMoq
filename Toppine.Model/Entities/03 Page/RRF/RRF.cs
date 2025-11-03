using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toppine.Model.Entities
{
    [Table("RRF")]
    public partial class RRF : CRUDBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        public DateTime? IssueDate { get; set; }  //Generate Time

        [StringLength(50)]
        public string CRNRRF { get; set; }

        public int? VersionNo { get; set; }

        public int LocationCodeID { get; set; }
        public int TCID { get; set; }
        public string TCYear { get; set; }
        public string IssueOfficer { get; set; }

        public string IssueOfficerPost { get; set; }

        public string GeneralRemarks { get; set; }
        public string Urgency { get; set; }                       //Urgency ,U--Urgent,E--Emergency,N--Normal
        public bool? HighRisk { get; set; }                      //High Risk 旧：HR(Y/N)

        public bool? CancelledRRF { get; set; }                  //Cancelled RRF

        public string FEHDType { get; set; }                      //FEHD Type  旧：FEHD(NT) or(T)  or(M)

        public string ClaimType { get; set; }                     //Claim Type 旧：页面设置Enabled = false不变

        //SubConRemark
        public int DistrictID { get; set; }                       //District 旧：DID

        public bool? Measurement { get; set; }
        public bool? IsNight { get; set; }                      //夜单，勾选此项,导入根据PDF设置  ,Special Rules RRF第一项，除了subcon 會變成特定subcon，也會勾選夜單
        public bool? IsDay { get; set; }                        //转日单，需从夜单 转换过来 ，一定是先選擇夜單了，才會有轉日單選項提供選。
        public bool? FollowUp { get; set; }                        //Follow Up
        //高危工作
        public bool? IsHRW { get; set; }                         //选中高危工作
        public int? HRWContent { get; set; }                     //选中高危内容ID
        public string HRWContentOthers { get; set; }             //高危内容选择其他

        public string GenRemarks { get; set; }                    //Remarks_Gen
        public string SuRemarks { get; set; }                     //Remarks_Su

        public string SubConRef { get; set; }                     //SubConRef
        public string SubConRemark { get; set; }                   //SubCon Remark

        //********************* 以下4个转至 RMWRelation 表中保存 *********************
        public string RRFRelation { get; set; }                         //RRF 旧:RRF No

        public string MWO { get; set; }                           //MWO 旧:MWONo
        public string WOBEP { get; set; }                         //WO（BEP)	 旧:WWONo
        public string MOrderNo { get; set; }                      //'M'Order No  旧:BPCDMONo
        //********************* end *********************

        public DateTime? DateForCommencement { get; set; }        //Date For Commencement
        public DateTime? TargetCompletionDate { get; set; }       //Target Completion Date
        public DateTime? ReportCompletionApp { get; set; }        //Report Completion(App)     旧：MPCDate
        public DateTime? TelephoneReportingDate { get; set; }     //Telephon eReporting Date 旧：TRDate
        public DateTime? TemporayCancel { get; set; }             //Temporay Cancel

        public DateTime? CancelledOn { get; set; }                //Cancelled On

        public int? AppStatus { get; set; } = 0;                    //App Status ，值0-5 参照手机定义

        public string DARRFStatus { get; set; }                   //RRF Status(DA)

        public string ImportStatus { get; set; } = "";                   //Import，导入RRF后的状态，在自动或手动导入RRF时，如果DISTRICT/subcon没值，设置: I,导入成功后，设置为""

        //Work Detail
        public string WorkerName { get; set; }
        public string WorkerTel { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? LeavingTime { get; set; }
        public string DelayReason { get; set; }

        //Batching
        public string BatchNo { get; set; }
        public DateTime? BatchDate { get; set; }
    }
}
