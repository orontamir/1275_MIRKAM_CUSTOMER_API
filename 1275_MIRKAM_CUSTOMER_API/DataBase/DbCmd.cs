using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace _1275_MIRKAM_CUSTOMER_API.DataBase
{
    public abstract class DbCmd
    {
        /// <summary>
        /// the table name
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Init the members
        /// </summary>
        abstract protected void Init();

        /// <summary>
        /// Set the command
        /// </summary>
        /// <param name="command">Oracle query </param>
        /// <param name="values">Params input query</param>
        /// <returns>the command</returns>
        abstract public void SetCmd(string command, string[] values);

        /// <summary>
        /// Set the command
        /// </summary>
        /// <param name="command">Oracle query </param>
        /// <returns>the command</returns>
        abstract public void SetCmd(string command);

        /// <summary>
        /// Get query command
        /// </summary>
        /// <param name="command">Oracle query </param>
        /// <returns>the command</returns>
        abstract public string GetCmd();

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DbCmd));

        /// <summary>
        /// Constructor
        /// </summary>
        public DbCmd()
        {
            Init();
        }
        
        

        /// <summary>
        /// Get text value
        /// </summary>
        /// <param name="val">the value</param>
        /// <returns>return value</returns>
        protected string GetTextVal(string val)
        {
            val = $@"'{val}'";
            return val;
        }

        /// <summary>
        /// Get boolian value
        /// </summary>
        /// <param name="val">the value</param>
        /// <returns>return value</returns>
        protected int GetBoolVal(bool val)
        {
            if (val) return 1;
            return 0;
        }

        /// <summary>
        /// read string that must not be empty - if it is emty - set the valid data flag to be false
        /// </summary>
        /// <param name="curReader">the current reader</param>
        /// <param name="clmName">the coulumn name</param>
        /// <returns>the string</returns>
        public string ReadString(OracleDataReader curReader, string clmName)
        {
            string str = ReadNotValidString(curReader, clmName);
            return str;
        }


        /// <summary>
        /// read string that can be empty
        /// </summary>
        /// <param name="curReader">the current reader</param>
        /// <param name="clmName">the coulumn name</param>
        /// <returns>the string</returns>
        public string ReadNotValidString(OracleDataReader curReader, string clmName)
        {
            string val = null;
            try
            {
                if (curReader[clmName] != null)
                {
                    val = curReader[clmName].ToString();
                }
            }
            catch
            {
                string errMsg = "Error: Invalid colum name: " + clmName;
                throw new Exception(errMsg);

            }
            return val;
        }
        /// <summary>
        /// read int that must not be empty - if it is emty - set the valid data flag to be false
        /// </summary>
        /// <param name="curReader">the current reader</param>
        /// <param name="clmName">the coulumn name</param>
        /// <returns>the int</returns>
        public int ReadInt(OracleDataReader curReader, string clmName)
        {
            int val = 0;
            string str = ReadString(curReader, clmName);
            val = Convert.ToInt32(str);
            return val;
        }

        /// <summary>
        /// read date time that must not be empty - if it is emty - set the valid data flag to be false
        /// </summary>
        /// <param name="curReader">the current reader</param>
        /// <param name="clmName">the coulumn name</param>
        /// <returns>the int</returns>
        public DateTime ReadDateTime(OracleDataReader curReader, string clmName)
        {
            DateTime val = DateTime.Now;
            string str = ReadString(curReader, clmName);
            val = Convert.ToDateTime(str);
            return val;
        }

        /// <summary>
        /// read date  that must not be empty - if it is emty - set the valid data flag to be false
        /// </summary>
        /// <param name="curReader">the current reader</param>
        /// <param name="clmName">the coulumn name</param>
        /// <returns>date in string</returns>
        public string ReadDate(OracleDataReader curReader, string clmName)
        {
            DateTime val = DateTime.Now;
            string str = ReadString(curReader, clmName);
            val = Convert.ToDateTime(str);
            return val.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// read time  that must not be empty - if it is emty - set the valid data flag to be false
        /// </summary>
        /// <param name="curReader">the current reader</param>
        /// <param name="clmName">the coulumn name</param>
        /// <returns>date in string</returns>
        public string ReadTime(OracleDataReader curReader, string clmName)
        {
            DateTime val = DateTime.Now;
            string str = ReadString(curReader, clmName);
            val = Convert.ToDateTime(str);
            return val.ToString("HH-mm-ss");
        }

        /// <summary>
        /// read boolean
        /// </summary>
        /// <param name="curReader">the current reader</param>
        /// <param name="clmName">the coulumn name</param>
        /// <returns>the boolean</returns>
        public bool ReadBool(OracleDataReader curReader, string clmName)
        {
            return Convert.ToBoolean(ReadInt(curReader, clmName));
        }

    }
}