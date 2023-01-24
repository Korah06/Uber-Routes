﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MVVM.Model
{
    public  class User
    {
        public string _id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public List<string> amigos { get; set; }
        public List<string> seguidores { get; set; }
        public string picture { get; set; }
        public string registro { get; set; }
        public string web { get; set; }





        //public int id { get; set; }
        //public string name { get; set; }
        //public string username { get; set; }
        //public string email { get; set; }
        //public Address address { get; set; }
    }

    //public class Address
    //{
    //    public string street { get; set; }
    //    public string suite { get; set; }
    //    public string city { get; set; }
    //    public string zipcode { get; set; }
    //    public Geo geo { get; set; }
    //}

    //public class Geo
    //{
    //    public string lat { get; set; }
    //    public string lng { get; set; }
    //}
}
