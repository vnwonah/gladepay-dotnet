using System;
using System.Collections.Generic;
using System.Text;

namespace gladepay_dotnet.Enums
{
    public enum ResponseCode
    {
        
        OK = 200,
        Accepted = 202,
        BadRequest = 400,
        Forbidden = 401,
        InternalServerError = 500,
        Unauthorized,
        NotFound = 404

    }
}
