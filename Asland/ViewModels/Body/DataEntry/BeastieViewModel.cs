﻿namespace Asland.ViewModels.Body.DataEntry
{
    using System;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using Asland.Common.Enums;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model used to describe a single beastie for display on the raw data entry view.
    /// </summary>
    public class BeastieViewModel : ViewModelBase, IBeastieViewModel
    {
        /// <summary>
        /// Set the beastie as observed in the model.
        /// </summary>
        private Action<string, bool, bool> setObservation;

        /// <summary>
        /// Field indicating whether this beastie has been selected as part of the current event.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Indicates whether the view model is managing seen or heard observations.
        /// </summary>
        private bool isSeen;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieViewModel"/> class.
        /// </summary>
        /// <param name="commonName">common name</param>
        /// <param name="latinName">latin name</param>
        /// <param name="imagePath">
        /// Path to an image of this beastie.
        /// </param>
        /// <param name="presence">
        /// Residency of this beastie.
        /// </param>
        /// <param name="isSelected">
        /// Indicates whether this beastie is present in the model.
        /// </param>
        /// <param name="setObservation">
        /// Action used to set an observation in the model.
        /// </param>
        /// <param name="isSeen">
        /// Indicates whether this observation is seen or heard.
        /// </param>
        public BeastieViewModel(
            string commonName,
            string latinName,
            string imagePath,
            Presence presence,
            bool isSelected,
            Action<string, bool, bool> setObservation,
            bool isSeen)
        {
            this.CommonName = commonName;
            this.LatinName = latinName;
            this.Presence = presence;
            this.isSelected = isSelected;
            this.isSeen = isSeen;
            this.setObservation = setObservation;

            if (string.IsNullOrEmpty(imagePath))
            {
                this.ImagePath = $"{DataPath.BasePath}\\Sample.png";
            }
            else
            {
                this.ImagePath = $"{DataPath.ImageDataPath}\\{imagePath}";
            }
        }

        /// <summary>
        /// Gets the name of the beastie.
        /// </summary>
        public string CommonName { get; }

        /// <summary>
        /// Gets the (latin) name of the beastie.
        /// </summary>
        public string LatinName { get; }

        /// <summary>
        /// Gets the path to an image of the beastie.
        /// </summary>
        public string ImagePath { get; }

        /// <summary>
        /// Gets a value which indicates the residential status of the beastie.
        /// </summary>
        public Presence Presence { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the beastie has been selected.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    this.RaisePropertyChangedEvent(nameof(this.IsSelected));

                    this.setObservation.Invoke(
                        this.CommonName,
                        this.isSelected,
                        this.isSeen);
                }
            }
        }
    }
}