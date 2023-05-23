using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBank
{
    class Bank // Bank collects all members
    {
        private IAccount acc;
        public List<IAccount> members;

        public Bank()
        {
            members = new List<IAccount>();
        }

        public void AddMember(IAccount acc)
        {
            members.Add(acc);
        }

        //public List<IAccount> GetMembers()
        //{
        //    return members;
        //}
    }
}
