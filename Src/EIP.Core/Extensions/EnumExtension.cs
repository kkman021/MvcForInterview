using System.ComponentModel;
using System.Reflection;

namespace EIP.Core.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        ///     取得 Enum 的 Description Attribute 文字內容
        ///     若為 Null 返回 null
        ///     若為 空值、空白、沒有標 DescriptionAttribute 返回 Enum 本身的名稱
        /// </summary>
        /// <param name="value">Enum 資料</param>
        /// <returns>Enum 的 Description Attribute 文字內容 </returns>
        public static string GetDescription(this System.Enum value)
        {
            if (value == null)
            {
                return null;
            }

            var field = value.GetType().GetField(value.ToString());

            var attribute = field.GetCustomAttribute<DescriptionAttribute>(false);

            if (attribute != null && !string.IsNullOrWhiteSpace(attribute.Description))
            {
                return attribute.Description;
            }

            return value.ToString();
        }
    }
}