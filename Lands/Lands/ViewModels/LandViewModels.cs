﻿using Lands.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Lands.ViewModels
{
    public class LandViewModels : BaseViewModels
    {
        #region Atributos
        private ObservableCollection<Border> borders;
        #endregion

        #region propiedades
        public Land Land { get; set; }
        public ObservableCollection<Border> Borders
        {
            get { return this.borders; }
            set { this.SetValue(ref this.borders, value); }
        }
        #endregion

        #region constructores
        public LandViewModels(Land land)
        {
            this.Land = land;
            this.LoadBorders();
        }
        #endregion
        #region metodos
        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().LandsList.
                    Where(l => l.Alpha3Code == border).FirstOrDefault(); ;
                if (land != null)
                {
                    this.Borders.Add(new Border { Code = land.Alpha3Code, Name = land.Name, });
                }
            }
        } 
        #endregion
    }
}