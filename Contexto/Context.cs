using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexto
{
    class Context
    {
        string emailSubject = null;
        string emailBody = null;
        string emailSender = null;

        /*
        *
        *Method to initialize the body of a new email
        */
        public void setEmailBody(object body)
        {
            // Cast email body to string and nitialize it.
            this.emailBody = (string)body; 
        }

        /*
        *Method to initialize the subject of a new email
        *
        */
        public void setEmailSubject(object subject)
        {
            // Cast email subject to string and nitialize it.
            this.emailSubject = (string)subject; 
        }

        /*
        *Method to initialize the sender of a new email.
        * 
        */

        public void setEmailSender(object sender)
        {
            // Cast email subject to string and nitialize it.
            this.emailSender = (string)sender;
        }

        /*
        *
        * This method will send request to the server script.
        * It returns a request from the server script.
        */

        public string sendRequest()
        {

            var client = new WebClient();
            var url = "http://10.10.26.53:8000/server/Contexto/ContextRequests.php?cmd=1&mailSubject=" + emailSubject + "&mailSender=" + emailSender;
            string requestResult = client.DownloadString(url);

            Console.Write(requestResult);

            return requestResult;
        }

        /*
        *Declare methods to be implemented in this class
        *
        */


        public void checkEmalSubjectContextMatch()
        {

        }
        public void checkEmailBodyContextMatch()
        {

        }
        public void setWorkingContext()
        {

        }
        public String getWorkingContext()
        {

            return "";
        }
        public void setContextEmails()
        {

        }

        public static void Main()
        {
            Context  Contextoz = new Context();

            Console.WriteLine("I have an output for you David");
            Contextoz.sendRequest();
            Console.WriteLine("Why not??");
        }

    }
}
