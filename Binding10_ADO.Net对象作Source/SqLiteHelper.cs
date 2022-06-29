using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Binding10_ADO.Net对象作Source
{
	/// <summary>
	/// SQLite 操作管理数据库
	/// </summary>
	class SqLiteHelper
	{
		/// <summary>
		/// 数据库连接定义
		/// </summary>
		private SQLiteConnection dbConnection;

		/// <summary>
		/// SQL命令定义
		/// </summary>
		private SQLiteCommand dbCommand;

		/// <summary>
		/// 数据读取定义
		/// </summary>
		private SQLiteDataReader dataReader;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="connectionString">连接SQLite数据库字符串</param>
		public SqLiteHelper(string connectionString)
		{
			try
			{
				dbConnection = new SQLiteConnection(connectionString);
				dbConnection.Open();
			}
			catch (Exception e)
			{

				Log(e.ToString());
			}
		}

		/// <summary>
		/// 执行SQL命令
		/// </summary>
		/// <param name="queryString"></param>
		/// <returns>SQL命令字符串</returns>
		public SQLiteDataReader ExecuteQuery(string queryString)
		{
			try
			{
				dbCommand = dbConnection.CreateCommand();
				dbCommand.CommandText = queryString;
				dataReader = dbCommand.ExecuteReader();
			}
			catch (Exception e)
			{

				Log(e.Message);
			}

			return dataReader;
		}

		public void CloseConnection()
		{
			//销毁Command
			if (dbCommand !=null)
			{
				dbCommand.Cancel();
			}
			dbCommand = null;

			//销毁Reader
			if (dataReader !=null)
			{
				dataReader.Close();
			}
			dataReader = null;

			//销毁Connection
			if (dbConnection != null)
			{
				dbConnection.Close();
			}
			dbConnection = null;
		}

		public SQLiteDataReader ReadFullTable(string tableName)
		{
			string queryString = "SELECT * FROM " + tableName;
			return ExecuteQuery(queryString);
		}

		/// <summary>
		/// 本地日志
		/// </summary>
		/// <param name="s"></param>
		static void Log(string s)
		{
			Console.WriteLine("class SqliteHelper:::" + s);
		}
	}
}
