using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace sb_admin_2.Web.Models.Employee
{
    public class QueryCondition
    {
        /*
         * jQuery Datatable 相關參數，正式情境要用我覺得這是比較好的解決方案：https://stackoverflow.com/a/45536685/4044747
         * 基本上處理方式是自己寫一個 ModelBinder 的方式
         */

        /// <summary>
        /// jQuery Datatable 的屬性 用來判斷 Ajax 來源與回傳是否同源
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// jQuery Datatable 的屬性 傳來要從第幾筆資料開始
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// jQuery Datatable 的屬性 分頁大小
        /// </summary>
        public int Length { get; set; }

        [DisplayName("員工編號")]
        public string EmployeeNo { get; set; }

        [DisplayName("員工姓名")]
        public string EmplyeeName { get; set; }
    }
}