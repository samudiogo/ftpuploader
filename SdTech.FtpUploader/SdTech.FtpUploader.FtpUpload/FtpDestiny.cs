using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SdTech.FtpUploader.FtpUpload
{
    public class FtpDestiny
    {

        private string pEndereco;
        public string PEndereco
        {
            get { return pEndereco; }
            set
            {
                // TODO Test if already have a ftp
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("empty uri");
                value = SanitizeEndereco(value);
                if (!Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute)) throw new UriFormatException();
                pEndereco = value;
            }
        }

        private static string SanitizeEndereco(string end)
        {
            end = end.TrimEnd('/');
            end = Regex.Replace(end, "^(https|http)", "ftp");
            if (!Regex.Match(end, "^(ftp)://.*$").Success) return $"ftp://{end}";
            return end;

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
}
