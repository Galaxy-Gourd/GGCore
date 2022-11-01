using System.Collections.Generic;

namespace GG.Core
{
    /// <summary>
    /// Custom logging solution. Scripts can queue logs with this static class - a log module will then dequeue the logs at a set interval
    /// </summary>
    public static class GameLog
    {
        #region INITIALIZATION

        public static readonly Queue<string> LogQueue = new Queue<string>();

        #endregion INITIALIZATION
        
        #region LOG

        public static void Log(string message)
        {
            LogQueue.Enqueue(message);
        }

        public static string[] GetQueuedLogs()
        {
            string[] logs = LogQueue.ToArray();
            LogQueue.Clear();
            return logs;
        }

        #endregion LOG
    }
}