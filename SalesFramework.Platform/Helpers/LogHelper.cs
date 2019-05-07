using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalesFramework.Platform.Helpers
{
    /// <summary>
    /// Static elper class to assist with information logging.
    /// </summary>
    public class LogHelper
    {
        #region Constants
        /// <summary>
        /// Path to the text log file used by this class.
        /// </summary>
        public static readonly string CaminhoLog = @"to be implemented...";
        #endregion Constants

        #region Register to Log file.
        /// <summary>
        /// Registers strings of information to a text file. 
        /// The file location is configured in the web.config file. 
        /// </summary>
        /// <param name="information">
        /// An array of string informations.
        /// </param>
        public static void Register(params string[] information)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n");
            sb.Append(DateTime.Now.ToString());
            sb.Append(" ==> ");

            foreach (string info in information)
            {
                sb.Append(info.GetType());
                sb.Append(info);
                sb.Append("\r\n");
            }

            File.AppendAllText(CaminhoLog, sb.ToString());
        }

        /// <summary>
        /// Registers strings of information to a text file. Also registers information from an Exception.
        /// The file location is configured in the web.config file. 
        /// </summary>
        /// <param name="exception">
        /// An exception with information about the error.
        /// </param>
        /// <param name="information">
        /// An array of string informations.
        /// </param>
        public static void Register(Exception exception, params string[] information)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n");
            sb.Append(DateTime.Now.ToString());
            sb.Append(" ==> ");

            foreach (string info in information)
            {
                sb.Append(info.GetType());
                sb.Append(info);
                sb.Append("\r\n");
            }

            sb.Append(string.Format("Message: {0}", exception.Message));
            sb.Append("\r\n");
            sb.Append(string.Format("StackTrace: {0}", exception.StackTrace));
            sb.Append("\r\n");
            sb.Append(string.Format("Source: {0}", exception.Source));
            sb.Append("\r\n");
            sb.Append(string.Format("HelpLink: {0}", exception.HelpLink));
            sb.Append("\r\n");

            File.AppendAllText(CaminhoLog, sb.ToString());
        }
        #endregion Register to Log file.
    }
}
