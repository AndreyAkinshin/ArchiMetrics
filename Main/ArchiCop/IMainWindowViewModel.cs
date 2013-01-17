﻿using System.Collections.ObjectModel;
using ArchiCop.ViewModel;

namespace ArchiCop
{
    public interface IMainWindowViewModel : IViewModelBase
    {
        /// <summary>
        ///     Returns a list of commands
        ///     that the UI can display and execute.
        /// </summary>
        ObservableCollection<CommandViewModel> Commands { get; }

        /// <summary>
        ///     Returns the collection of available workspaces to display.
        ///     A 'workspace' is a ViewModel that can request to be closed.
        /// </summary>
        ObservableCollection<WorkspaceViewModel> Workspaces { get; }
    }
}