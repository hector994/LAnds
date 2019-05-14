using Lands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    /// <summary>
    /// pruebas github
    /// </summary>
    public class MainViewModel
    {
        #region propiedades
        public List<Land> LandsList { get; set; }
        #endregion
        #region viewmodels
        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public LandViewModels Land { get; set; }
        #endregion

        #region constructor
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion
        #region singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
