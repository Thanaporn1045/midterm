using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ข้อสองห้องสมุด
{
    class PersonList
    {
        public List<Studentinfo> ListStudent;
        public List<Employeeinfo> ListEmployee;

        public PersonList()
        { 
            ListStudent = new List<Studentinfo>();
            ListEmployee = new List<Employeeinfo>();
        }

        public void AddlistStudent(Studentinfo Stundentinfofrominput)
        {
            ListStudent.Add(Stundentinfofrominput);
        }
        public void AddlistEmployee(Employeeinfo Employeeinfofrominput)
        {
            ListEmployee.Add(Employeeinfofrominput);
        }
    }
}
