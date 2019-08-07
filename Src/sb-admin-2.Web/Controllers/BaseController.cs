using System;
using System.Text;
using System.Web.Mvc;
using EIP.Core.Enum;
using EIP.Core.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace sb_admin_2.Web.Controllers
{
    public class BaseController : Controller
    {
        //For Demo，正確應該要接 User.Identity
        public int EmployeeId => 99;

        #region Notification

        /// <summary>
        ///     新增訊息提示
        /// </summary>
        /// <param name="type">訊息類別<see cref="NotifyType" /></param>
        /// <param name="message"></param>
        protected void AddNotify(NotifyType type, string message)
        {
            TempData["Msg.Type"] = type.ToString().ToLower();
            TempData["Msg.Title"] = type.GetDescription();
            TempData["Msg.Message"] = message;
        }

        /// <summary>
        ///     訊息提示：錯誤類型
        /// </summary>
        /// <param name="message">提示訊息</param>
        protected void NotifyError(string message)
        {
            AddNotify(NotifyType.Error, message);
        }

        /// <summary>
        ///     訊息提示：成功類型
        /// </summary>
        /// <param name="message">提示訊息</param>
        protected void NotifySuccess(string message)
        {
            AddNotify(NotifyType.Success, message);
        }

        #endregion

        #region JsonDotNetResult

        /// <summary>
        ///     覆寫 Json item 改成走 CamelCase
        /// </summary>
        /// <param name="data">資料</param>
        /// <param name="contentType">Response Content Type</param>
        /// <param name="contentEncoding">Response Content Encoding</param>
        /// <param name="behavior"><see cref="JsonRequestBehavior" />行為</param>
        /// <returns></returns>
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding,
            JsonRequestBehavior behavior)
        {
            return new JsonDotNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }

        /// <summary>
        ///     處理 Json 回傳物件
        /// </summary>
        private class JsonDotNetResult : JsonResult
        {
            private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            public override void ExecuteResult(ControllerContext context)
            {
                if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                    string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("GET request not allowed");
                }

                var response = context.HttpContext.Response;

                response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

                if (ContentEncoding != null)
                {
                    response.ContentEncoding = ContentEncoding;
                }

                if (Data == null)
                {
                    return;
                }

                response.Write(JsonConvert.SerializeObject(Data, Settings));
            }
        }

        #endregion
    }
}