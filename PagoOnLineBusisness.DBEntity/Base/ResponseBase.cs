using System;
using System.Collections.Generic;
using System.Text;

namespace PagoOnLineBusisness.DBEntity.Base
{
    public class ResponseBase
    {
        public bool isSuccess { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public object data { get; set; }
    }
}
