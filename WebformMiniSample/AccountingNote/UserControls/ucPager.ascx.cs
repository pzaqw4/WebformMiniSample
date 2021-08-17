﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.UserControls
{
    public partial class ucPager : System.Web.UI.UserControl
    {
        /// <summary> 頁面URL </summary>
        public string Url { get; set; }
        /// <summary>總筆數 </summary>
        public int TotalSize { get; set; }
        /// <summary>頁面筆數 </summary>
        public int PageSize { get; set; }
        /// <summary>目前頁數 </summary>
        public int CurrentPage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.Bind();
        }

        public void Bind()
        {
            int totalPages = this.GetTotalPages();
            this.ltPager.Text = $"共{this.TotalSize}筆," +
                $"共{totalPages}頁,目前在第{this.GetCurrentPage()}頁<br/>";


            for (var i = 1; i <= totalPages; i++)
            {
                this.ltPager.Text +=
                  $"<a href='{this.Url}?page={i}'>{i}</a>&nbsp";
            }
        }
        private int GetCurrentPage()
        {
            string pageText = this.Request.QueryString["page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;

            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;

            return intPage;
        }
        private int GetTotalPages()
        {
            int pagers = this.TotalSize / this.PageSize;

            if ((this.TotalSize % this.PageSize) > 0)
                pagers += 1;
            return pagers;
        }
    }
}