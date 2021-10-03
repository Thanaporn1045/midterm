using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ข้อสองห้องสมุด
{
    enum Usertype
    {
        Student = 1,
        Employee,
        notChoose
    }
    class SystemBase
    {
        public string Username;
        public string Password;
        public Usertype usertype;
        public string ID;

        public SystemBase()
        {
            this.Username = "-";
            this.Password = "-";
            this.usertype = (Usertype)3 ;
            this.ID = "0";
        }
    }
}
