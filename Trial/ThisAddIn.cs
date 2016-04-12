using System;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

namespace Trial
{
    public partial class ThisAddIn
    {
        Outlook.Items mailItems = null;
        Outlook.MAPIFolder MyFolder = null;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // NotifyIcon outlookNotification = this.Application.NotifyIcon; 
           // Debug.WriteLine("Imeanza sasa");
            MyFolder = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            mailItems = MyFolder.Items;
            mailItems.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(NewMail);
            //SetCurrentFolder();
            // Application.ActiveExplorer().Close();
            //Get the current context from db and initialize it here;

            var getCurrentContext = new WebClient();
            var currentContextRequest= "http://localhost:8000/server/Contexto/ContextRequests.php?cmd=14";
            try
            {
                var currentContextResult = getCurrentContext.DownloadString(currentContextRequest);

                JObject currentContextJson = JObject.Parse(currentContextResult);

                if ((int)currentContextJson["result"] == 1)
                {
                    JObject currentContextObj = (JObject)currentContextJson["context"];

                    string currentContextName = currentContextObj["contextName"].ToString();
                  //  string currentContextColor = currentContextObj["contextColor"].ToString();
                    EnumerateFoldersInDefaultStore(currentContextName);
                }

            }
            catch (Exception ex)
            {
                
            }
          

        
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }

