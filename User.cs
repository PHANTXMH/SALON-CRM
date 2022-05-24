using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salon_CRM
{    
    public class User
    {
        private int id;
        private string fname;
        private string lname;
        private string username;

        public User()
        {
            this.id = 0;
            this.fname = "<null>";
            this.lname = "<null>";
            this.username = "<null>";
        }
        public User(int id, string fname, string lname, string username)
        {
            this.id = id;
            this.fname = fname;
            this.lname = lname;
            this.username = username;
        }

        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        public string Fname
        {
            get { return fname; }
            set { this.fname = value; }
        }

        public string Lname
        {
            get { return lname; }
            set { this.lname = value; }
        }

        public string Username
        {
            get { return username; }
            set { this.username = value; }
        }
    }
}