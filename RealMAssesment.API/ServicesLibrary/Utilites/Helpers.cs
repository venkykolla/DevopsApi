using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modals;
using Newtonsoft.Json;


namespace ServicesLibrary.Utilites
{
    public static class Helpers
    {
        public static T Deserialize<T>(this string json)
        {
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
        
        public static DateTime GetDateTime(this string strDate)
        {
            CultureInfo culture = new CultureInfo("es-ZA");
            String myDate = string.IsNullOrEmpty(strDate) ? DateTime.MinValue.ToString() : FormateDate(strDate);
            DateTime date = DateTime.Parse(myDate, culture);
            return date;
        }

        private static string FormateDate(string str)
        {
            string year = "";
            string month = "";
            string date = "";
            string[] datestr = str.Split("-");
            if(datestr.Count() > 2)
            {
                year = datestr[0];
                month = datestr[1];
                date = datestr[2].Substring(0, 2);
            }
            return string.Format("{0}/{1}/{2}", date, month, year);
        }
    }
}
