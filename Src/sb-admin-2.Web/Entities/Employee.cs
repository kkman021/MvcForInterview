// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sb_admin_2.Web.Entities
{

    // Employee
    [Table("Employee", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public class Employee
    {

        ///<summary>
        /// 員工唯一流水識別碼
        ///</summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Index(@"PK_Employee", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        ///<summary>
        /// 員工編號
        ///</summary>
        [Column(@"No", Order = 2, TypeName = "nvarchar")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "No")]
        public string No { get; set; } // No (length: 50)

        [Column(@"ChtName", Order = 3, TypeName = "nvarchar")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(30)]
        [StringLength(30)]
        [Display(Name = "Cht name")]
        public string ChtName { get; set; } // ChtName (length: 30)

        ///<summary>
        /// 英文姓名
        ///</summary>
        [Column(@"EngName", Order = 4, TypeName = "nvarchar")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(30)]
        [StringLength(30)]
        [Display(Name = "Eng name")]
        public string EngName { get; set; } // EngName (length: 30)

        ///<summary>
        /// 員工 Email
        ///</summary>
        [Column(@"Email", Order = 5, TypeName = "nvarchar")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(100)]
        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } // Email (length: 100)

        ///<summary>
        /// 建立時間
        ///</summary>
        [Column(@"CreateOnUtc", Order = 6, TypeName = "datetime")]
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Create on utc")]
        public System.DateTime CreateOnUtc { get; set; } // CreateOnUtc

        ///<summary>
        /// 建立操作人員
        ///</summary>
        [Column(@"CreateBy", Order = 7, TypeName = "int")]
        [Required]
        [Display(Name = "Create by")]
        public int CreateBy { get; set; } // CreateBy

        ///<summary>
        /// 更新時間
        ///</summary>
        [Column(@"ModifyOnUtc", Order = 8, TypeName = "datetime")]
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Modify on utc")]
        public System.DateTime ModifyOnUtc { get; set; } // ModifyOnUtc

        ///<summary>
        /// 更新操作人員
        ///</summary>
        [Column(@"ModifyBy", Order = 9, TypeName = "int")]
        [Required]
        [Display(Name = "Modify by")]
        public int ModifyBy { get; set; } // ModifyBy
    }

}
// </auto-generated>