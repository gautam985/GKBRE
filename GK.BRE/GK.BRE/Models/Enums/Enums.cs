using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GK.BRE.Models.Enums
{
    public enum ProductType
    {
        Physical,
        Book,
        Membership,
        MembershipUpgrade,
        Video
    }

    public enum ResultCode
    {
        Success,
        Failed,
        Error
    }
}
