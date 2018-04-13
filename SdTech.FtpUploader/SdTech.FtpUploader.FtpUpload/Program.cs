using System;
using System.IO;
using System.Net;
using static System.Text.Encoding;
using System.Reflection;
using static System.Console;
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
                    PEnviar = args[3],
                    RLocal = args[4]
                };


                WriteLine(ftpParams);

                // ReSharper disable once StringLastIndexOfIsCultureSpecific.1
                var arquivo = ftpParams.PEnviar.Substring(ftpParams.PEnviar.LastIndexOf(@"\") + 1);
                var remoteFile = $@"{ftpParams.PEndereco}/{ftpParams.RLocal}{arquivo}";

                var request = (FtpWebRequest)WebRequest.Create(remoteFile);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(ftpParams.PUsuario, ftpParams.PSenha);
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
                request.EnableSsl = true;
                
                var fileContent = File.ReadAllBytes(ftpParams.PEnviar);

                request.ContentLength = fileContent.Length;

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContent, 0, fileContent.Length);
                }

                var response = (FtpWebResponse)request.GetResponse();

                WriteLine($"Arquivo \"{arquivo}\" enviado com sucesso.\nServer last message: \n{response.StatusDescription}\n");
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

    public class LogError
    {
        public static void Log(Exception ex, string[] args)
        {
            var fullPath = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\logs";
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);

            var filePath = $@"{fullPath}\FtpUpload-{DateTime.Now:yyyyMdd-HHm}.txt";

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