        private void NewMail(Object Item)
        {
           // Debug.WriteLine("A new email just came");
            Outlook.MailItem IncomingMail;
            IncomingMail = (Outlook.MailItem)Item;
            try
            {
                if(IncomingMail.Categories == null)
                {
                    //  System.IO.File.WriteLine(@"C:\Users\David\Documents\MEGA\4thYr\appprj\Project\WriteLines8.txt","tumian");
                    var client = new WebClient();

                    var subject = IncomingMail.Subject;
                    //  var sender = IncomingMail.SenderEmailAddress;
                    var mail_sender = GetSenderSMTPAddress(IncomingMail);

                    Debug.WriteLine(mail_sender);


                    var url = "http://localhost:8000/server/Contexto/ContextRequests.php?cmd=4&mailSubject=" + subject + "&mailSender=" + mail_sender;

                    try
                    {
                        string requestResult = client.DownloadString(url);

                        if (!requestResult.Equals("None"))
                        {
                            IncomingMail.Categories = requestResult;
                            Move_NewMail_To_ContextFolder(requestResult, IncomingMail);

                            Debug.WriteLine("Email Context is.... \n");

                            Debug.WriteLine(requestResult);
                        }
                        else
                        {
                            Outlook.MAPIFolder inBox = Application.ActiveExplorer().Session.GetDefaultFolder
                   (Outlook.OlDefaultFolders.olFolderInbox);
                            Outlook.Items items = inBox.Items;
                            Outlook.MailItem moveMail = null;


                            try
                            {
                                Outlook.MAPIFolder destFolder = inBox.Folders["Temp"];
                                moveToTempFolder(destFolder, moveMail);
                              //  moveMail.Move(destFolder);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                }
                else if (IncomingMail.Categories.Equals("None"))
                {
                    IncomingMail.Categories = "";
                }

            }
            catch( Exception nullEx)
            {

            }
         

        }
        private string GetSenderSMTPAddress(Outlook.MailItem mail)
        {
            string PR_SMTP_ADDRESS =
                @"http://schemas.microsoft.com/mapi/proptag/0x39FE001E";
            if (mail == null)
            {
                throw new ArgumentNullException();
            }
            if (mail.SenderEmailType == "EX")
            {
                Outlook.AddressEntry sender =
                    mail.Sender;
                if (sender != null)
                {
                    //Now we have an AddressEntry representing the Sender
                    if (sender.AddressEntryUserType ==
                        Outlook.OlAddressEntryUserType.
                        olExchangeUserAddressEntry
                        || sender.AddressEntryUserType ==
                        Outlook.OlAddressEntryUserType.
                        olExchangeRemoteUserAddressEntry)
                    {
                        //Use the ExchangeUser object PrimarySMTPAddress
                        Outlook.ExchangeUser exchUser =
                            sender.GetExchangeUser();
                        if (exchUser != null)
                        {
                            return exchUser.PrimarySmtpAddress;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return sender.PropertyAccessor.GetProperty(
                            PR_SMTP_ADDRESS) as string;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return mail.SenderEmailAddress;
            }
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        public void EnumerateFoldersInDefaultStore(string context)
        {
            Outlook.Folder root =
                Application.Session.
                DefaultStore.GetRootFolder() as Outlook.Folder;
            DisplayContextFolder(root,context);
        }

        // Uses recursion to enumerate Outlook subfolders.
        private void DisplayContextFolder(Outlook.Folder folder,string context)
        {
            Outlook.Folders childFolders =
                folder.Folders;
            if (childFolders.Count > 0)
            {
                foreach (Outlook.Folder childFolder in childFolders)
                {
                    // Write the folder path.
                  //  Debug.WriteLine(childFolder.FolderPath +" name is : " + childFolder.Name);
                    if (childFolder.Name.Equals(context))
                    {
                        Outlook.Explorer show = Application.ActiveExplorer();
                        Globals.ThisAddIn.Application.ActiveExplorer().CurrentFolder = childFolder;
                        show.Close();
                        childFolder.Display();
                      
                       //Debug.WriteLine(Globals.ThisAddIn.Application.ActiveExplorer().CurrentFolder.Name + "Active folder");
                        //Outlook.Explorer show = Application.ActiveExplorer();

                            // childFolder.Display();
                            //Marshal.ReleaseComObject(Application.ActiveExplorer());
                            //  Globals.ThisAddIn.Application.ActiveExplorer().CurrentFolder = MyFolder;

                            break;
                    }
                    // Call EnumerateFolders using childFolder.
                    //EnumerateFolders(childFolder);
                }
            }
        }

        //move items to their folders

        private void Move_NewMail_To_ContextFolder(string contextFolder,Object newMail)
        {
            Outlook.MAPIFolder inBox = Application.
                ActiveExplorer().Session.GetDefaultFolder
                (Outlook.OlDefaultFolders.olFolderInbox);

            Outlook.MailItem moveMail = (Outlook.MailItem)newMail;

          //  Outlook.MAPIFolder destFolder = inBox.Folders[contextFolder];

               
            Outlook.Folder root = Application.Session.DefaultStore.GetRootFolder() as Outlook.Folder;
            Outlook.Folders childFolders = root.Folders;
            Outlook.Folder tempFolder = null;
            if (childFolders.Count > 0)
            {
                foreach (Outlook.Folder destFolder in childFolders)
                {                 
                    if (destFolder.Name.Equals(contextFolder))
                    {
                        try
                        {
                            moveMail.Move(destFolder);
                        }
                        catch (Exception ex)
                        {
                           // MessageBox.Show(ex.Message);
                        }
                    }

                    if (destFolder.Name.Equals("Temp"))
                    {
                        tempFolder = destFolder;
                    }
                }
            }

            //move the email to temp folder
            //moveToTempFolder(tempFolder, moveMail);
        }

        private void moveToTempFolder(Outlook.MAPIFolder temp, Outlook.MailItem movingEmail)
        {
            movingEmail.Move(temp);
            movingEmail.Categories = "None";

            //move the email back to inbox after 2 minutes
            Outlook.MAPIFolder inBox = Application.ActiveExplorer().Session.GetDefaultFolder
                (Outlook.OlDefaultFolders.olFolderInbox);
            Outlook.Items items = inBox.Items;
            Outlook.MailItem moveMail = null;


            try
            {
                Outlook.MAPIFolder destFolder = inBox.Folders["Inbox"];
                moveMail.Move(destFolder);
            }
            catch (Exception ex)
            {

            }
         

        }

        private void addListenerToFolders()
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
                        //get the folder with this name
                        Outlook.MAPIFolder contextFolder = null;





                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public void moveItemsEventHandler(object movedItem)
        {
            Outlook.MailItem movedEmail = (Outlook.MailItem)movedItem;
            string subject = movedEmail.Subject;
            string sender = GetSenderSMTPAddress(movedEmail);
            string moveFrom = movedEmail.Categories;

            object thisFolderName = movedEmail.Parent.ToString();

            //send these data to the server now
            




        }

    }
}
