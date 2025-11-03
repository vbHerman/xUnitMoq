//
//using System.ComponentModel.DataAnnotations;

//namespace Toppine.Model.Entities
//{
//    /// <summary>
//    /// RRF实体类
//    /// </summary>
//    [SugarTable("RRFold")]
//    public partial class RRFold : CRUDBase
//    {
//        /// <summary>
//        /// 主键ID
//        /// </summary>
//        [Display(Name = "主键ID")]
//        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键ID")]
//        [Required(ErrorMessage = "请输入{0}")]
//        public int ID { get; set; }

//        /// <summary>
//        /// 生成时间
//        /// </summary>
//        [Display(Name = "生成时间")]
//        [SugarColumn(ColumnDescription = "生成时间", IsNullable = true)]
//        public DateTime? IssueDate { get; set; }

//        /// <summary>
//        /// CRNRRF编号
//        /// </summary>
//        [Display(Name = "CRNRRF编号")]
//        [SugarColumn(ColumnDescription = "CRNRRF编号", Length = 50, IsNullable = true)]
//        [StringLength(50, ErrorMessage = "【{0}】不能超过{1}字符长度")]
//        public string CRNRRF { get; set; }

//        /// <summary>
//        /// 版本号
//        /// </summary>
//        [Display(Name = "版本号")]
//        [SugarColumn(ColumnDescription = "版本号", IsNullable = true)]
//        public int? VersionNo { get; set; }

//        /// <summary>
//        /// 位置编码ID
//        /// </summary>
//        [Display(Name = "位置编码ID")]
//        [SugarColumn(ColumnDescription = "位置编码ID")]
//        [Required(ErrorMessage = "请输入{0}")]
//        public int LocationCodeID { get; set; }

//        /// <summary>
//        /// TCID
//        /// </summary>
//        [Display(Name = "TCID")]
//        [SugarColumn(ColumnDescription = "TCID")]
//        [Required(ErrorMessage = "请输入{0}")]
//        public int TCID { get; set; }

//        /// <summary>
//        /// TC年份
//        /// </summary>
//        [Display(Name = "TC年份")]
//        [SugarColumn(ColumnDescription = "TC年份", IsNullable = true)]
//        public string TCYear { get; set; }

//        /// <summary>
//        /// 签发人员
//        /// </summary>
//        [Display(Name = "签发人员")]
//        [SugarColumn(ColumnDescription = "签发人员", IsNullable = true)]
//        public string IssueOfficer { get; set; }

//        /// <summary>
//        /// 签发人员职位
//        /// </summary>
//        [Display(Name = "签发人员职位")]
//        [SugarColumn(ColumnDescription = "签发人员职位", IsNullable = true)]
//        public string IssueOfficerPost { get; set; }

//        /// <summary>
//        /// 一般备注
//        /// </summary>
//        [Display(Name = "一般备注")]
//        [SugarColumn(ColumnDescription = "一般备注", IsNullable = true)]
//        public string GeneralRemarks { get; set; }

//        /// <summary>
//        /// 紧急程度（U--紧急,E--特急,N--正常）
//        /// </summary>
//        [Display(Name = "紧急程度")]
//        [SugarColumn(ColumnDescription = "紧急程度（U--紧急,E--特急,N--正常）", IsNullable = true)]
//        public string Urgency { get; set; }

//        /// <summary>
//        /// 是否高危（Y/N）
//        /// </summary>
//        [Display(Name = "是否高危")]
//        [SugarColumn(ColumnDescription = "是否高危（Y/N）", IsNullable = true)]
//        public bool? HighRisk { get; set; }

//        /// <summary>
//        /// 是否取消RRF
//        /// </summary>
//        [Display(Name = "是否取消RRF")]
//        [SugarColumn(ColumnDescription = "是否取消RRF", IsNullable = true)]
//        public bool? CancelledRRF { get; set; }

//        /// <summary>
//        /// FEHD类型（NT/T/M）
//        /// </summary>
//        [Display(Name = "FEHD类型")]
//        [SugarColumn(ColumnDescription = "FEHD类型（NT/T/M）", IsNullable = true)]
//        public string FEHDType { get; set; }

//        /// <summary>
//        /// 索赔类型
//        /// </summary>
//        [Display(Name = "索赔类型")]
//        [SugarColumn(ColumnDescription = "索赔类型", IsNullable = true)]
//        public string ClaimType { get; set; }

