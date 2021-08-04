﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote.DBSource
{
    public class AccountingManager
    {
        /// <summary>
        /// 查詢流水帳清單
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataTable GetAccountingList(string userID)
        {
            string connStr =DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                    ID,
                    Caption,
                    Amount,
                    ActType,
                    CreateDate
                    FROM Accounting
                    WHERE UserID = @userID
                ";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@userID", userID);

                    try
                    {
                        conn.Open();
                        var reader = comm.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        return dt;
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex);
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 查詢流水帳
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataRow GetAccounting(int id,string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                    ID,
                    Caption,
                    Amount,
                    ActType,
                    CreateDate,
                    Body
                    FROM Accounting
                    WHERE id = @id AND UserID = @userID
                ";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@id", id);
                    comm.Parameters.AddWithValue("@userID", userID);

                    try
                    {
                        conn.Open();
                        var reader = comm.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        if (dt.Rows.Count == 0)
                            return null;
                        return dt.Rows[0];
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex);
                        return null;
                    }
                }
            }
        }
    

        /// <summary>
        /// 建立流水帳
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        public static void CreateAccounting(string userID, string caption, int amount
            ,int actType ,string body)
        {
            //檢查輸入值
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("金額必須介於0~一百萬之間");
            if (actType < 0 || actType > 1)
                throw new ArgumentException("必須為0或1");

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@"INSERT INTO [dbo].[Accounting]
                (    UserID
                    ,Caption
                    ,Amount
                    ,ActType
                    ,CreateDate
                    ,Body
                )
                VALUES
                (
                    @userID
                    ,@caption
                    ,@amount
                    ,@actType
                    ,@createDate
                    ,@body
                )
                ";

            //連線DB與執行
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@userID", userID);
                    comm.Parameters.AddWithValue("@caption", caption);
                    comm.Parameters.AddWithValue("@amount", amount);
                    comm.Parameters.AddWithValue("@actType", actType);
                    comm.Parameters.AddWithValue("@createDate", DateTime.Now);
                    comm.Parameters.AddWithValue("@body", body);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex);
                    }
                }
            }
        }

        /// <summary>
        /// 更新流水帳
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool UpdateAccounting(int ID, string userID, string caption, 
            int amount, int actType, string body)
        {
            //檢查輸入值
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("金額必須介於0~一百萬之間");
            if (actType < 0 || actType > 1)
                throw new ArgumentException("必須為0或1");

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@"UPDATE [Accounting]
                   SET 
                    UserID       = @userID
                    ,Caption     = @caption
                    ,Amount      = @amount
                    ,ActType     = @actType
                    ,CreateDate  = @createDate
                    ,Body        = @body
                   WHERE 
                    ID = @id ";
                

            //連線DB與執行
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@userID", userID);
                    comm.Parameters.AddWithValue("@caption", caption);
                    comm.Parameters.AddWithValue("@amount", amount);
                    comm.Parameters.AddWithValue("@actType", actType);
                    comm.Parameters.AddWithValue("@createDate", DateTime.Now);
                    comm.Parameters.AddWithValue("@body", body);
                    comm.Parameters.AddWithValue("@id", ID);

                    try
                    {
                        conn.Open();
                        int effectRows = comm.ExecuteNonQuery();

                        if (effectRows == 1)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 刪除流水帳資料
        /// </summary>
        /// <param name="ID"></param>
        public static void DeleteAccounting(int ID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@"DELETE [Accounting]
                   WHERE ID = @id ";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@id", ID);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex);
                    }
                }
            }
        }
    }
}
