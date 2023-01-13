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
    public partial class QtyMove : System.Web.UI.Page
    {
        CaLLIDO IDO = new CaLLIDO();
        ERPPMenu menu = new ERPPMenu();
        Config cc = new Config();
        Functions g_fn = new Functions();
        public string session, site;

        protected void Page_Load(object sender, EventArgs e)
        {
            session = menu.guID;
            site = ShareData.Site;

            if (ShareData.IsLoaded == 0)
            {
                cbTranDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
 
                //SetPage();
                //setPanel(1);
                setWhse();
                setLoc();
                //txtPO.Focus();
                tbTag.Focus();
                //dtTrans.Value = DateTime.Now;
                //Cursor.Current = Cursors.Default;

                cbbWhse.Text = ShareData.CurWhse;
                ShareData.IsLoaded = 1;
            }
        }

        void setWhse()
        {
            try
            {
                int i = 0;
                //txtLoc.Focus();
                //Cursor.Current = Cursors.WaitCursor;
                DataTable whse = IDO.GetList("SL.SLWhses", "Whse", "", "", 0); //string.Format("SiteRef='{0}'", site)
                //Cursor.Current = Cursors.Default;

                while (i < whse.Rows.Count)
                {
                    cbbWhse.Items.Add(whse.Rows[i]["Whse"].ToString());
                    i++;
                }
                cbbWhse.SelectedIndex = 0;
            }
            catch (Exception c)
            {
                //MessageBox.Show(string.Format("Error Please try again.\n\n{0}", c.Message.ToString()));
                string MGS = string.Format("Error Please try again.\n\n" + c.Message.ToString());
                Response.Write("<script LANGUAGE='JavaScript' >alert('" + MGS + "')</script>");
                return;
            }
        }

        void setLoc()
        {
            try
            {
                int i = 0;
              //  Cursor.Current = Cursors.WaitCursor;
                DataTable Loc = IDO.GetList("SLLocations", "Loc", string.Format("LocType='S'"), "", 0);
              //  Cursor.Current = Cursors.Default;

                while (i < Loc.Rows.Count)
                {
                    cbbFromLoc.Items.Add(Loc.Rows[i]["Loc"].ToString());
                    cbbToLoc.Items.Add(Loc.Rows[i]["Loc"].ToString());
                    i++;
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

        protected void btnMove_Click(object sender, EventArgs e)
        {
            try
            {
                string Trans_date = cbTranDate.Text.Substring(6,4) + "-" + cbTranDate.Text.Substring(3,2) + "-" + cbTranDate.Text.Substring(0,2) +
                                    " " + cbTranDate.Text.Substring(11,5);
                if (tbFromLoc.Text == "")
                    tbFromLoc.Text = cbbFromLoc.SelectedValue;
                if (tbToLoc.Text == "")
                    tbToLoc.Text = cbbToLoc.SelectedValue;
                //Cursor.Current = Cursors.WaitCursor;
                string parms = "";
                parms = "<Parameters>" +
                "<Parameter>" + site.ToString() + "</Parameter>" +	//	@Site
                "<Parameter>" + session.ToString() + "</Parameter>" +	//	@SessionID
                "<Parameter>" + Trans_date + "</Parameter>" +	//	@PDate
                "<Parameter>" + tbQty.Text.ToString() + "</Parameter>" +	//	@PQty
                "<Parameter>" + tbItem.Text.ToString() + "</Parameter>" +	//	@PItem
                "<Parameter>" + cbbWhse.SelectedValue.ToString() + "</Parameter>" +	//	@FromWhse
                "<Parameter>" + cbbWhse.SelectedValue.ToString() + "</Parameter>" +	//	@ToWhse
                "<Parameter>" + tbFromLoc.Text.ToString() + "</Parameter>" +	//	@FromLoc
                "<Parameter>" + tbToLoc.Text.ToString() + "</Parameter>" +	//	@ToLoc
                "<Parameter>" + tbLot.Text.ToString() + "</Parameter>" +	//	@FromLot
                "<Parameter>" + tbSerial.Text.ToString() + "</Parameter>" +	//	@ser_num
                "<Parameter>" + "0" + "</Parameter>" +	//	@PZeroCost
                "<Parameter>" + "" + "</Parameter>" +	//	@DocumentNum
                "<Parameter ByRef='Y'>" + "" + "</Parameter>" +        	 // @Infobar
                "</Parameters>";
                Object ReturnValue = Login.webService.CallMethod(ShareData.SecID, "ERPP_Web_QuantityMove", "ERPP_Web_DoMovePostSp", ref parms);
                //Cursor.Current = Cursors.Default;

                    //MessageBox.Show(string.Format("Add Location Error.\n\nCode : {0}\n{1}", ReturnValue.ToString(), parms));
                string ReturnStr = g_fn.ReturnStrOutputSp(parms.ToString(), 1);// Functions.ReturnStrOutputSp(parms.ToString(),1);

                if (ReturnValue.ToString() != "0")
                    ReturnStr = "<script LANGUAGE='JavaScript' >alert('Move Error.\\n\\nCode :" + ReturnValue.ToString() + "\\n" + ReturnStr.ToString() + "')</script>";
                else
                {
                    ClearTag();
                    ReturnStr = "<script LANGUAGE='JavaScript' >alert('Information.\\n\\nCode :" + "\\n" + ReturnStr.ToString() + "')</script>";
                }
                Response.Write(ReturnStr);
                return;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("Error Add Location,Pls try again.\n\n{0}", ex.Message.ToString()));
                string MGS = ex.Message.ToString();
                MGS = MGS.Replace("\n", "");
                MGS = "<script LANGUAGE='JavaScript' >alert('Move,Pls try again.\\n\\n" + MGS  + "')</script>";
                Response.Write(MGS);
                return;
            }
        }

        protected void tbTag_TextChanged(object sender, EventArgs e)
        {   
            try  
            {
                string item_tag;
                item_tag = tbTag.Text.ToString();
              
                //Cursor.Current = Cursors.WaitCursor;
                DataTable tagbar = IDO.GetList("SLItems", "Item,Description,SerialTracked,LotTracked,UM",
                string.Format("Item='{0}'", item_tag), "", 1);
               // Cursor.Current = Cursors.Default;
                if (tagbar.Rows.Count == 0)
                {
                    string MGS = "<script LANGUAGE='JavaScript' >alert('TagNo Item not found.!')</script>";
                    Response.Write(MGS); 
                    //MessageBox.Show("TagNo Item not found.!");
                    ClearTag();
                    return;
                }
                tbItem.Text = tagbar.Rows[0]["Item"].ToString();
                tbDesc.Text = tagbar.Rows[0]["Description"].ToString();
                tbUM.Text = tagbar.Rows[0]["UM"].ToString();
                //cbbToLoc.Focus();
                //txtLoc2.Focus();
                setLocRank(tbItem.Text.ToString(), cbbWhse.Text.ToString(), "from");
                setLocRank(tbItem.Text.ToString(), cbbWhse.Text.ToString(), "to");
                tbFromLoc.Focus();

                if (tagbar.Rows[0]["LotTracked"].ToString() == "1") tbLot.Enabled = true; else tbLot.Enabled = false;

                if (tagbar.Rows[0]["SerialTracked"].ToString() == "1")
                {
                    tbSerial.Enabled = true;
                    tbQty.Enabled = false;
                    tbQty.Text = "1";
                }
                else
                {
                    tbSerial.Enabled = false;
                    tbQty.Enabled = true;
                    tbQty.Text = "";
                }
 
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("Error,Please try again.\n\n{0}", ex.Message.ToString()));
                string MGS = "<script LANGUAGE='JavaScript' >alert('" + "Error,Please try again.\\n\\n" + ex.Message.ToString() + "')</script>";
                Response.Write(MGS);
                tbTag.Text = "";
                tbTag.Focus();
                return;
            }
            tbFromLoc.Focus();
            return;
        }

        protected void tbFromLoc_TextChanged(object sender, EventArgs e)
        {
            if (g_fn.checkloc(tbFromLoc.Text) == false)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Location Not Found.!')</script>");
                tbFromLoc.Text = "";
                tbFromLoc.Focus();
                return;
            }
            if (cbbFromLoc.Items.FindByText(tbFromLoc.Text) == null)
                cbbFromLoc.Items.Add(tbFromLoc.Text);

            cbbFromLoc.SelectedValue = cbbFromLoc.Items.FindByText(tbFromLoc.Text).Value;
            tbToLoc.Focus();
        }

        protected void tbToLoc_TextChanged(object sender, EventArgs e)
        {
            if (g_fn.checkloc(tbToLoc.Text) == false)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Location Not Found.!')</script>");
                tbToLoc.Text = "";
                tbToLoc.Focus();
                return;
            }
            if (cbbToLoc.Items.FindByText(tbToLoc.Text) == null)
                cbbToLoc.Items.Add(tbToLoc.Text);

            cbbToLoc.SelectedValue = cbbToLoc.Items.FindByText(tbToLoc.Text).Value;
            if (tbLot.Enabled == true)
                tbLot.Focus();
            else if (tbSerial.Enabled == true)
                tbSerial.Focus();
            else
                tbQty.Focus();
        }

        protected void cbbFromLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFromLoc.Text = cbbFromLoc.Text;
        }

        protected void cbbToLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbToLoc.Text = cbbToLoc.Text;
        }

        protected void tbLot_TextChanged(object sender, EventArgs e)
        {
            if (g_fn.checkLotloc(cbbWhse.Text, tbFromLoc.Text, tbItem.Text, tbLot.Text) == false)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Lot does not exists.!')</script>");
                tbLot.Text = "";
                tbLot.Focus();
                return;
            }
            else if (tbSerial.Enabled == true)
                tbSerial.Focus();
            else
                tbQty.Focus();

        }

        protected void tbSerial_TextChanged(object sender, EventArgs e)
        {
            tbQty.Text = "1";
            btnMove.Focus();
        }

        protected void tbQty_TextChanged(object sender, EventArgs e)
        {
            if (g_fn.isnumeric(tbQty.Text)==false)
            {
               Response.Write("<script LANGUAGE='JavaScript' >alert('Qty is not numeric.!')</script>");
                tbQty.Text = "";
                tbQty.Focus();
                return;
            }
            if (g_fn.checkQtyOnHand(cbbWhse.Text, tbFromLoc.Text, tbItem.Text, tbLot.Text,Convert.ToDecimal(tbQty.Text)) == false)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Qty more than QtyOnhand.!')</script>");
                tbQty.Text = "";
                tbQty.Focus();
                return;
            }
            else
                btnMove.Focus();
        
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearTag();
        }

        //SLItemLocs
        void setLocRank(string item, string whse, string fromto)
        {
            try
            {
                int i = 0;
                //Cursor.Current = Cursors.WaitCursor;
                DataTable locset = IDO.GetList("SLItemLocs", "Loc,NewRank",
                string.Format("Item='{0}' and Whse='{1}'", item, whse),
                "Whse,Item,NewRank,Loc", 0);
                //Cursor.Current = Cursors.Default;
                if (fromto == "from")
                {
                    cbbFromLoc.Items.Clear();
                    while (i < locset.Rows.Count)
                    {
                        cbbFromLoc.Items.Add(locset.Rows[i]["Loc"].ToString());
                        i++;
                    }
                    //cbbFromLoc.Text = locset.Rows[0]["Loc"].ToString();
                    //tbFromLoc.Text = locset.Rows[0]["Loc"].ToString();
                }
                else
                {
                    cbbToLoc.Items.Clear();
                    while (i < locset.Rows.Count)
                    {
                        cbbToLoc.Items.Add(locset.Rows[i]["Loc"].ToString());
                        i++;
                    }
                    //cbbToLoc.Text = locset.Rows[0]["Loc"].ToString();
                    //tbToLoc.Text = locset.Rows[0]["Loc"].ToString();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("Error Please try again.\n\n{0}", ex.Message.ToString()));
                string MGS = "<script LANGUAGE='JavaScript' >alert('" + "Error,Please try again.\\n\\n" + ex.Message.ToString() + "')</script>";
                Response.Write(MGS);
                return;
            }
        }

        void ClearTag()
        {
            //cbWhse.Text = "";
            tbTag.Text = "";
            tbItem.Text = "";
            tbDesc.Text = "";
            tbSerial.Text = "";
            //txtLoc2.Text = "";
            //cbToLoc.Text = "";
            tbLot.Text = "";
            tbQty.Text = "";
            tbUM.Text = "";
            tbTag.Focus();
            tbLot.Enabled = false;
            tbSerial.Enabled = false;
            //Cursor.Current = Cursors.Default;
        }
 
    }
}
