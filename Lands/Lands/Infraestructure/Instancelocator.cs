using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Infraestructure
{
    using ViewModels;
    public class Instancelocator
    { 
        #region Properties
        public MainViewModel Main{ get; set; }
        #endregion

        #region constructor
        public Instancelocator()
        {
            this.Main = new MainViewModel();
        } 
        #endregion
    }

}
