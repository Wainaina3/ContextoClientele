using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Trial
{
    public partial class newContextForm : Form
    {
        public newContextForm()
        {
            InitializeComponent();
        }

        private void newContextForm_Load(object sender, EventArgs e)
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

            //Type colorType = typeof(System.Drawing.Color);
            //PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
            //                               BindingFlags.DeclaredOnly | BindingFlags.Public);


          //  Debug.Write("The names of the Days Enum are:");
            foreach (string str in Enum.GetNames(typeof(Outlook.OlCategoryColor)))
            {
                //Check whether the color is in the exclusion color list
                if (!ExclusionColorList.Contains(str))
                {
                    this.contextColors.Items.Add(str.Remove(0, 15));
                }
            }


            //foreach (PropertyInfo c in propInfoList)
           // {
               // this.contextColors.Items.Add(c.Name);
         //   }

            // Hook up the MeasureItem and DrawItem events
            this.contextColors.DrawItem +=
                new DrawItemEventHandler(comboBox1_DrawItem);
            this.contextColors.MeasureItem +=
                new MeasureItemEventHandler(comboBox1_MeasureItem);
           
        }
        // You must handle the DrawItem event for owner-drawn combo boxes.  
        // This event handler changes the color, size and font of an 
        // item based on its position in the array.
        private void comboBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5,
                                rect.Width - 10, rect.Height - 10);
            }
        }

        // If you set the Draw property to DrawMode.OwnerDrawVariable, 
        // you must handle the MeasureItem event. This event handler 
        // will set the height and width of each item before it is drawn. 
        private void comboBox1_MeasureItem(object sender,System.Windows.Forms.MeasureItemEventArgs e)
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

        private void colorpicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void saveContext_Click(object sender, EventArgs e)
        {
            //Fetch context name from user textbox
            string newContext = this.newContext.Text;
            //Get selected color from a dropdown
            string colorName = this.contextColors.SelectedItem.ToString();
            //Save the new context in the database
            var client = new WebClient();
            var url = "http://localhost:8000/server/Contexto/ContextRequests.php?cmd=1&context=" + newContext + "&contextColor=" + colorName;
            string requestResult = client.DownloadString(url);

            //Declare an outlook category color
            Outlook.OlCategoryColor categoryColorName = Outlook.OlCategoryColor.olCategoryColorNone;

            //check the existence of selected color in the outlook category colors enumeration
            foreach (Outlook.OlCategoryColor olcateColor in Enum.GetValues(typeof(Outlook.OlCategoryColor)))
            {
                string str = olcateColor.ToString();
           
                if (str.Contains(colorName))
                {
                     categoryColorName = olcateColor;
                }

             }

            //create the category and assign the color
            Outlook.Categories categories = Globals.ThisAddIn.Application.Session.Categories;
            //check if category exists
            if (!CategoryExists(newContext))
            {
                //if not, create outlook category
                Outlook.Category category = categories.Add(newContext, categoryColorName);
                createCustomFolder(newContext);
            }
            //close form after saving
            this.Close();

        }
        private bool CategoryExists(string categoryName)
        {
            try
            {
                Outlook.Category category =
                    Globals.ThisAddIn.Application.Session.Categories[categoryName];
                if (category != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createCustomFolder( string newFolderName)
        {
            Outlook.MAPIFolder inBox = Globals.ThisAddIn.Application.ActiveExplorer().Session.GetDefaultFolder
                (Outlook.OlDefaultFolders.olFolderInbox);
            Outlook.MAPIFolder newContextFolder = null;
            try
            {
                newContextFolder = inBox.Folders.Add(newFolderName,
                    Outlook.OlDefaultFolders.olFolderInbox);
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }
    }
}