//        /// <summary>
//        /// 地区ID（旧：DID）
//        /// </summary>
//        [Display(Name = "地区ID")]
//        [SugarColumn(ColumnDescription = "地区ID（旧：DID）")]
//        [Required(ErrorMessage = "请输入{0}")]
//        public int DistrictID { get; set; }

//        /// <summary>
//        /// 是否测量
//        /// </summary>
//        [Display(Name = "是否测量")]
//        [SugarColumn(ColumnDescription = "是否测量", IsNullable = true)]
//        public bool? Measurement { get; set; }

//        /// <summary>
//        /// 是否夜单
//        /// </summary>
//        [Display(Name = "是否夜单")]
//        [SugarColumn(ColumnDescription = "是否夜单", IsNullable = true)]
//        public bool? IsNight { get; set; }

//        /// <summary>
//        /// 是否转日单
//        /// </summary>
//        [Display(Name = "是否转日单")]
//        [SugarColumn(ColumnDescription = "是否转日单", IsNullable = true)]
//        public bool? IsDay { get; set; }

//        /// <summary>
//        /// 是否跟进
//        /// </summary>
//        [Display(Name = "是否跟进")]
//        [SugarColumn(ColumnDescription = "是否跟进", IsNullable = true)]
//        public bool? FollowUp { get; set; }

//        /// <summary>
//        /// 是否高危工作
//        /// </summary>
//        [Display(Name = "是否高危工作")]
//        [SugarColumn(ColumnDescription = "是否高危工作", IsNullable = true)]
//        public bool? IsHRW { get; set; }

//        /// <summary>
//        /// 高危内容ID
//        /// </summary>
//        [Display(Name = "高危内容ID")]
//        [SugarColumn(ColumnDescription = "高危内容ID", IsNullable = true)]
//        public int? HRWContent { get; set; }

//        /// <summary>
//        /// 高危内容其他说明
//        /// </summary>
//        [Display(Name = "高危内容其他说明")]
//        [SugarColumn(ColumnDescription = "高危内容其他说明", IsNullable = true)]
//        public string HRWContentOthers { get; set; }

//        /// <summary>
//        /// 一般备注
//        /// </summary>
//        [Display(Name = "一般备注")]
//        [SugarColumn(ColumnDescription = "一般备注", IsNullable = true)]
//        public string GenRemarks { get; set; }

//        /// <summary>
//        /// Su备注
//        /// </summary>
//        [Display(Name = "Su备注")]
//        [SugarColumn(ColumnDescription = "Su备注", IsNullable = true)]
//        public string SuRemarks { get; set; }

//        /// <summary>
//        /// 分包商参考
//        /// </summary>
//        [Display(Name = "分包商参考")]
//        [SugarColumn(ColumnDescription = "分包商参考", IsNullable = true)]
//        public string SubConRef { get; set; }

//        /// <summary>
//        /// 分包商备注
//        /// </summary>
//        [Display(Name = "分包商备注")]
//        [SugarColumn(ColumnDescription = "分包商备注", IsNullable = true)]
//        public string SubConRemark { get; set; }

//        /// <summary>
//        /// RRF关联编号
//        /// </summary>
//        [Display(Name = "RRF关联编号")]
//        [SugarColumn(ColumnDescription = "RRF关联编号", IsNullable = true)]
//        public string RRFRelation { get; set; }

//        /// <summary>
//        /// MWO编号
//        /// </summary>
//        [Display(Name = "MWO编号")]
//        [SugarColumn(ColumnDescription = "MWO编号", IsNullable = true)]
//        public string MWO { get; set; }

//        /// <summary>
//        /// WO（BEP）编号
//        /// </summary>
//        [Display(Name = "WO（BEP）编号")]
//        [SugarColumn(ColumnDescription = "WO（BEP）编号", IsNullable = true)]
//        public string WOBEP { get; set; }

//        /// <summary>
//        /// 'M'订单编号
//        /// </summary>
//        [Display(Name = "'M'订单编号")]
//        [SugarColumn(ColumnDescription = "'M'订单编号", IsNullable = true)]
//        public string MOrderNo { get; set; }

