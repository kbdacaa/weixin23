using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeiXin
{
    public partial class index : System.Web.UI.Page
    {
        private readonly string Token = "fanjingchao";
        protected void Page_Load(object sender, EventArgs e)
        {
            Auth();
        }
        private void Auth()
        { 
            string signature=Request ["signature"];
            string timestamp=Request ["timestamp"];
            string nonce=Request ["nonce"];
            string echostr=Request ["echostr"];
            if(Request .HttpMethod =="GET")
            {
                if (CheckSignature.Check(signature, timestamp, nonce, Token))
                {
                    WriteContent(echostr);
                }
                else
                {
                    WriteContent("failed"+signature +","+CheckSignature .GetSignature (timestamp ,nonce ,Token )+"."+"如果在浏览器中看到这句话，说明地址可以被微信公众号后台的url，请保持Token一致");
                }
                Response.End();
            }
        }
        private void WriteContent(string str)
        {
            Response.Output.Write(str);
        }
    }
}