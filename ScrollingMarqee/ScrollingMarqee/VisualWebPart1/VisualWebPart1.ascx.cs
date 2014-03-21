using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.Office.Server;
using Microsoft.Office.Server.Administration;
using Microsoft.Office.Server.UserProfiles;
using MarqueText;



namespace ScrollingMarqee.VisualWebPart1

{
    
    [ToolboxItemAttribute(false)]
    public partial class VisualWebPart1 : WebPart
    {
        DataRow[] drArray = null;
        //SPSite siteCollection = new SPSite("http://my.kpl.gov/catalogs/users/simple.aspx");
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling using
        // the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public VisualWebPart1()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();          
        }

        private string strMarqueelibrary = "Library Name";
        [WebBrowsable(true),
        WebDisplayName("Library Name"),
        WebDescription("Library Name"),
        Personalizable(PersonalizationScope.Shared),
        Category("Settings"),
        DefaultValue("Library Name")]

        public string strMarqeeLibrary
        {
            get { return strMarqueelibrary; }
            set { strMarqueelibrary = value; }
        }

        private SPList getMarqeeLibrary()
        {
            SPContext oContext = SPContext.Current;
            SPSite oSite = oContext.Site;
            SPWeb oWeb = oSite.OpenWeb();
            SPList oList = null;
            oList = oWeb.Lists.TryGetList(strMarqeeLibrary);
            oWeb.Dispose();
            return oList;
        }

        private DataRow[] createDataTable(SPList olist)
        {
            DataTable dt = null;
          
            string strName = "";
            string strTitle = "";
            DateTime dtCreated;
            if (olist != null)
            {             
                {
                    dt = new DataTable();
                    dt.Columns.Add("Staff");
                    dt.Columns.Add("Reason");
                    dt.Columns.Add("Created");
                    foreach (SPListItem oItem in olist.Items)
                    {
                        //strName = oItem["Title"].ToString();                       
                        strName = oItem["Staff"].ToString();
                        strTitle = oItem["Reason"].ToString();
                        dtCreated = Convert.ToDateTime(oItem["Created"]);
                        //DateTime dateModified = (DateTime)oItem["Modified"];
                        dt.Rows.Add(strName, strTitle);
                        //dt.Rows.Add(strName, "../" + oItem.Url, dateModified.ToShortDateString());
                    }
                }

                    drArray = dt.Select(null, "Created");
                  
                   Array.Reverse(drArray);
                
            }
           var firstFive = drArray.Take(5).ToArray();
           
            return firstFive;
           // return drArray;
        }

        private void buildIndex(DataRow[] drArray, SPList lstWikiLibrary)
        {
            if (drArray != null)
            {
                #region Alphabetical Display

                string id = "";
                string name = "";
                //Int32 intID = 0;
                string reason = "";              
                    for (int i = 0; i < drArray.Length; i++)
                    {
                        id = drArray[i]["Staff"].ToString();
                        name = id.Split('#')[1];
                       
                        //litScrollingText.Text = name;
                        //id = (id.Substring(0, id.IndexOf(";")));
                        //intID =  Convert.ToInt32(id);
                        reason = drArray[i]["Reason"].ToString();
                        Get_User_Info(name, reason);
                        //litScrollingText.Text += reason;
                    }                   
            }
                 #endregion
            else
            {
                litScrollingText.Text += @"No sharepoint lists were found";
            }        
        }
        private void Get_User_Info(string userID, string title)
        {
          SPWeb web = new SPSite("http://my.kpl.gov/").OpenWeb();
          SPUser user = web.EnsureUser(userID);
            SPListItem item = web.SiteUserInfoList.Items.GetItemById(user.ID);
            string department = item["Department"].ToString();
            string url = item["Picture"].ToString();
            url = url.Substring(0, url.IndexOf(","));
            Page.ClientScript.RegisterStartupScript(this.GetType(), "test", "myfunction();", true);
            //litScrollingText.Text += ("<script language='javascript'> function myFunction(){ alert('tester');} </script>");
            litScrollingText.Text += "<li>" +"<span style='font-weight:bold'> "+ userID + "</br>" + department + "</span>"+ " <img src='" + url + "'/><p>" + title + "</p></li>";
        }           
        protected void Page_Load(object sender, EventArgs e)
        {
            SPList lstMarqeeLibrary = getMarqeeLibrary();
            DataRow[] dtMarqeeIndex = createDataTable(lstMarqeeLibrary);
            buildIndex(dtMarqeeIndex, lstMarqeeLibrary);
        }
    }
}
