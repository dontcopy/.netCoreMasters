using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.ApiModels
{
    public class AuthModel
    {
        public class Authentication
        {
            public JWT JWT { get; set; }
        }
        public class JWT
        {
            public string SecurityKey { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }
        }
    }
}
