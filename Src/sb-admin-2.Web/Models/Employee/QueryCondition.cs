using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace sb_admin_2.Web.Models.Employee
{
    public class QueryCondition
    {
        public int Draw { get; set; }

        public int StartRecordCount { get; set; }

        public int PageSize { get; set; }

        [DisplayName("員工編號")]
        public string EmployeeNo { get; set; }

        [DisplayName("員工姓名")]
        public string EmplyeeName { get; set; }
    }
}