using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.API
{
    public sealed class WM
    {
        /// <summary>
        /// 空值
        /// </summary>
        public const int NULL = 0x0000;

        /// <summary>
        /// 应用程序创建一个窗口
        /// </summary>
        public const int CREATE = 0x0001;

        /// <summary>
        /// 一个窗口被销毁
        /// </summary>
        public const int DESTROY = 0x0002; // 

        /// <summary>
        /// 移动一个窗口
        /// </summary>
        public const int MOVE = 0x0003; // 

        /// <summary>
        /// 改变一个窗口的大小
        /// </summary>
        public const int SIZE = 0x0005; // 

        /// <summary>
        /// 一个窗口被激活或失去激活状态
        /// </summary>
        public const int ACTIVATE = 0x0006; //； 

        /// <summary>
        /// 获得焦点后
        /// </summary>
        public const int SETFOCUS = 0x0007; // 

        /// <summary>
        /// 失去焦点
        /// </summary>
        public const int KILLFOCUS = 0x0008; // 

        /// <summary>
        /// 改变enable状态
        /// </summary>
        public const int ENABLE = 0x000A; // 

        /// <summary>
        /// 设置窗口是否能重画
        /// </summary>
        public const int SETREDRAW = 0x000B; // 

        /// <summary>
        /// 应用程序发送此消息来设置一个窗口的文本
        /// </summary>
        public const int SETTEXT = 0x000C; // 

        /// <summary>
        /// 应用程序发送此消息来复制对应窗口的文本到缓冲区
        /// </summary>
        public const int GETTEXT = 0x000D; // 

        /// <summary>
        /// 得到与一个窗口有关的文本的长度（不包含空字符） 
        /// </summary>
        public const int GETTEXTLENGTH = 0x000E; //

        /// <summary>
        /// 要求一个窗口重画自己 
        /// </summary>
        public const int PAINT = 0x000F; //

        /// <summary>
        /// 当一个窗口或应用程序要关闭时发送一个信号 
        /// </summary>
        public const int CLOSE = 0x0010; //

        /// <summary>
        /// 当用户选择结束对话框或程序自己调用ExitWindows函数 
        /// </summary>
        public const int QUERYENDSESSION = 0x0011; //

        /// <summary>
        /// 用来结束程序运行或当程序调用postquitmessage函数 
        /// </summary>
        public const int QUIT = 0x0012; //

        /// <summary>
        /// 当用户窗口恢复以前的大小位置时，把此消息发送给某个图标 
        /// </summary>
        public const int QUERYOPEN = 0x0013; //

        /// <summary>
        /// 当窗口背景必须被擦除时（例在窗口改变大小时） 
        /// </summary>
        public const int ERASEBKGND = 0x0014; //

        /// <summary>
        /// 当系统颜色改变时，发送此消息给所有顶级窗口 
        /// </summary>
        public const int SYSCOLORCHANGE = 0x0015; //

        /// <summary>
        /// 当系统进程发出QUERYENDSESSION消息后，此消息发送给应用程序，通知它对话是否结束 
        /// </summary>
        public const int ENDSESSION = 0x0016; // 

        /// <summary>
        /// 当隐藏或显示窗口是发送此消息给这个窗口 
        /// </summary>
        public const int SYSTEMERROR = 0x0017; // 

        /// <summary>
        /// 发此消息给应用程序哪个窗口是激活的，哪个是非激活的； 
        /// </summary>
        public const int SHOWWINDOW = 0x0018; //

        /// <summary>
        /// 当系统的字体资源库变化时发送此消息给所有顶级窗口
        /// </summary>
        public const int ACTIVATEAPP = 0x001C; //

        /// <summary>
        /// 当系统的时间变化时发送此消息给所有顶级窗口
        /// </summary>
        public const int FONTCHANGE = 0x001D; // 

        /// <summary>
        /// 发送此消息来取消某种正在进行的摸态（操作） 
        /// </summary>
        public const int TIMECHANGE = 0x001E; // 

        public const int CANCELMODE = 0x001F; //

        /// <summary>
        /// 如果鼠标引起光标在某个窗口中移动且鼠标输入没有被捕获时，就发消息给某个窗口
        /// </summary>
        public const int SETCURSOR = 0x0020; //

        /// <summary>
        /// 当光标在某个非激活的窗口中而用户正按着鼠标的某个键发送此消息给当前窗口 
        /// </summary>
        public const int MOUSEACTIVATE = 0x0021; //

        /// <summary>
        /// 发送此消息给MDI子窗口当用户点击此窗口的标题栏，或当窗口被激活，移动，改变大小 
        /// </summary>
        public const int CHILDACTIVATE = 0x0022; //

        /// <summary>
        /// 此消息由基于计算机的训练程序发送，通过WH_JOURNALPALYBACK的hook程序分离出用户输入消息 
        /// </summary>
        public const int QUEUESYNC = 0x0023; //

        /// <summary>
        /// 此消息发送给窗口当它将要改变大小或位置； 
        /// </summary>
        public const int GETMINMAXINFO = 0x0024; //

        /// <summary>
        /// 发送给最小化窗口当它图标将要被重画 
        /// </summary>
        public const int PAINTICON = 0x0026;

        /// <summary>
        /// 此消息发送给某个最小化窗口，仅当它在画图标前它的背景必须被重画 
        /// </summary>
        public const int ICONERASEBKGND = 0x0027;

        /// <summary>
        /// 发送此消息给一个对话框程序去更改焦点位置 
        /// </summary>
        public const int NEXTDLGCTL = 0x0028;

        /// <summary>
        /// 每当打印管理列队增加或减少一条作业时发出此消息 
        /// </summary>
        public const int SPOOLERSTATUS = 0x002A;

        /// <summary>
        /// 当button，combobox，listbox，menu的可视外观改变时发送此消息给这些空件的所有者 
        /// </summary>
        public const int DRAWITEM = 0x002B;

        /// <summary>
        /// 当button, combo box, list box, list view control, or menu item 被创建时发送此消息给控件的所有者 
        /// </summary>
        public const int MEASUREITEM = 0x002C;

        /// <summary>
        /// 当the list box 或combo box 被销毁或当某些项被删除通过LB_DELETESTRING, LB_RESETCONTENT, CB_DELETESTRING, or CB_RESETCONTENT 消息 
        /// </summary>
        public const int DELETEITEM = 0x002D;

        /// <summary>
        /// 此消息有一个LBS_WANTKEYBOARDINPUT风格的发出给它的所有者来响应KEYDOWN消息 
        /// </summary>
        public const int VKEYTOITEM = 0x002E;

        /// <summary>
        /// 此消息由一个LBS_WANTKEYBOARDINPUT风格的列表框发送给他的所有者来响应CHAR消息 
        /// </summary>
        public const int CHARTOITEM = 0x002F;

        /// <summary>
        /// 当绘制文本时程序发送此消息得到控件要用的颜色
        /// </summary>
        public const int SETFONT = 0x0030;

        /// <summary>
        /// 应用程序发送此消息得到当前控件绘制文本的字体 
        /// </summary>
        public const int GETFONT = 0x0031; //

        /// <summary>
        /// 应用程序发送此消息让一个窗口与一个热键相关连 
        /// </summary>
        public const int SETHOTKEY = 0x0032; //

        /// <summary>
        /// 应用程序发送此消息来判断热键与某个窗口是否有关联
        /// </summary>
        public const int GETHOTKEY = 0x0033; // 

        /// <summary>
        /// 此消息发送给最小化窗口，当此窗口将要被拖放而它的类中没有定义图标，应用程序能返回一个图标或光标的句柄，当用户拖放图标时系统显示这个图标或光标 
        /// </summary>
        public const int QUERYDRAGICON = 0x0037; //

        /// <summary>
        /// 发送此消息来判定combobox或listbox新增加的项的相对位置 
        /// </summary>
        public const int COMPAREITEM = 0x0039; //
        public const int GETOBJECT = 0x003D; //COMPACTING = 0x0041; //显示内存已经很少了 
        public const int WINDOWPOSCHANGING = 0x0046; //发送此消息给那个窗口的大小和位置将要被改变时，来调用setwindowpos函数或其它窗口管理函数 
        public const int WINDOWPOSCHANGED = 0x0047; //发送此消息给那个窗口的大小和位置已经被改变时，来调用setwindowpos函数或其它窗口管理函数 
        public const int POWER = 0x0048; //（适用于16位的windows）当系统将要进入暂停状态时发送此消息 
        public const int COPYDATA = 0x004A; //当一个应用程序传递数据给另一个应用程序时发送此消息 
        public const int CANCELJOURNAL = 0x004B; //当某个用户取消程序日志激活状态，提交此消息给程序 
        public const int NOTIFY = 0x004E; //当某个控件的某个事件已经发生或这个控件需要得到一些信息时，发送此消息给它的父窗口 
        public const int INPUTLANGCHANGEREQUEST = 0x0050; //当用户选择某种输入语言，或输入语言的热键改变 
        public const int INPUTLANGCHANGE = 0x0051; //当平台现场已经被改变后发送此消息给受影响的最顶级窗口 
        public const int TCARD = 0x0052; //当程序已经初始化windows帮助例程时发送此消息给应用程序 
        public const int HELP = 0x0053; //此消息显示用户按下了F1，如果某个菜单是激活的，就发送此消息个此窗口关联的菜单，否则就 
        //发送给有焦点的窗口，如果当前都没有焦点，就把此消息发送给当前激活的窗口 
        public const int USERCHANGED = 0x0054; //当用户已经登入或退出后发送此消息给所有的窗口，当用户登入或退出时系统更新用户的具体 
        //设置信息，在用户更新设置时系统马上发送此消息； 
        public const int NOTIFYformAT = 0x0055; //公用控件，自定义控件和他们的父窗口通过此消息来判断控件是使用ANSI还是UNICODE结构 
        //在NOTIFY消息，使用此控件能使某个控件与它的父控件之间进行相互通信 
        public const int CONTEXTMENU = 0x007B; //当用户某个窗口中点击了一下右键就发送此消息给这个窗口 
        public const int styleCHANGING = 0x007C; //当调用SETWINDOWLONG函数将要改变一个或多个窗口的风格时发送此消息给那个窗口 
        public const int styleCHANGED = 0x007D; //当调用SETWINDOWLONG函数一个或多个窗口的风格后发送此消息给那个窗口 
        public const int DISPLAYCHANGE = 0x007E; //当显示器的分辨率改变后发送此消息给所有的窗口 
        public const int GETICON = 0x007F; //此消息发送给某个窗口来返回与某个窗口有关连的大图标或小图标的句柄； 
        public const int SETICON = 0x0080; //程序发送此消息让一个新的大图标或小图标与某个窗口关联； 
        public const int NCCREATE = 0x0081; //当某个窗口第一次被创建时，此消息在CREATE消息发送前发送； 
        public const int NCDESTROY = 0x0082; //此消息通知某个窗口，非客户区正在销毁 
        public const int NCCALCSIZE = 0x0083; //当某个窗口的客户区域必须被核算时发送此消息 
        public const int NCHITTEST = 0x0084; //移动鼠标，按住或释放鼠标时发生 
        public const int NCPAINT = 0x0085; //程序发送此消息给某个窗口当它（窗口）的框架必须被绘制时； 
        public const int NCACTIVATE = 0x0086; //此消息发送给某个窗口仅当它的非客户区需要被改变来显示是激活还是非激活状态； 
        public const int GETDLGCODE = 0x0087; //发送此消息给某个与对话框程序关联的控件，widdows控制方位键和TAB键使输入进入此控件 
                                              //通过响应GETDLGCODE消息，应用程序可以把他当成一个特殊的输入控件并能处理它 

        /// <summary>
        /// 当光标在一个窗口的非客户区内移动时发送此消息给这个窗口
        /// (非客户区为：窗体的标题栏及窗的边框体)
        /// </summary>
        public const int NCMOUSEMOVE = 0x00A0;

        /// <summary>
        /// 在窗口非客户区按下鼠标左键
        /// </summary>
        public const int NCLBUTTONDOWN = 0x00A1; // 

        /// <summary>
        /// 在窗口非客户区释放鼠标左键
        /// </summary>
        public const int NCLBUTTONUP = 0x00A2;
         
        public const int NCLBUTTONDBLCLK = 0x00A3; //当用户双击鼠标左键同时光标某个窗口在非客户区十发送此消息 
        public const int NCRBUTTONDOWN = 0x00A4; //当用户按下鼠标右键同时光标又在窗口的非客户区时发送此消息 
        public const int NCRBUTTONUP = 0x00A5; //当用户释放鼠标右键同时光标又在窗口的非客户区时发送此消息 
        public const int NCRBUTTONDBLCLK = 0x00A6; //当用户双击鼠标右键同时光标某个窗口在非客户区十发送此消息 
        public const int NCMBUTTONDOWN = 0x00A7; //当用户按下鼠标中键同时光标又在窗口的非客户区时发送此消息 
        public const int NCMBUTTONUP = 0x00A8; //当用户释放鼠标中键同时光标又在窗口的非客户区时发送此消息 
        public const int NCMBUTTONDBLCLK = 0x00A9; //当用户双击鼠标中键同时光标又在窗口的非客户区时发送此消息 
        public const int KEYFIRST = 0x0100; // 
        public const int KEYDOWN = 0x0100; //按下一个键 
        public const int KEYUP = 0x0101; //释放一个键 
        public const int CHAR = 0x0102; //按下某键，并已发出KEYDOWN，KEYUP消息 
        public const int DEADCHAR = 0x0103; //当用translatemessage函数翻译KEYUP消息时发送此消息给拥有焦点的窗口 
        public const int SYSKEYDOWN = 0x0104; //当用户按住ALT键同时按下其它键时提交此消息给拥有焦点的窗口； 
        public const int SYSKEYUP = 0x0105; //当用户释放一个键同时ALT 键还按着时提交此消息给拥有焦点的窗口 
        public const int SYSCHAR = 0x0106; //当SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后提交此消息给拥有焦点的窗口 
        public const int SYSDEADCHAR = 0x0107; //当SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后发送此消息给拥有焦点的窗口 
        public const int KEYLAST = 0x0108; // 
        public const int INITDIALOG = 0x0110; //在一个对话框程序被显示前发送此消息给它，通常用此消息初始化控件和执行其它任务 
        public const int COMMAND = 0x0111; //当用户选择一条菜单命令项或当某个控件发送一条消息给它的父窗口，一个快捷键被翻译 
        public const int SYSCOMMAND = 0x0112; //当用户选择窗口菜单的一条命令或当用户选择最大化或最小化时那个窗口会收到此消息 
        public const int TIMER = 0x0113; //发生了定时器事件 
        public const int HSCROLL = 0x0114; //当一个窗口标准水平滚动条产生一个滚动事件时发送此消息给那个窗口，也发送给拥有它的控件 
        public const int VSCROLL = 0x0115; //当一个窗口标准垂直滚动条产生一个滚动事件时发送此消息给那个窗口也，发送给拥有它的控件INITMENU = 0x0116; // 
        //当一个菜单将要被激活时发送此消息，它发生在用户菜单条中的某项或按下某个菜单键，它允许 
        //程序在显示前更改菜单 
        public const int INITMENUPOPUP = 0x0117; //当一个下拉菜单或子菜单将要被激活时发送此消息，它允许程序在它显示前更改菜单，而不要 
        // 改变全部 
        public const int MENUSELECT = 0x011F; //当用户选择一条菜单项时发送此消息给菜单的所有者（一般是窗口） 
        public const int MENUCHAR = 0x0120; //当菜单已被激活用户按下了某个键（不同于加速键），发送此消息给菜单的所有者； 
        public const int ENTERIDLE = 0x0121; //当一个模态对话框或菜单进入空载状态时发送此消息给它的所有者，一个模态对话框或菜单进入空载状态就是在处理完一条或几条先前的消息后没有消息它的列队中等待 
        public const int MENURBUTTONUP = 0x0122; // 
        public const int MENUDRAG = 0x0123; // 
        public const int MENUGETOBJECT = 0x0124; // 
        public const int UNINITMENUPOPUP = 0x0125; // 
        public const int MENUCOMMAND = 0x0126; // 
        public const int CHANGEUISTATE = 0x0127; // 
        public const int UPDATEUISTATE = 0x0128; // 
        public const int QUERYUISTATE = 0x0129; // 
        public const int CTLCOLORMSGBOX = 0x0132; //在windows绘制消息框前发送此消息给消息框的所有者窗口，通过响应这条消息，所有者窗口可以 
        //通过使用给定的相关显示设备的句柄来设置消息框的文本和背景颜色 
        public const int CTLCOLOREDIT = 0x0133; //当一个编辑型控件将要被绘制时发送此消息给它的父窗口；通过响应这条消息，所有者窗口可以 
        //通过使用给定的相关显示设备的句柄来设置编辑框的文本和背景颜色 
        public const int CTLCOLORLISTBOX = 0x0134; //当一个列表框控件将要被绘制前发送此消息给它的父窗口；通过响应这条消息，所有者窗口可以 
        //通过使用给定的相关显示设备的句柄来设置列表框的文本和背景颜色 
        public const int CTLCOLORBTN = 0x0135; //当一个按钮控件将要被绘制时发送此消息给它的父窗口；通过响应这条消息，所有者窗口可以 
        //通过使用给定的相关显示设备的句柄来设置按纽的文本和背景颜色 
        public const int CTLCOLORDLG = 0x0136; //当一个对话框控件将要被绘制前发送此消息给它的父窗口；通过响应这条消息，所有者窗口可以 
        //通过使用给定的相关显示设备的句柄来设置对话框的文本背景颜色 
        public const int CTLCOLORSCROLLBAR = 0x0137; //当一个滚动条控件将要被绘制时发送此消息给它的父窗口；通过响应这条消息，所有者窗口可以 
        //通过使用给定的相关显示设备的句柄来设置滚动条的背景颜色 
        public const int CTLCOLORSTATIC = 0x0138; //当一个静态控件将要被绘制时发送此消息给它的父窗口；通过响应这条消息，所有者窗口可以 
        //通过使用给定的相关显示设备的句柄来设置静态控件的文本和背景颜色 
        public const int MOUSEFIRST = 0x0200; // 
        public const int MOUSEMOVE = 0x0200; //移动鼠标 
        public const int LBUTTONDOWN = 0x0201; //按下鼠标左键 
        public const int LBUTTONUP = 0x0202; //释放鼠标左键 
        public const int LBUTTONDBLCLK = 0x0203; //双击鼠标左键 
        public const int RBUTTONDOWN = 0x0204; //按下鼠标右键 
        public const int RBUTTONUP = 0x0205; //释放鼠标右键 
        public const int RBUTTONDBLCLK = 0x0206; //双击鼠标右键 
        public const int MBUTTONDOWN = 0x0207; //按下鼠标中键 
        public const int MBUTTONUP = 0x0208; //释放鼠标中键 
        public const int MBUTTONDBLCLK = 0x0209; //双击鼠标中键 
        public const int MOUSEWHEEL = 0x020A; //当鼠标轮子转动时发送此消息个当前有焦点的控件 
        public const int MOUSELAST = 0x020A; // 
        public const int PARENTNOTIFY = 0x0210; //当MDI子窗口被创建或被销毁，或用户按了一下鼠标键而光标在子窗口上时发送此消息给它的父窗口 
        public const int ENTERMENULOOP = 0x0211; //发送此消息通知应用程序的主窗口that已经进入了菜单循环模式 
        public const int EXITMENULOOP = 0x0212; //发送此消息通知应用程序的主窗口that已退出了菜单循环模式 
        public const int NEXTMENU = 0x0213; // 
        public const int SIZING = 532; //当用户正在调整窗口大小时发送此消息给窗口；通过此消息应用程序可以监视窗口大小和位置
        //也可以修改他们 
        public const int CAPTURECHANGED = 533; //发送此消息给窗口当它失去捕获的鼠标时； 
        public const int MOVING = 534; //当用户在移动窗口时发送此消息，通过此消息应用程序可以监视窗口大小和位置 
        //也可以修改他们； 
        public const int POWERBROADCAST = 536; //此消息发送给应用程序来通知它有关电源管理事件； 
        public const int DEVICECHANGE = 537; //当设备的硬件配置改变时发送此消息给应用程序或设备驱动程序 
        public const int IME_STARTCOMPOSITION = 0x010D; // 
        public const int IME_ENDCOMPOSITION = 0x010E; // 
        public const int IME_COMPOSITION = 0x010F; // 
        public const int IME_KEYLAST = 0x010F; // 
        public const int IME_SETCONTEXT = 0x0281; // 
        public const int IME_NOTIFY = 0x0282; // 
        public const int IME_CONTROL = 0x0283; // 
        public const int IME_COMPOSITIONFULL = 0x0284; // 
        public const int IME_SELECT = 0x0285; // 
        public const int IME_CHAR = 0x0286; // 
        public const int IME_REQUEST = 0x0288; // 
        public const int IME_KEYDOWN = 0x0290; // 
        public const int IME_KEYUP = 0x0291; // 
        public const int MDICREATE = 0x0220; //应用程序发送此消息给多文档的客户窗口来创建一个MDI 子窗口 
        public const int MDIDESTROY = 0x0221; //应用程序发送此消息给多文档的客户窗口来关闭一个MDI 子窗口 
        public const int MDIACTIVATE = 0x0222; //应用程序发送此消息给多文档的客户窗口通知客户窗口激活另一个MDI子窗口，当客户窗口收到 
        //此消息后，它发出MDIACTIVE消息给MDI子窗口（未激活）激活它； 
        public const int MDIRESTORE = 0x0223; //程序发送此消息给MDI客户窗口让子窗口从最大最小化恢复到原来大小 
        public const int MDINEXT = 0x0224; //程序发送此消息给MDI客户窗口激活下一个或前一个窗口 
        public const int MDIMAXIMIZE = 0x0225; //程序发送此消息给MDI客户窗口来最大化一个MDI子窗口； 
        public const int MDITILE = 0x0226; //程序发送此消息给MDI客户窗口以平铺方式重新排列所有MDI子窗口 
        public const int MDICASCADE = 0x0227; //程序发送此消息给MDI客户窗口以层叠方式重新排列所有MDI子窗口 
        public const int MDIICONARRANGE = 0x0228; //程序发送此消息给MDI客户窗口重新排列所有最小化的MDI子窗口 
        public const int MDIGETACTIVE = 0x0229; //程序发送此消息给MDI客户窗口来找到激活的子窗口的句柄 
        public const int MDISETMENU = 0x0230; //程序发送此消息给MDI客户窗口用MDI菜单代替子窗口的菜单 
        public const int ENTERSIZEMOVE = 0x0231; // 
        public const int EXITSIZEMOVE = 0x0232; // 
        public const int DROPFILES = 0x0233; // 
        public const int MDIREFRESHMENU = 0x0234; // 
        public const int MOUSEHOVER = 0x02A1; // 
        public const int MOUSELEAVE = 0x02A3; // 
        public const int CUT = 0x0300; //程序发送此消息给一个编辑框或combobox来删除当前选择的文本 
        public const int COPY = 0x0301; //程序发送此消息给一个编辑框或combobox来复制当前选择的文本到剪贴板 
        public const int PASTE = 0x0302; //程序发送此消息给editcontrol或combobox从剪贴板中得到数据 
        public const int CLEAR = 0x0303; //程序发送此消息给editcontrol或combobox清除当前选择的内容； 
        public const int UNDO = 0x0304; //程序发送此消息给editcontrol或combobox撤消最后一次操作 
        public const int RENDERformAT = 0x0305; // 
        public const int RENDERALLformATS = 0x0306; // 
        public const int DESTROYCLIPBOARD = 0x0307; //当调用ENPTYCLIPBOARD函数时发送此消息给剪贴板的所有者 
        public const int DRAWCLIPBOARD = 0x0308; //当剪贴板的内容变化时发送此消息给剪贴板观察链的第一个窗口；它允许用剪贴板观察窗口来 
        //显示剪贴板的新内容； 
        public const int PAINTCLIPBOARD = 0x0309; //当剪贴板包含CF_OWNERDIPLAY格式的数据并且剪贴板观察窗口的客户区需要重画； 
        public const int VSCROLLCLIPBOARD = 0x030A; // 
        public const int SIZECLIPBOARD = 0x030B; //当剪贴板包含CF_OWNERDIPLAY格式的数据并且剪贴板观察窗口的客户区域的大小已经改变是此消息通过剪贴板观察窗口发送给剪贴板的所有者； 
        public const int ASKCBformATNAME = 0x030C; //通过剪贴板观察窗口发送此消息给剪贴板的所有者来请求一个CF_OWNERDISPLAY格式的剪贴板的名字 
        public const int CHANGECBCHAIN = 0x030D; //当一个窗口从剪贴板观察链中移去时发送此消息给剪贴板观察链的第一个窗口； 
        public const int HSCROLLCLIPBOARD = 0x030E; // 
        //此消息通过一个剪贴板观察窗口发送给剪贴板的所有者；它发生在当剪贴板包含CFOWNERDISPALY格式的数据并且有个事件在剪贴板观察窗的水平滚动条上；所有者应滚动剪贴板图象并更新滚动条的值； 
        public const int QUERYNEWPALETTE = 0x030F; //此消息发送给将要收到焦点的窗口，此消息能使窗口在收到焦点时同时有机会实现他的逻辑调色板 
        public const int PALETTEISCHANGING = 0x0310; //当一个应用程序正要实现它的逻辑调色板时发此消息通知所有的应用程序 
        public const int PALETTECHANGED = 0x0311; //此消息在一个拥有焦点的窗口实现它的逻辑调色板后发送此消息给所有顶级并重叠的窗口，以此 
        //来改变系统调色板 
        public const int HOTKEY = 0x0312; //当用户按下由REGISTERHOTKEY函数注册的热键时提交此消息 
        public const int PRINT = 791; //应用程序发送此消息仅当WINDOWS或其它应用程序发出一个请求要求绘制一个应用程序的一部分； 
        public const int PRINTCLIENT = 792; // 
        public const int HANDHELDFIRST = 856; // 
        public const int HANDHELDLAST = 863; // 
        public const int PENWINFIRST = 0x0380; // 
        public const int PENWINLAST = 0x038F; // 
        public const int COALESCE_FIRST = 0x0390; // 
        public const int COALESCE_LAST = 0x039F; // 
        public const int DDE_FIRST = 0x03E0; // 
        public const int DDE_INITIATE = DDE_FIRST + 0; //一个DDE客户程序提交此消息开始一个与服务器程序的会话来响应那个指定的程序和主题名； 
        public const int DDE_TERMINATE = DDE_FIRST + 1; //一个DDE应用程序（无论是客户还是服务器）提交此消息来终止一个会话； 
        public const int DDE_ADVISE = DDE_FIRST + 2; //一个DDE客户程序提交此消息给一个DDE服务程序来请求服务器每当数据项改变时更新它 
        public const int DDE_UNADVISE = DDE_FIRST + 3; //一个DDE客户程序通过此消息通知一个DDE服务程序不更新指定的项或一个特殊的剪贴板格式的项 
        public const int DDE_ACK = DDE_FIRST + 4; //此消息通知一个DDE（动态数据交换）程序已收到并正在处理DDE_POKE, DDE_EXECUTE, DDE_DATA, DDE_ADVISE, DDE_UNADVISE, or DDE_INITIAT消息 
        public const int DDE_DATA = DDE_FIRST + 5; //一个DDE服务程序提交此消息给DDE客户程序来传递个一数据项给客户或通知客户的一条可用数据项 
        public const int DDE_REQUEST = DDE_FIRST + 6; //一个DDE客户程序提交此消息给一个DDE服务程序来请求一个数据项的值； 
        public const int DDE_POKE = DDE_FIRST + 7; //一个DDE客户程序提交此消息给一个DDE服务程序，客户使用此消息来请求服务器接收一个未经同意的数据项；服务器通过答复DDE_ACK消息提示是否它接收这个数据项； 
        public const int DDE_EXECUTE = DDE_FIRST + 8; //一个DDE客户程序提交此消息给一个DDE服务程序来发送一个字符串给服务器让它象串行命令一样被处理，服务器通过提交DDE_ACK消息来作回应； 
        public const int DDE_LAST = DDE_FIRST + 8; // 
        public const int APP = 0x8000; // 
        public const int USER = 0x0400; //此消息能帮助应用程序自定义私有消息；

        ///////////////////////////////////////////////////////////////////// 
        //通知消息(Notification message)是指这样一种消息，一个窗口内的子控件发生了一些事情，需要通 
        //知父窗口。通知消息只适用于标准的窗口控件如按钮、列表框、组合框、编辑框，以及Windows 95公 
        //共控件如树状视图、列表视图等。例如，单击或双击一个控件、在控件中选择部分文本、操作控件的 
        //滚动条都会产生通知消息。

        //按扭 
        //public const int BN_CLICKED //用户单击了按钮 
        //public const int BN_DISABLE //按钮被禁止 
        //public const int BN_DOUBLECLICKED //用户双击了按钮 
        //public const int BN_HILITE //用户加亮了按钮 
        //public const int BN_PAINT //按钮应当重画 
        //public const int BN_UNHILITE //加亮应当去掉
        ////组合框 
        //public const int CBN_CLOSEUP //组合框的列表框被关闭 
        //public const int CBN_DBLCLK //用户双击了一个字符串 
        //public const int CBN_DROPDOWN //组合框的列表框被拉出 
        //public const int CBN_EDITCHANGE //用户修改了编辑框中的文本 
        //public const int CBN_EDITUPDATE //编辑框内的文本即将更新 
        //public const int CBN_ERRSPACE //组合框内存不足 
        //public const int CBN_KILLFOCUS //组合框失去输入焦点 
        //public const int CBN_SELCHANGE //在组合框中选择了一项 
        //public const int CBN_SELENDCANCEL //用户的选择应当被取消 
        //public const int CBN_SELENDOK //用户的选择是合法的 
        //public const int CBN_SETFOCUS //组合框获得输入焦点
        ////编辑框 
        //public const int EN_CHANGE //编辑框中的文本己更新 
        //public const int EN_ERRSPACE //编辑框内存不足 
        //public const int EN_HSCROLL //用户点击了水平滚动条 
        //public const int EN_KILLFOCUS //编辑框正在失去输入焦点 
        //public const int EN_MAXTEXT //插入的内容被截断 
        //public const int EN_SETFOCUS //编辑框获得输入焦点 
        //public const int EN_UPDATE //编辑框中的文本将要更新 
        //public const int EN_VSCROLL //用户点击了垂直滚动条消息含义

        //    //列表框 
        //public const int LBN_DBLCLK //用户双击了一项 
        //public const int LBN_ERRSPACE //列表框内存不够 
        //public const int LBN_KILLFOCUS //列表框正在失去输入焦点 
        //public const int LBN_SELCANCEL //选择被取消 
        //public const int LBN_SELCHANGE //选择了另一项 
        //public const int LBN_SETFOCUS //列表框获得输入焦点
    }
}
