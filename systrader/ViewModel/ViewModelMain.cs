using System.Collections.Generic;
using systrader.Data;

namespace systrader.ViewModel
{
    class ViewModelMain : ViewModelBase
    {
        #region Private Members
        private string _searchTerm;
        private IEnumerable<MenuGroupVM> _searchedMenuGroup;
        private readonly IEnumerable<MenuGroupVM> _allMenuGroup;
        #endregion

        #region Constructors
        public ViewModelMain()
        {
            // Load Menu setting
            _allMenuGroup = new[]
            {
                new MenuGroupVM
                {
                    GroupName = "설정",
                    Items = new[] {
                        new MenuItemVM("화면설정"),
                        new MenuItemVM("신규주식등록")
                    }
                },
                new MenuGroupVM
                {
                    GroupName = "종목명",
                    Items = new[]
                    {
                        new MenuItemVM("삼성전자"),
                        new MenuItemVM("엘지전자")
                    }
                }
            };

            _searchedMenuGroup = _allMenuGroup;

            ((App)(System.Windows.Application.Current)).XM.Login();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Search terms
        /// </summary>
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                OnPropertyChanged("SearchTerm");
            }
        }

        /// <summary>
        /// Searched Menu list or All mene list
        /// </summary>
        public IEnumerable<MenuGroupVM> MenuList 
        {
            get { return _searchedMenuGroup;}
            set
            {
                _searchedMenuGroup = value;
                OnPropertyChanged("MenuList");
            }
        }

        /// <summary>
        /// Indicate current page.
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.MainPage;       

        #endregion
    }
}
