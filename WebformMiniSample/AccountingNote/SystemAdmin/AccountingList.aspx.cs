using AccountingNote.Auth;
using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class AccountingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //驗證登入
           if(!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }


            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null) //若帳號不存在,移動至登入頁
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }


            //讀取帳號資料
            var dt = AccountingManager.GetAccountingList(currentUser.ID);

            if (dt.Rows.Count > 0)
            {
                var dtPaged = this.GetPagedDataTable(dt);

                this.ucPager2.TotalSize = dt.Rows.Count;
                this.ucPager2.Bind();

                this.gvAccountingList.DataSource = dtPaged;
                this.gvAccountingList.DataBind();

                this.ucPager.TotalSize = dt.Rows.Count;
                this.ucPager.Bind();
            }

            else
            {
                this.gvAccountingList.Visible = false;
                this.plcNoData.Visible = true;
            }
        }

        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;

            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;
            
            return intPage;
        }

        private DataTable GetPagedDataTable(DataTable dt)//整段複製現有資料做回傳
        {
            DataTable dtPaged = dt.Clone(); //複製DataTable  
            int pageSize = this.ucPager2.PageSize; 

            int startIndex = (this.GetCurrentPage()-1) *pageSize;
            int endIndex = (this.GetCurrentPage()) * pageSize;
            if (endIndex > dt.Rows.Count)  //總筆數需做檢查
                endIndex = dt.Rows.Count;

            for(var i= startIndex; i < endIndex; i++)  //資料列
            {
                DataRow dr = dt.Rows[i];
                var drNew = dtPaged.NewRow();  //建立相同資料

                foreach(DataColumn dc in dt.Columns)  //欄位
                {
                    drNew[dc.ColumnName] = dr[dc];  //欄位名稱 = [值]
                }

                dtPaged.Rows.Add(drNew);
            }
            return dtPaged;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/AccountingDetail.aspx");
        }

        protected void gvAccountingList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;

            if(row.RowType==DataControlRowType.DataRow)
            {
                //Literal ltl = row.FindControl("ltActType") as Literal;
                Label lbl = row.FindControl("lblActType") as Label;


                var dr = row.DataItem as DataRowView;
                int actType = dr.Row.Field<int>("ActType");

                if (actType == 0)
                {
                    //ltl.Text = "支出";
                    lbl.Text = "支出";
                }
                else
                {
                    //ltl.Text = "收入";
                    lbl.Text = "收入";
                }
                if(dr.Row.Field<int>("Amount") > 10000)
                {
                    lbl.ForeColor = Color.Red;
                }
            }
        }
    }
}