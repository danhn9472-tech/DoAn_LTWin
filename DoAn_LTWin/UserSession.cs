using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_LTWin
{
    public static class UserSession
    {
        public static string UserName { get; set; }
        public static string Role { get; set; }
        public static string UserId { get; set; }

        public static void Clear()
        {
            UserName = null;
            Role = null;
            UserId = null;
        }
    }
}
