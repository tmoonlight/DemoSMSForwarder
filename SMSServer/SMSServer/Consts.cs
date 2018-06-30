using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSServer
{
    public static class Consts
    {
        #region jwtbearer相关参数
        public const string SecurityKey = "SKEGasddsSFSDFg453+#Q(%EWTSDGS345FGFDFgdfSC45RdfgWGSDFrfdsYZ";  //对称秘钥
        public const string TokenIssuer = "SMS_ISSUSER";                                    //有效token签发者
        public const string TokenAudience = "SMS";                                          //有效应用名
        #endregion

    }
}
