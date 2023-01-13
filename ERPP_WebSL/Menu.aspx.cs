using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ERPP_WebSL
{
    public partial class ERPPMenu : System.Web.UI.Page
    {
        CaLLIDO IDO = new CaLLIDO();
        private static String _g;
        private static String _site;
        public String guID { get { return _g; } set { _g = value; } }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SetCurWhse();
            ShareData.IsLoaded = 0;
            ShareData.Site = site;
        }
        
        void SetCurWhse()
        {
            try
            {
                //_UserLogin = ShareData.UserLogin;
                DataTable whse = IDO.GetList("SLUserNames", "UserLocalWhse", string.Format("Username='" + ShareData.UserLogin + "'"), "", 0);

                if (whse != null)
                {
                    ShareData.CurWhse = whse.Rows[0]["UserLocalWhse"].ToString();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("Error Please try again.\n\n{0}", ex.Message.ToString()));
                string MGS = string.Format("Error Please try again.\n\n" + ex.Message.ToString());
                Response.Write("<script LANGUAGE='JavaScript' >alert('" + MGS + "')</script>");
                return;
            }
        }

        public String site
        {
            get
            {
                //Cursor.Current = Cursors.WaitCursor;
                DataTable s = IDO.GetList("SLParms", "Site", "", "", 1);
                //Cursor.Current = Cursors.Default;
                if (s == null )
                {
                    
                    Response.Write("<script LANGUAGE='JavaScript' >alert('You are not licensed.')</script>");
                    return null;
                }
                _site = s.Rows[0]["Site"].ToString();
                return _site;
            }
            set
            {
                _site = value;
            }
        }
           
        protected void btnOrderShip_Click(object sender, EventArgs e)
        {
            if (site != null)
            {
                Response.Redirect("~/Forms/OrderShipping.aspx");
            }
        }

        protected void btnPORcpt_Click(object sender, EventArgs e)
        {
            if (site != null)
            { 
                Response.Redirect("~/Forms/PORcpt.aspx");
            }
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void btnQtyMove_Click(object sender, EventArgs e)
        {
            if (site != null)
            {
                Response.Redirect("~/Forms/QtyMove.aspx");
            }
        }



    }
}
