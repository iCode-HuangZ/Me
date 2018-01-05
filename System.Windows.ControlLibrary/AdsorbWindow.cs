using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.API;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Animation;

namespace System.Windows.ControlLibrary
{
    public class AdsorbWindow : Window
    {
        private static readonly DependencyPropertyKey AdsorbOrientationPropertyKey;
        public static readonly DependencyProperty AdsorbOrientationProperty;

        protected HwndSource HwndSource { get; private set; }

        /// <summary>
        /// 获取一个值，该值指示窗口吸附时的偏移量
        /// </summary>
        protected readonly double Offsize;

        /// <summary>
        /// 获取一个值，该值指示窗口是否跟随鼠标移动
        /// </summary>
        protected bool IsFollowMouse { get; private set; }

        /// <summary>
        /// 获取一个值，该值指示鼠标位于屏幕的位置
        /// </summary>
        protected Point MousePoint { get; private set; }

        /// <summary>
        /// 获取一个值，该值指示窗口吸附前的高度
        /// </summary>
        protected double OriginalHeight { get; private set; }

        /// <summary>
        /// 获取一个值，该值指示窗口吸附前的宽度
        /// </summary>
        protected double OriginalWidth { get; private set; }

        /// <summary>
        /// 获取一个值，该值指示窗口的吸附方向
        /// </summary>
        public AdsorbOrientation AdsorbOrientation
        {
            get { return (AdsorbOrientation)GetValue(AdsorbOrientationProperty); }
            private set
            {
                if (value != AdsorbOrientation)
                {
                    SetValue(AdsorbOrientationPropertyKey, value);
                    SetAdsorbLocation(AdsorbOrientation);
                }
            }
        }

        public RoutedCommand ResizeCommand { get; }

        static AdsorbWindow()
        {
            var ownerType = typeof(AdsorbWindow);
            DefaultStyleKeyProperty.OverrideMetadata(ownerType, new FrameworkPropertyMetadata(ownerType));
            AdsorbOrientationPropertyKey = DependencyProperty.RegisterReadOnly("AdsorbOrientation", typeof(AdsorbOrientation), ownerType, new FrameworkPropertyMetadata(default(AdsorbOrientation)));
            AdsorbOrientationProperty = AdsorbOrientationPropertyKey.DependencyProperty;
        }

        public AdsorbWindow()
        {
            Offsize = 5;
            
            ResizeCommand= new RoutedCommand("ResizeCommand", typeof(AdsorbWindow));
            CommandBindings.Add(new CommandBinding(ResizeCommand, ResizeCommandExecuted));
            AddSystemCommands();
            SourceInitialized += AdsorbWindow_SourceInitialized;
            MouseEnter += AdsorbWindow_MouseEnter;
            MouseLeftButtonDown += AdsorbWindow_MouseLeftButtonDown;
            MouseMove += AdsorbWindow_MouseMove;
            MouseLeftButtonUp += AdsorbWindow_MouseLeftButtonUp;
            MouseLeave += AdsorbWindow_MouseLeave;
            Activated += AdsorbWindow_Activated;
            LostKeyboardFocus += AdsorbWindow_LostKeyboardFocus;
        }

        private void ResizeCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (null != HwndSource)
            {
                var element = (FrameworkElement)e.OriginalSource;
                var resizeOrientation = (ResizeOrientation)element.Tag;
                User32.SendMessage(HwndSource.Handle, WM.SYSCOMMAND, resizeOrientation.GetWParam(), WM.NULL);
                switch (AdsorbOrientation)
                {
                    case AdsorbOrientation.Left:
                    case AdsorbOrientation.Right:
                        OriginalWidth = ActualWidth;
                        break;
                    default:
                        OriginalWidth = ActualWidth;
                        OriginalHeight = ActualHeight;
                        break;
                }
            }
            
        }

