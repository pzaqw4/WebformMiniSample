using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AccountingNote.Auth
{
    /// <summary>
    /// 負責處理登入相關元件 (auth為登入驗證相關的名字)
    /// </summary>
    public class AuthManager
    {
        /// <summary>
        /// 檢察目前是否登入
        /// </summary>
        /// <returns></returns>
        public static bool IsLogined()
        {
            if (HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;            
            else
                return true;
        }
    }
}
