using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sb_admin_2.Web.Models.Employee
{
    public class Edit
    {
        [Required]
        [DisplayName("流水Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("員工編號")]
        public string No { get; set; }

        [Required]
        [DisplayName("中文姓名")]
        public string ChtName { get; set; }

        [Required]
        [DisplayName("英文姓名")]
        public string EngName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}