using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Commands;

namespace System.Windows
{
    /// <summary>
    /// 表示视图元素对应的视图模型
    /// </summary>
    public abstract class ViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        protected Dictionary<string, ICollection<string>> ErrorDictionary { get; }

        /// <summary>
        /// 获取一个值，该值指示该实体是否有验证错误的值
        /// </summary>
        public bool HasErrors
        {
            get { return ErrorDictionary.Any(); }
        }

        /// <summary>
        /// 获取一个值，该值指示视图模型的视图元素
        /// </summary>
        public UIElement Element { get; private set; }

        /// <summary>
        /// 获取一个值，该值指示设置视图元素的命令
        /// </summary>
        public Command SetElement { get; }

        /// <summary>
        /// 当属性或整个实体的验证错误已经更改时发生
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// 在属性值更改时发生
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 初始化 System.Windows.ViewModel 类的新实例
        /// </summary>
        protected ViewModel()
        {
            ErrorDictionary = new Dictionary<string, ICollection<string>>();
            SetElement = new OnceCommand(SetElementExecuteDelegate,null);
        }

        public virtual bool Validation()
        {
            // 验证错误时，必须先要清空属性异常信息。
            // 因为，WPF 异常模板会屏蔽相同的错误信息。导致相同的错误信息，仅显示一次
            ErrorDictionary.Clear();
            // 属性验证
            var result = true;
            var properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                var validationContext = new ValidationContext(this);
                var validationResults = new List<ValidationResult>();
                validationContext.MemberName = property.Name;
                var value = property.GetValue(this);
                if (!Validator.TryValidateProperty(value, validationContext, validationResults))
                {
                    result = false;
                    // 仅显示第一个错误
                    var errorCollection = validationResults.Select(p => p.ErrorMessage).ToList();
                    ErrorDictionary[property.Name] = new List<string>
                    {
                        errorCollection[0]
                    };
                }
                OnErrorsChanged(property.Name);
            }
            return result;
        }

        /// <summary>
        /// 允许执行 SetElement
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private async Task<bool> SetElementCanExecuteDelegate(object o)
        {
            await Task.Run(() => { });
            return o is UIElement;
        }

        /// <summary>
        /// 执行 SetElement
        /// </summary>
        /// <param name="o"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SetElementExecuteDelegate(object o, CancellationToken cancellationToken)
        {
            await Task.Run(() => { });
            Element = (UIElement) o;
        }

        /// <summary>
        /// 获取指定属性或整个实体的验证错误
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <returns></returns>
        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

        protected void OnPropertyChanged<TValue>(ref TValue oldValue, TValue newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(oldValue, newValue))
            {
                oldValue = newValue;
                OnPropertyChanged(propertyName);
            }
        }

        /// <summary>
        /// 引发 PropertyChanged 事件
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 引发 DataErrorsChanged 事件
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
