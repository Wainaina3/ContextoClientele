using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Net;
using System.Windows.Forms;

namespace Contexto

{
    public partial class ThisAddIn
    {
        Outlook.NameSpace outlookNameSpace;
        Outlook.MAPIFolder inbox;
        Outlook.Items items;
        Outlook.Inspectors inspectors;

        Context contextAnalysis=new Context();  //declare a Context class object

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
           // MessageBox.Show("Worked");

            var client = new WebClient();
            var url = "http://10.10.30.168:8000/server/Contexto/ContextRequests.php?cmd=6";
            string requestResult = client.DownloadString(url);
            toFile();
            inspectors = this.Application.Inspectors;
            inspectors.NewInspector +=
            new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);

            outlookNameSpace = this.Application.GetNamespace("MAPI");
            inbox = outlookNameSpace.GetDefaultFolder(
                    Microsoft.Office.Interop.Outlook.
                    OlDefaultFolders.olFolderInbox);

            items = inbox.Items;
            items.ItemAdd +=
                new Outlook.ItemsEvents_ItemAddEventHandler(items_ItemAdd);

           
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
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

        private void items_ItemAdd(object Item)
        {
            toFile();
            Outlook.MailItem mail = (Outlook.MailItem)Item;
            if (Item != null)
            {
                // Send the subject and body of this email to Context class for analysis.
                contextAnalysis.setEmailBody(mail.Body);
                contextAnalysis.setEmailSubject(mail.Subject);
                contextAnalysis.setEmailSender(mail.SenderName);

                // This method will send request to server for analysis.

                var client = new WebClient();
                var url = "http://10.10.26.53:8000/server/Contexto/ContextRequests.php?cmd=1&mailSubject=movie&mailSender=george";
                string requestResult = client.DownloadString(url);
                contextAnalysis.sendRequest();
            }
        }

        void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {
            Outlook.MailItem mailItem = Inspector.CurrentItem as Outlook.MailItem;
            if (mailItem != null)
            {
                if (mailItem.EntryID == null)
                {
                    mailItem.Subject = "This text was added by using code";
                    mailItem.Body = "This text was added by using code";
                }

            }
        }

        public void toFile()
        {
            string[] lines = { "First line", "Second line", "Third line" };
            // Example #3: Write only some strings in an array to a file.
            // The using statement automatically flushes AND CLOSES the stream and calls 
            // IDisposable.Dispose on the stream object.
            // NOTE: do not use FileStream for text files because it writes bytes, but StreamWriter
            // encodes the output as text.
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\David\Documents\MEGA\4thYr\appprj\Project\WriteLines2.txt"))
            {
                foreach (string line in lines)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.
                    if (!line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                }
            }

        }

        public static void main(String[] args)
        {
           
        }
    }
}
