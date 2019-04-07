using System;
using System.Activities;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tadbir
{
    public class Image : System.Activities.CodeActivity<System.Drawing.Image>
    {
        public InArgument<string> Port { get; set; }

        public InArgument<string> dbName { get; set; }

        public InArgument<int> MerchId { get; set; }

        public InArgument<int> FPId { get; set; }

        public InArgument<string> ServiceKey { get; set; }

        protected override System.Drawing.Image Execute(CodeActivityContext context)
        {
            try
            {
                string port = Port.Get<string>(context);
                string db = dbName.Get<string>(context);
                int merchId = MerchId.Get<int>(context);
                int fpid = FPId.Get<int>(context);
                string serviceKey = ServiceKey.Get<string>(context);

                string url = string.Format("http://130.185.76.7:{0}/{1}/V3.0/Inventory/Image/GetImageById?MerchId={2}&SysId=4&FormId=2&FPId={3}&ShowAll=0&key={4}", port, db, merchId, fpid, serviceKey);

                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> message = client.GetAsync(url);
                message.Wait();
                Task<string> messageResult = message.Result.Content.ReadAsStringAsync();
                messageResult.Wait();

                System.Drawing.Image result = null;
                byte[] imageByteArray = Convert.FromBase64String(messageResult.Result.Replace("\"", ""));
                using (MemoryStream stream = new MemoryStream(imageByteArray))
                {
                    result = System.Drawing.Image.FromStream(stream);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public class ImageID : System.Activities.CodeActivity<System.Drawing.Image>
    {
        public InArgument<string> Port { get; set; }

        public InArgument<string> dbName { get; set; }

        public InArgument<int> MerchId { get; set; }

        public InArgument<int> FPId { get; set; }

        public InArgument<string> ServiceKey { get; set; }

        public InArgument<int> ImageId { get; set; }


        protected override System.Drawing.Image Execute(CodeActivityContext context)
        {
            try
            {
                string port = Port.Get<string>(context);
                string db = dbName.Get<string>(context);
                int merchId = MerchId.Get<int>(context);
                int fpid = FPId.Get<int>(context);
                string serviceKey = ServiceKey.Get<string>(context);
                int imageId = ImageId.Get<int>(context);

                string url = string.Format("http://130.185.76.7:{0}/{1}/V3.0/Inventory/Image/getImageByImageId?MerchId={2}&SysId=4&FormId=2&FPId={3}&key={4}&ImageId={5}", port, db, merchId, fpid, serviceKey, imageId);

                HttpClient client = new HttpClient();
                Task<HttpResponseMessage> message = client.GetAsync(url);
                message.Wait();
                Task<string> messageResult = message.Result.Content.ReadAsStringAsync();
                messageResult.Wait();

                System.Drawing.Image result = null;
                byte[] imageByteArray = Convert.FromBase64String(messageResult.Result.Replace("\"", ""));
                using (MemoryStream stream = new MemoryStream(imageByteArray))
                {
                    result = System.Drawing.Image.FromStream(stream);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
