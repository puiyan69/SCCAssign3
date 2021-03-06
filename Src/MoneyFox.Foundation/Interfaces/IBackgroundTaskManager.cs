﻿namespace MoneyFox.Foundation.Interfaces
{
    /// <summary>
    ///     Handles the Starting and stopping of background tasks who
    ///     can be configured by the user.
    ///     Tasks who has to run in order to ensure the system functions
    ///     are started automatically on the startup in each platform specific
    ///     project.
    /// </summary>
    public interface IBackgroundTaskManager
    {
        /// <summary>
        ///     Starts the backup sync task.
        /// </summary>
        void StartBackupSyncTask();

        /// <summary>
        ///     Stops the background sync task.
        /// </summary>
        void StopBackupSyncTask();
    }
}