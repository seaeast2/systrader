using System.Windows;
using XA_SESSIONLib;
using XA_DATASETLib;

namespace systrader.Model
{
    public class XingAPIModel
    {
        private XASession XAS = new XASession();
        private XAQuery XAQ = new XAQuery();

        public void Login()
        {
            MessageBox.Show("Hello world!");
        }
    }
}
