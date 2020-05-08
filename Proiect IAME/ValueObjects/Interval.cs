using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Proiect_IAME.ValueObjects
{
    public enum Interval
    {
        [Display(Name = "9:00 - 10:00")]
        [Description("9:00 - 10:00")]
        noua = 1,
        [Description("10:00 - 11:00")]
        [Display(Name = "10:00 - 11:00")]
        zece = 2,
        [Description("11:00 - 12:00")]
        [Display(Name = "11:00 - 12:00")]
        unsprezece = 3,
        [Description("12:00 - 13:00")]
        [Display(Name = "12:00 - 13:00")]
        doisprezece = 4,
        [Description("13:00 - 14:00")]
        [Display(Name = "13:00 - 14:00")]
        treisprezece = 5,
        [Description("14:00 - 15:00")]
        [Display(Name = "14:00 - 15:00")]
        paisprezece = 6,
        [Description("15:00 - 16:00")]
        [Display(Name = "15:00 - 16:00")]
        cinciprezece = 7,
        [Description("16:00 - 17:00")]
        [Display(Name = "16:00 - 17:00")]
        saisprezece = 8,
        [Description("17:00 - 18:00")]
        [Display(Name = "17:00 - 18:00")]
        saptesprezece = 9

    }

    public static class EnumExtensionMethods
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }

    }

    public static class GetDisplay
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }

}