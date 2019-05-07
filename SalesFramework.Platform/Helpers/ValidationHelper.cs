using SalesFramework.Platform.Model.EnumeratedTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SalesFramework.Platform.Helpers
{
    /// <summary>
    /// Static Helper class for Validation tasks.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Validates if a string is a valid Document.
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <param name="documentType">The document type defined bu the enumerator.</param>
        /// <returns>True if the string is a valid document, or False.</returns>
        public static System.Boolean ValidateDocument(System.String str, DocumentType documentType)
        {
            switch (documentType)
            {
                case DocumentType.CPF:
                    System.Int32[] lowMultiplier = new System.Int32[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                    System.Int32[] highMultiplier = new System.Int32[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                    System.String temp = System.String.Empty, digit = System.String.Empty;
                    System.Int32 sum = 0, remainder = 0;

                    str = str.Trim().Replace(".", "").Replace("-", "");

                    if (str.Length != 11)
                        return false;

                    temp = str.Substring(0, 9);

                    for (int i = 0; i < 9; i++)
                        sum += System.Int32.Parse(temp[i].ToString()) * lowMultiplier[i];

                    remainder = sum % 11;

                    if (remainder < 2)
                        remainder = 0;
                    else
                        remainder = 11 - remainder;

                    digit = remainder.ToString();
                    temp = temp + digit;
                    sum = 0;

                    for (int i = 0; i < 10; i++)
                        sum += System.Int32.Parse(temp[i].ToString()) * highMultiplier[i];

                    remainder = sum % 11;

                    if (remainder < 2)
                        remainder = 0;
                    else
                        remainder = 11 - remainder;

                    digit = digit + remainder.ToString();

                    return str.EndsWith(digit);
                case DocumentType.RG:
                    throw new NotImplementedException();
                case DocumentType.CNPJ:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Validates if a string is a valid brazilian formatted address code.
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns>True if the string is a valid brazilian address code, or False.</returns>
        public static System.Boolean ValidateAddressCode(System.String str)
        {
            Regex rgx = new Regex(@"^\d{5}-\d{3}$");

            if (!rgx.IsMatch(str))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Validates if a string is valid western number characters only.
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns>True if the string is only numbers, or False.</returns>
        public static System.Boolean ValidateStringIsNumber(System.String str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static System.Boolean ValidateEmail(System.String str)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(str);
                return addr.Address == str;
            }
            catch
            {
                return false;
            }
        }

        public static System.Boolean ValidatePassword(string str)
        {
            throw new NotImplementedException();
        }

    }
}
