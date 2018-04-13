using System;
using System.Text.RegularExpressions;

namespace SdTech.FtpUploader.FtpUpload
{
    public class FtpDestiny
    {

        private string _pEndereco;
        public string PEndereco
        {
            get => _pEndereco;
            set
            {
                // TODO Test if already have a ftp
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("empty uri");
                value = SanitizeEndereco(value);
                if (!Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute)) throw new UriFormatException();
                _pEndereco = value;
            }
        }

        private static string SanitizeEndereco(string end)
        {
            end = end.TrimEnd('/');
            end = Regex.Replace(end, "^(https|http)", "ftp");
            return !Regex.Match(end, "^(ftp)://.*$").Success ? $"ftp://{end}" : end;
        }

        private string _pUsuario;
        public string PUsuario
        {
            get => _pUsuario;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _pUsuario = value;
                else throw new Exception("empty user");

            }
        }
        private string _pSenha;
        public string PSenha
        {
            get => _pSenha;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _pSenha = value;
                else throw new Exception("empty password");
            }
        }

        private string _rLocal;
        public string RLocal
        {
            get => _rLocal;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _rLocal = $"%2F/{value.Replace("/", "%2F/")}/";
                else _rLocal = string.Empty;
            }
        }

        private string _pEnviar;
        public string PEnviar
        {
            get => _pEnviar;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _pEnviar = value;
                else throw new Exception("empty pEnviar");
            }
        }

        public override string ToString() => $"End: {PEndereco}\nUsuario: {PUsuario}\nSenha: {PSenha}\nEnviar: {PEnviar}";
    }
}
