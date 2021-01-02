﻿namespace Asland.ViewModels.Body.DataEntry
{
    using System;
    using Asland.Common.Enums;
    using Asland.Interfaces.Model.IO.DataEntry;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using Asland.ViewModels.Common;
    using Interfaces.ViewModels.Common;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// View model which supports a view reposible for the entry of the event details.
    /// </summary>
    public class EventDetailsEntryViewModel : ViewModelBase, IEventDetailsEntry
    {
        /// <summary>
        /// Gets or sets the date of the event.
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Gets or sets any notes pertaining to the event.
        /// </summary>
        private string notes;

        /// <summary>
        /// Gets or sets a value indicating whether the observations currently being marked have 
        /// been seen.
        /// </summary>
        private bool isSeen;

        /// <summary>
        /// Manager which handles observation data entry/interrogation.
        /// </summary>
        private IObservationManager observations;
        
        /// <summary>
        /// Initialises a new instance of the <see cref="EventDetailsEntryViewModel"/> class.
        /// </summary>
        /// <param name="observations">
        /// The observations model object.
        /// </param>
        /// <param name="isSeen">Indicates whether the observations are seen or heard</param>
        public EventDetailsEntryViewModel(
            IObservationManager observations,
            bool isSeen)
        {
            this.observations = observations;
            this.date = DateTime.Now;
            this.notes = string.Empty;
            this.isSeen = isSeen;

            this.LengthSelector =
                new EnumSelectorViewModel<ObservationLength>(
                    "Length",
                    ObservationLength.Unspecified,
                    this.NewObservationLength);

            this.IntensitySelector =
                new EnumSelectorViewModel<ObservationIntensity>(
                    "Intensity",
                    ObservationIntensity.NotRecorded,
                    this.NewObservationIntensity);

            this.TimeOfDaySelector =
                new EnumSelectorViewModel<ObservationTimeOfDay>(
                    "Time Of Day",
                    ObservationTimeOfDay.NotRecorded,
                    this.NewObservationTimeOfDay);

            this.WeatherSelector =
                new EnumSelectorViewModel<ObservationWeather>(
                    "Weather",
                    ObservationWeather.NotRecorded,
                    this.NewObservationWeather);

            this.HabitatSelector =
                new EnumSelectorCompoundViewModel<ObservationHabitat>(
                    "Habitats",
                    (ObservationHabitat) => { });
        }

        /// <summary>
        /// Gets or sets the location of the event.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the date of the event.
        /// </summary>
        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.Set(ref this.date, value);
                this.observations.SetDate(this.date);
            }
        }

        /// <summary>
        /// Gets or sets any notes pertaining to the event.
        /// </summary>
        public string Notes
        {
            get
            {
                return this.notes;
            }

            set
            {
                this.Set(ref this.notes, value);
                this.observations.SetNotes(this.notes);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the observations currently being marked have 
        /// been seen.
        /// </summary>
        public bool IsSeen
        {
            get
            {
                return this.isSeen;
            }

            set
            {
                this.Set(ref this.isSeen, value);
            }
        }

        /// <summary>
        /// Gets the length selector.
        /// </summary>
        public IEnumSelectorViewModel<ObservationLength> LengthSelector { get; }

        /// <summary>
        /// Gets the intensity selector.
        /// </summary>
        public IEnumSelectorViewModel<ObservationIntensity> IntensitySelector { get; }

        /// <summary>
        /// Gets the time of day selector.
        /// </summary>
        public IEnumSelectorViewModel<ObservationTimeOfDay> TimeOfDaySelector { get; }

        /// <summary>
        /// Gets the weather selector.
        /// </summary>
        public IEnumSelectorViewModel<ObservationWeather> WeatherSelector { get; }

        /// <summary>
        /// Gets the habitats selector.
        /// </summary>
        public IEnumSelectorCompoundViewModel<ObservationHabitat> HabitatSelector { get; }

        /// <summary>
        /// Set the new observation length
        /// </summary>
        /// <param name="newLength">new length</param>
        private void NewObservationLength(ObservationLength newLength)
        {
            this.observations.SetLength(newLength);
        }

        /// <summary>
        /// Set the new observation intensity
        /// </summary>
        /// <param name="newIntensity">new length</param>
        private void NewObservationIntensity(ObservationIntensity newIntensity)
        {
            this.observations.SetIntensity(newIntensity);
        }

        /// <summary>
        /// Set the new observation time of day.
        /// </summary>
        /// <param name="newTimeOfDay">new time of day</param>
        private void NewObservationTimeOfDay(ObservationTimeOfDay newTimeOfDay)
        {
            this.observations.SetTimeOfDay(newTimeOfDay);
        }

        /// <summary>
        /// Set the new observation weather.
        /// </summary>
        /// <param name="newWeather">new weather</param>
        private void NewObservationWeather(ObservationWeather newWeather)
        {
            this.observations.SetWeather(newWeather);
        }
    }
}