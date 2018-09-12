using System;

namespace systrader.ViewModel
{
    public class MenuItemVM
    {
        private static int idCount_;

        public MenuItemVM()
        {
            Id = idCount_++;
        } 

        public MenuItemVM(string title/*, Type content*/)
        {
            Id = idCount_++;
            Title = title;
            //Content = content;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        //public Type Content { get; set; }
    }
}
