using System;
using System.Activities;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonRequest_Click(object sender, EventArgs e)
        {
            Tadbir.Image Image = new Tadbir.Image();

            Image.IP = new InArgument<string>("130.185.76.7");
            Image.Port = new InArgument<string>("9020");
            Image.dbName = new InArgument<string>("TEST");
            Image.Version = new InArgument<string>("V3.0");
            Image.Group = new InArgument<string>("Inventory");
            Image.Entity = new InArgument<string>("Image");
            Image.Function = new InArgument<string>("getImageByImageId");
            Image.MerchId = new InArgument<int>(5);
            Image.FPId = new InArgument<int>(1);
            Image.SysId = new InArgument<int>(4);
            Image.FormId = new InArgument<int>(2);
            Image.ServiceKey = new InArgument<string>("1234");
            Image.ImageId = new InArgument<int>(87);
            pictureBoxRequest.Image = WorkflowInvoker.Invoke<Image>(Image);
        }
    }
}
