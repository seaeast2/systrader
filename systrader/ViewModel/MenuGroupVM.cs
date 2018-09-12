using System.Collections.Generic;

namespace systrader.ViewModel
{
    public class MenuGroupVM
    {
        public string GroupName { get; set; }
        public IEnumerable<MenuItemVM> Items { get; set; }
    }
}
