using System;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Trial
{
    public partial class contexto
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
           
            this.loadContexts();
            


        }

        public void loadContexts()
        {

            var client = new WebClient();
            var url = "http://localhost:8000/server/Contexto/ContextRequests.php?cmd=13";
            try
            {
                string jsonResult = client.DownloadString(url);
          

               
                JObject obj = JObject.Parse(jsonResult);

             //   Debug.Write("After trying to convert\n");

              //  Debug.Write("The value of result request is "+ obj["result"].ToString());
               // Debug.Write("\nThe value of context array is " + obj["contexts"].ToString() + "\n");
                
                if ((int)obj["result"] == 1)
                {
                    JArray contextArray = (JArray)obj["contexts"];

                    for (var i = 0; i < contextArray.Count; i++)
                    {
                        JObject context = (JObject)contextArray[i];

                        RibbonToggleButton contextOption = this.Factory.CreateRibbonToggleButton();

                        Bitmap flag = new Bitmap(18, 18);

                        Graphics flagGraphics = Graphics.FromImage(flag);
                        Color color = Color.FromName(context["context_color"].ToString());
                        //print the context color
                       // Debug.Write(context["context_color"].ToString() + "\n");

                        Brush b = new SolidBrush(color);

                        flagGraphics.FillRectangle(b, 0, 0, 18, 18);
                        //print the context name
                       // Debug.Write(context["context"].ToString() + "\n");
                        contextOption.Label = context["context"].ToString();

                        contextOption.ShowImage = true;
                        contextOption.Image = flag;
                       
                        this.contextsMenu.Items.Add(contextOption);
                        contextOption.Click += new RibbonControlEventHandler(onSwitchingContext);

                    }
                }
                else
                {
                   // Debug.Write("The result was not 1\n");
                }

            } catch (Exception ex)
            {
                //remember to remove this one later
               Debug.Write(ex.Message);
            }

            RibbonSeparator separator = this.Factory.CreateRibbonSeparator();

            this.contextsMenu.Items.Add(separator);

            RibbonButton settings = this.Factory.CreateRibbonButton();

            settings.Name = "openSettings";
            settings.Label = "Contexts";
            settings.ShowLabel = true;


            settings.Click += new RibbonControlEventHandler(openSettings_Click);

            this.contextsMenu.Items.Add(settings);
            // this.contextsMenu.SuspendLayout();


          //  contextsMenu.DropDown.AutoClose = false;


        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            newContextForm frm = new newContextForm();
            frm.Show();
        }

        private void openSettings_Click(object sender, RibbonControlEventArgs e)
        {
            settings settingsForm = new settings();

            settingsForm.Show();
        }

        private void myMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show((sender as MenuItem).Text);
        }

        private void onSwitchingContext(object sender, RibbonControlEventArgs e)
        {
            RibbonToggleButton selectedContext = (RibbonToggleButton)sender;

           // Debug.WriteLine(selectedContext.Label + " The lable of selected context");
            string newcontext = selectedContext.Label;

            Globals.ThisAddIn.EnumerateFoldersInDefaultStore(newcontext);
            var webclient = new WebClient();

            string updateContext = "http://localhost:8000/server/Contexto/ContextRequests.php?cmd=15&currentContext="+newcontext;
        }


     }

       
    
}
