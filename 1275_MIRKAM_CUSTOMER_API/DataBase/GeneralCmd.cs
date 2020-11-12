using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1275_MIRKAM_CUSTOMER_API.DataBase
{
    public class GeneralCmd : DbCmd
    {
        /// <summary>
        /// Contains al key values
        /// </summary>
        protected string m_WhereKeyValue;
        /// <summary>
        /// Contains all update values
        /// </summary>
        private string m_UpdatedValue;
        /// <summary>
        /// string that contains all  commnads columns
        /// </summary>
        private string m_ColumnsStr;
        /// <summary>
        /// string that contains all insert commnads values
        /// </summary>
        private string m_InsertvaluesStr;

        private string m_command;

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(GeneralCmd));

        /// <summary>
        /// Init the members
        /// </summary>
        protected override void Init()
        {
            m_UpdatedValue = null;
            m_WhereKeyValue = null;
            m_ColumnsStr = null;
            m_InsertvaluesStr = null;
            m_command = null;
        }

        public string GetWhereKeyValue()
        {
            return m_WhereKeyValue;
        }

        public string GetSetValue()
        {
            return m_UpdatedValue;
        }

        public string GetInsertColumn()
        {
            return m_ColumnsStr;
        }

        public string GetInsertValue()
        {
            return m_InsertvaluesStr;
        }
        /// <summary>
        /// Add where key value 
        /// </summary>
        /// <param name="clmName">the column name</param>
        /// <param name="val">the value</param>
        public void AddWhereKeyVal<T>(string clmName, T val)
        {
            string curVal = "";
            if (typeof(T) == typeof(string))
            {
                curVal =  $"{clmName} = '{val}'";
            }
            else
            {
                curVal = $"{clmName} = {val}";
            }
            if (m_WhereKeyValue != null)
            {
                m_WhereKeyValue += " AND ";
            }
            m_WhereKeyValue += curVal;
        }

        /// <summary>
        /// Add  value 
        /// </summary>
        /// <param name="clmName">the coulm name</param>
        /// <param name="val">the value</param>
        public void AddUpdateValue<T>(string clmName, T val)
        {
            AddSetColumnName( clmName, val);
        }

        private void AddSetColumnName<T>( string clmName, T val)
        {
            string curVal = "";
            if (typeof(T) == typeof(string))
            {
                curVal = $"{clmName} = '{val}'";
            }
            else
            {
                curVal = $"{clmName} = {val}";
            }
            if (m_UpdatedValue != null)
            {
                m_UpdatedValue += " , ";
            }
            m_UpdatedValue += curVal;
        }

        /// <summary>
        /// Add insert value 
        /// </summary>
        /// <param name="clmName">the coulm name</param>
        /// <param name="val">the value</param>
        public void AddInsertValue<T>(string clmName, T value)
        {
            AddColumnNameAndValue(clmName, value);
        }

        /// <summary>
        /// Add column and vlaue for insert command
        /// </summary>
        /// <param name="clmName">the column name</param>
        /// <param name="val">the value</param>
        protected void AddColumnNameAndValue<T>(string columnName, T value)
        {
            if (m_ColumnsStr != null)
            {
                m_ColumnsStr += " , ";
                m_InsertvaluesStr += " , ";

            }
            m_ColumnsStr += columnName;
            if (typeof(T) == typeof(string))
            {
                m_InsertvaluesStr += $"'{value}'";
            }
            else
            {
                m_InsertvaluesStr += value;
            }
           
        }
        /// <summary>
        /// Get the command
        /// </summary>
        /// <returns>the command</returns>
        public override void SetCmd(string command, string[] values)
        {
            string cmd = null;
            try
            {
                cmd = string.Format(command, values);
            }
           catch (Exception ex)
            {

            }
            finally
            {
                Init();
            }
          
            m_command =  cmd;
        }

        public override void SetCmd(string command)
        {
            string cmd = null;
            try
            {
                cmd = command;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Init();
            }

            m_command = cmd;
        }

        public override string GetCmd()
        {
            log.Debug($"Query command: {m_command}");
            return m_command;
        }

       
    }
}