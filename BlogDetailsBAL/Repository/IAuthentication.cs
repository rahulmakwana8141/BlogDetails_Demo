using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDetailsBAL.Repository
{
    public interface IAuthentication
    {
        string EncryptString(string textToEncrypt);
        string DecryptString(string textToDecrypt);
    }
}
