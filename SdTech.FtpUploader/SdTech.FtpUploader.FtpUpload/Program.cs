using System;
using System.IO;
using System.Net;
using static System.Text.Encoding;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SdTech.FtpUploader.FtpUpload
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var ftpParams = new FtpDestiny
                {
                    PEndereco = args[0],
                    PUsuario = args[1],
                    PSenha = args[2],
                    PEnviar = args[3]
                };

                Console.WriteLine(ftpParams);

                var request = (FtpWebRequest)WebRequest.Create(ftpParams.PEndereco);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(ftpParams.PUsuario, ftpParams.PSenha);

                byte[] fileContent = null;
                using (var strReader = new StreamReader(ftpParams.PEnviar))
                {
                    fileContent = UTF8.GetBytes(strReader.ReadToEnd());
                }

                request.ContentLength = fileContent.Length;

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContent, 0, fileContent.Length);
                }

                var response = (FtpWebResponse)request.GetResponse();

                Console.WriteLine($"Upload file complete, status {response.StatusDescription}");

            }

            catch (UriFormatException uriExcepion)
            {

                LogError.Log(uriExcepion, args);
            }

            catch (Exception ex)
            {

                LogError.Log(ex, args);
            }
        }
    }

    public class FtpDestiny
    {
        private string pEndereco;
        public string PEndereco
        {
            get { return pEndereco; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("empty uri");
                if (!Regex.Match(value, "^(https?|ftp)://.*$").Success) value = $"ftp://{value.TrimEnd('/')}";
                if (!Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute)) throw new UriFormatException();
                pEndereco = value;

            }
        }

        private string pUsuario;
        public string PUsuario
        {
            get { return pUsuario; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) pUsuario = value;
                else throw new Exception("empty user");

            }
        }
        private string pSenha;
        public string PSenha
        {
            get { return pSenha; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) pSenha = value;
                else throw new Exception("empty password");
            }
        }

        private string pEnviar;
        public string PEnviar
        {
            get { return pEnviar; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) pEnviar = value;
                else throw new Exception("empty pEnviar");
            }
        }

        public override string ToString() => $"End: {PEndereco}\nUsuario: {PUsuario}\nSenha: {PSenha}\nEnviar: {PEnviar}";
    }

    public class LogError
    {
        public static void Log(Exception ex, string[] args)
        {
            var fullPath = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\logs";
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);

            var filePath = $@"{fullPath}\FtpUpload-{DateTime.Now.ToString("yyyyMdd-HHm")}.txt";

            using (var sw = new StreamWriter(@filePath))
            {
                sw.WriteLine("Error to upload with args:");
                foreach (var a in args)
                    sw.WriteLine(a);
                var msg = $"\n{ex.Message}\n inner:{ex.InnerException?.Message}\n";
                sw.WriteLine(msg);
                for (var i = 0; i <= msg.Length; i++)
                    sw.Write("=");
            }
        }
    }
}
