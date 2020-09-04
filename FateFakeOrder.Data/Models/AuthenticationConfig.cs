using System;
using System.Collections.Generic;
using System.Text;

namespace FateFakeOrder.Data.Models
{
    public class AuthenticationConfig
    {
        public string JWTSigningKey { get; set; }
        public string JWTValidMins { get; set; }
    }
}
