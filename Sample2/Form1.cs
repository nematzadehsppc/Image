using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRequest_Click(object sender, EventArgs e)
        {
            Tadbir.ImageID Image = new Tadbir.ImageID();
            //Tadbir.Image Image = new Tadbir.Image();

            Image.Port = new InArgument<string>("9020");
            Image.dbName = new InArgument<string>("VICHI");
            Image.MerchId = new InArgument<int>(9784);
            Image.FPId = new InArgument<int>(4);
            Image.ServiceKey = new InArgument<string>("1234");
            Image.ImageId = new InArgument<int>(596);
            pictureBoxRequest.Image = System.Activities.WorkflowInvoker.Invoke<Image>(Image);
        }
    }
}