        private void AdsorbWindow_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ShrinkAnimatable(AdsorbOrientation);
        }

        private void AdsorbWindow_Activated(object sender, EventArgs e)
        {
            SpreadAnimatable(AdsorbOrientation);
        }
        
        private void AdsorbWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            if (MouseButtonState.Released == e.LeftButton)
            {
                if (IsFollowMouse)
                {
                    IsFollowMouse = false;
                }
                ShrinkAnimatable(AdsorbOrientation);
            }
        }

        private void AdsorbWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsFollowMouse = false;
        }

        private void AdsorbWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsFollowMouse)
            {
                var mousePoint = this.GetMousePoint();
                AdsorbOrientation = GetAdsorbOrientation(mousePoint);
                SetWindowLocation(AdsorbOrientation, mousePoint, MousePoint);
                MousePoint = mousePoint;
            }
        }

        private void AdsorbWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MouseButtonState.Pressed == e.LeftButton)
            {
                IsFollowMouse = true;
                MousePoint = this.GetMousePoint();
                // 解除吸附动画锁定的依赖属性
                BeginAnimation(LeftProperty, null);
                BeginAnimation(TopProperty, null);
                // 记录原始宽高
                if (AdsorbOrientation == AdsorbOrientation.None)
                {
                    OriginalHeight = ActualHeight;
                    OriginalWidth = ActualWidth;
                }
            }
        }

        private void AdsorbWindow_MouseEnter(object sender, MouseEventArgs e)
        {
            SpreadAnimatable(AdsorbOrientation);
        }

        private void AdsorbWindow_SourceInitialized(object sender, EventArgs e)
        {
            HwndSource = PresentationSource.FromVisual(this) as HwndSource;
        }

        #region system commands

        /// <summary>
        /// 新增系统命令（窗口关闭、最小化、最大化、还原等）
        /// </summary>
        private void AddSystemCommands()
        {
            CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, CloseWindowCommandExecuted));
            CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, MaximizeWindowCommandExecuted));
            CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, MinimizeWindowCommandExecuted));
            CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, RestoreWindowCommandExecuted));
            CommandBindings.Add(new CommandBinding(SystemCommands.ShowSystemMenuCommand, ShowSystemMenuCommandExecuted));
        }

        private void ShowSystemMenuCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var element = e.OriginalSource as FrameworkElement;
            if (element == null)
                return;
            var point = WindowState == WindowState.Maximized ? new Point(0, element.ActualHeight)
                : new Point(Left + BorderThickness.Left, element.ActualHeight + Top + BorderThickness.Top);
            point = element.TransformToAncestor(this).Transform(point);
            SystemCommands.ShowSystemMenu(this, point);
        }

        private void RestoreWindowCommandExecuted(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            SystemCommands.RestoreWindow(this);
        }

        private void MinimizeWindowCommandExecuted(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void MaximizeWindowCommandExecuted(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            SystemCommands.MaximizeWindow(this);
        }

        private void CloseWindowCommandExecuted(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            Close();
        }

        #endregion

        /// <summary>
        /// 获取窗口的吸附方向
        /// </summary>
        /// <param name="point"></param>
        /// <param name="range"></param>
        private AdsorbOrientation GetAdsorbOrientation(Point point, double range = 20)
        {
            // 左
            if (point.X.Range(0, range))
            {
                return AdsorbOrientation.Left;
            }
            // 上
            if (point.Y.Range(0, range))
            {
                return AdsorbOrientation.Top;
            }
            // 右
            if (point.X.Range(SystemParameters.WorkArea.Right - range, SystemParameters.WorkArea.Right))
            {
                return AdsorbOrientation.Right;
            }
            return AdsorbOrientation.None;
        }

        /// <summary>
        /// 设置吸附时的初始位置
        /// </summary>
        private void SetAdsorbLocation(AdsorbOrientation adsorbOrientation)
        {
            switch (adsorbOrientation)
            {
                case AdsorbOrientation.None:
                    Topmost = false;
                    Height = OriginalHeight;
                    Width = OriginalWidth;
                    break;
                case AdsorbOrientation.Left:
                    Topmost = true;
                    Left = 0 - BorderThickness.Left + Offsize;
                    Top = 0;
                    Height = SystemParameters.WorkArea.Height;
                    break;
                case AdsorbOrientation.Top:
                    Topmost = true;
                    Top = 0 - BorderThickness.Top + Offsize;
                    break;
                case AdsorbOrientation.Right:
                    Topmost = true;
                    Left = SystemParameters.WorkArea.Width - ActualWidth - Offsize + BorderThickness.Right;
                    Top = 0;
                    Height = SystemParameters.WorkArea.Height;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 设置窗口位置
        /// </summary>
        /// <param name="adsorbOrientation"></param>
        /// <param name="current"></param>
        /// <param name="reference"></param>
        private void SetWindowLocation(AdsorbOrientation adsorbOrientation, Point current, Point reference)
        {
            switch (adsorbOrientation)
            {
                case AdsorbOrientation.None:
                    Left = Left + current.X - reference.X;
                    Top = Top + current.Y - reference.Y;
                    break;
                case AdsorbOrientation.Left:
                    break;
                case AdsorbOrientation.Top:
                    Left = Left + current.X - reference.X;
                    break;
                case AdsorbOrientation.Right:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 伸展
        /// </summary>
        /// <param name="adsorbOrientation"></param>
        private void SpreadAnimatable(AdsorbOrientation adsorbOrientation)
        {
            switch (adsorbOrientation)
            {
                case AdsorbOrientation.Left:
                    AdsorbAnimatable(0 - BorderThickness.Left + Offsize, new PropertyPath(Window.LeftProperty));
                    break;
                case AdsorbOrientation.Top:
                    AdsorbAnimatable(0 - BorderThickness.Top + Offsize, new PropertyPath(Window.TopProperty));
                    break;
                case AdsorbOrientation.Right:
                    AdsorbAnimatable(SystemParameters.WorkArea.Width - ActualWidth - Offsize + BorderThickness.Right, new PropertyPath(Window.LeftProperty));
                    break;
            }
        }

        /// <summary>
        /// 收缩
        /// </summary>
        /// <param name="adsorbOrientation"></param>
        private void ShrinkAnimatable(AdsorbOrientation adsorbOrientation)
        {
            switch (adsorbOrientation)
            {
                case AdsorbOrientation.Left:
                    AdsorbAnimatable(0 - ActualWidth - Offsize + BorderThickness.Left, new PropertyPath(Window.LeftProperty));
                    break;
                case AdsorbOrientation.Top:
                    AdsorbAnimatable(0 - ActualHeight - Offsize + BorderThickness.Top, new PropertyPath(Window.TopProperty));
                    break;
                case AdsorbOrientation.Right:
                    AdsorbAnimatable(SystemParameters.WorkArea.Width - BorderThickness.Right + Offsize, new PropertyPath(Window.LeftProperty));
                    break;
            }
        }

        /// <summary>
        /// 吸附动画
        /// </summary>
        /// <param name="to"></param>
        /// <param name="propertyPath"></param>
        private void AdsorbAnimatable(double to, PropertyPath propertyPath)
        {
            //Console.WriteLine(to);
            var doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = TimeSpan.FromMilliseconds(300);
            doubleAnimation.To = to;
            Storyboard.SetTarget(doubleAnimation, this);
            Storyboard.SetTargetProperty(doubleAnimation, propertyPath);
            var storyboard = new Storyboard();
            storyboard.Children.Add(doubleAnimation);
            BeginStoryboard(storyboard, HandoffBehavior.SnapshotAndReplace, true);
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            AddSystemCommands();
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            HwndSource = PresentationSource.FromVisual(this) as HwndSource;
        }


        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            SpreadAnimatable(AdsorbOrientation);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MouseButtonState.Pressed == e.LeftButton)
            {
                IsFollowMouse = true;
                MousePoint = this.GetMousePoint();
                // 解除吸附动画锁定的依赖属性
                BeginAnimation(LeftProperty, null);
                BeginAnimation(TopProperty, null);
                // 记录原始宽高
                if (AdsorbOrientation == AdsorbOrientation.None)
                {
                    OriginalHeight = ActualHeight;
                    OriginalWidth = ActualWidth;
                }
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsFollowMouse)
            {
                var mousePoint = this.GetMousePoint();
                AdsorbOrientation = GetAdsorbOrientation(mousePoint);
                SetWindowLocation(AdsorbOrientation, mousePoint, MousePoint);
                MousePoint = mousePoint;
            }
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsFollowMouse = false;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            if (MouseButtonState.Released == e.LeftButton)
            {
                if (IsFollowMouse)
                {
                    IsFollowMouse = false;
                }
                ShrinkAnimatable(AdsorbOrientation);
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            SpreadAnimatable(AdsorbOrientation);
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            ShrinkAnimatable(AdsorbOrientation);
        }

        private void Window_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ShrinkAnimatable(AdsorbOrientation);
        }

    }
}
