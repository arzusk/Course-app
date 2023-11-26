using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Helpers.Extensions
{
    public static class RegisterExcentions
    {
        public static bool IsValidEmailFormat(this string inputEmail)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (regex.IsMatch(inputEmail))
            {
                return true;
            }
            return false;
        }
        public static bool CheckNameorSurnameFormat(this string name)
        {
            Regex regex = new Regex(@"^[A-Z][a-zA-Z]*$");
            if (regex.IsMatch(name))
            {
                return true;
            }
            return false;
        }
        public static bool CheckFullName(this string fullname)
        {
            Regex regex = new Regex(@"^[A-Z]\w+( [A-Z]\w+)+");
            if (regex.IsMatch(fullname))
            {
                return true;
            }
            return false;
        }
        public static bool CheckPhoneNumber(this string phoneNumber)
        {
            Regex regex = new Regex(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$");
            if (regex.IsMatch(phoneNumber))
            {
                return false;
            }
            return true;
        }    
    }
}
