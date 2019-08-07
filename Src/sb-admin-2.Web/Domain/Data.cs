using sb_admin_2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sb_admin_2.Web.Domain
{
    public class Data
    {
        public IEnumerable<Navbar> NavbarItems()
        {
            var menu = new List<Navbar>
            {
                new Navbar
                {
                    Id = 1,
                    nameOption = "員工管理",
                    controller = "Home",
                    action = "Index",
                    imageClass = "fa fa-dashboard fa-fw",
                    status = true,
                    isParent = false,
                    parentId = 0
                }
            };

            return menu.ToList();
        }
    }
}