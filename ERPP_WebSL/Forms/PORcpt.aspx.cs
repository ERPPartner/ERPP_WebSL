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

namespace ERPP_WebSL.Form
{
    public partial class PORcpt : System.Web.UI.Page
    {
        CaLLIDO IDO = new CaLLIDO();
        ERPPMenu menu = new ERPPMenu();
        Config cc = new Config();
        Guid gid;
        string session, site, whse, item_tag, vendnum, lot_track, ser_track;

        protected void Page_Load(object sender, EventArgs e)
        {
            cbTranDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            whse = "MAIN";
            session = menu.guID;
            site = menu.site;
            if (site == null)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('You are not licensed.')</script>");
            }
            //SetPage();
            //setPanel(1);
            //setLoc();
            GRN_Combobox();
            //txtPO.Focus();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "setFocus", "var focusFieldId = '" + tbPO.ClientID + "';", true);
            //dtTrans.Value = DateTime.Now;
            //Cursor.Current = Cursors.Default;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }

        protected void tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "setFocus", "var focusFieldId = '" + tbPO.ClientID + "';", true);
                //Cursor.Current = Cursors.WaitCursor;
                //DataTable po = IDO.GetList("SLPos", "PoNum,Stat,VendNum,VendorName,Whse",
                //string.Format("PoNum='{0}'", txtPO.Text.ToString()), "", 1);
                //Cursor.Current = Cursors.Default;
                //if (po.Rows.Count == 0)
                //{
                //    MessageBox.Show(string.Format("Po Number [{0}] not found.", txtPO.Text.ToString()));
                //    ClearPO();
                //    return;
                //}
                //if (po.Rows[0]["Stat"].ToString() != "O")
                //{
                //    MessageBox.Show("Status is not Ordered.");
                //    ClearPO();
                //    return;
                //}
                //vendnum = po.Rows[0]["VendNum"].ToString();
                //whse = po.Rows[0]["Whse"].ToString();
                //txtWhse.Text = po.Rows[0]["Whse"].ToString();
                //txtVen.Text = po.Rows[0]["VendorName"].ToString();
               // txtGRN.Focus();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("Error,Pls try again.\n\n{0}", ex.Message.ToString()));
                string MGS = string.Format("<script LANGUAGE='JavaScript' >alert('{0}')</script>" + ex.Message.ToString());
                Response.Write(MGS);
               // ClearPO();
                return;
            }
        }


        void GRN_Combobox()
        {
            try
            {
               // cbbGRN.DropDownStyle = ComboBoxStyle.DropDownList;
                int i = 0;
                //Cursor.Current = Cursors.WaitCursor;
                DataTable grn = IDO.GetList("UserDefinedTypeValues", "Value",
                string.Format("TypeName='ERPP_GRNPrefix'"), "Value", 0);
              //  Cursor.Current = Cursors.Default;
                if (grn.Rows.Count == 0)
                {
                    //MessageBox.Show("GRN Prefix not Added.");
                    Response.Write("<script LANGUAGE='JavaScript' >alert('GRN Prefix not Added.l')</script>");
                    return;
                }
                while (i < grn.Rows.Count)
                {
                    cbbGRN.Items.Add(grn.Rows[i]["Value"].ToString());
                    i++;
                }
            }
            catch (Exception ex)
            {
                string MGS = string.Format("Error,Pls Check GRN and Restart Programs.\n\n"+ex.Message.ToString());
                Response.Write("<script LANGUAGE='JavaScript' >alert('"+MGS+"')</script>");
                //MessageBox.Show(string.Format("Error,Pls Check GRN and Restart Programs.\n\n{0}", ex.Message.ToString()));
              //  ClearGRN();
                return;
            }
        }



    }
}
