using System;
using System.Activities;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tadbir
{
    public class Image : CodeActivity<System.Drawing.Image>
    {
        public InArgument<string> IP { get; set; }

        public InArgument<string> Port { get; set; }

        public InArgument<string> dbName { get; set; }

        public InArgument<string> Version { get; set; }

        public InArgument<string> Group { get; set; }

        public InArgument<string> Entity { get; set; }

        public InArgument<string> Function { get; set; }

        public InArgument<int> MerchId { get; set; }

        public InArgument<int> FPId { get; set; }

        public InArgument<int> SysId { get; set; }

        public InArgument<int> FormId { get; set; }

        public InArgument<string> ServiceKey { get; set; }

        public InArgument<int> ImageId { get; set; }

        protected override System.Drawing.Image Execute(CodeActivityContext context)
        {

            try
            {
                string ip = IP.Get<string>(context);
                string port = Port.Get<string>(context);
                string db = dbName.Get<string>(context);
                string version = Version.Get<string>(context);
                string group = Group.Get<string>(context);
                string entity = Entity.Get<string>(context);
                string function = Function.Get<string>(context);
                int merchId = MerchId.Get<int>(context);
                int fpid = FPId.Get<int>(context);
                int sysId = SysId.Get<int>(context);
                int formId = FormId.Get<int>(context);
                string serviceKey = ServiceKey.Get<string>(context);
                int imageId = ImageId.Get<int>(context);

                string url = string.Format("http://{0}:{1}/{2}/{3}/{4}/{5}/{6}?MerchId={7}&SysId={8}&FormId={9}&FPId={10}&key={11}&ImageId={12}",
                    ip, port, db, version, group, entity, function, merchId, sysId, formId, fpid, serviceKey, imageId);

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
