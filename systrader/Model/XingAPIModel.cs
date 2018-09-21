using System.Windows;
using XA_SESSIONLib;
using XA_DATASETLib;

namespace systrader.Model
{
    public class XingAPIModel
    {
        readonly XASession XAS = new XASession();
        readonly XAQuery XAQ = new XAQuery();

        public void Login()
        {
            MessageBox.Show("Hello world!");
        }
    }
}
