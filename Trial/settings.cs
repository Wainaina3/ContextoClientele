using Microsoft.Office.Tools.Ribbon;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Trial
{
    public partial class settings : Form
    {
     
        public object Factory { get; private set; }

        public settings()
        {
            InitializeComponent();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            initializeContextColors();
          
            initializeContextCheckList();

            this.contexts.ItemCheck += new ItemCheckEventHandler(contexts_ItemCheck);

        }

        private void initializeContextCheckList()
        {
                        
            var client = new WebClient();
            var url = "http://localhost:8000/server/Contexto/ContextRequests.php?cmd=13";
            try
            {
                string jsonResult = client.DownloadString(url);
            
                JObject obj = JObject.Parse(jsonResult);

                if ((int)obj["result"] == 1)
                {
                    JArray contextArray = (JArray)obj["contexts"];

                    for (var i = 0; i < contextArray.Count; i++)
                    {
                        JObject context = (JObject)contextArray[i];

                        string contextName = context["context"].ToString();
                       var  contextColorName = context["context_color"].ToString();

                        this.contexts.Items.Add(contextName);

                       
                    }
                }
                else
                {
                    // Debug.Write("The result was not 1\n");
                }

            }
            catch (Exception ex)
            {
                //remember to remove this one later
                Debug.Write(ex.Message);
            }


        }


        private void initializeContextColors()
        {
            ArrayList ExclusionColorList = new ArrayList();
            ExclusionColorList.Add(Outlook.OlCategoryColor.olCategoryColorDarkMaroon.ToString());
            ExclusionColorList.Add(Outlook.OlCategoryColor.olCategoryColorDarkPurple.ToString());
            ExclusionColorList.Add(Outlook.OlCategoryColor.olCategoryColorDarkSteel.ToString());
            ExclusionColorList.Add(Outlook.OlCategoryColor.olCategoryColorDarkTeal.ToString());
            ExclusionColorList.Add(Outlook.OlCategoryColor.olCategoryColorSteel.ToString());
            ExclusionColorList.Add(Outlook.OlCategoryColor.olCategoryColorPeach.ToString());
            ExclusionColorList.Add(Outlook.OlCategoryColor.olCategoryColorDarkYellow.ToString());
            ExclusionColorList.Add(Outlook.OlCategoryColor.olCategoryColorDarkPeach.ToString());
            ExclusionColorList.Add(Outlook.OlCategoryColor.olCategoryColorDarkPurple.ToString());
            ExclusionColorList.Add(Outlook.OlCategoryColor.olCategoryColorDarkOlive.ToString());

            //  Debug.Write("The names of the Days Enum are:");
            foreach (string str in Enum.GetNames(typeof(Outlook.OlCategoryColor)))
            {
                //Check whether the color is in the exclusion color list
                if (!ExclusionColorList.Contains(str))
                {
                    this.contextColor.Items.Add(str.Remove(0, 15));
                }
            }



            // Hook up the MeasureItem and DrawItem events
            this.contextColor.DrawItem +=
                new DrawItemEventHandler(contextColor_DrawItem);
            this.contextColor.MeasureItem +=
                new MeasureItemEventHandler(contextColor_MeasureItem);
        }
        // You must handle the DrawItem event for owner-drawn combo boxes.  
        // This event handler changes the color, size and font of an 
        // item based on its position in the array.
        private void contextColor_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
           // Debug.Write("Items drawn\n");
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
             ///   g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 5, rect.Y + 5,
                                rect.Width - 10, rect.Height - 10);
            }
        }

        // If you set the Draw property to DrawMode.OwnerDrawVariable, 
        // you must handle the MeasureItem event. This event handler 
        // will set the height and width of each item before it is drawn. 
        private void contextColor_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
        {

            switch (e.Index)
            {
                case 0:
                    e.ItemHeight = 45;
                    break;
                case 1:
                    e.ItemHeight = 20;
                    break;
                case 2:
                    e.ItemHeight = 35;
                    break;
            }
            e.ItemWidth = 260;

        }

        private void newContextbtn_Click(object sender, EventArgs e)
        {
            newContextForm newContext = new newContextForm();

            newContext.Show();
        }

        private void contexts_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < contexts.Items.Count; ++ix)
                    if (e.Index != ix) contexts.SetItemChecked(ix, false);
        }


        private void contexts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
