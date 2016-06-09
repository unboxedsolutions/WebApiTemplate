using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTemplate.Infrastructure {
    public interface IWebApiTemplateAuthentication {
        bool Authenticate(string username, string password);
    }
}
