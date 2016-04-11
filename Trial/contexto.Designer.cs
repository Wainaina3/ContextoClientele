namespace Trial
{
    partial class contexto : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public contexto()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.contextoGroup = this.Factory.CreateRibbonGroup();
            this.createContext = this.Factory.CreateRibbonButton();
            this.contextsMenu = this.Factory.CreateRibbonMenu();
            this.tab1.SuspendLayout();
            this.contextoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabMail";
            this.tab1.Groups.Add(this.contextoGroup);
            this.tab1.Label = "TabMail";
            this.tab1.Name = "tab1";
            // 
            // contextoGroup
            // 
            this.contextoGroup.Items.Add(this.createContext);
            this.contextoGroup.Items.Add(this.contextsMenu);
            this.contextoGroup.Label = "Contexto";
            this.contextoGroup.Name = "contextoGroup";
            // 
            // createContext
            // 
            this.createContext.Label = "new context";
            this.createContext.Name = "createContext";
            this.createContext.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // contextsMenu
            // 
            this.contextsMenu.Dynamic = true;
            this.contextsMenu.Image = global::Trial.Properties.Resources.contexto_logo;
            this.contextsMenu.Label = "contexts";
            this.contextsMenu.Name = "contextsMenu";
            this.contextsMenu.ShowImage = true;
            // 
            // contexto
            // 
            this.Name = "contexto";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.contextoGroup.ResumeLayout(false);
            this.contextoGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup contextoGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton createContext;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu contextsMenu;
    }

    partial class ThisRibbonCollection
    {
        internal contexto Ribbon1
        {
            get { return this.GetRibbon<contexto>(); }
        }
    }
}
