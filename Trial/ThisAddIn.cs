using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Net;
using System.Diagnostics;
namespace Trial
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
        
            Outlook.MAPIFolder MyFolder = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            MyFolder.Items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(NewMail);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }

        private void NewMail(Object Item)
        {
            Outlook.MailItem IncomingMail;
            IncomingMail = (Outlook.MailItem)Item;

            //  System.IO.File.WriteLine(@"C:\Users\David\Documents\MEGA\4thYr\appprj\Project\WriteLines8.txt","tumian");
            var client = new WebClient();

            var subject = IncomingMail.Subject;
            var sender = IncomingMail.SenderEmailAddress;

            var url = "http://localhost:8000/server/Contexto/ContextRequests.php?cmd=4&mailSubject="+subject+"&mailSender="+sender;

            string requestResult = client.DownloadString(url);

            IncomingMail.Categories = requestResult;

            Debug.WriteLine("Email Context is....");

            Debug.WriteLine(requestResult);



            
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
