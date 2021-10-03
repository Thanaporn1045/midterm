using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ข้อสองห้องสมุด
{
    class Studentinfo :SystemBase
    {
        public string StudentID;
        public Studentinfo() : base()
        {
            this.StudentID = ID; 
        }
    }
}
