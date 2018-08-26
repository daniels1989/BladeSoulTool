using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using BladeSoulTool.lib;
using BladeSoulTool.ui;

namespace BladeSoulTool
{
    public partial class App : Form
    {
        private static App _instance;

        public static App Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new App();
                }
                return _instance;
            }
        }

        private Form _formCostume;
        private Form _formAttach;
        private Form _formWeapon;
        private Form _formUtil;

        private BstI18NLoader _i18N;

        private App()
        {
            InitializeComponent();

            // 初始化数据
            var dataManager = BstManager.Instance;
            // 初始化icon图片加载器
            var loader = BstIconLoader.Instance;
            // 检查新版本
            //this.CheckNewVersion();
            // 检查游戏安装路径设置
            this.CheckBnsGamePath();

            this.InitI18N();
            this.Init();
        }

        private void InitI18N()
        {
            this._i18N = BstI18NLoader.Instance;
            this.tabCostume.Text = this._i18N.LoadI18NValue("App", "tabCostume");
            this.tabAttach.Text = this._i18N.LoadI18NValue("App", "tabAttach");
            this.tabWeapon.Text = this._i18N.LoadI18NValue("App", "tabWeapon");
            this.tabUtil.Text = this._i18N.LoadI18NValue("App", "tabUtil");
            this.Text = this._i18N.LoadI18NValue("App", "title");
        }

        private void Init()
        {
            BstLogger.Instance.Log("[App] BladeSoulTool App start ...");
            // 初始化第一个tab，costume
            this._formCostume = CreateItemsForm(BstManager.TypeCostume);
            this.tabCostume.Controls.Add(this._formCostume);
            // 注册tab切换事件
            this.tabControl.SelectedIndexChanged += new EventHandler(tabControl_SelectedIndexChanged);
        }

        private void CheckBnsGamePath()
        {
            new Thread(() =>
            {
                var gamePath = (string) BstManager.Instance.SystemSettings["path"]["game"];
                if (!Directory.Exists(gamePath) || !File.Exists(gamePath + "/bin/Client.exe"))
                {
                    // 游戏地址配置不存在或不正确，更新为null
                    BstManager.Instance.SystemSettings["path"]["game"] = null;
                    BstManager.WriteJsonFile(BstManager.PathJsonSettings, BstManager.Instance.SystemSettings);
                    BstManager.DisplayErrorMessageBox(
                        BstI18NLoader.Instance.LoadI18NValue("App", "gamePathErrTitle"),
                        BstI18NLoader.Instance.LoadI18NValue("App", "gamePathErrContent")
                    );
                }
            }).Start();
        }

        private void CheckNewVersion()
        {
            var currentVer = (string) BstManager.Instance.SystemSettings["version"];
            new Thread(() =>
            {
                var releasedVer = BstManager.GetStringFromWeb(BstManager.GithubVersionTxt);
                // releasedVer是从网络下载的，在网络无法访问或下载失败的情况下，可能为null，需要做验证
                if (!String.IsNullOrEmpty(releasedVer) && currentVer != releasedVer)
                {
                    var result = BstManager.DisplayConfirmMessageBox(
                        this._i18N.LoadI18NValue("App", "newVerTitle"),
                        string.Format(
                            this._i18N.LoadI18NValue("App", "newVerContent"),
                            currentVer,
                            releasedVer,
                            BstI18NLoader.Instance.LoadI18NValue("App", "releaseSiteUrl"))
                    );
                    if (result == DialogResult.OK)
                    {
                        Process.Start(BstI18NLoader.Instance.LoadI18NValue("App", "releaseSiteUrl"));
                    }
                }
            }).Start();
        }

        private void tabControl_SelectedIndexChanged(Object sender, EventArgs e)
        {
            BstLogger.Instance.Log("[App] Switch to tab: " + this.tabControl.SelectedIndex);
            switch (this.tabControl.SelectedIndex)
            {
                case BstManager.TypeCostume:
                    if (this._formCostume == null) 
                    {
                        this._formCostume = App.CreateItemsForm(BstManager.TypeCostume);
                        this.tabCostume.Controls.Add(this._formCostume);
                    }
                    break;
                case BstManager.TypeAttach:
                    if (this._formAttach == null)
                    {
                        this._formAttach = App.CreateItemsForm(BstManager.TypeAttach);
                        this.tabAttach.Controls.Add(this._formAttach);
                    }
                    break;
                case BstManager.TypeWeapon:
                    if (this._formWeapon == null)
                    {
                        this._formWeapon = App.CreateItemsForm(BstManager.TypeWeapon);
                        this.tabWeapon.Controls.Add(this._formWeapon);
                    }
                    break;
                case BstManager.TypeUtil:
                    if (this._formUtil == null)
                    {
                        this._formUtil = App.CreateUtilForm();
                        this.tabUtil.Controls.Add(this._formUtil);
                    }
                    break;
                default:
                    break;
            }
        }

        private static Form CreateItemsForm(int type)
        {
            return App.CreateFormAttr(new GuiItems(type));
        }

        private static Form CreateUtilForm()
        {
            return App.CreateFormAttr(new GuiUtil());
        }

        private static Form CreateFormAttr(Form form)
        {
            form.TopLevel = false;
            form.Visible = true;
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;
            form.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

            return form;
        }
    }
}
