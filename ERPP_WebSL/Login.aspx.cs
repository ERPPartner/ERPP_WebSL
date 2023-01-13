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
    public partial class Login : System.Web.UI.Page
    {
        public Login()
        {
            //InitializeComponent();
        }
        //Config cc = new Config();
        

        public static IDO.IDOWebService webService = new IDO.IDOWebService();
        public static string users,pass,site1;
        
        private void ClearError()
        {
            label_Error.Text = "";
            label_Error.Visible = false;
        }
        private void ShowError(String ErrorStr)
        {
            label_Error.Text = ErrorStr;
            label_Error.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)

        {
            ClearError();
            string[] GetConfigname;
            try
            {
                label_ver.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                //cc.checkFileServerIP();
                //if (cc.server_name == null)
                //{
                //    label_Error.Text="Please set IP Address.";
                //    label_Error.Visible = true;
                //   // Application.Exit();
                //    return;
                //}
                webService.Url = string.Format("http://{0}/IDORequestService/IDOWebService.asmx",ShareData.Server);

                if (cbConfig.Items.Count == 0)
                {
                    try
                    {
                        GetConfigname = webService.GetConfigurationNames();
                        foreach (string item in GetConfigname)
                        {
                            cbConfig.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex.Message.ToString());
                        
                        //MessageBox.Show(string.Format("Please set IP Address.\n\n{0}", ex.Message.ToString()));
                        //Application.Exit();
                        return;
                    }
                }
            }
            catch (Exception ee)
            {
                ShowError(ee.Message.ToString());
       
                //MessageBox.Show(ee.Message.ToString());
                //Application.Exit();
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            CheckAuthorization();
        }

        private void CheckAuthorization()
        {
            ClearError();

            DataSet idoDataSet = new DataSet();
            DataTable DTable = new DataTable();
            try
            {
                users = txtUser.Text.ToString();
                pass = txtPass.Text.ToString();
                site1 = cbConfig.Text.ToString();
                ShareData.UserLogin = users;
                ShareData.Password = pass;
                ShareData.Site = site1;
                ShareData.SecID = webService.CreateSessionToken(users, pass, site1);
                ShareData.LoginDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                ShowError(string.Format("!Invalid UserName And Password OR Current User In use\n{0}", ex.Message.ToString()));
                //MessageBox.Show(string.Format("!Invalid UserName And Password OR Current User In use\n{0}", ex.Message.ToString()));
                txtPass.Text = "";
                txtPass.Focus();
                return;
            }
            ERPPMenu main = new ERPPMenu();
            main.guID = Guid.NewGuid().ToString();
            
            Response.Redirect("~/Menu.aspx");
           

        }


    }
}
