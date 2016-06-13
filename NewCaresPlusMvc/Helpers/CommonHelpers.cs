using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace NewCaresPlusMvc.Helpers
{
    public static class CommonHelpers
    {
        public class UsState
        {
            public UsState()
            {
                Abbreviation = null;
                Name = null;
            }

            public UsState(string ab, string name)
            {
                Abbreviation = ab;
                Name = name;
            }

            public string Abbreviation { get; set; }

            public string Name { get; set; }

            public override string ToString()
            {
                return string.Format("{0} - {1}", Abbreviation, Name);
            }

        }

        public static string RenderPartialToString(Controller controller, string viewName, object model)
        {
            controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        public static string StripPunctuation(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            str = str.Replace(" ", "");
            str = str.Replace("-", "");
            str = str.Replace("(", "");
            str = str.Replace(")", "");
            str = str.Replace(".", "");
            str = str.Replace("/", "");
            return str;
        }

        public static string FormatPhoneNumber(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            var x = Left(str, 3);
            var y = Mid(str, 3, 3);
            var z = Right(str, 4);
            str = "(" + x + ")" + " " + y + "-" + z;
            return str;
        }

        public static string FormatCds(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            var x = Left(str, 2);
            var y = Mid(str, 2, 5);
            var z = Right(str, 7);
            str = x + " " + y + " " + z;
            return str;
        }

        public static string Left(this string str, int length)
        {
            return str.Substring(0, Math.Min(length, str.Length));
        }

        public static string Right(this string str, int length)
        {
            return str.Substring(str.Length - length);
        }

        public static string Mid(this string str, int start, int length)
        {
            return str.Substring(start, length);
        }

        public static string ToFirstCap(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            var array = str.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (var i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

        public static string PadToWidth(this string number, int totalWidth)
        {
            return number.PadLeft(totalWidth, '0');
        }

        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> items,
                Func<T, string> text, Func<T, string> value = null, Func<T, Boolean> selected = null)
        {
            return items.Select(p => new SelectListItem
            {
                Text = text.Invoke(p),
                Value = (value == null ? text.Invoke(p) : value.Invoke(p)),
                Selected = selected != null && selected.Invoke(p)
            });
        }

        public static List<KeyValuePair<int, string>> EnumToList(Type enumType)
        {
            var enumList = enumType
                .GetFields()
                .Where(p => p.IsLiteral && !p.Name.StartsWith("__")) //Double underscore start means not show on UI
                .ToDictionary(k => (int)Enum.Parse(enumType, k.Name), v => v.Name.Replace("_", " "))
                .ToList();

            return enumList;
        }

        public static string GetEnumName(Type enumType, object value, bool replace = true)
        {
            var name = Enum.GetName(enumType, value);

            if (replace && name != null)
                name = name.Replace("_", " ");

            return name;
        }

        public static List<UsState> GetUsStates()
        {
            var states = new List<UsState>(50)
            {
                new UsState("AL", "Alabama"),
                new UsState("AK", "Alaska"),
                new UsState("AZ", "Arizona"),
                new UsState("AR", "Arkansas"),
                new UsState("CA", "California"),
                new UsState("CO", "Colorado"),
                new UsState("CT", "Connecticut"),
                new UsState("DE", "Delaware"),
                new UsState("DC", "District Of Columbia"),
                new UsState("FL", "Florida"),
                new UsState("GA", "Georgia"),
                new UsState("HI", "Hawaii"),
                new UsState("ID", "Idaho"),
                new UsState("IL", "Illinois"),
                new UsState("IN", "Indiana"),
                new UsState("IA", "Iowa"),
                new UsState("KS", "Kansas"),
                new UsState("KY", "Kentucky"),
                new UsState("LA", "Louisiana"),
                new UsState("ME", "Maine"),
                new UsState("MD", "Maryland"),
                new UsState("MA", "Massachusetts"),
                new UsState("MI", "Michigan"),
                new UsState("MN", "Minnesota"),
                new UsState("MS", "Mississippi"),
                new UsState("MO", "Missouri"),
                new UsState("MT", "Montana"),
                new UsState("NE", "Nebraska"),
                new UsState("NV", "Nevada"),
                new UsState("NH", "New Hampshire"),
                new UsState("NJ", "New Jersey"),
                new UsState("NM", "New Mexico"),
                new UsState("NY", "New York"),
                new UsState("NC", "North Carolina"),
                new UsState("ND", "North Dakota"),
                new UsState("OH", "Ohio"),
                new UsState("OK", "Oklahoma"),
                new UsState("OR", "Oregon"),
                new UsState("PA", "Pennsylvania"),
                new UsState("RI", "Rhode Island"),
                new UsState("SC", "South Carolina"),
                new UsState("SD", "South Dakota"),
                new UsState("TN", "Tennessee"),
                new UsState("TX", "Texas"),
                new UsState("UT", "Utah"),
                new UsState("VT", "Vermont"),
                new UsState("VA", "Virginia"),
                new UsState("WA", "Washington"),
                new UsState("WV", "West Virginia"),
                new UsState("WI", "Wisconsin"),
                new UsState("WY", "Wyoming")
            };
            return states;
        }
    }
}