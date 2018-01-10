namespace System.Windows.Input.Commands
{
    public interface ICommandState
    {
        /// <summary>
        /// 获取一个值，该值指示命令是否已经执行完毕
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// 获取一个值，该值指示执行命令时，是否出现异常而导致失败
        /// </summary>
        bool IsFaulted { get; }

        /// <summary>
        /// 获取一个值，该值指示执行命令时，用户是否取消执行
        /// </summary>
        bool IsCancel { get; }
    }
}