//        /// <summary>
//        /// 开始日期
//        /// </summary>
//        [Display(Name = "开始日期")]
//        [SugarColumn(ColumnDescription = "开始日期", IsNullable = true)]
//        public DateTime? DateForCommencement { get; set; }

//        /// <summary>
//        /// 目标完成日期
//        /// </summary>
//        [Display(Name = "目标完成日期")]
//        [SugarColumn(ColumnDescription = "目标完成日期", IsNullable = true)]
//        public DateTime? TargetCompletionDate { get; set; }

//        /// <summary>
//        /// 报告完成日期（App）
//        /// </summary>
//        [Display(Name = "报告完成日期（App）")]
//        [SugarColumn(ColumnDescription = "报告完成日期（App）", IsNullable = true)]
//        public DateTime? ReportCompletionApp { get; set; }

//        /// <summary>
//        /// 电话报告日期
//        /// </summary>
//        [Display(Name = "电话报告日期")]
//        [SugarColumn(ColumnDescription = "电话报告日期", IsNullable = true)]
//        public DateTime? TelephoneReportingDate { get; set; }

//        /// <summary>
//        /// 临时取消日期
//        /// </summary>
//        [Display(Name = "临时取消日期")]
//        [SugarColumn(ColumnDescription = "临时取消日期", IsNullable = true)]
//        public DateTime? TemporayCancel { get; set; }

//        /// <summary>
//        /// 取消日期
//        /// </summary>
//        [Display(Name = "取消日期")]
//        [SugarColumn(ColumnDescription = "取消日期", IsNullable = true)]
//        public DateTime? CancelledOn { get; set; }

//        /// <summary>
//        /// 应用状态（0-5，参照手机定义）
//        /// </summary>
//        [Display(Name = "应用状态")]
//        [SugarColumn(ColumnDescription = "应用状态（0-5，参照手机定义）")]
//        [Required(ErrorMessage = "请输入{0}")]
//        public int? AppStatus { get; set; } = 0;

//        /// <summary>
//        /// RRF状态(DA)
//        /// </summary>
//        [Display(Name = "RRF状态(DA)")]
//        [SugarColumn(ColumnDescription = "RRF状态(DA)", IsNullable = true)]
//        public string DARRFStatus { get; set; }

//        /// <summary>
//        /// 导入状态（导入RRF后的状态，自动或手动导入时若DISTRICT/subcon无值则设为I，成功后设为空）
//        /// </summary>
//        [Display(Name = "导入状态")]
//        [SugarColumn(ColumnDescription = "导入状态", IsNullable = true)]
//        public string ImportStatus { get; set; } = "";

//        /// <summary>
//        /// 工人姓名
//        /// </summary>
//        [Display(Name = "工人姓名")]
//        [SugarColumn(ColumnDescription = "工人姓名", IsNullable = true)]
//        public string WorkerName { get; set; }

//        /// <summary>
//        /// 工人电话
//        /// </summary>
//        [Display(Name = "工人电话")]
//        [SugarColumn(ColumnDescription = "工人电话", IsNullable = true)]
//        public string WorkerTel { get; set; }

//        /// <summary>
//        /// 到达时间
//        /// </summary>
//        [Display(Name = "到达时间")]
//        [SugarColumn(ColumnDescription = "到达时间", IsNullable = true)]
//        public DateTime? ArrivalTime { get; set; }

//        /// <summary>
//        /// 离开时间
//        /// </summary>
//        [Display(Name = "离开时间")]
//        [SugarColumn(ColumnDescription = "离开时间", IsNullable = true)]
//        public DateTime? LeavingTime { get; set; }

//        /// <summary>
//        /// 延迟原因
//        /// </summary>
//        [Display(Name = "延迟原因")]
//        [SugarColumn(ColumnDescription = "延迟原因", IsNullable = true)]
//        public string DelayReason { get; set; }

//        /// <summary>
//        /// 批次号
//        /// </summary>
//        [Display(Name = "批次号")]
//        [SugarColumn(ColumnDescription = "批次号", IsNullable = true)]
//        public string BatchNo { get; set; }

//        /// <summary>
//        /// 批次日期
//        /// </summary>
//        [Display(Name = "批次日期")]
//        [SugarColumn(ColumnDescription = "批次日期", IsNullable = true)]
//        public DateTime? BatchDate { get; set; }
//    }
//}