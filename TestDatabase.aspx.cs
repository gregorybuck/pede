using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatriciaEdgarAndDonEdgar
{
    public partial class TestDatabase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnTestDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                PatriciaEdgarAndDonEdgar.Common.Datahandler.logVisit("testDatabase", Request.ServerVariables["REMOTE_ADDR"].ToString(), null, null, null, null, null);
                message.Text = "database access OK";
            }
            catch (Exception ex)
            {
                message.Text = ex.Message;
            }
        }
    }
}