﻿namespace Asland.Interfaces.ViewModels.Body
{
    using System.Collections.Generic;
    using NynaeveLib.Commands;

    /// <summary>
    /// Interface for a view model which supports the configuration view. This is the top level view
    /// of configuration and should also support switching between the different sub views.
    /// </summary>
    public interface IConfigurationViewModel
    {
        /// <summary>
        /// Gets the view model for the workspace which is displayed.
        /// </summary>
        object CurrentWorkspace { get; }

        /// <summary>
        /// Gets a selection of commands which are used to choose a page to display.
        /// </summary>
        List<IIndexCommand<string>> PageSelector { get; }
    }
}
