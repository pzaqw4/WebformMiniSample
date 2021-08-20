using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AccountingNote.Models;

namespace AccountingNote.Handlers
{
    /// <summary>
    /// AccountingNoteHandler 的摘要描述
    /// </summary>
    public class AccountingNoteHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string actionName = context.Request.QueryString["ActionName"];

            if (string.IsNullOrEmpty(actionName))
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "text/plain";
                context.Response.Write("ActionName is required.");
                context.Response.End();
            }
            if(actionName == "create")
            {
                //取得使用者的輸入值
                string caption = context.Request.Form["Caption"];
                string amountText = context.Request.Form["Amount"];
                string actTypeText = context.Request.Form["ActType"];
                string body = context.Request.Form["Body"];

                //ID of admin
                string id = "13B5B8AB-3CEF-4006-9E18-7D31818ABA7B";

                //檢查欄位是否輸入
                if (string.IsNullOrWhiteSpace(caption) || string.IsNullOrWhiteSpace(amountText) || string.IsNullOrWhiteSpace(actTypeText))
                {
                    this.ProcessError(context, "標題,金額,與行為為必填.");
                    return;
                }

                //將整數欄位做轉型
                int tempAmount, tempActType;
                if (!int.TryParse(amountText, out tempAmount) || !int.TryParse(actTypeText, out tempActType))
                {
                    this.ProcessError(context, "標題,金額為整數.");
                    return;
                }

                try 
                { 
                //呼叫方法,建立流水帳
                AccountingManager.CreateAccounting(id, caption, tempAmount, tempActType, body);
                context.Response.ContentType = "text/plain";
                context.Response.Write("OK!!");
                }
                catch(Exception ex)
                {
                    context.Response.StatusCode = 503;
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Error!");
                }
            }
            else if (actionName == "update")
            {

            }
            else if(actionName == "delete")
            {

            }
            else if(actionName=="list")
            {
                string userID = "13B5B8AB-3CEF-4006-9E18-7D31818ABA7B";
                
                DataTable dataTable = AccountingManager.GetAccountingList(userID);

                List<AccountingNoteViewModel> list = new List<AccountingNoteViewModel>();
                foreach (DataRow drAccounting in dataTable.Rows)
                {
                    AccountingNoteViewModel model = new AccountingNoteViewModel()
                    {
                        ID = drAccounting["ID"].ToString(),
                        Caption = drAccounting["Caption"].ToString(),
                        Amount = drAccounting.Field<int>("Amount"),
                        ActType = (drAccounting.Field<int>("ActType") == 0) ? "支出" : "收入",
                        CreateDate = drAccounting.Field<DateTime>("CreateDate").ToString("yyyy-MM-dd")
                    };

                    list.Add(model);
                }
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(dataTable);

                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);
            }
            else if(actionName == "query")
            {
                string idText = context.Request.Form["ID"];
                int id;
                int.TryParse(idText, out id);
                string userID = "13B5B8AB-3CEF-4006-9E18-7D31818ABA7B";

                var drAccounting = AccountingManager.GetAccounting(id,userID);

                if(drAccounting == null)
                {
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("No data:"+idText);
                    context.Response.End();
                    return;
                }

                AccountingNoteViewModel model = new AccountingNoteViewModel()
                {
                    ID = drAccounting["ID"].ToString(),
                    Caption = drAccounting["Caption"].ToString(),
                    Body = drAccounting["Body"].ToString(),
                    CreateDate = drAccounting.Field<DateTime>("CreateDate").ToString("yyyy-MM-dd"),
                    ActType = drAccounting.Field<int>("ActType").ToString(),
                    Amount = drAccounting.Field<int>("Amount"),
                };

                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);
            }

        }
        private void ProcessError(HttpContext context, string msg)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "text/plain";
            context.Response.Write(msg);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}